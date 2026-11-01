# Ronda 4: el `BackgroundService` vive en su propio host, `CourtConnect.Worker`

Repo `formacion-dotnet-junior`, rama `docs/masterclass-arquitectura`. Sigue sin haber commit, push ni staging. No toques ningún PowerPoint, `masterclass-dotnet-technologies.md` ni su quiz. Mantén el formato de las masterclasses (puntos clave, «Qué decir», «Contexto para Yamel»), el máximo de 4 términos nuevos en negrita por diapositiva, el estilo C# del repo y el idioma sencillo para un junior.

## El problema

La ronda 3 deja el worker continuo (`minReplicas = 1`, `maxReplicas = 1`) como una tercera app de Container Apps. Pero en ningún sitio del reto existe ese host: `docs/court-connect/architecture/README.md` solo lista `Api`, `Ui.Web` y las capas, y los ejercicios 1 y 2 de la Parte III no piden crearlo. Si Driss registra el `BackgroundService` en la API (lo más natural), la hoja de costes y el ejercicio 4 se contradicen: con la API a mínimo 0 no hay caducidades, y con dos réplicas habría dos temporizadores haciendo lo mismo.

## Decisión (Yamel, 31/10)

El `BackgroundService` de caducidades vive en un proyecto aparte, **`CourtConnect.Worker`** (plantilla *Worker Service*, sin HTTP, sin ingress). Referencia a `Application` e `Infrastructure`, igual que la API. No aplica migraciones: las aplica la API o el paso que ya decida el ejercicio 4. Las cifras de la hoja de costes no cambian.

## Cambios pedidos

1. **`docs/court-connect/architecture/README.md`:**
   - Añade la fila `CourtConnect.Worker` a la tabla de proyectos, con «Parte III» en la responsabilidad.
   - Ajusta la decisión «Proceso en segundo plano» para que diga que va en ese host.
   - Comprueba también `docs/court-connect/plantilla-repo/README.md` y `AGENTS.md`, `enunciado-dominio.md`, `evaluacion.md`, `issues-reto.md` y `calendario.md`: haz grep de «segundo plano», «BackgroundService» y «caducidad», y corrige lo que describa la estructura de proyectos.
2. **`reto/Parte3/Ejercicio1/README.md`:** en la pregunta de la especificación sobre quién hace caducar las inscripciones, deja la pista del `BackgroundService` y añade que irá en un host propio, `CourtConnect.Worker`. No pidas más que eso en el ejercicio 1.
3. **`reto/Parte3/Ejercicio2/README.md`:**
   - En «Plan técnico y tareas», pide revisar que el plan incluya el proyecto `CourtConnect.Worker` y que la constitución lo permita.
   - En la revisión línea a línea, mantén los puntos sobre `TimeProvider` y `DbContext`. Añade qué pasa si hubiera dos instancias del worker.
   - Anota en los criterios de aceptación que la caducidad corre en `CourtConnect.Worker` y no en la API.
   - No subas la estimación de 7 h salvo que lo justifiques; escribe en la respuesta cuánto calculas que añade (orientativamente 30 min) y cómo queda dentro del tiempo.
4. **`reto/Parte3/Ejercicio4/README.md`:**
   - Paso 2 (imágenes): incluye la del worker. Añade que la CI debe construirla igual que las de la Parte II.
   - Paso 3 (Container Apps): el entorno lleva API, web **y worker**. El worker no tiene ingress.
   - Paso 4 (secretos): el worker también necesita la cadena de conexión a SQL.
   - Paso 6 (migraciones): aclara que el worker no migra.
   - Paso 7: ya no dice «el `BackgroundService` de los ejercicios 1 y 2», sino «el proyecto `CourtConnect.Worker`». Conserva `minReplicas = 1` y `maxReplicas = 1`, y la explicación de por qué.
   - No exijas que el worker entre en `docker-compose.yml`. Si lo mencionas, que sea opcional para ejecutarlo en local.
   - Extra de Aspire: puede añadir el worker al `AppHost`; indícalo solo como extra.
5. **`docs/masterclasses/masterclass-architecture.md`:** en las diapositivas 3 y 16 (worker y `BackgroundService`), nombra `CourtConnect.Worker` como el host del reto. Mantén los 110 minutos y el límite de términos. Revisa que la diapositiva 16 no diga ni sugiera que va en la API.
6. **`docs/masterclasses/masterclass-cloud-azure.md`:** en la diapositiva 3 y la del diagrama del taller, cambia «el worker existente» o «el BackgroundService ya construido» por el proyecto `CourtConnect.Worker` que construyen en la Parte III. Indica que el worker consulta SQL y la web no. Mantén sin cambios las cifras de `masterclass-cloud-costes-yamel.md`; solo ajusta el texto.
7. **`docs/masterclasses/masterclass-integrations.md`:** el `OutboxWorker` de la diapositiva 8 debe presentarse como el tipo de servicio que viviría en `CourtConnect.Worker`. No añadas ningún requisito al reto.
8. **Quizzes** (`architecture`, `cloud`, `integrations`): comprueba si alguna pregunta o respuesta supone que el worker está en la API o que «ya existe». Si hace falta, corrígela sin romper el equilibrio de letras ni de longitudes de la ronda 3.

## Comprobaciones al terminar

- Haz grep en todo `docs/` y `reto/` de «worker», «BackgroundService» y «segundo plano». Cada mención debe encajar con un host propio.
- Vuelve a pasar enlaces locales y anclas, agendas, máximo de 4 términos en negrita y el equilibrio de los quizzes.
- Si cambias algún fragmento C#, compílalo fuera del repo como en la ronda 3.
- Dime los ficheros cambiados, qué has dejado sin verificar y cuánto tiempo calculas que añade el worker al ejercicio 2.
