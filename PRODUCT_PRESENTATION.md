# Taskly

## Apresentação do produto

O **Taskly** é uma lista de tarefas simples, objetiva e visualmente organizada para ajudar pessoas a transformar intenção em ação. A primeira versão combina uma interface web leve com uma API .NET 8 para criar, consultar e organizar tarefas em um único espaço.

> Pequenos passos. Grandes resultados.

## O problema

Tarefas espalhadas, prioridades pouco claras e falta de visibilidade sobre os prazos tornam a rotina mais difícil do que deveria ser. O Taskly centraliza o que precisa ser feito e oferece uma visão rápida do andamento do dia.

## A solução

Com o Taskly, o usuário pode:

- Criar uma tarefa com título, descrição e prazo.
- Visualizar todas as tarefas em uma lista organizada.
- Filtrar tarefas pendentes e concluídas.
- Buscar por título ou descrição.
- Acompanhar indicadores de total, andamento, conclusão e próximos prazos.
- Receber feedback visual durante carregamento, criação e falhas de conexão.

## Para quem é

- Pessoas que querem organizar compromissos e atividades pessoais.
- Estudantes acompanhando estudos e entregas.
- Profissionais que precisam de uma visão rápida das próximas ações.
- Pequenas equipes que desejam validar um fluxo simples de tarefas antes de adotar uma solução maior.

## Experiência do produto

A interface foi desenhada para reduzir distrações e destacar a próxima ação:

- **Dashboard principal** com resumo da produtividade.
- **Sidebar de navegação** para acesso rápido às áreas do workspace.
- **Formulário de nova tarefa** sempre disponível.
- **Lista com busca e filtros** para localizar tarefas rapidamente.
- **Design responsivo** para desktop e telas menores.
- **Estados de interface** para carregamento, lista vazia, sucesso e erro.

## Primeira versão funcional

### Criar tarefa

O usuário informa:

- Título obrigatório, entre 1 e 100 caracteres.
- Descrição opcional, com até 500 caracteres.
- Prazo opcional, que não pode estar no passado.

Uma nova tarefa é criada com o status **Pending** e recebe identificador e data de criação automaticamente.

### Listar tarefas

A lista exibe as tarefas não excluídas, ordenadas das mais recentes para as mais antigas. Cada item apresenta título, descrição, status e prazo.

### Status e evolução

A interface já apresenta os status de tarefa previstos pelo domínio. A primeira entrega contempla criação e listagem; os fluxos de conclusão e exclusão estão preparados na regra de negócio para uma próxima versão da API.

## Arquitetura da solução

```text
Frontend React/Vite
		│
		│ HTTP + JSON
		▼
API ASP.NET Core/.NET 8
		│
		▼
Repositório em memória
```

### Tecnologias

- React 19
- Vite 8
- JavaScript
- CSS responsivo
- ASP.NET Core/.NET 8
- C#
- Swagger/OpenAPI
- Repositório em memória

## Benefícios

- **Foco**: reduz a tarefa ao próximo passo claro.
- **Simplicidade**: não exige configuração complexa para começar.
- **Visibilidade**: indicadores mostram o estado atual da lista.
- **Extensibilidade**: a API está separada em domínio, aplicação, infraestrutura e apresentação.
- **Baixo atrito**: criação rápida e busca integrada na mesma tela.

## Demonstração local

Inicie a API:

```powershell
dotnet run --project .\provaOsnildo\provaOsnildo\provaOsnildo.csproj
```

Em outro terminal, inicie o frontend:

```powershell
cd .\projeto-html\meu-primeiro-react
npm run dev
```

Abra no navegador:

```text
http://localhost:5173/
```

## Roadmap sugerido

1. Implementar conclusão de tarefas pela interface.
2. Implementar exclusão com confirmação.
3. Adicionar edição de tarefas.
4. Persistir dados em banco de dados.
5. Adicionar autenticação e workspaces por usuário.
6. Adicionar categorias, prioridades e etiquetas.
7. Incluir notificações para prazos próximos.
8. Adicionar testes automatizados de frontend e integração.

## Estado atual

O Taskly está pronto para demonstração local da primeira versão de criação e listagem de tarefas. Como o armazenamento atual é em memória, os dados são perdidos quando a API é reiniciada.
docs/PRODUCT_PRESENTATION.pptx