# 🌱 EcoTrack — Cidades ESG Inteligentes

O **EcoTrack** é uma aplicação desenvolvida com foco em iniciativas relacionadas aos princípios de **ESG (Environmental, Social and Governance)**, com o objetivo de apoiar ações de sustentabilidade por meio da tecnologia.

O projeto disponibiliza uma API para o gerenciamento de informações relacionadas a ações sustentáveis, usuários e dicas ESG. Além do desenvolvimento do backend, a atividade envolveu containerização com Docker, automação de testes e integração e entrega contínuas (CI/CD), com publicação da aplicação nos ambientes de staging e produção.

## 🎯 Objetivo do projeto

Desenvolver uma aplicação backend que permita gerenciar informações relacionadas à sustentabilidade, utilizando tecnologias modernas de desenvolvimento, banco de dados relacional, containerização e automação de processos.

## 🛠️ Tecnologias utilizadas

* **C#** — linguagem de programação.
* **ASP.NET Core 8** — desenvolvimento da API REST.
* **Oracle Database** — armazenamento dos dados.
* **Entity Framework Core** — acesso e gerenciamento dos dados no banco.
* **JWT** — autenticação baseada em tokens.
* **Swagger / OpenAPI** — documentação e testes dos endpoints.
* **Docker** — containerização da aplicação.
* **Docker Compose** — configuração e execução do ambiente Docker.
* **GitHub Actions** — automação do pipeline CI/CD.
* **Render** — publicação da aplicação nos ambientes de staging e produção.
* **xUnit e Moq** — ferramentas utilizadas nos testes automatizados.

## 🏗️ Arquitetura da aplicação

O projeto é composto por uma API desenvolvida em ASP.NET Core 8, responsável por disponibilizar os endpoints e processar as requisições da aplicação.

A API se comunica com o Oracle Database para acessar e persistir informações. O Swagger permite visualizar e testar os endpoints disponíveis, enquanto o Docker possibilita executar a aplicação em um ambiente containerizado.

O fluxo de entrega foi automatizado com GitHub Actions, integrando as etapas de compilação, testes e deploy.

## 📦 Funcionalidades

A API contempla recursos relacionados ao gerenciamento de informações e ações sustentáveis, incluindo:

* Gerenciamento de usuários.
* Gerenciamento de ações ESG.
* Consulta e gerenciamento de dicas de sustentabilidade.
* Acesso a informações relacionadas ao contexto climático.
* Autenticação baseada em JWT.
* Disponibilização de endpoints para integração com outras aplicações.

> Os recursos e endpoints disponíveis dependem da implementação atual do backend.

## 🐳 Containerização com Docker

A aplicação foi preparada para execução em containers utilizando Docker e Docker Compose.

Arquivos de configuração utilizados:

* `Dockerfile` — define as etapas de compilação e publicação da aplicação.
* `docker-compose.yml` — configura a execução do container.
* `.dockerignore` — define os arquivos que não devem ser enviados para o contexto de build.
* `.env.example` — apresenta um modelo das variáveis de ambiente necessárias.

O Dockerfile utiliza a estratégia **multi-stage build**, separando a compilação da etapa final de execução. O Oracle Database permanece externo ao container, sendo acessado por meio da connection string configurada no ambiente.

### Executar localmente

**Pré-requisitos:**

* Docker Desktop ou Docker Engine com Docker Compose.
* Acesso ao banco Oracle utilizado pelo projeto.
* Variáveis de ambiente configuradas conforme o arquivo de exemplo.

**1. Clone o repositório**

```bash
git clone <URL_DO_REPOSITORIO>
cd <PASTA_DO_PROJETO>
```

**2. Configure as variáveis de ambiente**

Consulte o arquivo `.env.example` e configure as variáveis necessárias no ambiente local. Utilize uma connection string válida para acessar o Oracle.

Não publique credenciais, tokens ou arquivos `.env` com informações sensíveis no repositório.

**3. Construa a imagem e inicie a aplicação**

```bash
docker compose up --build
```

**4. Verifique o container em execução**

```bash
docker compose ps
```

**5. Acesse o Swagger**

```text
http://localhost:8080/swagger
```

**6. Encerre a execução**

```bash
docker compose down
```

## 🔄 Pipeline CI/CD

O projeto utiliza **GitHub Actions** para automatizar a validação e a entrega da aplicação.

O workflow é executado em eventos de push para a branch `master` e em pull requests direcionados a essa branch.

### Etapas do pipeline

1. **Checkout:** obtém o código-fonte do repositório.
2. **Configuração do .NET 8:** prepara o ambiente de execução.
3. **Restore:** restaura as dependências do projeto.
4. **Build:** compila a aplicação em modo Release.
5. **Testes:** executa os testes automatizados.
6. **Deploy em staging:** solicita a publicação no ambiente de homologação.
7. **Deploy em produção:** solicita a publicação no ambiente de produção após o sucesso da etapa anterior.

Os deploys são realizados no Render por meio de Deploy Hooks configurados como secrets no GitHub Actions. Os ambientes `staging` e `production` são utilizados para organizar as etapas de entrega.

## 🌐 Ambientes publicados

### Staging

Ambiente de homologação utilizado para validar a aplicação antes da publicação em produção.

**URL:** https://ecotrack-staging-2t3y.onrender.com/dicas-esg

### Production

Ambiente destinado à versão publicada da aplicação.

**URL:** https://ecotrack-prod.onrender.com/dicas-esg

> Observação: a disponibilidade dos ambientes pode variar conforme o estado do serviço de hospedagem.

## 📸 Evidências do projeto

### Docker e containerização

Adicione aqui os prints da criação da imagem, execução do container e configuração do Docker Compose.

### Swagger e API

Adicione aqui os prints do Swagger e de uma requisição realizada com sucesso, incluindo o retorno `200 OK` do endpoint testado.

### Pipeline CI/CD

Adicione aqui o print do GitHub Actions mostrando a conclusão bem-sucedida das etapas de build, testes e deploy.

### Ambientes de staging e produção

Adicione aqui os prints da aplicação ou dos endpoints respondendo nos dois ambientes publicados.

## 📚 Aprendizados

O desenvolvimento deste projeto proporcionou a prática de conceitos de desenvolvimento backend com C# e ASP.NET Core, integração com banco de dados Oracle, configuração de ambientes por variáveis, containerização com Docker e automação de processos com GitHub Actions.

Também foram explorados o encadeamento de etapas de CI/CD, a configuração de ambientes de staging e produção e a integração entre as ferramentas utilizadas para disponibilizar a aplicação.

## 👥 Integrantes

* Fernando Souza Breviglieri
* Jessica Pereira da Silva
* Katharina Coutinho Uliani Santos
* Enzo Cortez Andreassa

---

**Projeto acadêmico desenvolvido na FIAP**
