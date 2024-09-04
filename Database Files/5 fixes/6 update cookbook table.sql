with x as(
select 
20 as CookbookId,
1 as SkillLevel
union all
select
21,
2
union all
select
22,
3
union all
select
23,
1
)
update c
set c.SkillLevel = x.SkillLevel
from Cookbook c
join x on c.CookbookId = x.CookbookId

select * from cookbook