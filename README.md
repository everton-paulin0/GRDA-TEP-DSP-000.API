🎤 GRDA TEP DSP 000 – API de Gestão de Palestras

API responsável pela gestão de palestras, trilhas e sessões de uma conferência, desenvolvida com ASP.NET Core 8, utilizando CQRS, MediatR e boas práticas de arquitetura.

🧩 Sobre

Este serviço provê operações para:

Criar palestras

Listar palestras

Buscar por ID

Filtrar por Trilha e Sessão

Atualizar

Excluir

Totalmente desacoplado via CQRS + MediatR.

┌──────────────────┐
│   Presentation    │  → Controllers (API)
└─────────┬────────┘
          │
          ▼
┌──────────────────┐
│      CQRS         │  → Commands, Queries e Handlers
└─────────┬────────┘
          │
          ▼
┌──────────────────┐
│   Domain Layer    │  → Entities, Enums, Regras
└─────────┬────────┘
          │
          ▼
┌──────────────────┐
│ Infrastructure    │ → Repositórios / DB
└──────────────────┘

🛣️ Endpoints Reais
📌 1. Criar palestra

POST /api/palestra

📌 2. Listar palestras

GET /api/palestra

📌 3. Buscar por ID

GET /api/palestra/{id}

📌 4. Filtrar por trilha e sessão

GET /api/palestra/trilha/{trail}/sessao/{sessionTime}

📌 5. Atualizar palestra

PUT /api/palestra/{id}

📌 6. Excluir palestra

DELETE /api/palestra?id={id}

🔢 Enums
🎯 Trail
Valor	Trilha
0	Backend
1	Frontend
2	DevOps
3	Dados / IA
🎯 SessionTimes
Valor	Horário
0	08:00
1	10:00
2	14:00
3	16:00
🧭 Diagramas
🔹 Fluxo com CQRS + MediatR
┌────────────┐     ┌──────────────┐     ┌───────────────┐
│ Controller │ --> │  Command/Query│ --> │    Handler     │
└────────────┘     └──────────────┘     └───────┬─────────┘
                                                ▼
                                       ┌───────────────────┐
                                       │   Repository       │
                                       └───────────────────┘

✔️ Regras de Negócio

IDs enviados no body e na rota devem coincidir

Trilha e Sessão precisam existir nos respectivos Enums

Atualização não retorna body (204)

Filtros obrigatoriamente exigem trilha + sessão

Exclusão via query param (?id=)

🚀 Como Rodar
1. Restaurar dependências
dotnet restore

2. Rodar a API
dotnet run --project GRDA_TEP_DSP_000.API

3. Acessar Swagger
http://localhost:5000/swagger

🧪 Exemplos cURL
Criar palestra
curl -X POST http://localhost:5000/api/palestra \
-H "Content-Type: application/json" \
-d '{"titulo":"Intro .NET","descricao":"Desc","palestrante":"João","trail":1,"sessionTime":2}'

Listar
curl http://localhost:5000/api/palestra

Buscar por trilha + sessão
curl http://localhost:5000/api/palestra/trilha/1/sessao/2

Atualizar
curl -X PUT http://localhost:5000/api/palestra/10 \
-H "Content-Type: application/json" \
-d '{"idPalestra":10,"titulo":"Novo Título","descricao":"Atualizado","palestrante":"Ana","trail":2,"sessionTime":1}'

Excluir
curl -X DELETE "http://localhost:5000/api/palestra?id=10"

🧰 Tecnologias Utilizadas

ASP.NET Core 8

MediatR

CQRS

SQLite / SQL Server

Swagger UI

Repository Pattern
