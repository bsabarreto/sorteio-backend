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
    
![image](https://user-images.githubusercontent.com/122547975/212552733-c2b3cc72-dca9-4354-800c-5a1c50e6e43e.png)


Rodando os testes implementados

Para rodar os testes do backend, entrar no projeto Test, entrar em uma das classes de teste. Pode rodas os testes clicando com o botão direito do mouse e clicando em "Run Tests".


![image](https://user-images.githubusercontent.com/122547975/212564278-d17a2856-cb2a-475d-99b5-48aa3ad7b513.png)


Assim, os testes são executados.

![image](https://user-images.githubusercontent.com/122547975/212552666-e572c95c-a3a4-4cb5-bcb2-690a68c69887.png)

    

