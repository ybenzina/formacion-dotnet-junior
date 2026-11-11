# Anuncios de Discord · Masterclasses

Cada bloque es un mensaje independiente, listo para copiar y pegar. Fija el primero en el canal. Los enlaces apuntan a `main`: las guías nuevas o actualizadas deben publicarse allí antes de enviar los anuncios. Todas las sesiones tienen fecha y hora salvo la de contenedores, que solo tiene fecha.

## Mensaje fijado · Calendario

```markdown
📌 **Masterclasses · Calendario de formación**

Estas sesiones acompañan al reto CourtConnect: trabajaremos sobre lo que ya hayas hecho y prepararemos el siguiente paso.

- **M 17/11/2026 · 12:30 · Arquitectura:** 110 min, con 10 de descanso. Repaso de la Parte I antes de la demo 1.
- **M 24/11/2026 · 12:30 · IA y agentes:** 90 min, con una pausa de 10. Antes de trabajar P2 · Ej5.
- **D 29/11/2026 · Mañana · Contenedores, Compose y Aspire:** 90 min. Repaso del ejercicio de Docker, antes del despliegue.
- **M 01/12/2026 · 12:30 · Azure, infraestructura como código y costes:** 90 min. Después del Día 20 y antes del despliegue del Día 22.
- **Próximamente · Seguridad e integraciones:** antes de empezar Àmbit, sin fecha. Seguridad: dos sesiones de 90 min; integraciones: una de 90 min.

**Hora por confirmar en la sesión de contenedores.** Los quizzes se hacen al día siguiente, fuera del tiempo de clase. Las masterclasses no cuentan como días de trabajo del reto.

📚 [Calendario del reto](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/court-connect/calendario.md) · [Guías y anuncios](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/Anuncios.md)
```

## Arquitectura

```markdown
📢 **Masterclass · Arquitectura: entender las piezas de tu aplicación**

**Fecha:** martes 17/11/2026, de 12:30 a 14:20 (sustituye al seguimiento de ese día).
**Duración:** 110 minutos, incluidos 10 de descanso y un taller de 20.

Ya tienes la Parte I hecha: ahora toca entender bien lo que has construido.
Seguiremos una petición desde la web hasta la base de datos.
Veremos qué hace de verdad EF Core (el `DbContext` como unidad de trabajo) y cómo funciona la inyección de dependencias: Transient, Scoped, Singleton y por qué un Singleton no puede usar el `DbContext`.
Reconoceremos seis patrones y cuándo ayudan de verdad.
Trabajaremos sobre tu `RegistrationService` para elegir una mejora pequeña y comprobable.

**Antes de venir, Driss:**
- Pasa `/check-pr` por tus PR de la Parte I y crea o cierra las issues con tus horas reales.
- Repasa las reglas R1–R6 del [dominio](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/court-connect/enunciado-dominio.md) y la [guía de arquitectura](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/court-connect/architecture/README.md).
- Trae tu `RegistrationService`, sus pruebas y tus dudas sobre lo que te generó la IA (constructores primarios, inyección de dependencias, EF).

🎯 **Te llevarás:** un mapa de responsabilidades de tu código y una mejora que puedas explicar en la demo 1. El quiz, al día siguiente: 20 minutos fuera de clase.

📚 [Markdown de la masterclass](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/masterclass-architecture.md)
```

## Contenedores, Compose y Aspire

```markdown
📢 **Masterclass · Contenedores, Compose y Aspire**

**Fecha:** domingo 29/11/2026, por la mañana, después del Día 15.
**Hora:** hora por confirmar.
**Duración:** 90 minutos, incluido un taller de 25.

Revisaremos cómo tus Dockerfile convierten el código en imágenes ejecutables.
Seguiremos la red, los datos y el arranque de web, API y SQL con Compose.
Veremos qué aporta Aspire para ejecutar y observar las piezas en desarrollo.
Buscaremos un fallo de conexión o arranque y comprobaremos una mejora.

**Antes de venir, Driss:**
- Tener trabajado [P2 · Ej4: Docker y Docker Compose](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/reto/Parte2/Ejercicio4/README.md). Es un repaso y ampliación, no la introducción para empezar ese ejercicio.
- Trae tus Dockerfile y `docker-compose.yml`, y repasa el recorrido web → API → base de datos. Si algo falla, trae el error sin credenciales.

🎯 **Te llevarás:** una explicación de cómo arranca tu aplicación, una mejora contrastada y criterios para distinguir Compose de Aspire. No necesitas instalar Aspire de antemano ni crear recursos de pago.

📚 [Markdown de la masterclass](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/masterclass-cloud-local.md)
```

## IA y agentes

```markdown
📢 **Masterclass · IA y agentes para desarrollar con criterio**

**Fecha:** martes 24/11/2026, de 12:30 a 14:00 (sustituye al seguimiento de ese día), antes de trabajar P2 · Ej5.
**Duración:** 90 minutos, incluida una pausa de 10.

Distinguiremos modelo, asistente, workflow y agente, sin atribuirles capacidades que no hemos comprobado.
Veremos cómo influyen el contexto, las instrucciones y los permisos de las herramientas.
Practicaremos cómo delimitar una tarea y pedir evidencias de que funciona.
Prepararemos el siguiente ejercicio sin resolver su tutor ni adelantar sus casos de prueba.

**Antes de venir, Driss:**
- Tener trabajada la Parte II hasta el ejercicio 4. **No tienes que hacer P2 · Ej5 antes de la sesión.**
- Repasa las [reglas de IA de CourtConnect](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/court-connect/plantilla-repo/AGENTS.md) y lee la [plantilla de diseño de agentes](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/ai/plantillas/diseno-agente.md).
- Trae una duda de tu uso de IA, sin secretos ni datos personales. No abras el tutor de referencia ni ejecutes por adelantado los casos de P2 · Ej5: primero investigarás y propondrás tu diseño.

🎯 **Te llevarás:** criterios para diseñar una ayuda acotada, revisar sus permisos y comprobar sus respuestas. El taller usa otra tarea; no sustituye tu trabajo del ejercicio. Quiz al día siguiente: 15 minutos fuera de clase.

📚 [Markdown de la masterclass](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/masterclass-ai-agents.md)
```

## Azure, infraestructura como código y costes

```markdown
📢 **Masterclass · Azure, infraestructura como código y costes**

**Fecha:** martes 01/12/2026, de 12:30 a 14:00 (sustituye al seguimiento de ese día), después del Día 20.
**Duración:** 90 minutos, incluido un taller de costes de 30.

Relacionaremos la web, la API, el worker y los datos de CourtConnect con servicios de Azure.
Compararemos cómo describir infraestructura con Bicep y Terraform.
Estimaremos un mes normal y un pequeño pico de uso, dejando claros los supuestos.
Prepararemos las decisiones del despliegue del Día 22, sin desplegar durante la clase.

**Antes de venir, Driss:**
- Haber trabajado la sesión de Contenedores, Compose y Aspire y [P3 · Ej2: implementación y revisión](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/reto/Parte3/Ejercicio2/README.md), hasta el Día 20.
- Repasa el recorrido web → API → base de datos y el trabajo de caducidad en segundo plano. Trae dudas sobre qué necesita seguir ejecutándose.
- Ten un navegador disponible para la calculadora. **No necesitas haber hecho el despliegue del Día 22**, crear recursos de pago ni compartir credenciales.

🎯 **Te llevarás:** un mapa de servicios y una estimación de laboratorio con hipótesis, límites y gastos que no hay que olvidar. Será un ejercicio con datos ficticios, no un presupuesto del proyecto real.

📚 [Markdown de la masterclass](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/masterclass-cloud-azure.md)
```

## Próximamente · Seguridad e integraciones

```markdown
🔜 **Próximamente · Seguridad e integraciones**

**Fecha:** sin fecha fijada, antes de empezar Àmbit; seguridad, al terminar el reto.
**Hora:** hora por confirmar para cada sesión.
**Duración:** seguridad, dos sesiones de 90 minutos; integraciones, una de 90 minutos. No es una única clase de cuatro horas y media.

Revisaremos identidad, permisos, sesiones y riesgos habituales de seguridad.
Veremos cómo proteger datos y secretos, y cómo comprobar los controles.
Trabajaremos reintentos, idempotencia y tareas en segundo plano sin duplicar operaciones.

**Antes de venir, Driss:**
- Seguridad: repasa [Seguridad en 15 minutos](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/court-connect/seguridad-en-15-minutos.md), P2 · Ej2 y tu revisión del PR trampa de P3 · Ej5. Trae una duda de permisos y otra de sesiones.
- Integraciones: trae el diseño de pago y caducidad trabajado en P3 · Ej2. No hace falta integrar una pasarela real.

🎯 **Te llevarás:** criterios para revisar accesos y diseñar integraciones que toleren fallos. Usaremos datos ficticios, sin cuentas cloud ni credenciales reales.

📚 Markdown de las masterclasses: [Seguridad e identidad](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/masterclass-security.md) · [Integraciones y tareas en segundo plano](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/masterclass-integrations.md)
```
