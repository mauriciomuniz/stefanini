# Mauricio Santana Muniz, api restful com backend .NET e frontend feito em html+js





 
## Ferramentas necessárias
- .NET na versão 8
- Docker
- Banco de dados Postgres

#### Na pasta stefanini-prova abrir a solução
##
Abrir o projeto e usar o comando para instalar o entity framework globalmente
```
dotnet tool install --global dotnet-ef
```

## No visual studio ir na solução, clicar com botão direito, ir no 'Gerenciar pacotes nuget para a solução' e instalar os seguintes pacotes

- Microsoft.EntityFrameworkCore.Tools Versão 8.0.2
- Microsoft.VisualStudio.Web.CodeGeneration.Design Versão 8.0.1
- Npgsql.EntityFrameworkCore.PostgreSQL  Versão 8.0.2

### criar um bd no postgres com os seguintes dados
"User ID=stefaniniprova;Password=stefaniniprova;Host=localhost;Port=5432;Database=stefaniniprova;"
## Primeira vez rodando

rodar comando na pasta raiz stefanini-prova
```ssh
docker compose up -d
```
e rode as migrations conforme [seção](#rodar-migrations)

## Acesso aos bancos
__As informações default já estão conforme o docker compose, altere somente se acessar outro banco__


# Migrations

## criar migration
entre na pasta stefanini-prova e rode o seguinte comando
### windows
```ssh
.run.bat add-migration
```
e informe o nome da migration
### linux
```ssh
make add-migration
```
e informe o nome da migration

## rodar migrations
ainda na pasta stefanini-prova e rode o seguinte comando
### windows
```ssh
.run.bat update-database
```
### linux
```ssh
make update-database
```

