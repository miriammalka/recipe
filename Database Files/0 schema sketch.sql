/*FB Amazing work!! See some comments below, no need to resubmit. Mark: 100%

cuisine: 
   CuisineId int not null identity primary key,
   CuisineName varchar(50) constraint ck_Cuisine_CuisineName_cannot_be_blank check(CuisineName > '')
        constraint u_Cuisine_CuisineName unique

course: 
    CourseId int not null identity primary key,
    CourseName varchar(25) not null constraint ck_Course_CourseName_cannot_be_blank check(CourseName > '')
        constraint u_Course_CourseName unique
            (must be: appetizer, main, mainside, dessert)
    Sequence int not null
        constraint ck_Course_Sequence_must_be_between_1_and_4 check(Sequence between 1 and 4)

Ingredient:
    IngredientId int not null identity primary key,
    IngredientName varchar(50) not null
        constraint ck_Ingredient_IngredientName_cannot_be_blank check(IngredientName > '')
        constraint u_Ingredient_IngredientName unique
    Picture as concat('Ingredient-', replace(IngredientName,' ', '-'), '.jpg')
        constraint u_Ingredient_Picture unique,

User: 
    UserId int not null identity primary key,
    FirstName varchar (50) not null 
        constraint ck_User_FirstName_cannot_be_blank check(FirstName > ''), 
    LastName varchar (50) not null 
        constraint ck_User_LastName_cannot_be_blank check(LastName > ''), 
    Username varchar (100) not null 
        constraint ck_User_UserName_cannot_be_blank check(UserName > '')
        constraint u_User_Username unique
            --FB If the username is unique then you don't need first, last name and username to be unique - the unique constraint will never be used

Recipe:
    RecipeId int not null identity primary key,
    CuisineId int not null constraint f_Cuisine_recipe foreign key reference Cuisine(CuisineId),
    UserId int not null constraint f_User_Recipe foreign key references User(UserId),
    RecipeName varchar(100) not null 
        constraint ck_Recipe_RecipeName_cannot_be_blank check(RecipeName > '') 
        constraint u_Recipe_RecipeName unique,
    Calories int not null 
        constraint ck_Recipe_Calories_must_be_between_0_and_5000 check(Calories between 0 and 5000),
    DateCreated not null default getdate()
        constraint ck_DateCreated_must_be_between_January_1_2015_12:00_and_the_present check(DateCreated between January 1, 2015 12:00 and Getdate()),
    DatePublished datetime null
        constraint ck_DatePublished_must_be_between_January_1_2015_12:00_and_the_present check(DatePublished between January 1, 2015 12:00 and Getdate()),
    DateArchived datetime null
        constraint ck_DateArchived_must_be_between_January_1_2015_12:00_and_the_present check(DateArchived between January 1, 2015 12:00 and Getdate()),
    Status as case when DateArchived is not null then 'archive',
    when Datepublished is not null then 'published',
    else 'draft'
    end,
    Picture as concat('Recipe-', replace(RecipeName,' ', '-'), '.jpg')
        constraint u_Recipe_Picture unique,
        constraint u_RecipeName_CuisineId unique (RecipeName, CuisineId)
        constraint ck_DateCeated_must_be_less_than_DatePublished_and_DateArchived check(DateCreated <= DatePublished and DateCreated <= DateArchived)

RecipeIngredient:
    RecipeIngredientId int not null identity primary key,
    RecipeId int not null constraint f_Recipe_RecipeIngredient foreign key references Recipe(RecipeId), 
    IngredientId int not null constraint f_Ingredient_RecipeIngredient Ingredient(IngredientId),
    Sequence int not null 
        constraint ck_RecipeIngredient_Sequence_must_be_between_1_and_50 check(Sequence between 1 and 50),
    MeasurementType varchar(25) not null 
        constraint ck_RecipeIngredient_MeasurementType_cannot_be_blank check(MeasurementType > ''), 
    Amount int not null 
        constraint ck_Amount_must_be_greater_than_0 check(Amount > 0),
            constraint u_RecipeIngredient_RecipeId_IngredientId unique(RecipeId, IngredientId)

Instruction:
    InstructionId int not null identity primary key,
    RecipeId int not null constraint f_Recipe_Instruction foreign key references Recipe(RecipeId), 
    Sequence int not null 
        constraint ck_Instruction_Sequence_must_be_between_1_and_50 check(Sequence between 1 and 50), 
    Instruction varchar (1000) not null
        constraint ck_Instruction_Instruction_cannot_be_blank check(Instruction > ''),
    --FB see below improved formatting for the 2 multi column constriants
     constraint u_Instruction_RecipeId_Instruction unique(RecipeId, Instruction)
     constraint u_Instruction_RecipeId_Sequence unique(RecipeId, Sequence)

Meal:
    MealId int not null identity primary key,
    MealName varchar(50) not null 
        constraint ck_Meal_MealName_cannot_be_blank check(MealName > '')
        constraint u_Meal_MealName unique,
    UserId int not null constraint f_User_Meal foreign key referneces User(UserId),
    DateCreated date not null
        constraint ck_DateCreated_must_be_between_January_1_2015_12:00_and_the_present check(DateCreated between January 1, 2015 12:00 and Getdate()),
    Active bit not null,
    Picture as concat('Meal-', replace(MealName,' ', '-'), '.jpg')
        constraint u_Meal_Picture unique

MealCourse:
    MealCourseId int not null identity primary key,
    MealId int not null constraint f_Meal_MealCourse foreign key referneces Meal(MealId),  
    CourseId int not null constraint f_Course_Meal foreign key refernces Course(CourseId), 
    RecipeId int not null constraint f_Recipe_MealCourse foreign key references Recipe(RecipeId),
            constraint u_MealCourse_MealId_RecipeId unique(MealId, RecipeId)


Cookbook:
    CookbookId int not null identity primary key,
    CookbookName varchar(75) not null
        constraint ck_Cookbook_CookbookName_cannot_be_blank check(CookbookName > '')
        constraint u_Cookbook_CookbookName unique,
    Price decimal(4,2) not null
        constraint ck_Cookbook_Price_must_be_greater_than_0 check(Price > 0),
    UserId int not null constraint f_User_Meal foreign key referneces User(UserId),
    DateCreated datetime not null
        constraint ck_DateCreated_must_be_between_January_1_2015_12:00_and_the_present check(StatusDate between January 1, 2015 12:00 and Getdate()),
    Active bit not null,
    Picture as concat('Cookbook-', replace(CookbookName,' ', '-'), '.jpg')
        constraint u_Cookbook_Picture unique,
        constraint ck_Price_is_0_and_Status_is_0_or_Price_is_greater_than_0_and_Status_is_1 check((Price = 0 and Status = 0) or (Price > 0 and Status = 1))

CookbookRecipe:
    CookbookRecipeId int not identity primary key, 
    CookbookId int not null constraint f_Cookbook_CookbookRecipe foreign key refernces Cookbook(CookbookId),
    RecipeId int not null constraint f_Recipe_CookbookRecipe foreign key refernces Recipe(RecipeId),
            constraint u_CookbookRecipe_CookbookId_RecipeId unique(CookbookId, RecipeId)

*/