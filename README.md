# BinaryLab.CopaFilmes.Api
Microserviço para disputa entre filmes de viersos gêneros.

Este projeto conta com algumas das melhores práticas à serem seguidas no desenvolvimento de software.
  - Testes Unitários
  - Utilização de padrões
    - SOLID
    - Resiliência
    - Retentativas
    - Fábrica

### Em Breve
  - Testes de Integração

### Docker
É possível encontrar a imagem da aplicação no [docker hub](https://hub.docker.com/r/thiagocarreno/binarylab_copafilmes-filme) e seguir os passos abaixo para roda-lá.
```sh
docker pull thiagocarreno/binarylab_copafilmes-filme
```
```sh
docker run -p 127.0.0.1:80:80 --name copafilmes-filme -d thiagocarreno/binarylab_copafilmes-filme
```
Acesse a [url](http://127.0.0.1:80/swagger) para testar.