# Enunciado del dominio — CourtConnect

> Este documento es el **enunciado**. Tu tarea del primer día es convertirlo en `docs/domain.md` en el repo `court-connect`: con tus palabras, con un diagrama entidad-relación en Mermaid y con las decisiones que tomes donde el enunciado no dice nada.

## Contexto

CourtConnect es una aplicación para jugadores de **baloncesto callejero** (*street basketball*).

Hoy los partidos se organizan con historias de Instagram o grupos de mensajería: alguien publica «sábado a las 11 en la cancha de siempre», la gente contesta y nunca está claro cuántos vendrán, si sobran o faltan jugadores ni quién se ha borrado a última hora.

En CourtConnect, un **organizador** publica **partidos** (quedadas) en una **cancha**, con un número de **plazas**, y los **jugadores** se apuntan ellos mismos. Más adelante habrá **torneos** por equipos, con cuota de inscripción y pago (simulado).

## Antes de escribir `domain.md`: habla con tu grupo

Tú eres usuario de este dominio. Antes de diseñar, dedica **30–45 minutos** durante la Parte I a hablar con 2 o 3 personas con las que juegas. Es descubrimiento con usuarios reales: lo mismo que hacemos con el cliente de Àmbit.

Preguntas de partida (añade las tuyas):

1. ¿Cómo quedáis hoy? ¿Quién organiza?
2. ¿Qué falla? Por ejemplo: no saber cuántos vendrán, que falte o sobre gente, enterarse tarde de que alguien se ha borrado.
3. ¿Cómo hacéis los equipos? ¿Salen equilibrados?
4. ¿Pagáis alguna vez la pista? ¿Hacéis torneos?
5. ¿Usaríais una web o una app en lugar de Instagram? ¿Qué os haría cambiar y qué no?

Apunta las conclusiones en `docs/discovery.md` de `court-connect`. **Las reglas R1 a R6 de la Parte I no cambian**: lo que descubras se usa en las partes II y III, sobre todo para elegir la segunda funcionalidad SDD. Si concluyes que Instagram ya basta, también es un resultado válido: tendrás que explicar qué aporta la aplicación.

## Glosario

El código se escribe en inglés y la documentación en español. Usa estos nombres:

| Concepto | Nombre en código |
|---|---|
| Cancha | `Court` |
| Partido (quedada) | `Game` |
| Jugador | `Player` |
| Inscripción (apuntarse a un partido) | `Registration` |
| Torneo | `Tournament` |
| Equipo | `Team` |
| Pago | `Payment` |

## Parte I — Partidos e inscripciones (obligatorio)

**Cancha**
- Tiene nombre y ubicación (texto libre: dirección o zona).

**Partido**
- Tiene cancha, fecha y hora de inicio, duración, número de plazas (por ejemplo, 6 para un 3 contra 3 o 10 para un 5 contra 5; como mínimo 2), edad mínima y precio por jugador (0 si la cancha es pública; algo más si hay que alquilar pista).
- Estados: **borrador**, **abierto** (admite inscripciones) y **cerrado** (el organizador cierra la lista).

**Jugador**
- Tiene un **apodo** (único: es como le conocen en la cancha), nombre, fecha de nacimiento y correo.
- Guarda **solo los datos necesarios**: nada de teléfono, foto ni datos de salud.
- En la plataforma solo se registran jugadores de **16 años o más**. Por debajo de 14 años, el RGPD exige el consentimiento de los padres; así el reto no trata datos de menores de esa edad y deja margen.

**Inscripción**
- Relaciona un jugador con un partido. Guarda la fecha de creación, el importe y el estado.
- En la Parte I, una inscripción nueva queda **confirmada** directamente. El pago llega con los torneos, en la Parte III.
- Estados en la Parte I: **confirmada** y **cancelada**.
- **Todavía no hay login:** en la Parte I el jugador se indica en la petición. En la Parte II, quién eres lo dirá tu sesión, no el cuerpo de la petición.

### Reglas de negocio (Parte I)

| Id | Regla |
|---|---|
| R1 | Un partido no puede tener más inscripciones activas (no canceladas) que plazas |
| R2 | Un jugador no puede tener dos inscripciones activas en el mismo partido |
| R3 | La edad del jugador **en la fecha del partido** debe ser igual o mayor que la edad mínima del partido, que nunca puede ser inferior a 16 |
| R4 | Solo se admiten inscripciones en partidos **abiertos** y antes de su hora de inicio |
| R5 | Cancelar una inscripción libera la plaza. Solo se puede cancelar antes de la hora de inicio |
| R6 | El importe de la inscripción es el precio por jugador del partido en el momento de apuntarse |

## Parte II — Cuentas y organizadores

- Cada jugador tiene **una cuenta**: correo y contraseña con ASP.NET Core Identity. Como extra, entrar con Google, Microsoft o Facebook. Jugador y cuenta van uno a uno.
- **Rol organizador:** crea canchas y partidos, los abre y los cierra, y ve quién se ha apuntado.
- **Rol jugador:** ve los partidos abiertos y se apunta o se borra **él mismo**.

| Id | Regla |
|---|---|
| R7 | Solo el organizador de un partido puede modificarlo, abrirlo o cerrarlo |
| R8 | Un jugador solo puede apuntarse a sí mismo y cancelar sus propias inscripciones |

## Parte III — Torneos y pago (con SDD)

### Funcionalidad SDD 1 (obligatoria): torneos con pago simulado y caducidad

Se especifica con Spec Kit. Idea de partida, que tendrás que concretar en la especificación:

- Un **torneo** tiene cancha, fecha, número máximo de equipos y una **cuota por equipo**.
- Un **equipo** tiene nombre, un **capitán** (un jugador) y un número mínimo y máximo de jugadores. El capitán inscribe al equipo.
- En la web, el capitán inscribe al equipo **en varios pasos**: datos del equipo, jugadores y pago.
- La inscripción del equipo queda **pendiente de pago** y **retiene la plaza** durante un tiempo configurable.
- El pago se hace contra una **pasarela simulada** que acepta o rechaza.
- Si se acepta, la inscripción pasa a **confirmada**. Confirmar dos veces el mismo pago no debe tener efectos (idempotencia).
- Si vence el plazo sin pago, la inscripción **caduca** y la plaza queda libre.
- Fuera de alcance: reembolsos, pasarelas reales y el cuadro de partidos del torneo.

### Funcionalidad SDD 2: elige una

Según lo que salga de hablar con tu grupo:

- **Lista de espera** en los partidos: si está lleno, te apuntas a la espera; si alguien se borra, entra el primero y se le avisa (aviso simulado).
- **Equipos aleatorios** para un partido: con los apuntados, genera equipos al azar o equilibrados por un nivel que declara cada jugador. Tiene que poder probarse: piensa cómo, igual que con la fecha.

Fuera del reto: estadísticas y resultados de los partidos.

## Preguntas que tu `domain.md` debe responder

1. ¿Qué entidad es responsable de comprobar cada regla (R1 a R6)? ¿Por qué ahí?
2. ¿Qué pasa si dos personas se apuntan a la vez a la última plaza? (No hace falta resolverlo el primer día, pero apúntalo.)
3. ¿Qué datos del jugador guardas y por qué no guardas más? ¿Por qué la edad mínima de la plataforma?
4. ¿En qué zona horaria guardas la hora del partido? ¿Qué pasaría con el cambio de hora de octubre?
5. ¿Qué decisiones has tomado donde el enunciado no decía nada?
