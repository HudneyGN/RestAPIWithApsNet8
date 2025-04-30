<!DOCTYPE html>
<html lang="pt-BR">
<head>
  <meta charset="UTF-8">
  <title>RestAPIWithAspNet8</title>
</head>
<body>
  <h1>📚 RestAPIWithAspNet8</h1>
  <p>Este projeto é uma API RESTful desenvolvida com <strong>ASP.NET 8</strong>, utilizando <strong>MySQL</strong> como banco de dados e <strong>Evolve</strong> para controle de migrações. A aplicação realiza operações CRUD (Create, Read, Update, Delete) para as entidades <code>Person</code> e <code>Books</code>.</p>

  <hr>

  <h2>🔧 Tecnologias Utilizadas</h2>
  <ul>
    <li><a href="https://dotnet.microsoft.com/en-us/" target="_blank">.NET 8</a></li>
    <li><a href="https://learn.microsoft.com/aspnet/core" target="_blank">ASP.NET Core Web API</a></li>
    <li><a href="https://www.mysql.com/" target="_blank">MySQL</a></li>
    <li><a href="https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql" target="_blank">Pomelo.EntityFrameworkCore.MySql</a></li>
    <li><a href="https://github.com/leonardoporro/evolve" target="_blank">Evolve DB</a></li>
    <li><a href="https://serilog.net/" target="_blank">Serilog</a></li>
  </ul>

  <hr>

  <h2>🚀 Como Executar o Projeto</h2>

  <h3>Pré-requisitos</h3>
  <ul>
    <li>.NET SDK 8+</li>
    <li>MySQL Server 8+</li>
    <li>Visual Studio 2022 ou superior</li>
    <li>Git</li>
  </ul>

  <h3>1. Clone o repositório</h3>
  <pre><code>git clone https://github.com/seu-usuario/RestAPIWithAspNet8.git
cd RestAPIWithAspNet8</code></pre>

  <h3>2. Configure o <code>appsettings.json</code></h3>
  <pre><code>{
  "ConnectionStrings": {
    "MySqlConnection": "Server=localhost;Database=RestAPI;User=root;Password=suaSenha;"
  }
}</code></pre>

  <h3>3. Execute as migrações com o Evolve</h3>
  <p>As migrações estão localizadas em:</p>
  <pre><code>/db/dataset
/db/migrations</code></pre>
  <p>Ao iniciar o projeto, a função <code>MigrateDatabase()</code> será chamada para aplicar os scripts automaticamente.</p>

  <h3>4. Rode a aplicação</h3>
  <pre><code>dotnet run</code></pre>
  <p>A API estará disponível em <code>https://localhost:5001</code> (ou conforme configurado).</p>

  <hr>

  <h2>📂 Estrutura do Projeto</h2>
  <pre><code>
├── Business
│   ├── Implementations
│   └── Interfaces
├── Controllers
├── db
│   ├── dataset
│   └── migrations
├── Model
│   ├── Base
│   ├── Books.cs
│   └── Person.cs
├── Repository
│   ├── Generic
│   └── Implementations
├── Context
│   └── MySqlContext.cs
├── Program.cs
└── appsettings.json
  </code></pre>

  <hr>

  <h2>✅ Funcionalidades</h2>
  <ul>
    <li>✔️ CRUD para <code>Person</code></li>
    <li>✔️ CRUD para <code>Books</code></li>
    <li>✔️ Injeção de dependência configurada</li>
    <li>✔️ Validação de migrações com Evolve</li>
    <li>✔️ Boas práticas com SOLID e Clean Architecture</li>
  </ul>

  <hr>

  <h2>📬 Contato</h2>
  <p>Feito com ❤️ por <a href="https://github.com/hudneygn" target="_blank">Hudney Gomes Nunes</a></p>
  <ul>
    <li>LinkedIn: <a href="https://www.linkedin.com/in/hudneygomesnunes" target="_blank">/in/hudneygomesnunes</a></li>
    <li>GitHub: <a href="https://github.com/hudneygn" target="_blank">/hudneygn</a></li>
  </ul>
</body>
</html>
