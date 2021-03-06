# DesafioJuros
Desafio .Net Core

## Docker

> Windows 10 pro  
> [Docker 20.10.2](https://docs.docker.com/docker-for-windows/install/#what-to-know-before-you-install) (_Windows 10 Home?_ [_use esse link_](https://docs.docker.com/docker-for-windows/install-windows-home/)).  
> [WSL 2](https://docs.microsoft.com/en-us/windows/wsl/install-win10)

- abra o console _(no exemplo uso powershell)_ e navega até a pasta onde o projeto foi clonado;
- entre com os comandos abaixo:
  ``` powershell
  docker build -t api2 .  
  # entre na pasta Api1
  cd Api1 # o mesmo que "sl Api1"
  docker build -t api1 .  
  docker run -d -p 8001:80 --name henryk_Api1 api1  
  docker run -d -p 8002:80 --name henryk_Api2 api2  
  ```
  
> **OBS:** É preciso que os dois containers se comunique  _\(Api2 consome a Api1\)_. Veja uma forma fazer isso logo abaixo.  
> A outra opção é usando [user defined network](https://docs.docker.com/network/bridge/) _(Dependendo das permissões de sua conta e rede isso pode não funcionar_).
  
Para que os dois containers se comunique, uma das formas, é descobrir seus IPs dentro da rede que eles estão conectados:
``` powershell
# lista todas as conexões criadas pelo Docker  
docker network ls  
# Verifique os IPs dos containers  
docker network inspect [NETWORK ID]  
```  
  
No projeto Api2 no arquivo `appsettings.json` no node "urls"."Api1", substitua o valor pelo endereço IP do container da Api1.  
- **Exp.:** http://localhost:8001 -> http://172.17.0.2

:warning: **Se já havia montado a imagem e o container da Api2. Delete o container e monte a imagem novamente.**

# Seleção de pessoa Desenvolvedora .Net Core

## A demanda
Você deverá criar duas API's uma com dois endpoints e outra com um endpoint:

## API 1

### :satellite: Retorna taxa de juros

Responde pelo path relativo `/taxaJuros` Retorna o juros de 1% ou 0,01 (fixo no código) Exemplo: /taxaJuros Resultado esperado: 0,01  

## API 2

### :satellite: Calcula Juros

Responde pelo path relativo `/calculajuros`  
  
Ela faz um cálculo em memória, de juros compostos, conforme abaixo:  

> Valor Final = Valor Inicial * (1 + juros) ^ Tempo  
  
- **Valor inicial** é um decimal recebido como parâmetro;
- **Valor do Juros** deve ser consultado na **API 1**;
- **Tempo** é um inteiro que representa os meses. Também recebido como parâmetro.   
  
> :information_source: `^` _representa a operação de potência._  
  
Resultado final deve ser truncado (sem arredondamento) em duas casas decimais.  
  
**Exemplo:** `/calculajuros?valorinicial=100&meses=5`  
**Resultado esperado:** `105,10`

### :satellite: Show me the code

Este responde pelo path relativo `/showmethecode`. Deverá retornar a url do repositório deste projeto (obrigatoriamente no github).

## Resultado Esperado

1.	Código fonte em [asp.net core][aspnetcore] no github (Mostrar conhecimento básico de git)
2.	Teste unitários (Mostrar conhecimento de testes unitários, se possível TDD)

Extras
1.	Utilização de Docker
2.	Teste de integração da API em linguagem de sua preferência (Damos importância para pirâmide de testes)
3.	Utilizar swagger

> **Prazo e retorno** :warning:  
> Isso será combinado com quem você fez a entrevista. Você terá tempo para entender o cenário e nos retornar um prazo.  
> Lembre-se: Prazo dado é prazo cumprido.  

Boa sorte!

[aspnetcore]: https://en.wikipedia.org/wiki/.NET_Core
