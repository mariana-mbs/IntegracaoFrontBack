# Integração Frontend e Backend

Aplicação de gerenciamento de produtos com uma API ASP.NET Core e uma interface Angular.

## Tecnologias

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Angular

## Estrutura do projeto

- `Backend/MinhaPrimeiraApi`: API, migrações e acesso ao banco SQLite.
- `Frontend/Produtos`: aplicação Angular.

## Pré-requisitos

- .NET 10 SDK
- Node.js e npm
- Ferramenta `dotnet-ef` versão 10.0.12

Caso ainda não tenha a ferramenta do Entity Framework instalada:

```powershell
dotnet tool install --global dotnet-ef --version 10.0.12
```

## Executar o backend

Abra um terminal na pasta raiz do repositório e rode:

```powershell
cd Backend/MinhaPrimeiraApi
dotnet restore
dotnet ef database update
dotnet run
```

A API estará em `http://localhost:5036` e o Swagger em `http://localhost:5036/swagger`.

O banco SQLite `minhaapi.db` é criado localmente pelas migrações. Para visualizá-lo no DBeaver, abra o arquivo `Backend/MinhaPrimeiraApi/minhaapi.db`.

## Executar o frontend

Em outro terminal, também a partir da pasta raiz:

```powershell
cd Frontend/Produtos
npm install
npm start
```

A aplicação Angular estará em `http://localhost:4200`. O backend precisa continuar em execução para o frontend acessar a API.

## Endpoints

- `GET /api/Produtos`: lista os produtos.
- `GET /api/Produtos/{id}`: busca um produto pelo ID.
- `POST /api/Produtos`: cadastra um produto.
- `PUT /api/Produtos/{id}`: atualiza um produto.
- `DELETE /api/Produtos/{id}`: exclui um produto.