with x as(
select 
52 as RecipeId,
0 as Vegan
union all
select
53,
0
union all
select 
54,
0
union all
select 
55,
0
union all
select 
56,
0
union all
select 
57,
1
union all
select 
58,
1
union all
select 
59,
0
union all
select 
60,
0
union all
select 
61,
1
union all
select 
62,
0
union all
select 
63,
0
union all
select 
64,
0
union all
select 
65,
0
)
update r
set r.Vegan = x.Vegan
from recipe r
join x on r.RecipeId = x.RecipeId
