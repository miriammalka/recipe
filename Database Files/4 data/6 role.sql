delete roles

insert roles(rolename, rolerank)
select 'user', '1'
union select 'superuser', '2'
union select 'admin1', '3'
union select 'admin2', '4'

select * from roles