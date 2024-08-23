with x as(
select 
13 as CookbookId,
1 as SkillLevel
union all
select
14,
2
union all
select
15,
3
union all
select
16,
1
)
update c
set c.SkillLevel = x.SkillLevel
from Cookbook c
join x on c.CookbookId = x.CookbookId

select * from cookbook