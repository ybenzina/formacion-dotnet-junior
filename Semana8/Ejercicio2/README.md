# Ejercicio 2 — Docker y Docker Compose *(esbozo)*

**Martes 27 de octubre · unas 4 h**

## Objetivo

Empaquetar la API y la web en imágenes y levantar la aplicación completa con un solo comando.

## Antes de empezar

Repaso de [Docker: primeros pasos](https://docs.docker.com/get-started/) (Dockerfile y Docker Compose). Conceptos nuevos (añádelos al glosario): **Dockerfile**, **build multi-stage**, **red de Compose** y **variable de entorno**.

## Entregable

- `Dockerfile` *multi-stage* para la API y para la web.
- `docker-compose.yml` con SQL Server, API y web: red, variables de entorno, volumen y dependencias de arranque.
- Las migraciones se aplican de una forma que sepas explicar.
- La CI construye las imágenes en cada PR.
- Los security hotspots que marque SonarQube Cloud en los Dockerfile (por ejemplo, ejecutar como `root`) revisados o corregidos.

## Preguntas que tendrás que saber responder

- ¿Qué hace cada etapa del Dockerfile y por qué la imagen final no lleva el SDK?
- ¿Cómo encuentra la API a SQL Server dentro de Compose?

*Pasos, criterios de aceptación y recursos: pendientes de detallar.*
