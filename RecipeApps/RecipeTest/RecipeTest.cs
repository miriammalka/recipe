using System.Data;

namespace RecipeTest
{
    public class RecipeTest
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server=.\\SQLExpress;Database=RecipeDB;Trusted_Connection=true");
        }


        [Test]
        [TestCase(400, "06/06/2022")]
        [TestCase(120, "09/19/2020")]
        public void InsertNewRecipe(int calories, DateTime datecreated)
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "no recipes in DB, can't run test");
            DataTable exisitngdt = SQLUtility.GetDataTable("select * from recipe where recipeid = " + recipeid);
            string recipename = exisitngdt.Rows[0]["RecipeName"].ToString();
            recipename = recipename + DateTime.Now.TimeOfDay.ToString();

            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int cuisineid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "no cuisines in DB, can't run test");
            int userid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 userid from users");
            Assume.That(userid > 0, "no users in DB, can't run test");

            TestContext.WriteLine("we want to insert a new recipe for " + recipename);

            r["CuisineId"] = cuisineid;
            r["UserId"] = userid;
            r["RecipeName"] = recipename;
            r["Calories"] = calories;
            r["DateCreated"] = datecreated;
            Recipe.Save(dt);

            int newid = SQLUtility.GetFirstColumnFirstRowValue("select recipeid from recipe where recipename = '" + recipename + "'");
            //AF The below message should specify the recipe name, if the insert fails, there won't be a recipeid
            Assert.IsTrue(newid > 0, "recipe for " + recipename + " with id (" + newid + ") is not found in DB");
            TestContext.WriteLine("recipe for " + recipename + " with id (" + newid + ") is found in DB");
        }

        [Test]
        public void ChangeExistingRecipeCalories()
        {
            int recipeid = GetExistingRecipeId();
            int calories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            Assume.That(recipeid > 0, "no recipes in DB, can't run test");
            //AF It would be clearer to write 'calories for recipe with id = 4' or 'calories for recipe(4)' etc.  'Calories for recipeid 4' can sound confusing 
            //AF It's nice to keep the message format consistent throughout the test 
            TestContext.WriteLine("calories for recipe with id (" + recipeid + ") = " + calories);
            calories = calories + 10;
            TestContext.WriteLine("we want to change calories to " + calories);
            
            DataTable dt =  Recipe.Load(recipeid);
            dt.Rows[0]["calories"] = calories;
            Recipe.Save(dt);

            int newcalories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            Assert.IsTrue(calories == newcalories, "calories for recipe with id (" + recipeid + ") <> " + newcalories);
            TestContext.WriteLine("calories for recipe with id (" + recipeid + ") = " + newcalories);
        }


        [Test]
        public void DeleteRecipe()
        {
            //AF What would happen if you delete a recipe in the mealcourse table or cookbookrecipe table?
            //MMG I spoke to Jacob Felder about this and he said for now I need to insert a few recipes that are not connected to any other tables so I can run this test.
            //MMG This is because all my recipe records I created in Azure Data Studio are connected to multiple tables.
            DataTable dt = SQLUtility.GetDataTable("select top 1 r.RecipeId from recipe r left join recipeingredient ri on ri.recipeid = r.recipeid where ri.recipeid is null");
            int recipeid = 0;
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
            }
            Assume.That(recipeid > 0, "no recipes in DB, can't run test");
            TestContext.WriteLine("existing recipe record without ingredients with id = " + recipeid);
            TestContext.WriteLine("we want to ensure that test can delete recipe with id = " + recipeid);
            Recipe.Delete(dt);
            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from recipe where recipeid = " + recipeid);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "delete procedure did not work, because selected recipeid = " + recipeid + " is still in DB");
            TestContext.WriteLine("recipe with id = " + recipeid + " was successfully deleted from DB");
        }

        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "no recipes in DB, can't run test");
            TestContext.WriteLine("existing recipe record with id = " + recipeid);
            TestContext.WriteLine("ensure that test returns recipe record with id = " + recipeid);
            DataTable dt = Recipe.Load(recipeid);
            int loadedid = (int)dt.Rows[0]["recipeid"];
            Assert.IsTrue(loadedid == recipeid, loadedid + " <> " + recipeid);
            TestContext.WriteLine("loaded recipe with id = " + recipeid);
        }

        [Test]
        public void GetListOfCuisines()
        {
            int cuisinecount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from cuisine");
            Assume.That(cuisinecount > 0, "no cuisines in DB, can't test");
            TestContext.WriteLine("number of cuisines in DB = " + cuisinecount);
            TestContext.WriteLine("We want to ensure that number of rows returned by test = " + cuisinecount);
            DataTable dt = Recipe.GetCuisineList();
            //AF It's nice to keep the messages consistent - just small details but for example 'rows returned by test', use '=' instead of using '()', if that's how it was written above
            //MMG I can change it but then it looks confusing because there is this sign " = " an then this sign " <> "
            Assert.IsTrue(dt.Rows.Count == cuisinecount, "number of rows returned by test = " + dt.Rows.Count + "  <> " + cuisinecount); ;
            TestContext.WriteLine("Number of rows in Cuisine returned by test = " + dt.Rows.Count);
        }

        [Test]
        public void GetListOfUsers()
        {
            int usercount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from users");
            Assume.That(usercount > 0);
            TestContext.WriteLine("number of users in DB = " + usercount);
            TestContext.WriteLine("we want to ensure that number of rows returned by test = " + usercount);
            DataTable dt = Recipe.GetUsersList();
            Assert.IsTrue(dt.Rows.Count == usercount, "number of rows in users = " + dt.Rows.Count + " <> " + usercount);
            TestContext.WriteLine("number of rows in users returned by test = " + dt.Rows.Count);
        }

        private int GetExistingRecipeId()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeid from recipe");
        }
    }
}