add-migration:
	@read -p "Informe o nome da migration: " table \
	&& dotnet ef --startup-project  stefanini-prova.csproj migrations add $${table} --context Contexto

update-database:
	&& dotnet ef --startup-project  stefanini-prova.csproj database update --context Contexto