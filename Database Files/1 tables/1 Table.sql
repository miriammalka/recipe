--BG Fabulous work! Very neat and clean code! 98% Please see comments and resubmit
use RecipeDB 
go 
drop table if exists CookbookRecipe
go 
drop table if exists CookBook
go 
drop table if exists MealcourseRecipe
go
drop table if exists MealCourse
go 
drop table if exists Meal
go 
drop table if exists Instruction
go 
drop table if exists RecipeIngredient
go 
drop table if exists Recipe 
go 
drop table if exists Users
go 
drop table if exists MeasurementType 
go 
drop table if exists Ingredient
go 
drop table if exists Course 
go 
drop table if exists Cuisine
go 

create table dbo.Cuisine(
   CuisineId int not null identity primary key,
   CuisineName varchar(50) not null constraint ck_Cuisine_CuisineName_cannot_be_blank check(CuisineName > '')
        constraint u_Cuisine_CuisineName unique
    )
go 
create table dbo.Course( 
    CourseId int not null identity primary key,
    CourseName varchar(25) not null constraint ck_Course_CourseName_cannot_be_blank check(CourseName > '')
        constraint u_Course_CourseName unique,
    SequenceOrder int not null
        constraint ck_Course_Sequence_must_be_1_or_greater check(SequenceOrder >= 1)
        constraint u_Course_SequenceOrder unique
)
go 
create table dbo.Ingredient(
    IngredientId int not null identity primary key,
    IngredientName varchar(50) not null
        constraint ck_Ingredient_IngredientName_cannot_be_blank check(IngredientName > '')
        constraint u_Ingredient_IngredientName unique,
    Picture as concat('Ingredient-', replace(IngredientName,' ', '-'), '.jpg') persisted
    )
go
create table dbo.MeasurementType(
    MeasurementTypeId int not null identity primary key,
    MeasurementType varchar(25) not null 
        constraint ck_MeasurementType_MeasurementType_cannot_be_blank check(MeasurementType > '')
        constraint u_MeasurementType_MeasurementType unique
)
go
create table dbo.Users( 
    UsersId int not null identity primary key,
    FirstName varchar (50) not null 
        constraint ck_User_FirstName_cannot_be_blank check(FirstName > ''), 
    LastName varchar (50) not null 
        constraint ck_User_LastName_cannot_be_blank check(LastName > ''), 
    Username varchar (100) not null 
        constraint ck_User_UserName_cannot_be_blank check(UserName > '')
        constraint u_User_Username unique
    )
go 
alter table recipe add Vegan bit not null default 0
go
create table dbo.Recipe(
    RecipeId int not null identity primary key,
    CuisineId int not null constraint f_Cuisine_recipe foreign key references Cuisine(CuisineId),
    UsersId int not null constraint f_User_Recipe foreign key references Users(UsersId),
    RecipeName varchar(100) not null 
        constraint ck_Recipe_RecipeName_cannot_be_blank check(RecipeName > '') 
        constraint u_Recipe_RecipeName unique,
    Calories int not null 
        constraint ck_Recipe_Calories_must_be_between_0_and_5000 check(Calories between 0 and 5000),
    DateCreated datetime not null default getdate()
        constraint ck_Recipe_DateCreated_must_be_between_January_1_2015_and_the_present check(DateCreated between '01-01-2015' and Getdate()),
    DatePublished datetime null
        constraint ck_Recipe_DatePublished_must_be_between_January_1_2015_and_the_present check(DatePublished between '01-01-2015' and Getdate()),
    DateArchived datetime null
        constraint ck_Recipe_DateArchived_must_be_between_January_1_2015_and_the_present check(DateArchived between '01-01-2015' and Getdate()),
    RecipeStatus as case 
        when DateArchived is not null then 'archived'
        when DatePublished is not null then 'published'
        else 'draft'
        end,
    Picture as Lower(concat('Recipe_', replace(RecipeName,' ', '_'), '.jpg')) persisted,
    constraint ck_DateCeated_must_be_less_than_DatePublished_and_DateArchived check(DateCreated <= DatePublished and DateCreated <= DateArchived)
    )
go 
create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key,
    RecipeId int not null constraint f_Recipe_RecipeIngredient foreign key references Recipe(RecipeId), 
    IngredientId int not null constraint f_Ingredient_RecipeIngredient foreign key references Ingredient(IngredientId),
    MeasurementTypeId int not null constraint f_RecipeIngredient_MeasurementType foreign key references MeasurementType(MeasurementTypeId),
    SequenceOrder int not null 
        constraint ck_RecipeIngredient_Sequence_must_be_between_1_and_50 check(SequenceOrder between 1 and 50), 
    Amount decimal (4,2) not null 
        constraint ck_Amount_must_be_greater_than_0 check(Amount > 0),
    constraint u_RecipeIngredient_RecipeId_IngredientId unique(RecipeId, IngredientId)
    )
go 
create table dbo.Instruction(
    InstructionId int not null identity primary key,
    RecipeId int not null constraint f_Recipe_Instruction foreign key references Recipe(RecipeId), 
    SequenceOrder int not null 
        constraint ck_Instruction_Sequence_must_be_between_1_and_50 check(SequenceOrder between 1 and 50), 
    Instruction varchar (1000) not null
        constraint ck_Instruction_Instruction_cannot_be_blank check(Instruction > ''),
    constraint u_Instruction_RecipeId_Instruction unique(RecipeId, Instruction),
    constraint u_Instruction_RecipeId_Sequence unique(RecipeId, SequenceOrder)
    )
go 
create table dbo.Meal(
    MealId int not null identity primary key,
    UsersId int not null constraint f_User_Meal foreign key references Users(UsersId),
    MealName varchar(50) not null 
        constraint ck_Meal_MealName_cannot_be_blank check(MealName > '')
        constraint u_Meal_MealName unique,
    DateCreated datetime not null
        constraint ck_Meal_DateCreated_must_be_between_January_1_2015_and_the_present check(DateCreated between '01-01-2015' and Getdate()),
    Active bit not null,
    Picture as concat('Meal-', replace(MealName,' ', '-'), '.jpg') persisted
    )
go 
alter table meal add MealDesc varchar(500) not null default ''
go
create table dbo.MealCourse(
    MealCourseId int not null identity primary key,
    MealId int not null constraint f_Meal_MealCourse foreign key references Meal(MealId),  
    CourseId int not null constraint f_Course_MealCourse foreign key references Course(CourseId),
    constraint u_MealCourse_MealId_CourseId unique(MealId, CourseId)
    )
go 
create table dbo.MealCourseRecipe(
    MealCourseRecipeId int not null identity primary key,
    MealCourseId int not null constraint f_Mealcourse_MealcourseRecipe foreign key references MealCourse(MealCourseId),
    RecipeId int not null constraint f_Recipe_MealcourseRecipe foreign key references Recipe(RecipeId),
    MainDish bit not null,
    constraint u_MealcourseRecipe_MealCourseId_RecipeId unique(MealCourseId, RecipeId)
        --MMG how do you ensure the meal does not have 2 of the same recipes?
        --BG: the way you wrote the constraint allows the meal to be unique to its recipe. Great Work!
)
go 
create table dbo.Cookbook(
    CookbookId int not null identity primary key,
    UsersId int not null constraint f_User_Cookbook foreign key references Users(UsersId),
    CookbookName varchar(75) not null
        constraint ck_Cookbook_CookbookName_cannot_be_blank check(CookbookName > '')
        constraint u_Cookbook_CookbookName unique,
    Price decimal(4,2) not null
        constraint ck_Cookbook_Price_must_be_greater_than_or_equal_to_0 check(Price >= 0),
    DateCreated datetime not null
        constraint ck_Cookbook_DateCreated_must_be_between_January_1_2015_and_the_present check(DateCreated between '01-01-2015' and Getdate()),
    Active bit not null,
    Picture as concat('Cookbook-', replace(CookbookName,' ', '-'), '.jpg') persisted,
    --constraint ck_Price_is_0_and_Active_is_0_or_Price_is_greater_than_0_and_Active_is_1 check((Price = 0 and Active = 0) or (Price > 0 and Active = 1))
    /*AF The way that the constraint is written now, it blocks an inactive cookbook from having a price greater than 0, which I don't think is part of the schema. 
     This constraint can be changed a little to fix that by removing 'Price = 0' in the case where 'ACtive=0'.  So the check statement will just check either (active = 0)
     or (price > 0 and active = 1).  So if it's inactive, it can have any price*/
	constraint ck_An_active_cookbook_must_have_a_price_greater_than_0 check((Active = 0) or (Price > 0 and Active = 1))
)
go 
alter table cookbook add SkillLevel int not null default 1
go
alter table cookbook add SkillLevelDesc as case
	when SkillLevel = 1 then 'beginner'
	when SkillLevel = 2 then 'intermediate'
	when SkillLevel = 3 then 'advanced'
	end
go

alter table cookbook
add constraint ck_SkillLevel_must_be_between_1_and_3 check (SkillLevel between 1 and 3)
go

create table dbo.CookbookRecipe(
    CookbookRecipeId int not null identity primary key, 
    CookbookId int not null constraint f_Cookbook_CookbookRecipe foreign key references Cookbook(CookbookId),
    RecipeId int not null constraint f_Recipe_CookbookRecipe foreign key references Recipe(RecipeId),
	SequenceOrder int not null,
    constraint ck_CookbookRecipe_Sequence_must_be_between_1_and_50 check(SequenceOrder between 1 and 50), 
    constraint u_CookbookRecipe_CookbookId_RecipeId unique(CookbookId, RecipeId)
)
go 

