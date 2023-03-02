--BG: 100% Excellent Work! See comment below for formatting tip. No need to resubmit
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.
--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.
delete cr 
--select * 
from CookbookRecipe cr 
join Cookbook cb 
on cb.CookbookId = cr.CookbookId
join Recipe r 
on r.RecipeId = cr.RecipeId
join Users u 
on u.UserId = cb.UserId
or u.UserId = r.UserId
where u.FirstName = 'Isaac'
and u.LastName = 'Rosen'

delete cb
--select * 
from Cookbook cb 
join Users u 
on u.UserId = cb.UserId
where u.FirstName = 'Isaac'
and u.LastName = 'Rosen'

delete mcr
--select * 
from MealcourseRecipe mcr 
join MealCourse mc
on mc.mealcourseid = mcr.MealCourseId
join Meal m 
on m.MealId = mc.MealId
join Recipe r 
on r.RecipeId = mcr.RecipeId
join Users u 
on u.UserId = m.UserId
or u.UserId = r.UserId
where u.FirstName = 'Isaac'
and u.LastName = 'Rosen'

delete  mc 
--select *
from MealCourse mc 
join meal m 
on m.MealId = mc.mealId
join Users u 
on u.UserId = m.UserId
where u.FirstName = 'Isaac'
and u.LastName = 'Rosen'

delete m
--select *
from meal m 
join Users u 
on u.UserId = m.UserId
where u.FirstName = 'Isaac'
and u.LastName = 'Rosen'

delete s
--select *
from Instruction s 
join Recipe r 
on r.RecipeId = s.RecipeId
join Users u 
on u.UserId = r.UserId
where u.FirstName = 'Isaac'
and u.LastName = 'Rosen'


delete ri
--select * 
from RecipeIngredient ri 
join recipe r 
on r.RecipeId = ri.RecipeId
join Users u 
on u.UserId = r.UserId 
where u.FirstName = 'Isaac'
and u.LastName = 'Rosen'

delete r
--select *
from recipe r 
join Users u 
on u.UserId = r.UserId
where u.FirstName = 'Isaac'
and u.LastName = 'Rosen'

delete u
--select *
from Users u 
where u.FirstName = 'Isaac'
and u.LastName = 'Rosen'

--2) Sometimes we want to clone a recipe as a starting point and then edit it. 
--For example we have a complex recipe (steps and ingredients) and want to make a modified version. 
--Write the SQL that clones a specific recipe, add " - clone" to its name.

insert Recipe (CuisineId, UserId, RecipeName, Calories, DateCreated, DatePublished, DateArchived)
select r.CuisineId, r.UserId, RecipeName = r.RecipeName + '" - clone"', r.Calories, r.DateCreated, r.DatePublished, r.DateArchived
from recipe r 
where r.RecipeName = 'Ice Coffee Crush'


/*
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The prices should be the number of recipes times $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/

;
with x as(
    select u.userid, NumRecipes = count(r.RecipeId)
    from Recipe r 
    join Users u 
    on r.UserId = u.UserId
    where u.FirstName = 'Miriam'
    and u.LastName = 'Gross'
    group by u.UserId
)
insert Cookbook (UserId, CookbookName, Price, DateCreated, Active)
select u.UserId, concat('Recipes by', ' ',u.FirstName, ' ', u.Lastname), 1.33 * x.NumRecipes, getdate(), 1
from x 
join Users u 
on u.UserId = x.UserId
where u.FirstName = 'Miriam'
and u.LastName = 'Gross'

select cb.cookbookId, r.RecipeId, r.RecipeName, SequenceOrder = ROW_NUMBER() over (order by r.RecipeName)
from users u 
join Cookbook cb 
on cb.UserId = u.UserId
join Recipe r 
on r.UserId = u.UserId
where u.FirstName = 'Miriam'
and u.LastName = 'Gross'
and cb.CookbookName = concat('Recipes by', ' ',u.FirstName, ' ', u.Lastname)

/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calories for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count of butter went down by 2 per ounce, and 10 for a stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/
--1 tsp sugar is 10 cal instead of 15
--1 cup is 680 cal instead of 720
--1 tablespoon is 40 cal instead of 50
update r 
set Calories = 
    case 
        when mt.MeasurementType = 'teaspoon' then r.Calories - (ri.Amount * 5) 
        when mt.MeasurementType = 'cup' then r.Calories - (ri.Amount * 40)
        when mt.MeasurementType = 'tablespoon' then r.Calories - (ri.Amount * 10)
    end
from recipe r 
join RecipeIngredient ri 
on ri.recipeId = r.RecipeId
join MeasurementType mt 
on mt.MeasurementTypeId = ri.MeasurementTypeId
join Ingredient i 
on i.IngredientId = ri.IngredientId
where i.IngredientName = 'sugar'

/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time all recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/


--I also did this as a CTE because I was told this is how it is supposed to be done, but I do not think I am correct because this is way more complicated than the previous way I did it
--BG: I marked the second way. Its the proper way to do it
--BG: Please reformatt this question.
;
with x as(
   select r.recipeId, r.UserID, AvgHours = (select(avg(datediff(hour,r.DateCreated, r.DatePublished))) from recipe r), HoursInDraft = datediff(hour, r.DateCreated, getdate())
   from recipe r
   group by r.UserId, r.RecipeId, r.DateCreated
)
select 
    u.FirstName, 
    u.LastName, 
    EmailAddress = concat(substring(u.FirstName,1,1), u.LastName, '@heartyhearth.com'),
    Alert = concat('Your recipe ', r.RecipeName, ' is sitting in draft for ', x.HoursInDraft, ' hours.', ' That is ', x.HoursInDraft - x.AvgHours,
    ' hours more than the average ', x.AvgHours,' hours all other recipes took to be published.')
from x 
join Recipe r 
on x.RecipeId = r.RecipeId
join Users u 
on u.UserId = r.UserId
where r.DatePublished is null 
and r.DateArchived is null 
and x.HoursInDraft > x.AvgHours
group by u.FirstName, u.LastName, r.RecipeName, r.DateCreated, x.AvgHours, x.HoursInDraft

/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average prices is [Y]. You can order all for 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/
select Email = concat(
    'Order cookbooks from HeartyHearth.com! We have ', 
    count(cb.CookbookId), 
    ' books for sale, average prices is $', 
    avg(cb.Price),
    '. You can order all for 25% discount, for a total of $', 
    (sum(cb.Price) * .75), 
    '. Click <a href = "www.heartyhearth.com/order/', 
    NEWid(),
    '">here</a> to order.'
    )
from Cookbook cb 