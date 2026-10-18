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

- Proyecto `src/CourtConnect.Infrastructure` con los paquetes de EF Core para SQL Server.
- Proyecto `src/CourtConnect.Api` (plantilla `webapi`, todavía vacía) que registra el `DbContext`. Lo usarás como proyecto de arranque de las migraciones; los endpoints llegan mañana.
- `CourtConnectDbContext` con la configuración de cada entidad en una clase `IEntityTypeConfiguration<T>` (no en atributos del dominio): claves, longitudes máximas, precisión del precio, relaciones e índices (por ejemplo, el que evita dos inscripciones activas del mismo jugador en el mismo campus).
- Cadena de conexión con **`dotnet user-secrets`** en el proyecto Api. Nunca en `appsettings.json`.

### 3. Revisar lo que te has traído con los paquetes (≈ 15 min)

Cuando añades un paquete NuGet casi nunca añades uno solo. `Microsoft.EntityFrameworkCore.SqlServer` arrastra otros, que a su vez arrastran más: son las **dependencias transitivas**. No las eliges tú, pero acaban dentro de tu aplicación igual que las que sí escribiste, y si alguna tiene un fallo de seguridad publicado, lo tienes tú.

Mira primero todo lo que ha entrado:

```powershell
dotnet list package --include-transitive
```

Y ahora solo lo que tiene avisos de seguridad:

```powershell
dotnet list package --vulnerable --include-transitive
```

Sin `--include-transitive` el comando solo mira los paquetes que tú escribiste en el `.csproj`, y el problema casi nunca está ahí.

**Si no sale nada, perfecto.** Anota en el PR que lo has comprobado y sigue. Lo que se evalúa es la comprobación, no el hallazgo.

**Si sale algo,** verás el paquete, la versión, la severidad y un enlace al aviso. Tiene esta pinta:

```text
El proyecto "CourtConnect.Infrastructure" tiene los paquetes vulnerables siguientes
   > System.Security.Cryptography.Pkcs   9.0.11   High   https://github.com/advisories/GHSA-...
```

Entonces, por orden:

1. **Lee el aviso.** El enlace dice qué versiones están afectadas y a partir de cuál está corregido. Sin eso no sabes a dónde tienes que llegar.
2. **Averigua por dónde entra.** Tú no pediste ese paquete, así que alguien lo pidió por ti:

   ```powershell
   dotnet nuget why src\CourtConnect.Infrastructure System.Security.Cryptography.Pkcs
   ```

   Te dibuja la cadena completa, desde el paquete que sí pusiste tú hasta el vulnerable:

   ```text
   └── Microsoft.EntityFrameworkCore.SqlServer (v10.0.13)
       └── Microsoft.Data.SqlClient (v6.1.7)
           └── System.Security.Cryptography.Pkcs (v9.0.11)
   ```

3. **Arréglalo.** Hay dos caminos y el orden importa:
   - **Primero, actualiza el paquete de primer nivel** (el de arriba de la cadena). Si ya existe una versión suya que apunte a una versión corregida, es la solución limpia: desaparece el problema y no añades nada a tu `.csproj`.
   - **Si no la hay,** añade tú una referencia directa al paquete vulnerable, en una versión sana. Funciona porque NuGet resuelve siempre **la versión más alta que alguien pida**, así que tu referencia directa gana a la que viene de abajo.
4. **Ponlo donde nace, no donde aparece.** El aviso te saldrá en todos los proyectos que dependan de ese, directa o indirectamente: aquí aparecería también en `Api` y en `IntegrationTests`, que no tienen culpa de nada. Arreglándolo **solo** en el proyecto que lo trae, desaparece de todos. Si lo pones en los tres, tendrás tres sitios que mantener y que se te desincronizarán.
5. **Comprueba y explica.** Repite el comando del principio: tiene que salir limpio. En el PR escribe qué paquete era, por dónde entraba y por qué el arreglo va donde lo has puesto.

Una advertencia para que no te vuelvas loco: **esto no lo mira el quality gate del viernes.** SonarQube analiza el código que escribes tú; tus dependencias son otra cosa y se revisan con estos comandos. Volvemos sobre ello en el Ejercicio 5.

### 4. Migración y datos de prueba (≈ 1 h 15 min)

- Crea la migración inicial y aplícala. Abre el fichero de la migración y entiende qué hace.
- Genera el script SQL de la migración (`dotnet ef migrations script`) y compáralo con `docs/court-connect/data-model/init.sql`: ¿qué hace EF que el script a mano no hacía, y al revés?
- Añade datos de prueba ficticios: al menos 3 campus (uno lleno, uno cerrado) y 5 jugadores de varias edades. Elige entre `HasData` y `UseSeeding` y explica por qué en el PR.

### 5. Tests del modelo (≈ incluido en el paso 2)

La configuración de EF Core también es código y cuenta para la cobertura. Escribe tests que construyan el modelo (no necesitan conectarse a la base de datos) y comprueben, al menos:

- El índice que impide dos inscripciones activas del mismo jugador en el mismo campus.
- La precisión del precio y las longitudes máximas de los textos.
- Las relaciones y el comportamiento de borrado que hayas decidido.

Agrupa los casos parecidos con `[Theory]`.

## Criterios de aceptación

- [ ] SQL Server en Docker con volumen, y el comando documentado sin secretos.
- [ ] Configuración de entidades con `IEntityTypeConfiguration`, sin atributos de EF en Domain.
- [ ] Migración inicial aplicada y datos de prueba cargados.
- [ ] `dotnet list package --vulnerable --include-transitive` ejecutado y su resultado anotado en el PR. Si salía algo, está resuelto y explicado por dónde entraba.
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
- Tu aplicación incluye paquetes que tú no has añadido. ¿Cómo averiguas cuáles son, quién los trae y si alguno tiene un problema conocido?

## Comparación con IA

Con el PR abierto, pide a la IA la configuración de EF Core de tus entidades y compárala con la tuya: longitudes, índices, borrado en cascada, tipos decimales.

## Recursos

- [EF Core: primeros pasos](https://learn.microsoft.com/es-es/ef/core/get-started/overview/first-app)
- [Migraciones de EF Core](https://learn.microsoft.com/es-es/ef/core/managing-schemas/migrations/)
- [Inicialización de datos (seeding)](https://learn.microsoft.com/es-es/ef/core/modeling/data-seeding)
- [SQL Server en contenedores Linux con Docker](https://learn.microsoft.com/es-es/sql/linux/quickstart-install-connect-docker)
- [Secretos de usuario en desarrollo](https://learn.microsoft.com/es-es/aspnet/core/security/app-secrets)
- `docs/masterclasses/masterclass-docker.md` de este repo.
