alter table cookbook add SkillLevel int not null default 1
go
alter table cookbook add SkillLevelDesc as case
	when SkillLevel = 1 then 'beginner'
	when SkillLevel = 2 then 'intermediate'
	when SkillLevel = 3 then 'advanced'
	end
go

alter table cookbook
add constraint ck_SkillLevel_must_be_between_1_and_3 check (SkillLevel between 1 and 3)
go