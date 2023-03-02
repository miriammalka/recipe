--BG: 100% Excellent Corrections! Keep up the great work!
--Home Page
--One result set with number of recipes, meals, and cookbooks
select TotalRecipes = count(distinct r.RecipeId), TotalMeals = count(distinct m.MealId), TotalCookbooks = count(distinct c.CookbookId)
from Recipe r 
cross join meal m 
cross join Cookbook c 

/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the result set show the Recipe with its status, dates it was published and archived (blank if not archived), user, number of calories and number of ingredients.
*/
select 
    RecipeName = 
        case 
            when r.RecipeStatus = 'published' then r.RecipeName
            when r.RecipeStatus = 'archived' then concat('<span style="color:gray">',r.RecipeName,'</span>')
        end, 
    r.RecipeStatus, 
    r.DatePublished, 
    DateArchived = isnull(convert(varchar, r.DateArchived), ''), 
    u.Username, 
    r.Calories, 
    TotalIngredients = count(i.IngredientId)
from recipe r 
join users u 
on u.UserId = r.UserId
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join ingredient i
on i.IngredientId = ri.IngredientId
where r.RecipeStatus in('published','archived')
group by r.RecipeName, r.RecipeStatus, r.DatePublished, r.DateArchived, u.Username, r.Calories
order by r.RecipeStatus desc, r.RecipeName 

/*
Recipe details page:
    Show for a specific recipe (three result sets):
*/
--a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
select r.RecipeName, r.Calories, NumIngredients = count(distinct ri.ingredientId), NumSteps = count(distinct i.InstructionId), r.Picture
from recipe r 
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId
join Instruction i 
on i.RecipeId = r.RecipeId
where r.RecipeName = 'Cheese Bread'
group by r.RecipeName, r.Calories, r.Picture

--b) List of ingredients: show the measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt 
select ListOfIngredients = concat(mt.MeasurementType, ' ', i.IngredientName)
from Ingredient i 
join RecipeIngredient ri 
on ri.IngredientId = i.IngredientId
join recipe r 
on r.RecipeId = ri.RecipeId
join measurementtype mt 
on mt.MeasurementTypeId = ri.measurementtypeid
where r.RecipeName = 'Cheese Bread'
order by ri.SequenceOrder

--c) List of prep steps sorted by sequence.
select i.SequenceOrder, i.Instruction
from Instruction i 
join recipe r 
on r.RecipeId = i.RecipeId
where r.RecipeName = 'Cheese Bread'
order by i.SequenceOrder

/*
Meal list page:
    All active meals, meal name, user that created meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
select m.MealName, u.Username, TotalCalories = sum(r.Calories), TotalCourses = count(mc.MealCourseId), TotalRecipes = count(r.RecipeId)
from meal m 
join Users u 
on u.UserId = m.UserId
join MealCourse mc 
on mc.MealId = m.MealId
join MealcourseRecipe mcr 
on mcr.MealcourseId = mc.MealCourseId
join recipe r 
on r.RecipeId = mcr.RecipeId
where m.Active = 1
group by m.MealName, u.Username
order by m.MealName

/*
Meal details page:
    Show for a specific meal:
*/
--a) Meal header: meal name, user, date created.
select m.MealName, u.Username, m.DateCreated, m.Picture 
from Meal m 
join Users u 
on u.UserId = m.UserId
where m.MealName = 'Classic Shabbos Meal'
/*
        b) List of all recipes. 
            Display in one column the course type, recipe, and for the main course show which dish is the main and which are side. 
			In this format "Course Type: Main\Side dish - Recipe Name. Then main dishes should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
select 
    RecipeList = 
        case 
            when c.CourseName = 'Main: Main course' then concat('<b>',c.CourseName,' - ', r.RecipeName,'</b>')
            when c.CourseName = 'Main: Main side' then concat(c.CourseName, ' - ', r.RecipeName)
        else concat(c.CourseName,': - ', r.RecipeName)
    end
from course c 
join MealCourse mc 
on mc.CourseId = c.CourseId
join meal m 
on m.MealId = mc.MealId
join MealcourseRecipe mcr 
on mcr.MealcourseId = mc.MealCourseId
join recipe r 
on r.RecipeId = mcr.RecipeId
where m.MealName = 'Classic Shabbos Meal'
order by c.SequenceOrder

/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select c.CookbookName, u.FirstName, u.LastName, NumRecipes = count(r.RecipeId)
from users u 
join Cookbook c 
on c.UserId = u.UserId
join CookbookRecipe cr 
on cr.CookbookId = c.CookbookId
join recipe r 
on r.RecipeId = cr.RecipeId
where c.Active = 1
group by c.CookbookName, u.FirstName, u.LastName
order by c.CookbookName

/*
Cookbook details page:
    Show for specific cookbook:
*/
--a) Cookbook header: cookbook name, user, date created, price, number of recipes.
select c.CookbookName, u.Username, c.DateCreated, c.Price, NumRecipes = count(r.RecipeId), c.Picture
from users u 
join Cookbook c 
on c.UserId = u.UserId
join CookbookRecipe cr 
on cr.CookbookId = c.CookbookId
join recipe r 
on r.RecipeId = cr.RecipeId
where c.CookbookName = 'Treats for Two'
group by c.CookbookName, u.Username, c.DateCreated, c.Price, c.Picture

--b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  Note: User will click on recipe to see all ingredients and steps.
select r.RecipeName, c.CuisineName, NumIngredients = count(distinct ri.IngredientId), NumSteps = count(distinct i.InstructionId)
from cuisine c 
join recipe r 
on r.CuisineId = c.CuisineId
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId
join Instruction i 
on i.RecipeId = r.RecipeId
join CookbookRecipe cr 
on cr.RecipeId = r.RecipeId
join cookbook b
on b.CookbookId = cr.CookbookId
where b.CookbookName = 'Treats for Two'
group by cr.CookbookRecipeId,r.RecipeName, c.CuisineName
order by cr.CookbookRecipeId

/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name proper cased. There are matching pictures for those names, 
    include the reversed picture names so that we can show the joke pictures.
    b) When the user clicks on a specific recipe they should see a list of the first ingredient of each recipe in the system, and a list of the last step in each recipe in the system
*/
--a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name proper cased. There are matching pictures for those names, 
--include the reversed picture names so that we can show the joke pictures.
;with x as(
    select r.recipeid, RecipeName = reverse(lower(r.recipename)), Picture = reverse(lower(r.picture))
    from Recipe r 
)
select distinct RecipeName = concat(upper(substring(x.recipename,1,1)), substring(x.RecipeName,2,100)), 
Picture = concat(substring(x.Picture,1,4), upper(substring(x.Picture,5,1)), substring(x.Picture,6,100))
from x 
join Recipe r 
on r.RecipeId = x.RecipeId
join CookbookRecipe cr 
on cr.RecipeId = r.RecipeId


-- b) When the user clicks on a specific recipe they should see a list of the first ingredient of each recipe in the system, and a list of the last step 
--in each recipe in the system
;
with x as(
select r.RecipeName, IngredientSequence = min(ri.SequenceOrder), InstructionSequence = max(s.SequenceOrder)
from recipe r 
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId 
join Instruction s 
on s.RecipeId = r.RecipeId
group by r.RecipeName
)
select x.RecipeName, i.IngredientName, s.Instruction
from x 
join recipe r 
on r.RecipeName = x.RecipeName
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId
and ri.SequenceOrder = x.IngredientSequence
join Ingredient i 
on i.IngredientId = ri.IngredientId 
join Instruction s 
on s.RecipeId = r.RecipeId
and s.SequenceOrder = x.InstructionSequence
order by r.RecipeName

/*
For site administration page:
--5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if none
	b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) List of how many meals each user created and whether they're active or inactive. Show 0 if none
    d) List of how many cookbooks each user created and whether they're active or inactive. Show 0 if none
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/
--a) List of how many recipes each user created per status. Show 0 if none
select u.Username, r.RecipeStatus, NumRecipes = count(r.RecipeId) 
from recipe r 
left join users u 
on u.UserId = r.UserId 
group by u.Username, r.RecipeStatus
order by u.Username
--b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
select u.Username, NumRecipes = count(r.RecipeId), DaysToPublish = avg(datediff(day,r.DateCreated, r.DatePublished))
from recipe r 
left join Users u 
on u.UserId = r.UserId
group by u.Username
--c) List of how many meals each user created and whether they're active or inactive. Show 0 if none
select u.Username, NumMeals = count(m.MealId), m.Active
from Meal m 
left join Users u 
on u.UserId = m.UserId
group by u.Username, m.Active
--d) List of how many cookbooks each user created and whether they're active or inactive. Show 0 if none
select u.Username, NumCookbooks = count(c.CookbookId), c.Active
from Cookbook c 
join Users u 
on u.UserId = c.UserId
group by u.Username, c.Active
--e) List of archived recipes that were never published, and how long it took for them to be archived.
select r.RecipeName, r.RecipeStatus, DaysToArchive = datediff(day,r.DateCreated, r.DateArchived)
from Recipe r 
where r.DatePublished is null 
and r.DateArchived is not null

/*
For user dashboard page:
*/
--a) Show number of the user's recipes, meals and cookbooks.
select u.username, TotalRecipes = count(distinct r.RecipeId), TotalMeals = count(distinct m.mealId), TotalCookbooks = count(distinct c.cookbookId)
from users u 
left join Recipe r 
on r.UserId = u.UserId
left join Meal m 
on m.UserId = u.UserId
left join Cookbook c 
on c.UserId = u.UserId
where u.Username = 'AMarks123'
group by u.Username

--b) List of their recipes, display the status and the number of hours between the status it's in and the one before that. Show null if recipe has the status drafted.
select 
    u.username, 
    r.RecipeName, 
    r.RecipeStatus, 
    HoursBetweenStatus = 
        case 
            when r.DateArchived is not null and r.DatePublished is null then datediff(hour, r.DateCreated, r.DateArchived)
            when r.DateArchived is not null then datediff(hour, r.DatePublished, r.DateArchived)
            when r.DatePublished is not null then datediff(hour, r.DateCreated, r.DatePublished)
        else null
        end 
from Users u 
join recipe r  
on r.UserId = u.UserId
where u.Username = 'AMarks123'
order by u.Username

--c) Count of their recipes per cuisine. Show 0 for none.
select u.Username, c.CuisineName, TotalRecipes = count(r.RecipeId)
from Cuisine c 
left join Recipe r 
on r.CuisineId = c.CuisineId
left join Users u 
on u.UserId = r.UserId 
where u.Username = 'AMarks123'
group by u.Username, c.CuisineName
order by u.Username






