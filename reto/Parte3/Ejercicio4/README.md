# Ejercicio 4 — Despliegue en Azure

**Día 22 · estimación: 5 h** · Issue: «P3 · Ej4 · Despliegue en Azure»

## Objetivo

Que el MVP funcione en Azure con una URL que puedas enseñar. Es lo mismo que se hará en la iteración 0 de Àmbit, a menor escala.

## Antes de empezar (≈ 30 min)

Repasa la masterclass de contenedores, Aspire y Azure (el domingo siguiente al Día 13). Conceptos (añádelos al glosario): **Azure Container Apps**, **Azure SQL**, **registro de contenedores**, **secreto de Container Apps** o **Key Vault**, **identidad gestionada** y **escalar a cero**.

**Coste:** se usa la suscripción que indique Yamel. Container Apps tiene una concesión gratuita mensual y Azure SQL una oferta gratuita para desarrollo. Antes de crear nada, mira en la calculadora de Azure qué costaría si se superan, y **borra o para los recursos** cuando acabe el reto.

## Pasos

Rama `chore/despliegue-azure`, desde `develop`.

**Release antes de desplegar:** cuando el despliegue esté integrado en `develop`, abre un PR de `develop` a `main` (*merge commit*) y etiqueta **`v0.2.0`**. Se despliega lo que hay en `main`: lo que está en Azure tiene que corresponder siempre a una versión.

1. **Base de datos:** Azure SQL con la oferta gratuita, con la opción de **pausarse al llegar al límite** (no la de seguir cobrando).
2. **Imágenes:** las de la Parte II, publicadas en un registro (Azure Container Registry o GitHub Container Registry).
3. **Container Apps:** un entorno con la API y la web. La web, accesible desde internet; la API, solo desde la web si te da tiempo (si no, pública y anótalo como deuda).
4. **Configuración y secretos:** cadena de conexión y claves como secretos, nunca en la imagen ni en el repositorio.
5. **Migraciones:** decide cómo se aplican en Azure y explícalo.
6. **Documentación:** apartado «Despliegue» en el README con los pasos y los recursos creados.

Hazlo primero a mano (portal o `az`) para entender cada pieza. Automatizarlo desde la CI es un extra.

## Criterios de aceptación

- [ ] La web funciona en una URL pública, con login y datos ficticios.
- [ ] Lo desplegado corresponde a una versión etiquetada de `main`.
- [ ] Ningún secreto en las imágenes ni en el repositorio.
- [ ] La base de datos no puede generar costes inesperados.
- [ ] README con los pasos de despliegue y la lista de recursos.

## Extra

- Desplegar desde GitHub Actions con credenciales federadas (OIDC), sin guardar contraseñas de Azure.
- **Aspire:** un `AppHost` para el desarrollo local y `ServiceDefaults` con OpenTelemetry. Mira las trazas de una inscripción en el panel de Aspire.

## Preguntas para la demo

- ¿Qué recursos de Azure has creado, para qué sirve cada uno y cuánto cuestan al mes?
- ¿Dónde está la contraseña de la base de datos en Azure, y quién puede verla?
- Si mañana hay 10 veces más jugadores, ¿qué cambiarías?
