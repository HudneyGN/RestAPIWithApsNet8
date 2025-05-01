<!DOCTYPE html>
<html lang="pt-BR">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>README - RestAPIWithApsNet8</title>
</head>
<body>
  <h1>📘 RestAPIWithApsNet8</h1>
  <p>Este projeto é uma API RESTful desenvolvida com <strong>ASP.NET Core 8</strong> que realiza operações CRUD em uma base de dados MySQL. O projeto segue boas práticas de arquitetura e design, como injeção de dependência, separação de responsabilidades, e a aplicação do padrão <strong>Value Object (VO)</strong>.</p>

  <h2>🚀 Tecnologias Utilizadas</h2>
  <ul>
    <li>ASP.NET Core 8</li>
    <li>C#</li>
    <li>MySQL</li>
    <li>Entity Framework Core</li>
    <li>Injeção de Dependência (DI)</li>
    <li>Padrão VO (Value Object)</li>
  </ul>

  <h2>📦 Estrutura do Projeto</h2>
  <ul>
    <li><strong>Controllers</strong> - Camada responsável por expor os endpoints da API</li>
    <li><strong>Business</strong> - Contém as regras de negócio (ex: BooksBusiness, PersonBusiness)</li>
    <li><strong>Repository</strong> - Responsável pela comunicação com o banco de dados</li>
    <li><strong>Data/VO</strong> - Implementa o padrão <strong>Value Object</strong> (ex: <code>PersonVO</code>, <code>BooksVO</code>)</li>
    <li><strong>Model</strong> - Define as entidades persistidas no banco de dados</li>
    <li><strong>db/migrations</strong> - Scripts para criação de tabelas</li>
    <li><strong>db/dataset</strong> - Scripts de população de dados</li>
  </ul>

  <h2>🧱 Padrão VO (Value Object)</h2>
  <p>Foi implementada a separação entre a entidade <code>Person</code> e o objeto de transferência <code>PersonVO</code>, promovendo um desacoplamento entre o modelo de dados e a interface da API.</p>

  <pre><code>// Exemplo de Value Object (PersonVO)
public class PersonVO {
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
}
  </code></pre>

  <h2>⚙️ Como Executar</h2>
  <ol>
    <li>Clone este repositório</li>
    <li>Configure sua connection string no <code>appsettings.json</code></li>
    <li>Execute os scripts SQL no diretório <code>db</code> para criar e popular o banco</li>
    <li>Rode a aplicação</li>
  </ol>

  <h2>📬 Endpoints</h2>
  <ul>
    <li><code>GET /api/person</code> - Lista todas as pessoas</li>
    <li><code>GET /api/person/{id}</code> - Busca uma pessoa por ID</li>
    <li><code>POST /api/person</code> - Cria uma nova pessoa</li>
    <li><code>PUT /api/person</code> - Atualiza uma pessoa</li>
    <li><code>DELETE /api/person/{id}</code> - Deleta uma pessoa</li>
  </ul>

  <h2>👨‍💻 Autor</h2>
  <p>Hudney Gomes Nunes - Desenvolvedor Back-End em evolução 🚀<br />
  <a href="https://github.com/seuusuario">GitHub</a> |
  <a href="https://www.linkedin.com/in/seulinkedin">LinkedIn</a></p>

  <h2>📝 Licença</h2>
  <p>Este projeto está licenciado sob a licença MIT.</p>
</body>
</html>
