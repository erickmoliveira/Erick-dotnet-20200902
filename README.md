# DotNet Challenge 20200902

## FitnessFoods.Core

Projeto responsável pela persistência com o banco de dados e suas entidades.

### FitnessFoods.Tests
 
Projeto com NUnit para os testes unitários.
 

## FitnessFoods.WebApi
 
Projeto web api .net core 5, contém também o front em Angular e o seu dockerfile para o Deploy .


## Como Instalar

Instalar os pacotes via Nuget e executar.

## Observações

- A importação dos produtos é feito todo dia as 05:00.
- Caso tenha algum erro o sentry irá nos informar.
- Podemos visualizar os eventos através do hangfire, assim como assionar determinado evendo.
- Swagger incluso com a listagem dos endpoints.

 Exemplos URL :

 ## Swagger: https://localhost:5001/swagger/index.html
 ## Cron Detail: https://localhost:5001/
 ## Listagem de Produtos cadastrados : https://localhost:5001/fetch-data
 ## HangFire: https://localhost:5001/hangfire


## API KEY

- Apikey está no arquivo de configuração do projeto.



