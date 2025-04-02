# LeadManagementAPI - Teste Vaga Desenvolvedor FullStack

Este projeto é uma API REST desenvolvida em .NET 9.0 para gerenciamento de leads.

## Requisitos

- .NET 9.0 SDK
- SQL Server

## Configuração

1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-usuario/LeadManagementAPI.git
   cd LeadManagementAPI
   ```

2. Configure a conexão com o banco de dados no arquivo `appsettings.json`.

3. Importe o dump do banco de dados para o SQL Server `dump.sql`.

5. Restaure os pacotes e rode a aplicação:
   ```sh
   dotnet restore
   dotnet run
   ```

## Endpoints

### Obter todos os leads
```http
GET /api/leads
```
Retorna todos os leads com status "Invited".

### Obter leads convidados
```http
GET /api/leads/invited
```
Retorna todos os leads com status "Invited".

### Obter leads aceitos
```http
GET /api/leads/accepted
```
Retorna todos os leads com status "Accepted".

### Alterar status de um lead
```http
PUT /api/leads/{id}/change-status
```
**Parâmetros:**
- `id` (int): ID do lead.
- `NewStatus` (string): Novo status do lead (`Invited`, `Accepted`, `Denied`).

**Exemplo de corpo da requisição:**
```json
{
  "NewStatus": "Accepted"
}
```

## Tecnologias Utilizadas

- .NET 9.0
- Entity Framework Core
- SQL Server
- MailKit para envio de e-mails
