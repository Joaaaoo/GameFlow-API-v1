# GameFlow

**GameFlow** é uma API para gerenciar um sistema de locação e venda de jogos. A aplicação utiliza tecnologias modernas como .NET 7, Entity Framework Core, Redis para caching, JWT para autenticação e MediatR para manipulação de comandos e consultas de forma escalável. O sistema é projetado para ser fácil de expandir e personalizar de acordo com as necessidades de um sistema de gerenciamento de jogos.

## Tecnologias Utilizadas

- **.NET 7**: Framework para desenvolvimento da aplicação.
- **Entity Framework Core**: ORM para interação com o banco de dados.
- **SQL Server**: Banco de dados relacional para armazenar as informações dos jogos.
- **Redis**: Sistema de cache para melhorar a performance da aplicação.
- **JWT Authentication**: Autenticação via tokens JWT.
- **Swagger**: Documentação da API para facilitar o desenvolvimento e testes.
- **Docker**: Containerização da aplicação e do banco de dados, facilitando a configuração e o ambiente de produção.
- **Angular**: Framework para desenvolvimento do front-end web.

## Funcionalidades

- **Cadastro e gerenciamento de jogos**: Possibilidade de cadastrar, listar, editar e excluir jogos.
- **Autenticação JWT**: Garantia de segurança no acesso a endpoints da API.
- **Cache com Redis**: Armazenamento em cache para melhorar o desempenho das consultas.
- **Migrações com EF Core**: Gerenciamento de alterações no banco de dados.
- **API Restful**: Endpoints para CRUD (Criar, Ler, Atualizar, Deletar) de jogos.
- **Interface Web**: Interface amigável para interação com o sistema.

## Como Rodar o Projeto

### Pré-requisitos

- **.NET SDK 7.0** ou superior
- **Docker** (opcional, para containerização)
- **SQL Server** (local ou Docker)
- **Node.js** e **npm** (para o web app Angular)

### Rodando Localmente

1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/GameFlow.git
    cd GameFlow
    ```

2. Restaurar as dependências do projeto:
    ```bash
    dotnet restore
    ```

3. Aplicar migrações no banco de dados:
    ```bash
    dotnet ef database update
    ```

4. Executar o projeto:
    ```bash
    dotnet run --project GameFlow.API
    ```

### Rodando o Web App Angular

1. Navegue até o diretório do web app:
    ```bash
    cd GameFlow-Web-App
    ```

2. Instale as dependências do projeto:
    ```bash
    npm install
    ```

3. Inicie o servidor de desenvolvimento:
    ```bash
    npm start
    ```

4. Abra o navegador e acesse `http://localhost:4200/`.

### Usando Docker

Para rodar a aplicação e o banco de dados com Docker, você pode usar o `docker-compose.yml` incluído no repositório.

1. Subir o banco de dados (SQL Server) com Docker:
    ```bash
    ./start-sqlserver.sh
    ```

2. Rodar a aplicação:
    ```bash
    docker-compose up
    ```

A API estará disponível em `https://localhost:7056`.

## Estrutura do Projeto

- **GameFlow.API**: Contém a API que expõe os endpoints RESTful.
- **GameFlow.Application**: Contém as lógicas de negócios, comandos e consultas (MediatR).
- **GameFlow.Domain**: Define as entidades e regras de domínio.
- **GameFlow.Infrastructure**: Implementa a persistência de dados, incluindo o DbContext e configurações de banco de dados.
- **GameFlow-Web-App**: Contém o front-end web desenvolvido com Angular.
- **Docker**: Contém arquivos necessários para containerizar a aplicação.

## Comandos de Migração

Para adicionar uma nova migração, use o comando:

```bash
dotnet ef migrations add NomeDaMigração --project GameFlow.Infrastructure --startup-project GameFlow.API
```

Para atualizar o banco de dados com as últimas migrações:

```bash
dotnet ef database update --project GameFlow.Infrastructure --startup-project GameFlow.API
```