--FB Fantastic work!! 100%
use RecipeDB
go 
delete CookbookRecipe 
delete CookBook
delete MealcourseRecipe
delete MealCourse 
delete Meal 
delete Instruction 
delete RecipeIngredient 
delete Recipe  
delete Users 
delete MeasurementType 
delete Ingredient
delete Course  
delete Cuisine
go 
insert Cuisine(CuisineName)
select 'American'
union select 'English'
union select 'French'
union select 'Mexican'
union select 'Israeli'
go 
insert Course(CourseName, SequenceOrder)
select 'Appetizer', 1 
union select 'Main: Main course', 2
union select 'Main: Main side', 3
union select 'Dessert', 4
go 
insert Ingredient (IngredientName)
select 'sugar'
union select 'oil'
union select 'egg'
union select 'flour'
union select 'vanilla sugar'
union select 'baking powder'
union select 'baking soda'
union select 'chocolate chips'
union select 'granny smith apple'
union select 'vanilla yogurt'
union select 'orange juice'
union select 'honey'
union select 'ice cube'
union select 'club bread'
union select 'butter'
union select 'shredded cheese'
union select 'garlic clove (crushed)'
union select 'black pepper'
union select 'salt'
union select 'vanilla pudding'
union select 'whipped cream cheese'
union select 'sour cream cheese'
union select 'chicken breast'
union select 'Italian flavored bread crumbs'
union select 'onion consomme'
union select 'paprika'
union select 'crushed red pepper flakes'
union select 'Yukon gold potatoes'
union select 'peeled shallot'
union select 'thyme'
union select 'onion'
union select 'fresh button mushrooms'
union select 'red bell pepper'
union select 'yellow bell pepper'
union select '10 inch flour tortilla'
union select 'salsa'
union select 'sour cream'
union select 'peanut butter'
union select 'powdered sugar'
union select 'margarine'
union select 'coffee'
union select 'chocolate syrup'
union select 'hot water'
union select 'vanilla'
union select 'milk'
go 
insert MeasurementType(MeasurementType)
select 'cup'
union select 'tablespoon'
union select 'teaspoon'
union select 'pound'
union select 'ounce'
union select 'unit'
union select 'sprig'
union select 'pinch'
union select 'stick'
go 
insert Users(FirstName, LastName, Username)
select 'Sam', 'Johnson', 'SJohnson123'
union select 'Alice', 'Marks', 'AMarks123'
union select 'Miriam', 'Gross', 'MGross123'
union select 'Isaac', 'Rosen', 'IRosen123'
go 
; with x as (
    Select Cuisine = 'American', Users = 'SJohnson123', RecipeName = 'Chocolate Chip Cookies', Calories = 200, DateCreated = '2015-09-14', DatePublished = '2015-12-21', DateArchived = null
    union select 'French', 'AMarks123', 'Apple Yogurt Smoothie', 150, '2016-06-04', '2016-07-01', null
    union select 'English', 'MGross123', 'Cheese Bread', 250, '2018-01-19', '2018-07-17', '2022-07-20' 
    union select 'American', 'IRosen123', 'Butter Muffins', 300, '2021-03-07', '2021-10-08', null
    union select 'Israeli', 'MGross123', 'Fried Chicken Cutlets', 300, '2015-05-16', '2015-05-29', null 
    union select 'American', 'AMarks123', 'Crispy Potato Roast', 350, '2017-03-14', '2017-05-16', '2022-07-21' 
    union select 'Mexican', 'AMarks123', 'Quesadillas', 400, '2020-07-18', '2020-10-21', null
    union select 'American', 'MGross123', 'Peanut Butter Truffles', 500, '2019-09-19', null, '2019-11-23'
    union select 'American', 'IRosen123', 'Ice Coffee Crush', 150, '2020-12-13', null, null
    union select 'American', 'IRosen123', 'Ice Cream Pie', 350, '2020-12-13', '2021-01-09', null
    union select 'French', 'IRosen123', 'Cranberry Cobbler', 150, '2022-12-13', '2023-01-09', null
    union select 'American', 'IRosen123', 'Potato Kugel', 150, '2019-12-13', '2020-01-09', null
)
insert Recipe(CuisineId, UserId, RecipeName, Calories, DateCreated, DatePublished, DateArchived)
select c.CuisineId, u.UserId, x.RecipeName, x.Calories, x.DateCreated, x.DatePublished, x.DateArchived
from x
join Cuisine c 
on c.CuisineName = x.Cuisine
join users u 
on u.Username = x.Users

go
; with x as(
    select Recipe = 'Chocolate Chip Cookies', Ingredient = 'sugar', SequenceOrder = 1, MeasurementType = 'cup', Amount = 1
    union select 'Chocolate Chip Cookies', 'oil', 2, 'cup', .5
    union select 'Chocolate Chip Cookies', 'egg', 3, 'unit', 3
    union select 'Chocolate Chip Cookies', 'flour', 4, 'cup', 2
    union select 'Chocolate Chip Cookies', 'vanila sugar', 5, 'teaspoon', 1
    union select 'Chocolate Chip Cookies', 'baking powder', 6, 'teaspoon', 2
    union select 'Chocolate Chip Cookies', 'baking soda', 7, 'teaspoon', .5
    union select 'Chocolate Chip Cookies', 'chocolate chips', 8, 'cup', 1
    union select 'Apple Yogurt Smoothie', 'granny smith apple', 1, 'unit', 3
    union select 'Apple Yogurt Smoothie', 'vanilla yogurt', 2, 'cup', 2
    union select 'Apple Yogurt Smoothie', 'sugar', 3, 'teaspoon', 2
    union select 'Apple Yogurt Smoothie', 'orange juice', 4, 'cup', .5
    union select 'Apple Yogurt Smoothie', 'honey', 5, 'tablespoon', 2
    union select 'Apple Yogurt Smoothie', 'ice cube', 6, 'unit', 5 
    union select 'Cheese Bread', 'club bread', 1, 'unit', 1
    union select 'Cheese Bread', 'butter', 2, 'ounce', 4
    union select 'Cheese Bread', 'shredded cheese', 3, 'ounce', 8
    union select 'Cheese Bread', 'garlic clove (crushed)', 4, 'unit', 2
    union select 'Cheese Bread', 'black pepper', 5, 'teaspoon', .5
    union select 'Cheese Bread', 'salt', 6, 'pinch', 1 
    union select 'Butter Muffins', 'butter', 1, 'stick', 1
    union select 'Butter Muffins', 'sugar', 2, 'cup', 3
    union select 'Butter Muffins', 'vanilla pudding', 3, 'tablespoon', 2
    union select 'Butter Muffins', 'egg', 4, 'unit', 4
    union select 'Butter Muffins', 'whipped cream cheese', 5, 'ounce', 8
    union select 'Butter Muffins', 'sour cream cheese', 6, 'ounce', 8
    union select 'Butter Muffins', 'flour', 7, 'cup', 1
    union select 'Butter Muffins', 'baking powder', 8, 'teaspoon', 2
    union select 'Fried Chicken Cutlets', 'chicken breast', 1, 'pound', 2
    union select 'Fried Chicken Cutlets', 'egg', 2, 'unit', 1
    union select 'Fried Chicken Cutlets', 'Italian bread crumbs', 3, 'cup', 1
    union select 'Fried Chicken Cutlets', 'onion consomme', 4, 'tablespoon', 3
    union select 'Fried Chicken Cutlets', 'paprika', 5, 'tablespoon', 1
    union select 'Fried Chicken Cutlets', 'black pepper', 6, 'teaspoon', .5 
    union select 'Fried Chicken Cutlets', 'oil', 7, 'cup', .33
    union select 'Crispy Potato Roast', 'oil', 1, 'tablespoon', 6
    union select 'Crispy Potato Roast', 'salt', 2, 'teaspoon', 1
    union select 'Crispy Potato Roast', 'Yukon gold potatoes', 3, 'pound', 4
    union select 'Crispy Potato Roast', 'peeled shallot', 4, 'unit', 4
    union select 'Crispy Potato Roast', 'thyme', 5, 'sprig', 8
    union select 'Quesadillas', 'butter', 1, 'tablespoon', 2
    union select 'Quesadillas', 'oinion', 2, 'unit', 1
    union select 'Quesadillas', 'fresh button mushrooms', 3, 'pound', .5
    union select 'Quesadillas', 'red bell pepper', 4, 'unit', 1
    union select 'Quesadillas', 'yellow bell pepper', 5, 'unit', 1
    union select 'Quesadillas', 'shredded cheese', 6, 'cup', .5
    union select 'Quesadillas', '10 inch flour tortilla', 7, 'unit', 8
    union select 'Quesadillas', 'salsa', 8, 'cup', 1
    union select 'Quesadillas', 'sour cream', 9, 'cup', 1
    union select 'Peanut Butter Truffles', 'Peanut Butter', 1, 'cup', 1
    union select 'Peanut Butter Truffles', 'Powdered Sugar', 2, 'cup', 1
    union select 'Peanut Butter Truffles', 'chocolate chips', 3, 'cup', 1
    union select 'Peanut Butter Truffles', 'margarine', 4, 'tablespoon', 6
    union select 'Ice Coffee Crush', 'coffee', 1, 'tablespoon', 1
    union select 'Ice Coffee Crush', 'hot water', 2, 'tablespoon', 1
    union select 'Ice Coffee Crush', 'milk', 3, 'cup', 1
    union select 'Ice Coffee Crush', 'ice cube', 4, 'cup', 2
    union select 'Ice Coffee Crush', 'chocolate syrup', 5, 'tablespoon', 2
    union select 'Ice Coffee Crush', 'sugar', 6, 'tablespoon', 2
    union select 'Ice Coffee Crush', 'vanilla', 7, 'teaspoon', 1
) 
insert RecipeIngredient (RecipeId, IngredientId, SequenceOrder, MeasurementTypeId, Amount)
select r.RecipeId, i.IngredientId, x.SequenceOrder, mt.MeasurementTypeId, x.Amount
from x
join recipe r 
on r.RecipeName = x.Recipe
join Ingredient i 
on i.IngredientName = x.Ingredient
join MeasurementType mt 
on x.MeasurementType = mt.MeasurementType
go 
;
with x as (
    select Recipe = 'Chocolate Chip Cookies', SequenceOrder = 1, Instruction = 'First combine sugar, oil and eggs in a bowl'
    union select 'Chocolate Chip Cookies', 2, 'mix well'
    union select 'Chocolate Chip Cookies', 3, 'add flour, vanilla sugar, baking powder and baking soda'
    union select 'Chocolate Chip Cookies', 4, 'beat for 5 minutes'
    union select 'Chocolate Chip Cookies', 5, 'add chocolate chips'
    union select 'Chocolate Chip Cookies', 6, 'freeze for 1-2 hours'
    union select 'Chocolate Chip Cookies', 7, 'roll into balls and place spread out on a cookie sheet'
    union select 'Chocolate Chip Cookies', 8, 'bake on 350 for 10 min'
    union select 'Apple Yogurt Smoothie', 1, 'Peel the apples and dice'
    union select 'Apple Yogurt Smoothie', 2, 'Combine all ingredients in bowl except for apples and ice cubes'
    union select 'Apple Yogurt Smoothie', 3, 'mix until smooth'
    union select 'Apple Yogurt Smoothie', 4, 'add apples and ice cubes'
    union select 'Apple Yogurt Smoothie', 5, 'pour into glasses'
    union select 'Cheese Bread', 1, 'Slit bread every 3/4 inch'
    union select 'Cheese Bread', 2, 'Combine all ingredients in bowl'
    union select 'Cheese Bread', 3, 'fill slits with cheese mixture'
    union select 'Cheese Bread', 4, 'wrap bread into a foil and bake for 30 minutes.'
    union select 'Butter Muffins', 1, 'Cream butter with sugars'
    union select 'Butter Muffins', 2, 'Add eggs and mix well'
    union select 'Butter Muffins', 3, 'Slowly add rest of ingredients and mix well'
    union select 'Butter Muffins', 4, 'fill muffin pans 3/4 full and bake for 30 minutes'
    union select 'Fried Chicken Cutlets', 1, 'cut up the chicken breast into think pieces, about 1/4 inch thick'
    union select 'Fried Chicken Cutlets', 2, 'crack the egg into a bowl and whisk it up'
    union select 'Fried Chicken Cutlets', 3, 'pour the bread crumbs, onion consomme, paprika, and black pepper on a plate and mix them up'
    union select 'Fried Chicken Cutlets', 4, 'pour oil as needed into a pan and turn the fire on medium-high and wait untill the oil starts sizzling'
    union select 'Fried Chicken Cutlets', 5, 'dip each chicken cutlet into the egg and then coat it with the bread crumb mixture'
    union select 'Fried Chicken Cutlets', 6, 'stick each coated cutlet in the frying pan and fry on each side, about 4 to 5 minutes, untill golden brown'
    union select 'Fried Chicken Cutlets', 7, 'let each cutlet cool on a plate with a napkin for about 10 minutes and then enjoy!'
    union select 'Crispy Potato Roast', 1, 'preheat oven to 375 degrees'
    union select 'Crispy Potato Roast', 2, 'pour 1 tablespoon of oil into 9 x 13 inch pan, spread evenly, and sprinkle salt on top'
    union select 'Crispy Potato Roast', 3, 'cut all potatoes very thinly and arrange them vertically in the pan'
    union select 'Crispy Potato Roast', 4, 'cut shallots very thinly and place them between the potato slices'
    union select 'Crispy Potato Roast', 5, 'pour remaining oil on top and season with more salt'
    union select 'Crispy Potato Roast', 6, 'bake for 1 hour and 15 minutes'
    union select 'Crispy Potato Roast', 7, 'then arrange thyme sprigs on top and bake for another 35 minutes'
    union select 'Quesadillas', 1, 'Preheat oven to 350 degrees'
    union select 'Quesadillas', 2, 'cup up the mushrooms, onions and peppers into thin slices'
    union select 'Quesadillas', 3, 'melt butter in a large skillet and saute the cut up vegetables until they are soft'
    union select 'Quesadillas', 4, 'place tortillas in a large pan'
    union select 'Quesadillas', 5, 'place vegetables and cheese on each tortilla and then cover it with another tortilla'
    union select 'Quesadillas', 6, 'bake for 10 minutes'
    union select 'Quesadillas', 7, 'slice them up and serve with sour cream and salsa'
    union select 'Peanut Butter Truffles', 1, 'Mix peanut butter and powdered sugar in a bowl until clumpy'
    union select 'Peanut Butter Truffles', 2, 'form them into balls about 1 inch in diameter'
    union select 'Peanut Butter Truffles', 3, 'melt chocolate chips and margarine in a bowl in the microwave for 1 minute'
    union select 'Peanut Butter Truffles', 4, 'mix the melted chocolate chips and margarine'
    union select 'Peanut Butter Truffles', 5, 'dip each peanut butter ball in the chocolate mixture'
    union select 'Peanut Butter Truffles', 6, 'freeze the balls for an hour and then enjoy'
    union select 'Ice Coffee Crush', 1, 'dissolve the coffee in the hot water'
    union select 'Ice Coffee Crush', 2, 'put all the ingredients in a blender and blend untill all ice is fully crushed'
    union select 'Ice Coffee Crush', 3, 'put in glasses and enjoy'
)
insert Instruction(RecipeId, SequenceOrder, Instruction)
select r.RecipeId, x.SequenceOrder, x.Instruction
from x 
join recipe r 
on r.RecipeName = x.Recipe

go 
insert Meal (UserId, MealName, DateCreated, Active)
select (select u.UserId from users u where u.Username = 'MGross123'),'Breakfast Bash', '2022-03-11', 0
union select (select u.UserId from users u where u.Username = 'IRosen123'), 'Family Brunch', '2022-06-21', 1
union select (select u.UserId from users u where u.Username = 'AMarks123'), 'Fiesta', '2022-02-13', 1
union select (select u.UserId from users u where u.Username = 'SJohnson123'), 'Classic Shabbos Meal',  '2022-01-09', 1
go 
;
with x as (
    select Meal = 'Breakfast Bash', Course = 'Appetizer'
    union select 'Breakfast Bash', 'Main: Main course'
    union select 'Breakfast Bash', 'Main: Main side'
    union select 'Family Brunch', 'Appetizer'
    union select 'Family Brunch', 'Main: Main course'
    union select 'Family Brunch', 'Main: Main side'
    union select 'Family Brunch', 'Dessert'
    union select 'Fiesta', 'Appetizer'
    union select 'Fiesta', 'Main: Main course'
    union select 'Fiesta', 'Main: Main side'
    union select 'Classic Shabbos Meal', 'Main: Main course'
    union select 'Classic Shabbos Meal', 'Main: Main side'
    union select 'Classic Shabbos Meal', 'Dessert'   
)
insert MealCourse (MealId, CourseId)
select m.MealId, c.CourseId
from x 
join Meal m 
on m.MealName = x.Meal
join Course c 
on c.CourseName = x.Course
go
;
with x as (
    select Meal = 'Breakfast Bash', Course = 'Appetizer', Recipe = 'Apple Yogurt Smoothie', MainDish = 0
    union select 'Breakfast Bash', 'Main: Main course', 'Cheese Bread', 1
    union select 'Breakfast Bash', 'Main: Main side', 'Butter Muffins', 0
    union select 'Family Brunch', 'Appetizer', 'Apple Yogurt Smoothie', 0
    union select 'Family Brunch', 'Main: Main course', 'Cheese Bread', 1
    union select 'Family Brunch', 'Main: Main side', 'Crispy Potato Roast', 0
    union select 'Family Brunch', 'Dessert', 'Chocolate Chip Cookies', 0
    union select 'Fiesta', 'Appetizer', 'Cheese Bread', 0
    union select 'Fiesta', 'Main: Main course', 'Quesadillas', 1
    union select 'Fiesta', 'Main: Main side', 'Butter Muffins', 0
    union select 'Classic Shabbos Meal', 'Main: Main course', 'Fried Chicken Cutlets', 1
    union select 'Classic Shabbos Meal', 'Main: Main side', 'Crispy Potato Roast', 0
    union select 'Classic Shabbos Meal', 'Dessert', 'Chocolate Chip Cookies', 0
)
insert MealcourseRecipe (MealcourseId, RecipeId, MainDish)
select mc.MealCourseId, r.RecipeId, x.MainDish
from x 
join meal m 
on m.mealname = x.meal
join course c 
on c.CourseName = x.Course
join MealCourse mc 
on mc.CourseId = c.CourseId
and mc.MealId = m.MealId
join recipe r 
on r.RecipeName = x.Recipe
go 

insert Cookbook (UserId, CookbookName, Price, DateCreated, Active)
select (select u.UserId from users u where u.Username = 'IRosen123'), 'Treats for Two', 30, '2022-06-23', 1
union select (select u.UserId from users u where u.Username = 'MGross123'), 'Jewish Cooking', 45, '2022-04-01', 1
union select (select u.UserId from users u where u.Username = 'SJohnson123'), 'Easy Vegetarian Recipes', 0, '2022-03-11', 0 
union select (select u.UserId from users u where u.Username = 'AMarks123'), 'Breakfast Made Easy', 25, '2022-01-13', 1
go 
;
with x as (
    select Cookbook = 'Treats for Two', Recipe = 'Chocolate Chip Cookies'
    union select 'Treats for Two', 'Apple Yogurt Smoothie'
    union select 'Treats for Two', 'Cheese Bread'
    union select 'Treats for Two', 'Butter Muffins'
    union select 'Jewish Cooking', 'Fried Chicken Cutlets'
    union select 'Jewish Cooking', 'Crispy Potato Roast'
    union select 'Jewish Cooking', 'Chocolate Chip Cookies'
    union select 'Easy Vegetarian Recipes', 'Apple Yogurt Smoothie'
    union select 'Easy Vegetarian Recipes', 'Quesadillas'
    union select 'Easy Vegetarian Recipes', 'Cheese Bread'
    union select 'Easy Vegetarian Recipes', 'Chocolate Chip Cookies'
    union select 'Breakfast Made Easy', 'Apple Yogurt Smoothie'
    union select 'Breakfast Made Easy', 'Cheese Bread'
    union select 'Breakfast Made Easy', 'Butter Muffins'
    union select 'Breakfast Made Easy', 'Chocolate Chip Cookies'
)
insert CookbookRecipe (CookbookId, RecipeId)
select c.cookbookId, r.RecipeId
from x 
join Cookbook c 
on c.CookbookName = x.Cookbook
join recipe r  
on r.RecipeName = x.Recipe

select * from  CookbookRecipe order by CookbookId 
select * from  CookBook
select * from  MealcourseRecipe order by MealcourseId
select * from  MealCourse 
select * from  Meal 
select * from  Instruction order by RecipeId
select * from  RecipeIngredient order by RecipeId
select * from  Recipe  
select * from  Users  
select * from  Ingredient
select * from  Course  
select * from  Cuisine
