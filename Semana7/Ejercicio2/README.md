# Ejercicio 2 — EF Core y SQL Server en Docker

**Martes 20 de octubre · unas 4 h** · Issue: «S7 · Ej2 · EF Core y SQL Server en Docker»

## Objetivo

Persistir el dominio en SQL Server con EF Core, usando una base de datos que se ejecuta en un contenedor Docker en tu máquina.

## Antes de empezar

- Docker Desktop instalado y funcionando (`docker version`).
- Herramienta de EF Core: `dotnet tool install --global dotnet-ef`.

## Pasos

Rama `feature/persistencia`.

### 1. SQL Server en Docker (≈ 45 min)

- Arranca un contenedor con la imagen oficial `mcr.microsoft.com/mssql/server:2022-latest`. Necesitarás aceptar la licencia, darle una contraseña de `sa`, publicar el puerto 1433 y usar un **volumen** para no perder los datos.
- Conéctate con la extensión **SQL Server (mssql)** de VS Code o con SSMS y comprueba que responde.
- Apunta en el README del repo el comando que has usado, **sin la contraseña**.

Prueba: para el contenedor, bórralo y vuelve a crearlo con el mismo volumen. ¿Siguen ahí tus datos?

### 2. Infrastructure y DbContext (≈ 1 h 30 min)

- Proyecto `src/DeemSoft.CourtConnect.Infrastructure` con los paquetes de EF Core para SQL Server.
- Proyecto `src/DeemSoft.CourtConnect.Api` (plantilla `webapi`, todavía vacía) que registra el `DbContext`. Lo usarás como proyecto de arranque de las migraciones; los endpoints llegan mañana.
- `CourtConnectDbContext` con la configuración de cada entidad en una clase `IEntityTypeConfiguration<T>` (no en atributos del dominio): claves, longitudes máximas, precisión del precio, relaciones e índices (por ejemplo, el que evita dos inscripciones activas del mismo jugador en el mismo campus).
- Cadena de conexión con **`dotnet user-secrets`** en el proyecto Api. Nunca en `appsettings.json`.

### 3. Migración y datos de prueba (≈ 1 h 15 min)

- Crea la migración inicial y aplícala. Abre el fichero de la migración y entiende qué hace.
- Genera el script SQL de la migración (`dotnet ef migrations script`) y compáralo con `docs/court-connect/data-model/init.sql`: ¿qué hace EF que el script a mano no hacía, y al revés?
- Añade datos de prueba ficticios: al menos 3 campus (uno lleno, uno cerrado) y 5 jugadores de varias edades. Elige entre `HasData` y `UseSeeding` y explica por qué en el PR.

### 4. Tests del modelo (≈ incluido en el paso 2)

La configuración de EF Core también es código y cuenta para la cobertura. Escribe tests que construyan el modelo (no necesitan conectarse a la base de datos) y comprueben, al menos:

- El índice que impide dos inscripciones activas del mismo jugador en el mismo campus.
- La precisión del precio y las longitudes máximas de los textos.
- Las relaciones y el comportamiento de borrado que hayas decidido.

Agrupa los casos parecidos con `[Theory]`.

## Criterios de aceptación

- [ ] SQL Server en Docker con volumen, y el comando documentado sin secretos.
- [ ] Configuración de entidades con `IEntityTypeConfiguration`, sin atributos de EF en Domain.
- [ ] Migración inicial aplicada y datos de prueba cargados.
- [ ] Ningún secreto en el repositorio (revisa el diff antes del PR).
- [ ] Tests del modelo con cobertura ≥ 80 % de las clases de configuración.
- [ ] **Calidad:** la carpeta `Migrations` es código generado y se excluirá del análisis el viernes; el resto del código nuevo tiene que poder superar el gate (ver [`calidad.md`](../../docs/court-connect/calidad.md)).

## Extra

- Un `docker-compose.yml` solo con SQL Server (el martes de la semana 8 lo ampliarás).
- Un *concurrency token* (`rowversion`) en `Camp` para la pregunta de la última plaza.

## Preguntas para la demo

- ¿Qué es una migración y qué pasa si dos personas crean migraciones a la vez?
- ¿Dónde está guardada la contraseña de la base de datos y por qué ahí?
- ¿Qué cambiaría si mañana usáramos PostgreSQL?

## Comparación con IA

Con el PR abierto, pide a la IA la configuración de EF Core de tus entidades y compárala con la tuya: longitudes, índices, borrado en cascada, tipos decimales.

## Recursos

- [EF Core: primeros pasos](https://learn.microsoft.com/es-es/ef/core/get-started/overview/first-app)
- [Migraciones de EF Core](https://learn.microsoft.com/es-es/ef/core/managing-schemas/migrations/)
- [Inicialización de datos (seeding)](https://learn.microsoft.com/es-es/ef/core/modeling/data-seeding)
- [SQL Server en contenedores Linux con Docker](https://learn.microsoft.com/es-es/sql/linux/quickstart-install-connect-docker)
- [Secretos de usuario en desarrollo](https://learn.microsoft.com/es-es/aspnet/core/security/app-secrets)
- `docs/masterclasses/masterclass-docker.md` de este repo.
