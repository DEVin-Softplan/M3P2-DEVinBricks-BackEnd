<h1 align="center">
</h1>

<h1 align="center">
   <p>DEVinBricks - API RESTful de Vendas de Mateirais de Construção</p>
</h1>

<h4 align="center"> 
	🚧  Projeto em desenvolvimento 🚧
</h4>

<br>

<p align="center">
 <a href="#-sobre-o-projeto">Sobre</a> •
 <a href="#-como-executar-o-projeto">Como executar</a> • 
 <a href="#-tecnologias">Tecnologias</a> • 
 <a href="#-contribuidores">Contribuidores</a> • 
 <a href="#-autores">Autores</a> •  
</p>
<br>

## 💻 Sobre o projeto

O projeto trata-se de uma API desenvolvida em .NET Core 6 com Entity Framework, que segue o padrão RESTful, para um sistema de vendas de materiais de construção.

<br>

## 🚀 Como executar o projeto

Este projeto é uma aplicação web em Backend.

### Pré-requisitos

Para rodar o projeto em sua máquina, você vai precisar ter instalado as seguintes ferramentas:
[Git](https://git-scm.com) e [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
Além disto é importante ter um editor para trabalhar com o código, como [VisualStudio](https://visualstudio.microsoft.com/) e um sistema gerenciador de Banco de dados relacional, como o [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).

#### 🎲 Rodando a Aplicação

<ol start="1">
<li>No repositório do GitHub, clone o projeto 👇</li>

```bash
# Clone este repositório
$ git clone -b develop https://github.com/DEVin-Softplan/M3P2-DEVinBricks-BackEnd.git
```

<li>Abra o projeto no VisualStudio, clicando 2x no arquivo <b style="color:#7b9eeb">DevInBricks.sln</b></li>
<br>
<li>Vá para o arquivo <b style="color:#7b9eeb">appsettings.Development.json</b> e adicione a ConnectionString, seguindo o modelo abaixo 👇<br>

```bash
"ConnectionStrings": {
  "Server=YOURSERVER\\SQLEXPRESS;Database=DEVinBricks;Trusted_Connection=True;"
  }
```

</li>

<li>Instale as seguintes dependências, via NuGet:</li>
<ul>
<li>Microsoft.EntityFrameworkCore</li>
<li>Microsoft.EntityFrameworkCore.Tools</li>
<li>Microsoft.EntityFrameworkCore.Design</li>
<li>Microsoft.EntityFrameworkCore.SqlServer</li>
<li>Swashbuckle.AspNetCore</li>
<li>coverlet.collector</li>
<li>FluentValidation</li>
<li>Microsoft.AspNetCore.Authentication.JwtBearer</li>
<li>Microsoft.AspNetCore.Mvc.NewtonsoftJson</li>
<li>Microsoft.AspNetCore.Mvc.Testing</li>
<li>Microsoft.EntityFrameworkCore.InMemory</li>
<li>Microsoft.NET.Test.Sdk</li>
<li>Moq</li>
<li>Newtonsoft.Json</li>
<li>NUnit</li>
<li>NUnit3TestAdapter</li>
<li>RabbitMQ.Client</li>
</ul><br>

<li>Com os pacotes instalados, abra o console do gerenciador de pacotes e digite o comando abaixo 👇</li>

```bash
Update-Database
```

<li>Com esses passos executados, você já pode executar a aplicação, com o <b style="color:#7b9eeb">F5</b>, que abrirá a aplicação no Swagger.</li>
</ol><br>

## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

<div style="display: inline_block" align="center">

<img align="center" alt="C#" height="80" width="100" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">
<img align="center" alt="dotNetCore" height="75" width="100"  src="https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg">

</div><br>

## 👨‍💻 Contribuidores

💜 Muito obrigada para essa turma incrível que fez esse projeto tomar forma e sair do papel 👏

<b style="color:#7b9eeb">Squad 01 - DotinhoDaNet</b>

<table>
   <tr>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/lacijr" width="100px;" alt="avatar Laci"/><br />
         <sub><b>Laci Leal</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/86383785?v=4" width="100px;" alt="avatar Emanuel"/><br />
         <sub><b>Emanuel Lopes</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/93409627?v=4" width="100px;" alt="avatar Gabriel Cordeiro Pereira"/><br />
         <sub><b>Gabriel Pereira</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/93232919?v=4" width="100px;" alt="avatar Narriman Desiree de Cássia da Silva Lima"/><br />
         <sub><b>Narriman Lima</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/93687924?v=4" width="100px;" alt="avatar Romulo Ladeira"/><br />
         <sub><b>Romulo Ladeira</b></sub>
         <br/>
      </td>
   </tr>
</table>

<b style="color:#7b9eeb">Squad 02 - IPAAPI</b>

<table>
   <tr>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/VeroniJrStudant" width="100px;" alt="avatar Veroni"/><br />
         <sub><b>Veroni Júnior</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/73497963?v=4" width="100px;" alt="avatar Ramon Telles"/><br />
         <sub><b>Ramon Telles</b></sub>
         <br/>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/Rschwedersky" width="100px;" alt="avatar Rodrigo"/><br />
         <sub><b>Rodrigo Schwedersky</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/Victor-Higa1997" width="100px;" alt="avatar Victor"/><br />
         <sub><b>Victor Higa</b></sub>
         <br/>
            <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/viniHiagoRosa" width="100px;" alt="avatar Vinicius R"/><br />
         <sub><b>Vinicius Rosa</b></sub>
         <br/>
      </td>
   </tr>
</table>

<b style="color:#7b9eeb">Squad 03 - CTHOR</b>

<table>
   <tr>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/GuiVeigaSesiSenai" width="100px;" alt="avatar Guilherme"/><br />
         <sub><b>Guilherme Veiga</b></sub>
         <br/>
      </td>
            <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/camila-kunitz" width="100px;" alt="avatar Camila"/><br />
         <sub><b>Camila Kunitz</b></sub>
         <br/>
      </td>
            <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/zighue1" width="100px;" alt="avatar Federico"/><br />
         <sub><b>Federico Zighue</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/ViniiSouza" width="100px;" alt="avatar Vinicius S"/><br />
         <sub><b>Vinicius Souza</b></sub>
         <br/>
      </td>
   </tr>
</table>

<b style="color:#7b9eeb">Squad 04 - ROMEU</b>

<table>
   <tr>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/douglas-devinhouse" width="100px;" alt="avatar Douglas"/><br />
         <sub><b>Douglas Nascimento</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/ernanipozza" width="100px;" alt="avatar Ernani"/><br />
         <sub><b>Ernani Pozza</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/janinelps" width="100px;" alt="avatar Janine"/><br />
         <sub><b>Janine Santos</b></sub>
         <br/>
      </td>
      <td align="center">
         <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/werikorus" width="100px;" alt="avatar Werik"/><br />
         <sub><b>Werik Santos</b></sub>
         <br/>
      </td>
   </tr>
</table>

<br>

## 🦸 Autores

<table>
   <tr>
      <td align="center">
         <img src="./Img/DotinhoDaNet.gif" width="100px;" alt="logo squad dotinho"/>
         <br/>
         <sub><b>DotinhoDaNet</b></sub>
      </td>
      <td align="center">
         <img src="./Img/IPAAPI.gif" width="100px;" alt="logo squad IPAAPI"/>
         <br/>
         <sub><b>IPAAPI</b></sub>
      </td>
      <td align="center">
         <img src="./Img/CTHOR.png" width="100px;" alt="logo squad CTHOR"/>
         <br/>
         <sub><b>CTHOR</b></sub>
      </td>
      <td align="center">
         <img src="./Img/ROMEU.jpg" width="100px;" alt="logo squad ROMEU"/>
         <br/>
         <sub><b>ROMEU</b></sub>
      </td>
   </tr>
</table>
