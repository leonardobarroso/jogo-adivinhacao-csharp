# Jogo de adivinhação em C#

Exercício de console desenvolvido durante meus estudos de C# na Alura.
O objetivo é praticar variáveis, funções, condicionais, repetição e leitura de dados.

## Como jogar

O programa sorteia um número entre **1 e 100**, inclusive. Digite um palpite e
receba uma dica: o número secreto é maior ou menor. Ao acertar, o jogo informa
quantas tentativas válidas foram necessárias e pergunta se você deseja jogar novamente.
Digite `s` para iniciar outra partida ou `n` para sair.

Entradas que não são números inteiros entre 1 e 100 não contam como tentativas.
Na pergunta de reinício, maiúsculas e espaços ao redor da resposta são aceitos.

## Como executar

Requisito: [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0).
Abra um terminal na pasta que contém `JogoAdivinhacao.csproj` e execute:

```powershell
dotnet run
```

Para conferir se o projeto compila:

```powershell
dotnet build
```

## Arquivos do projeto

- `Program.cs`: código do jogo, adaptado do arquivo original `Exercicio1.cs`.
- `JogoAdivinhacao.csproj`: define o aplicativo de console e a versão do .NET.
- `.gitignore`: exclui arquivos gerados e configurações locais do controle de versão.
- `README.md`: apresentação e instruções do projeto.

O arquivo `.csproj` transforma o código em um projeto que pode ser compilado e
executado com `dotnet`. Não é necessário um arquivo de solução para este exercício.

## Correções feitas antes da publicação

- Removida a impressão do número secreto, que revelava a resposta.
- Adicionado `break` ao `case "s"` do `switch`. Em C#, deixar um `case` com
  instruções continuar para o próximo causa o erro de compilação `CS0163`.
- Validados os palpites entre 1 e 100 antes de contar uma tentativa.
- Tratado o fim da entrada para evitar repetição infinita quando não há mais dados.
- Mantidos os conceitos de funções, `if`/`else`, `while` e `switch` do exercício.

## Como enviar para o GitHub

Git guarda o histórico no computador; GitHub hospeda uma cópia desse histórico.
Os passos abaixo devem ser executados nesta pasta. Antes, confira `git status` e
`git remote -v` para identificar qualquer configuração já existente.

Se ainda não houver repositório local:

```powershell
git init -b main
```

Se o autor ainda não estiver configurado, use seu nome e seu e-mail do GitHub
(ou o endereço privado `noreply` disponível nas configurações de e-mail da conta):

```powershell
git config user.name "SEU NOME"
git config user.email "SEU EMAIL"
```

Esses comandos configuram somente este repositório. Não publique os textos de
exemplo como se fossem seus dados reais.

Prepare os arquivos e registre a primeira versão, caso ainda não exista commit:

```powershell
git add Program.cs JogoAdivinhacao.csproj README.md .gitignore
git diff --cached
git commit -m "Adiciona jogo de adivinhacao em C#"
```

`add` seleciona os arquivos; `diff --cached` mostra o que será registrado;
`commit` cria um ponto no histórico local.

No [GitHub](https://github.com/new), crie um repositório chamado
`jogo-adivinhacao-csharp`, escolhendo se será público ou privado. Para receber
este projeto local, deixe as opções de criar README, `.gitignore` e licença
desmarcadas. Se esse nome já existir, confira o conteúdo antes de usá-lo.

Copie a URL HTTPS do repositório criado e substitua `SEU_USUARIO` abaixo:

```powershell
git remote -v
git remote add origin https://github.com/SEU_USUARIO/jogo-adivinhacao-csharp.git
git push -u origin main
```

Adicione `origin` somente se ele ainda não existir. Se existir, confira a URL antes
de continuar. Se o repositório remoto já tiver arquivos ou se o envio for recusado,
interrompa e confira o histórico; não use `--force`.

`remote add` conecta o projeto ao endereço do GitHub. `push` envia os commits.
Conclua a autenticação pelo fluxo oferecido pelo Git/GitHub; não use a senha da
conta como senha do Git nem coloque tokens em arquivos ou na URL do repositório.

Após o envio, confira os arquivos no site e execute:

```powershell
git status
git ls-remote origin refs/heads/main
git rev-parse HEAD
```

O identificador retornado para `main` deve ser igual ao commit local (`HEAD`).
