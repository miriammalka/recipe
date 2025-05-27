with x as(
select 
1014 as MealId,
'Delicous breakfast food to keep you full' as MealDesc
union all
select
1015,
'Family friendly food for all'
union all
select
1016,
'Mexican style food'
union all
select
1017,
'Traditional Shabbos menu'
)
update m
set m.MealDesc = x.MealDesc
from Meal m
join x on m.MealId = x.MealId


select * from meal
