@echo off


if %1%==add-migration goto add-migration
if %1%==update-database goto update-database

echo UNKNOWN OPERATION
goto:eof 

:add-migration
set /p name= Informe nome da mingration: 
dotnet ef --startup-project  stefanini-prova.csproj migrations add %name% --context Contexto
goto:eof

:update-database
echo Certeza que deseja rodar as migrations?
set /p confirm= Enter para confirmar ou CTRL + C para cancelar 
dotnet ef --startup-project  stefanini-prova.csproj database update --context Contexto
goto:eof