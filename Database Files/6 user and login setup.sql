--Important- switch to RecipeDB
create user dev_user from login dev_login

alter role db_datawriter add member dev_user 
alter role db_datareader add member dev_user 