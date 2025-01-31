
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
	  WHEN UsersId = 13 THEN 'password'
	  else 'password'

           END,
    RoleId= CASE 
                WHEN UsersId = 13 THEN (select r.roleId from roles r where r.rolerank = 1)
                WHEN UsersId = 14 THEN (select r.roleId from roles r where r.rolerank = 2)
                WHEN UsersId = 15 THEN (select r.roleId from roles r where r.rolerank = 3)
				WHEN UsersId = 16 THEN (select r.roleId from roles r where r.rolerank = 4)
             END

ALTER TABLE users
ALTER COLUMN RoleId int NOT NULL
go

ALTER TABLE users
ALTER COLUMN password varchar(20) NOT NULL
go


select * from users