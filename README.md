# Getting Started

# **Passo 1** - Configurando o banco de dados
  Dentro do projeto API *src\Services\NTTData.Sale.API* no arquivo appsettings.json será necessário informar uma connectionString para um banco local ou nuvem.

# **Passo 2** - Rodando os comandos de Migrations e UpdateDatabase
  - No visualStudio procure no menu *Tools* a opção *Nuget Package Manager* e dentro dela clique em *Package Manager Console*.
  - Na linha de comando que abrir, escolha a opção *src\Services\NTTData.Sale.Infra* no input de seleção chamado *Default project*.
  - Escreva o comando a seguir e pressione Enter para executar:
    Update-Database Initial
  - Se nenhum erro com a connectionString for encontrado, o seu banco de dados será atualizado com as tabelas da aplicação.

# **Passo 3** - Executar o projeto API

  - Execute o projeto NTTData.Sale.API e a UI do Swagger irá carregar com toda a documentação dos endpoints necessários para manipular os registros de venda.


# Observação do desenvolvedor

  - Forneci mais algumas validações além das exigidas na documentação do teste. Deixei de uma forma que a aplicação, pelas validações, calculasse o valor do desconto sem precisar fornecer no request.
  - Pensei em um padrão arquitetural mais próximo da de um Microserviço e, com o pouco tempo, tentei chegar o mais próximo do que eu queria. 

    
