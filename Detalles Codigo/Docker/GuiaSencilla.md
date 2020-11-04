# Docker
´´´

´´´
## Introduccion
## Creacion de imagenes
Para la creacion de imagenes, el comando tiene esta estructura:
´´´
docker -f [archivo_dockerfile] -t [nombre_imagen_docker] [conexto_donde_crear_imagen]
´´´
El contexto donde docker va crear la imagen es donde debe estar todo lo que va a necesitar para
crear dicha imagen. Siempre poner el Dockerfile donde va a utilizar arcivos externos.

Ejemplo de aplicación Hello (ejecutar el comando donde esta la aplicacion -> /Hello):
´´´
docker -f Dockerfile -t hello-app .
´´´
## Construccion de contenedores
## Docker compose