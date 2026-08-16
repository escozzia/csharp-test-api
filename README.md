# API de Cotações

API REST pequena com CRUD simples para fins de estudo e testes práticos.

## Stack
- C# / .NET 8
- ASP.NET Core Minimal API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Executar localmente

```bash
dotnet restore
dotnet run
```

A API ficará disponível em `http://localhost:5000` (ou na porta indicada pelo .NET).

Swagger:
`/swagger`

## Endpoints

- `GET /api/cotacoes`
- `GET /api/cotacoes/{id}`
- `POST /api/cotacoes`
- `PUT /api/cotacoes/{id}`
- `DELETE /api/cotacoes/{id}`

Exemplo de POST:

```json
{
  "descricao": "Cotação de materiais",
  "fornecedor": "Fornecedor XPTO",
  "valor": 1250.50,
  "data": "2026-08-15"
}
```

## Docker

```bash
docker build -t api-cotacoes .
docker run -p 8080:8080 api-cotacoes
```

Swagger:
`http://localhost:8080/swagger`

## GitHub Actions

O workflow em `.github/workflows/ci.yml` restaura, compila e executa os testes automaticamente em push e pull request.
