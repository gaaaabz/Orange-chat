# Orange chat

## Definição do Projeto

O **Orange Route** é uma API desenvolvida para servir como backend de um aplicativo de guia de carreira na área da tecnologia. O projeto busca facilitar o acesso de profissionais e aspirantes a informações, recomendações e oportunidades de crescimento, conectando usuários a conteúdos, mentorias e networking voltados para desenvolvimento de carreira tech.

### Objetivo do Projeto

O objetivo principal é solucionar a falta de orientação estruturada para quem deseja ingressar ou evoluir na área tecnológica, oferecendo um sistema centralizado e automatizado para guiar o usuário por trilhas de carreira e sugerir conteúdos.

### Escopo

O escopo do Orange chat inclui:

- Serviço de cadastro e autenticação de usuários.
- Gestão de trilhas de carreira e recomendações personalizadas.
- Atividades e ferramentas orientadas para cada área.

#### Funcionalidades Principais

- Cadastro, login e gerenciamento de perfil do usuário.
- Criação e recomendação de trilhas de carreira personalizadas.
- Sugestão automática de conteúdos.

## Requisitos Funcionais e Não Funcionais

### Requisitos Funcionais

- Autenticação e autorização segura de usuários.
- Gerenciamento de trilhas de carreira.

### Requisitos Não Funcionais

- Escalabilidade: Suporte a múltiplos usuários simultâneos.
- Segurança: Proteção de dados e comunicação segura.
- Manutenibilidade: Código desacoplado e testável.

## Desenho da Arquitetura

O projeto adota **Clean Architecture**, promovendo separação de responsabilidades e facilitando evolução e manutenção do sistema.

### Camadas da Aplicação

#### 1. Apresentação

Responsável pela interface de comunicação (API REST) entre o cliente (aplicativo mobile/web) e o backend. Essa camada inclui controladores e endpoints, permitindo que as requisições sejam recebidas e direcionadas às camadas apropriadas.

**Justificativa:** Mantém o sistema desacoplado, facilitando a troca ou evolução do frontend sem impactar regras de negócio.

#### 2. Aplicação

Contém os serviços, casos de uso e regras que coordenam as operações de negócio. Nessa camada são definidos os fluxos para cadastro, autenticação, recomendação e chat.

**Justificativa:** Isola processos de negócio e facilita testes unitários, promovendo organização e clareza.

#### 3. Domínio

Reúne os modelos e entidades, além das regras de negócio mais puras e independentes de tecnologia. Tudo o que diz respeito ao conhecimento de carreira e evolução do usuário reside aqui.

**Justificativa:** Permite reutilização de modelos e lógica central, independente da tecnologia empregada na apresentação ou infraestrutura.

#### 4. Infraestrutura

Gerencia o acesso a dados, integração com outras APIs e serviços externos, persistência de informações e comunicação com bancos de dados e terceiros.

**Justificativa:** Facilita a substituição de tecnologias e adaptações a novas integrações, sem afetar regras de negócio ou fluxos principais.

---

## Estrutura de Pastas Sugerida

```
orange-chat/
├── src/
│   ├── presentation/      # Endpoints, controllers, DTOs
│   ├── application/       # Services, use-cases
│   ├── domain/            # Entities, models, business rules
│   └── infrastructure/    # Repositories, API integrations
└── README.md
```

## Conclusão

O Orange Route é uma solução moderna e escalável para quem quer iniciar ou evoluir na carreira de tecnologia, adotando práticas de Clean Architecture para garantir qualidade, organização e facilidade de manutenção. O projeto está aberto para contribuições e sugestões da comunidade!
