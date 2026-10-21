# Masterclass Contenedores, Aspire y Azure

**El domingo siguiente al Día 13 del reto**, antes de la Parte III. Sustituye a las antiguas masterclasses de Docker y de Cloud.

## Contenido

- **Modelos de servicio:** IaaS, PaaS y SaaS, y por qué Àmbit va en PaaS sin diseño *serverless*.
- **Azure Container Apps:** entorno, aplicaciones, réplicas, escalar a cero y concesión gratuita. Por qué Container Apps y no Kubernetes.
- **Azure SQL:** niveles, oferta gratuita y sus límites (copias y restauración), y qué conviene en producción con datos sensibles.
- **Secretos y configuración:** secretos de Container Apps, Key Vault e **identidad gestionada** (sin contraseñas en la configuración).
- **Despliegue desde GitHub Actions** con credenciales federadas (OIDC).
- **Aspire:** `AppHost` para levantar todo en local, `ServiceDefaults` y **OpenTelemetry** (trazas, métricas y logs) con su panel; en Azure, Application Insights.
- **Costes:** la calculadora de Azure.

## Ejercicio

Con la calculadora de Azure, estimar el coste mensual de la arquitectura prevista para Àmbit (portal, backoffice, API, *worker*, Azure SQL, almacenamiento y correo), con un escenario normal y uno de pico en mayo.
