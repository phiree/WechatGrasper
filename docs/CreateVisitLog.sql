truncate table visitlogs
declare @month int
declare @year int
declare @index int

declare @pv int
declare @uv int
declare @newuser int
declare @date datetime
set @index=1
set @month=1
set @year=2020

while(@index<=120)
begin 
	-- 制造数据
	select @pv=1000+2000*RAND()
	select @uv=300+500*RAND()
	select @newUser=70+30*rand()
	insert  into VisitLogs(id,     year, month,  pv, uv, NewUsersAmount) 
					values(NEWID(),@year,@month, @pv,@uv,@newuser)

	select @date=DATEFROMPARTS(@year,@month,1)
	select @date=DATEADD(MONTH,1,@date)
	select @year=YEAR(@date)
	select @month=MONTH(@date)
	select @index=@index+1
end

select * from VisitLogs order by year,Month