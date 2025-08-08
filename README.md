# 🧖‍♀️ Spa API

API desenvolvida em ASP.NET Core (.NET 8) para gerenciamento de clientes e serviços prestados por um centro de estética ou spa. A aplicação possui regras de negócio específicas para controle de sessões, valores e cálculo automático de preço dos serviços.

---

## 📌 Funcionalidades

- CRUD completo para **Clientes**
- CRUD completo para **Serviços Prestados**
- Cálculo automático do valor total com base no número de sessões
- Uso de **AutoMapper** para mapeamento entre entidades e DTOs
- Autenticação básica com **JWT Bearer Token**
- Estrutura em **camadas** seguindo boas práticas (Controller, Service, Mappings, DTO, Maps)
- Integração futura com envio de mensagens (ex: Twilio ou SMS/WhatsApp)

---

## 🧠 Regras de Negócio

- Cada serviço possui um **valor unitário por sessão**
- O cliente informa a **quantidade de sessões** no momento do agendamento
- O sistema calcula automaticamente o **valor total = valorSessao * quantidade**
- Serviços podem ser alterados apenas enquanto ainda não estiverem pagos
- Um cliente pode possuir múltiplos serviços associados

---

## 📁 Estrutura do Projeto

```
SpaAPI/
│
├── Controllers/
│   └── ClienteController.cs
│   └── ServicoController.cs
│
├── Services/
│   └── ClienteService.cs
│   └── ServicoService.cs
│
├── Repositories/
│   └── ClienteRepository.cs
│   └── ServicoRepository.cs
│
├── DTOs/
│   └── ClienteDTO.cs
│   └── ServicoDTO.cs
│
├── Models/
│   └── Cliente.cs
│   └── Servico.cs
│
├── Profiles/
│   └── AutoMapperProfile.cs
│
├── Data/
│   └── SpaDbContext.cs
│
├── Program.cs
└── appsettings.json
```

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- AutoMapper
- SQL Server
- JWT Bearer (Autenticação)
- Swagger (para testes)



---

## 🚧 Melhorias Futuras

- Autenticação de usuários com perfis (Admin, Cliente)
- Envio de lembretes via WhatsApp/SMS (Twilio)
- Integração com sistema de pagamentos
- Logs de acesso e auditoria

---

## 📬 Contato

Desenvolvido por [Caio Nery]  
📧 caionery40@gmail.com  
🔗 [LinkedIn](https://www.linkedin.com/in/caio-nery-csharp)
