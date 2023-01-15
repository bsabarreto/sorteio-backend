Implementação do backend foi feito com .NET Core 3.1.

Estrutura do Backend

![image](https://user-images.githubusercontent.com/122547975/212552243-790bd121-1638-47dd-99a5-47290705d6ca.png)

Utilizado para desenvolver o sistema o Desing DDD.

    API: Controllers que são chamadas pelo front.
    Business: Camada onde foi implementado as regras de negócio do sorteio
    CrossCuting: Utilizado para criarmos injeção de dependência no projeto.
    Domain: Criação de Interfaces, Entities, Enums.
    Repository: Responsavél por acessar o sistema de dados.
    Test: Implementação de testes da aplicação.
    
    
    Implementado o swagger para ficar mais fácil de testarmos a API.
    
    ![image](https://user-images.githubusercontent.com/122547975/212552476-8e5dab44-f071-4e79-8d21-980d9ab395c8.png)


Rodando os testes implementados

![image](https://user-images.githubusercontent.com/122547975/212552666-e572c95c-a3a4-4cb5-bcb2-690a68c69887.png)

    

