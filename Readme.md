# Operacion Fuego de Quasar


Implementacion de challenge para prueba tecnica MeLi.

## Caracteristicas

### Solucion

Se implementa metodo de Trilateracion para generar solucion de la localizacion del punto (x,y) de la nave emisora del mensaje.

### Implementacion

Se realiza implementacion en lenguaje C# haciendo uso de .NET 5.0 y EF 5, con un patron arquitectonico de n-capas, tambien se genera uso de las siguientes caracteristicas:

- Migracion automatica basada en el cambio de modelo hacia RDBMS
- Insercion automatica de datos base de funcionamiento de aplicacion
- Patron de repositorio y servicios genericos para implementacion de otros componentes de manera mas agil
- Inyeccion de dependencias automaticas
- Pruebas automaticas por framework MSTest
- Endpoint para pruebas por OpenApi

## Despliege y ejecucion

```Para poder realizar la ejecucion de manera local debera contarse con Docker y docker-compose instalado en la maquina.```

Para poder ejecutar el set de pruebas  ejecutar en la consola: ```docker-compose -f docker-compose-tests.yml up --build```

Para ejecutar el ambiente de pruebas ejecutar: ```docker-compose up --build```, este comando desplegara el ambiente la url [http://localhost:9000](http://localhost:9000) y open api en [http://localhost:9000/swagger](http://localhost:9000/swagger).

La version online se encuentra disponible en [http://35.226.115.206:24639](http://35.226.115.206:24639) y open api en [http://35.226.115.206:24639/swagger](http://35.226.115.206:24639/swagger).
