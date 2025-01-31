drop table if exists roles
go
create table dbo.roles(
roleId int not null identity primary key,
rolename varchar(10) not null constraint u_Role_Role_Name unique,
rolerank int not null constraint u_Role_Role_Rank unique
)
go