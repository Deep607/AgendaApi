README - Projeto Backend Agenda de Contatos
Descrição do Projeto
Este é o backend de uma aplicação de Agenda de Contatos, desenvolvido em .NET 6 com Entity Framework Core. Ele fornece uma API RESTful para gerenciar contatos, permitindo operações como criação, leitura, atualização e exclusão (CRUD). O projeto utiliza um banco de dados relacional para persistência dos dados.

Funcionalidades
Listar Contatos: Recupera todos os contatos do banco de dados.
Buscar Contato por ID: Recupera as informações de um contato específico.
Criar Contato: Adiciona um novo contato ao banco de dados.
Editar Contato: Atualiza as informações de um contato existente.
Excluir Contato: Remove permanentemente um contato do banco de dados.

Tecnologias Utilizadas
.NET 6
Entity Framework Core
SQLite (ou outro banco de dados configurável)
Swagger (para documentação da API)
Pré-requisitos
SDK do .NET 6
Visual Studio ou Visual Studio Code
Banco de dados configurado (SQLite, SQL Server ou outro).

Instalação
Clone o repositório do projeto:
git clone https://github.com/Deep607/AgendaApi

Acesse o diretório do projeto:
cd agenda-contatos-backend

Restaure as dependências:
dotnet restore

Inicie o servidor:
dotnet run
