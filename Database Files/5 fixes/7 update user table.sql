
alter table users 
add roleId int null
go

alter table users 
add password varchar(20) null
go

alter table users 
add sessionkey varchar(255) not null default ''
go

alter table users 
add sessionkeyDate datetime null
go


UPDATE users
SET 
    Password = case
	  WHEN UsersId = 14 THEN 'password'
	  else 'password'

           END,
    RoleId= CASE 
                WHEN UsersId = 14 THEN (select r.roleId from roles r where r.rolerank = 1)
                WHEN UsersId = 1015 THEN (select r.roleId from roles r where r.rolerank = 2)
                WHEN UsersId = 1016 THEN (select r.roleId from roles r where r.rolerank = 3)
				WHEN UsersId = 1017 THEN (select r.roleId from roles r where r.rolerank = 4)
             END

ALTER TABLE users
ALTER COLUMN RoleId int NOT NULL
go

ALTER TABLE users
ALTER COLUMN password varchar(20) NOT NULL
go


select * from users

--insert data
insert Users(FirstName, LastName, Username, roleId, password)
select 'Sam', 'Johnson', 'SJohnson123',(select r.roleId from roles r where r.rolerank = 1), 'password'
union select 'Alice', 'Marks', 'AMarks123',(select r.roleId from roles r where r.rolerank = 2), 'password'
union select 'Miriam', 'Gross', 'MGross123', (select r.roleId from roles r where r.rolerank = 3),'password'
union select 'Isaac', 'Rosen', 'IRosen123', (select r.roleId from roles r where r.rolerank = 4),'password'
go