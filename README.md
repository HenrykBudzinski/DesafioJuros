# DesafioJuros
Desafio .Net Core

## Docker
``` powershell
docker build -t api2 .  
cd Api1  
docker build -t api1 .  
docker run -d -p 8001:80 --name henryk_Api1 api1  
docker run -d -p 8002:80 --name henryk_Api2 api2  
```

# Seleção de pessoa Desenvolvedora .Net Core

## A demanda
Você deverá criar duas API's uma com dois endpoints e outra com um endpoint:

## API 1

### Retorna taxa de juros

Responde pelo path relativo `/taxaJuros` Retorna o juros de 1% ou 0,01 (fixo no código) Exemplo: /taxaJuros Resultado esperado: 0,01  

## API 2

### Calcula Juros

Responde pelo path relativo `/calculajuros`  
  
Ela faz um cálculo em memória, de juros compostos, conforme abaixo:  

> Valor Final = Valor Inicial * (1 + juros) ^ Tempo  
  
- **Valor inicial** é um decimal recebido como parâmetro;
- **Valor do Juros** deve ser consultado na **API 1**;
- **Tempo** é um inteiro que representa os meses. Também recebido como parâmetro.   
  
> `^` _representa a operação de potência._  
  
Resultado final deve ser truncado (sem arredondamento) em duas casas decimais.  
  
**Exemplo:** `/calculajuros?valorinicial=100&meses=5`  
**Resultado esperado:** `105,10`

### Show me the code

Este responde pelo path relativo `/showmethecode`. Deverá retornar a url do repositório deste projeto (obrigatoriamente no github).

Esperamos que a entrega tenha:

1.	Código fonte em [asp.net core][aspnetcore] no github (Mostrar conhecimento básico de git)
2.	Teste unitários (Mostrar conhecimento de testes unitários, se possível TDD)

Extras
1.	Utilização de Docker
2.	Teste de integração da API em linguagem de sua preferência (Damos importância para pirâmide de testes)
3.	Utilizar swagger

> [!NOTE] 
> **Prazo e retorno**  
> Isso será combinado com quem você fez a entrevista. Você terá tempo para entender o cenário e nos retornar um prazo.  
> Lembre-se: Prazo dado é prazo cumprido.  

Boa sorte!

[aspnetcore]: https://en.wikipedia.org/wiki/.NET_Core
