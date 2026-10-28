# Ejercicio 4 — Docker y Docker Compose

**Día 15 · estimación: 4 h** · Issue: «P2 · Ej4 · Docker y Docker Compose»

## Objetivo

Empaquetar la API y la web en imágenes y levantar la aplicación completa con un solo comando. Es la base del despliegue en Azure de la Parte III.

## Antes de empezar (≈ 30 min)

Repaso de [Docker: primeros pasos](https://docs.docker.com/get-started/) (Dockerfile y Docker Compose). Conceptos nuevos (añádelos al glosario): **Dockerfile**, **build multi-stage**, **red de Compose**, **variable de entorno** y **healthcheck**.

## Pasos

Rama `chore/docker`.

1. `Dockerfile` *multi-stage* para la API y para la web. La imagen final lleva solo el *runtime*, no el SDK, y no se ejecuta como `root`.
2. `docker-compose.yml` con SQL Server, API y web: red, variables de entorno, volumen para los datos y orden de arranque (la API espera a que SQL Server esté listo).
3. Secretos fuera del repositorio: contraseña de `sa` y claves en un `.env` que está en `.gitignore`, con un `.env.example` sin valores reales.
4. Las migraciones se aplican de una forma que sepas explicar (al arrancar la API en desarrollo, un contenedor aparte o un paso manual). Anota la elección y su riesgo en producción.
5. La CI construye las dos imágenes en cada PR.

## Criterios de aceptación

- [ ] `docker compose up` desde un clon limpio deja la web funcionando, con login.
- [ ] Imágenes sin SDK y sin ejecutarse como `root`.
- [ ] Ningún secreto en el repositorio; `.env.example` documentado en el README.
- [ ] La CI construye las imágenes.
- [ ] Los security hotspots que marque SonarQube Cloud en los Dockerfile, revisados o corregidos.

## Extra

- Un `healthcheck` en la API y que la web espere a que esté sana.
- Etiquetar las imágenes con el commit en la CI.

## Preguntas para la demo

- ¿Qué hace cada etapa del Dockerfile y por qué la imagen final no lleva el SDK?
- ¿Cómo encuentra la API a SQL Server dentro de Compose? ¿Y la web a la API?
- ¿Dónde están las contraseñas cuando arrancas con Compose, y por qué no en el `docker-compose.yml`?
- ¿Qué riesgo tiene aplicar las migraciones al arrancar la API si hubiera dos copias arrancando a la vez?

## Comparación con IA

Pide a la IA los Dockerfile y el `docker-compose.yml` y compáralos con los tuyos: usuario, tamaño de imagen, secretos y orden de arranque.

## Recursos

- [Imágenes de contenedor para .NET](https://learn.microsoft.com/es-es/dotnet/core/docker/introduction)
- [Docker Compose](https://docs.docker.com/compose/)
- `docs/masterclasses/masterclass-docker.md` de este repo.
