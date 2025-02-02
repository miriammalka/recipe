using RecipeSystem;
using System.Configuration;
using System.Data;

namespace RecipeTest
{
    public class RecipeTest
    {
        string connstring = ConfigurationManager.ConnectionStrings["devconn"].ConnectionString;
        string testconnstring = ConfigurationManager.ConnectionStrings["unittestconn"].ConnectionString;

        [SetUp]
        public void Setup()
        {           
            DBManager.SetConnectionString(connstring,true);
        }

        private DataTable GetDataTable(string sql)
        {
            DataTable dt = new();
            DBManager.SetConnectionString(testconnstring, false);
            dt = SQLUtility.GetDataTable(sql);
            DBManager.SetConnectionString(connstring, false);
            return dt;
        }

        private int GetFirstColumnFirstRowValue(string sql)
        {
            int n = 0;
            DBManager.SetConnectionString(testconnstring, false);
            n = SQLUtility.GetFirstColumnFirstRowValue(sql);
            DBManager.SetConnectionString(connstring, false);
            return n;
        }

        [Test]
        [TestCase(400, "2022-06-06")]
        [TestCase(120, "2020-01-01")]
        public void InsertNewRecipe(int calories, DateTime datecreated)
        {

            int recipeid = GetExistingRecipeId();
            
            Assume.That(recipeid > 0, "no recipes in DB, can't run test");           
            
            string recipename = GetFirstColumnFirstRowValueAsString("select r.recipename from recipe r where r. recipeid = " + recipeid);
            recipename = recipename + DateTime.Now.TimeOfDay.ToString();         
            int cuisineid = GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            
            Assume.That(cuisineid > 0, "no cuisines in DB, can't run test");
            
            int usersid = GetFirstColumnFirstRowValue("select top 1 usersid from users");
            
            Assume.That(usersid > 0, "no users in DB, can't run test");

            TestContext.WriteLine("we want to insert a new recipe for " + recipename);
            
            bizRecipe bizrecipe = new();
            
            bizrecipe.CuisineId = cuisineid;
            bizrecipe.UsersId = usersid;
            bizrecipe.RecipeName = recipename;
            bizrecipe.Calories = calories;
            bizrecipe.DateCreated = datecreated;

            bizrecipe.Save();

            int newid = bizrecipe.RecipeId;
            Assert.IsTrue(newid > 0, "recipe for " + recipename + " is not found in DB");
            TestContext.WriteLine("recipe for " + recipename + " with id (" + newid + ") is found in DB");
        }

        [TestCase(120, "09/19/2020")]
        [Test]
        public void InsertDuplicateRecipe(int calories, DateTime datecreated)
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "no recipes in DB, can't run test");
            string recipename = GetFirstColumnFirstRowValueAsString("select r.recipename from recipe r where r. recipeid = " + recipeid);
            TestContext.WriteLine("existing recipe in DB with recipe name " + recipename);
            DataTable dt = GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int cuisineid = GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "no cuisines in DB, can't run test");
            int usersid = GetFirstColumnFirstRowValue("select top 1 usersid from users");
            Assume.That(usersid > 0, "no users in DB, can't run test");

            TestContext.WriteLine("we want to ensure we cannot insert a duplicate recipe for " + recipename);

            r["CuisineId"] = cuisineid;
            r["UsersId"] = usersid;
            r["RecipeName"] = recipename;
            r["Calories"] = calories;
            r["DateCreated"] = datecreated;

            Exception ex = Assert.Throws<Exception>(()=> Recipe.Save(dt));

            TestContext.WriteLine(ex.Message);
        }


        [Test]
        public void ChangeExistingRecipeCalories()
        {
            int recipeid = GetExistingRecipeId();
            int calories = GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            Assume.That(recipeid > 0, "no recipes in DB, can't run test");
            TestContext.WriteLine("calories for recipe with id (" + recipeid + ") = " + calories);
            calories = calories + 10;
            TestContext.WriteLine("we want to change calories to " + calories);
            
            DataTable dt =  Recipe.Load(recipeid);
            dt.Rows[0]["calories"] = calories;
            Recipe.Save(dt);

            int newcalories = GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            Assert.IsTrue(calories == newcalories, "calories for recipe with id (" + recipeid + ") <> " + newcalories);
            TestContext.WriteLine("calories for recipe with id (" + recipeid + ") = " + newcalories);
        }

        [Test]
        public void ChangeExistingRecipeCaloriesToInvalidAmount()
        {
            int recipeid = GetExistingRecipeId();
            int calories = GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            Assume.That(recipeid > 0, "no recipes in DB, can't run test");
            TestContext.WriteLine("calories for recipe with id (" + recipeid + ") = " + calories);
            calories = calories + 5001;
            TestContext.WriteLine("we want to ensure app cannot change calories to " + calories + " which is an invalid amount.");

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["calories"] = calories;

            Exception ex = Assert.Throws<Exception>(()=> Recipe.Save(dt));
            
            TestContext.WriteLine(ex.Message);
        }


        [Test]
        public void DeleteRecipe()
        {
            DataTable dt = GetDataTable("select top 1 r.RecipeId , r.RecipeName from recipe r where r.RecipeStatus = 'Draft'");
            int recipeid = 0;
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
            }
            Assume.That(recipeid > 0, "no recipes with related records in DB, can't run test");
            TestContext.WriteLine("existing recipe record with related records with id = " + recipeid);
            TestContext.WriteLine("we want to ensure that test can delete recipe with id = " + recipeid);
            bizRecipe bizrecipe = new();
            bizrecipe.Load(recipeid);
            bizrecipe.Delete();
            DataTable dtafterdelete = GetDataTable("select * from recipe where recipeid = " + recipeid);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "delete procedure did not work, because selected recipeid = " + recipeid + " is still in DB");
            TestContext.WriteLine("recipe with id = " + recipeid + " was successfully deleted from DB");
        }

        [Test]
        public void DeleteRecipeWithRecipeIngredientAndPublishedOrArchivedLessThanThirtyDays()
        {
            string sql = @"
select top 1 r.RecipeId 
from recipe r
left join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
left join Instruction i
on r.RecipeId = i.RecipeId
left join MealCourseRecipe mcr
on r.RecipeId = mcr.RecipeId
left join CookbookRecipe cr
on r.RecipeId = cr.RecipeId
where mcr.MealCourseRecipeId is null
and cr.CookbookRecipeId is null
and (r.RecipeStatus = 'published' 
or DATEDIFF(Day, r.DateArchived, getdate()) <= 30)
";
            DataTable dt = GetDataTable(sql);
            int recipeid = 0;
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
            }
            Assume.That(recipeid > 0, "no recipes with records in recipeingredient table, can't run test");
            TestContext.WriteLine("existing recipe record with record in recipeingredient table with id = " + recipeid + " and status is published or archived less than 30 days");
            TestContext.WriteLine("we want to ensure that app cannot delete recipe with id = " + recipeid + " and status is published or archived less than 30 days");

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "no recipes in DB, can't run test");
            TestContext.WriteLine("existing recipe record with id = " + recipeid);
            TestContext.WriteLine("ensure that test returns recipe record with id = " + recipeid);
            bizRecipe bizrecipe = new();
            bizrecipe.Load(recipeid);
            int loadedid = bizrecipe.RecipeId;
            string recipename = bizrecipe.RecipeName;
            Assert.IsTrue(loadedid == recipeid && recipename != "", loadedid + " <> " + recipeid + " RecipeName = " + recipename);
            TestContext.WriteLine("loaded recipe with id = " + recipeid + " RecipeName = " + recipename);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetListOfRecipes(bool includeblank)
        {
            int recipecount = GetFirstColumnFirstRowValue("select total = count(*) from recipe");
            Assume.That(recipecount > 0, "no recipes in DB, can't test");
            if(includeblank == true)
            {
                recipecount = recipecount + 1;
            }
            TestContext.WriteLine("number of recipes in DB = " + recipecount);
            TestContext.WriteLine("We want to ensure that number of rows returned by test = " + recipecount);

            bizRecipe recipe = new();
            var lst = recipe.GetList(includeblank);

            Assert.IsTrue(lst.Count == recipecount, "number of rows returned by test (" + lst.Count + ")  <> " + recipecount); 
            TestContext.WriteLine("Number of rows in Recipe returned by test = " + lst.Count);
        }

        [Test]
        public void SearchRecipe()
        {
            string recipename = "a";
            int cuisineid = 16;
            int recipecount = GetFirstColumnFirstRowValue($"select total = count(*) from recipe where recipename like '%{recipename}%'");
            TestContext.WriteLine("Num of search results in DB = " + recipecount);
            TestContext.WriteLine("Ensure that number of rows returned by test matches " + recipecount);
            bizRecipe recipe = new();
            List<bizRecipe> lst = recipe.Search(recipename, cuisineid);
            Assert.IsTrue(lst.Count == recipecount, "num rows returned by search (" + lst.Count + ") <>" + recipecount);
            TestContext.WriteLine("number of rows in search results returned by test = " + recipecount);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetListOfIngredients(bool includeblank)
        {
            int ingredientcount = GetFirstColumnFirstRowValue("select total = count(*) from ingredient");
            Assume.That(ingredientcount > 0, "no ingredients in DB, can't test");
            if (includeblank == true)
            {
                ingredientcount = ingredientcount + 1;
            }
            TestContext.WriteLine("number of ingredients in DB = " + ingredientcount);
            TestContext.WriteLine("We want to ensure that number of rows returned by test = " + ingredientcount);

            bizIngredient ingredient = new();
            var lst = ingredient.GetList(includeblank);

            Assert.IsTrue(lst.Count == ingredientcount, "number of rows returned by test (" + lst.Count + ")  <> " + ingredientcount); ;
            TestContext.WriteLine("Number of rows in ingredient returned by test = " + lst.Count);
        }

        [Test]
        public void SearchIngredient()
        {
            string ingredientname = "a";
            int ingredientcount = GetFirstColumnFirstRowValue($"select total = count(*) from ingredient where ingredientname like '%{ingredientname}%'");
            TestContext.WriteLine("Num of search results in DB = " + ingredientcount);
            TestContext.WriteLine("Ensure that number of rows returned by test matches " + ingredientcount);
            bizIngredient ingredient = new();
            List<bizIngredient> lst = ingredient.Search(ingredientname);
            Assert.IsTrue(lst.Count == ingredientcount, "num rows returned by search (" + lst.Count + ") <>" + ingredientcount);
            TestContext.WriteLine("number of rows in search results returned by test = " + ingredientcount);
        }

        [Test]
        public void GetListOfCuisines()
        {
            int cuisinecount = GetFirstColumnFirstRowValue("select total = count(*) from cuisine");
            Assume.That(cuisinecount > 0, "no cuisines in DB, can't test");
            TestContext.WriteLine("number of cuisines in DB = " + cuisinecount);
            TestContext.WriteLine("We want to ensure that number of rows returned by test = " + cuisinecount);
            DataTable dt = Recipe.GetCuisineList();
            Assert.IsTrue(dt.Rows.Count == cuisinecount, "number of rows returned by test (" + dt.Rows.Count + ")  <> " + cuisinecount); ;
            TestContext.WriteLine("Number of rows in Cuisine returned by test = " + dt.Rows.Count);
        }

        [Test]
        public void GetListOfUsers()
        {
            int userscount = GetFirstColumnFirstRowValue("select total = count(*) from users");
            Assume.That(userscount > 0);
            TestContext.WriteLine("number of users in DB = " + userscount);
            TestContext.WriteLine("we want to ensure that number of rows returned by test = " + userscount);
            DataTable dt = Recipe.GetUsersList();
            Assert.IsTrue(dt.Rows.Count == userscount, "number of rows in users = " + dt.Rows.Count + " <> " + userscount);
            TestContext.WriteLine("number of rows in users returned by test = " + dt.Rows.Count);
        }

        private int GetExistingRecipeId()
        {
            return GetFirstColumnFirstRowValue("select top 1 recipeid from recipe");
        }

        private string GetFirstColumnFirstRowValueAsString (string? sql)
        {
            string? s = "";
            DataTable dt = GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    s = dt.Rows[0][0].ToString();
                }
            }
            return s;
        }
    }
}