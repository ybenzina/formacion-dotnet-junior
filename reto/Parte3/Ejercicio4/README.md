# Ejercicio 4 — Despliegue en Azure

**Día 22 · estimación: 5 h** · Issue: «P3 · Ej4 · Despliegue en Azure»

## Objetivo

Que el MVP funcione en Azure con una URL que puedas enseñar. Es lo mismo que se hará en la iteración 0 de Àmbit, a menor escala.

## Antes de empezar (≈ 30 min)

Repasa la [sesión 2 de cloud: Azure, infraestructura como código y costes](../../../docs/masterclasses/masterclass-cloud-azure.md), del **domingo siguiente al Día 20**, antes de este despliegue del **Día 22**. La [sesión 1](../../../docs/masterclasses/masterclass-cloud-local.md), del domingo siguiente al Día 15, revisó tus contenedores. Conceptos para el glosario: **Azure Container Apps**, **Azure SQL**, **registro de contenedores**, **secreto de Container Apps** o **Key Vault**, **identidad gestionada** y **escalar a cero**.

**Coste:** se usa la suscripción que indique Yamel. Container Apps tiene una concesión gratuita mensual y Azure SQL una oferta gratuita para desarrollo. Antes de crear nada, mira en la calculadora de Azure qué costaría si se superan, y **borra o para los recursos** cuando acabe el reto.

## Pasos

Rama `chore/despliegue-azure`, desde `develop`.

**Release antes de desplegar:** cuando el despliegue esté integrado en `develop`, abre un PR de `develop` a `main` (*merge commit*) y etiqueta **`v0.2.0`**. Se despliega lo que hay en `main`: lo que está en Azure tiene que corresponder siempre a una versión.

1. **Base de datos:** Azure SQL con la oferta gratuita, con la opción de **pausarse al llegar al límite** (no la de seguir cobrando).
2. **Imágenes:** las de API y web de la Parte II y la de `CourtConnect.Worker`, construido en la Parte III, publicadas en un registro (Azure Container Registry o GitHub Container Registry). Crea su `Dockerfile`, igual que los de la Parte II (≈ 10 min), y la CI debe construir también su imagen.
3. **Container Apps:** un entorno con API, web y `CourtConnect.Worker`, cada uno en su propia app. La web, accesible desde internet; la API, solo desde la web si te da tiempo (si no, pública y anótalo como deuda). El worker no tiene HTTP ni ingress.
4. **Configuración y secretos:** cadena de conexión y claves como secretos, nunca en la imagen ni en el repositorio. La API y el worker necesitan la cadena de conexión a SQL; la web llama a la API, no consulta SQL.
5. **Sesión y réplicas:** el asistente de inscripción guarda su estado en la sesión, y con `AddDistributedMemoryCache` la sesión vive en la memoria de cada réplica. Decide y explica una opción: una sola réplica para la web, afinidad de sesión (*session affinity*) en Container Apps o una caché distribuida. Piensa también qué pasa al escalar a cero con una inscripción a medias, y con las claves de Data Protection que cifran las cookies.
6. **Migraciones:** decide cómo se aplican en Azure, desde la API o desde un paso de despliegue, y explícalo. El worker no aplica migraciones.
7. **Worker continuo:** despliega el proyecto `CourtConnect.Worker`, sin convertirlo en Job, con `minReplicas = 1` y `maxReplicas = 1`. Justifica ese mínimo: sin ingress, sin una regla externa de activación y sin mínimo positivo, su temporizador interno no puede volver a arrancarlo desde cero. No se añade otra implementación de caducidad al Día 22.
8. **Documentación:** apartado «Despliegue» en el README con los pasos, recursos y límites de escalado explícitos de web, API y worker.

Hazlo primero a mano (portal o `az`) para entender cada pieza. Automatizarlo desde la CI es un extra.

## Criterios de aceptación

- [ ] La web funciona en una URL pública, con login y datos ficticios.
- [ ] Lo desplegado corresponde a una versión etiquetada de `main`.
- [ ] Ningún secreto en las imágenes ni en el repositorio.
- [ ] La base de datos no puede generar costes inesperados.
- [ ] La decisión sobre la sesión con varias réplicas, explicada en el README.
- [ ] El README indica mínimos y máximos explícitos de web, API y worker; este último usa mínimo 1 y máximo 1.
- [ ] README con los pasos de despliegue y la lista de recursos.

## Extra

- Comparar el worker continuo con un Job mediante la [hoja de costes](../../../docs/masterclasses/masterclass-cloud-costes-yamel.md), solo como análisis, sin implementar el Job.
- Desplegar desde GitHub Actions con credenciales federadas (OIDC), sin guardar contraseñas de Azure.
- **Aspire:** un `AppHost` para el desarrollo local y `ServiceDefaults` con OpenTelemetry; como parte de este extra, puedes añadir `CourtConnect.Worker` al `AppHost`. Mira las trazas de una inscripción en el panel de Aspire.

## Preguntas para la demo

- ¿Qué recursos de Azure has creado, para qué sirve cada uno y cuánto cuestan al mes?
- ¿Dónde está la contraseña de la base de datos en Azure, y quién puede verla?
- Si mañana hay 10 veces más jugadores, ¿qué cambiarías?
