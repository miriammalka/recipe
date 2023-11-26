script to create login and user is excluded from this repo.
Create a file called create-login.sql (this file is ignored by git ignore in this repo)
add the following to that file
--IMPORTANT create login in MASTER
--use MASTER
create login [loginname] with PASSWORD = '[password]'

--IMPORTANT switch to target database = RecipeDB
create user [username] from login [login name]