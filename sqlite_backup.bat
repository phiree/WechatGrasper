@echo off
for /f %%i in ('powershell ^(get-date^).DayOfWeek') do set dow=%%i
echo %dow%
 copy "TourInfo.db3"  d:\TourInfo.%dow%.db3  
pause