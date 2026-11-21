# Anuncios de Discord · Masterclasses

Cada bloque es un mensaje independiente, listo para copiar y pegar. Fija el primero en el canal. Los enlaces apuntan a `main`: las guías nuevas o actualizadas deben publicarse allí antes de enviar los anuncios. Todas las sesiones tienen fecha y hora.

## Mensaje fijado · Calendario

```markdown
📌 **Masterclasses · Calendario de formación**

Estas sesiones acompañan al reto CourtConnect: trabajaremos sobre lo que ya hayas hecho y prepararemos el siguiente paso.

- **D 22/11/2026 · 17:00 · Arquitectura (versión condensada):** 75 min, con 5 de descanso. Antes de la Parte III; el 20/11 ya vimos la inyección de dependencias.
- **D 22/11/2026 · a continuación (hacia las 18:25) · Contenedores, avance:** unos 35 min, sin taller. Antes de P2 · Ej4; ya no es una sesión aparte.
- **M 24/11/2026 · 15:00 · IA y agentes:** 90 min, con una pausa de 10. Antes de trabajar P2 · Ej5.
- **V 27/11/2026 · 16:00 · Demo 2:** 90 min, solo Docker y Ej5.
- **D 29/11/2026 · 17:00 · Azure, infraestructura como código y costes:** 90 min. Antes del despliegue del Día 22 (X 02/12).
- **Próximamente · Seguridad e integraciones:** antes de empezar Àmbit, sin fecha. Seguridad: dos sesiones de 90 min; integraciones: una de 90 min.

Los quizzes se hacen al día siguiente, fuera del tiempo de clase. Las masterclasses no cuentan como días de trabajo del reto.

📚 [Calendario del reto](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/court-connect/calendario.md) · [Guías y anuncios](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/Anuncios.md)
```

## Arquitectura

```markdown
📢 **Masterclass · Arquitectura: entender las piezas de tu aplicación**

**Fecha:** domingo 22/11/2026, a las 17:00, antes de la Parte III (empieza el miércoles 25/11).
**Duración:** 75 minutos, en versión condensada, con un descanso de 5 y un taller de 15.

Ya tienes hecha la Parte I y el 20/11 repasamos contigo la inyección de dependencias, las referencias entre proyectos y el recorrido de una petición hasta la base de datos. Hoy no lo repetimos: vamos a lo que necesitas para la Parte III.
Veremos *slices*, *handlers* y qué hace de verdad EF Core como unidad de trabajo.
Hablaremos de ciclos de vida (Transient, Scoped, Singleton) y de la dependencia cautiva.
Reconoceremos Adapter, Hexagonal, Strategy y Options, y cuándo ayudan de verdad.
Trabajaremos sobre tu servicio de la Parte I para elegir una mejora pequeña y comprobable.

**Antes de venir, Driss:**
- Cierra las tres tareas pendientes de la Parte I: `retro.md`, los issues de SonarCloud y el glosario de los ejercicios hechos.
- Repasa las reglas R1–R6 del [dominio](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/court-connect/enunciado-dominio.md) y la [guía de arquitectura](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/court-connect/architecture/README.md).
- Trae tu `RegistrationService`, sus pruebas y tus dudas sobre lo que te generó la IA.

🎯 **Te llevarás:** un mapa de responsabilidades de tu código y una mejora que puedas explicar. El quiz queda como tarea posterior.

📚 [Markdown de la masterclass](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/masterclass-architecture.md)
```

## Contenedores, Compose y Aspire

```markdown
📢 **Masterclass · Contenedores: un avance antes de tu Dockerfile**

**Fecha:** domingo 22/11/2026, a continuación de Arquitectura (hacia las 18:25), antes de empezar P2 · Ej4 el lunes.
**Duración:** unos 35 minutos, sin taller. Ya no es una sesión aparte de 90 minutos.

Veremos qué son una imagen, un contenedor y un registry, y por qué un Dockerfile separa construir de ejecutar (*multi-stage*).
Veremos cómo Compose describe web, API y SQL, y la diferencia entre «arrancado» y «preparado».
Aspire queda como extra.

**Antes de venir, Driss:**
- Nada que preparar: es un avance para que te suene lo que vas a hacer, o estás haciendo si ya empezaste, en [P2 · Ej4: Docker y Docker Compose](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/reto/Parte2/Ejercicio4/README.md). **No empieces el ejercicio antes.**
- El viernes 27/11, en la demo 2, revisaremos tu Dockerfile y tu `docker-compose.yml`.

🎯 **Te llevarás:** el vocabulario y el esquema mental para enfrentarte al ejercicio con menos sorpresas. No necesitas instalar Aspire ni crear recursos de pago.

📚 [Markdown de la masterclass](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/masterclasses/masterclass-cloud-local.md)
```

## IA y agentes

```markdown
📢 **Masterclass · IA y agentes para desarrollar con criterio**

**Fecha:** martes 24/11/2026, de 15:00 a 16:30, antes de trabajar P2 · Ej5.
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

## Demo 2

```markdown
📢 **Demo 2 · Docker y ejercicio 5**

**Fecha:** viernes 27/11/2026, de 16:00 a 17:30 (sustituye al seguimiento de ese día).
**Duración:** 90 minutos.

Es una demo corta: solo Docker y el ejercicio 5, porque el resto ya lo vimos en la sesión del 20/11.
Revisaremos tu Dockerfile y tu `docker-compose.yml`, y la herramienta de IA que elijas para el piloto.

**Antes de venir, Driss:**
- Tener hechos [P2 · Ej4: Docker y Docker Compose](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/reto/Parte2/Ejercicio4/README.md) y [P2 · Ej5: Demo 2 y preparación del SDD](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/reto/Parte2/Ejercicio5/README.md).

📚 [Calendario del reto](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/docs/court-connect/calendario.md)
```

## Azure, infraestructura como código y costes

```markdown
📢 **Masterclass · Azure, infraestructura como código y costes**

**Fecha:** domingo 29/11/2026, a las 17:00, antes del despliegue del Día 22 (miércoles 02/12). El martes 01/12 queda libre.
**Duración:** 90 minutos, incluido un taller de costes de 30.

Relacionaremos la web, la API, el worker y los datos de CourtConnect con servicios de Azure.
Compararemos cómo describir infraestructura con Bicep y Terraform.
Estimaremos un mes normal y un pequeño pico de uso, dejando claros los supuestos.
Prepararemos las decisiones del despliegue del Día 22, sin desplegar durante la clase.

**Antes de venir, Driss:**
- Haber hecho [P2 · Ej4: Docker y Docker Compose](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/reto/Parte2/Ejercicio4/README.md) y llevar [P3 · Ej2: implementación y revisión](https://github.com/ybenzina/formacion-dotnet-junior/blob/main/reto/Parte3/Ejercicio2/README.md) hasta donde llegues el Día 19. No hace falta haberlo terminado.
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
