# Costes cloud: hoja de apoyo para Yamel

Solución del taller de estimación de la [sesión Azure](masterclass-cloud-azure.md#taller-de-costes-de-courtconnect), no del ejercicio de programación. Datos ficticios e hipótesis no medidas. No se han creado recursos ni consultado precios de una cuenta real.

## Contexto que debe quedar registrado

- Región: `West Europe`; moneda: EUR; escenario: 30 días, 720 horas.
- Plan: Container Apps Consumption, sin perfiles Dedicated ni red privada con cargos adicionales en este supuesto.
- Web: mínimo 0, máximo 1; API: mínimo 0, máximo 2. Ambas en el mismo entorno; API con ingress interno, invocada por el servidor web.
- Cada réplica: 0,25 vCPU y 0,5 GiB. Las duraciones incluyen arranque y cierre o espera de reducción de réplicas.
- Base: `CourtConnect.Worker`, host continuo construido en la Parte III, mínimo 1, máximo 1, 720 horas activas supuestas. Consulta SQL, sin HTTP ni ingress y sin aplicar migraciones. Se despliega sin convertirlo en Job.
- Alternativa Job: cada cinco minutos UTC, una réplica, 30 segundos por ejecución; sin reintentos, fallos ni solapamientos en la comparación. Sustituye al worker, no se suma ni se exige implementarlo. No usa límites `minReplicas` de app.
- Franquicia completa disponible: ninguna otra carga de la suscripción la ha gastado. Comprobar esta condición en un presupuesto real.
- Fecha de consulta de precios: **X, por completar al preparar la sesión**. No es una fecha de convocatoria ni un precio ya verificado.

## Cantidades comprobadas

Ejecuciones por día: `24 × 60 / 5 = 288`. Por mes: `288 × 30 = 8.640`.

Tiempo del Job: `8.640 × 30 = 259.200 s = 72 h`. Cada ejecución consume `0,25 × 30 = 7,5 vCPU-s` y `0,5 × 30 = 15 GiB-s`.

| Recurso | Horas-réplica normal | vCPU-s normal | GiB-s normal | Horas-réplica pico | vCPU-s pico | GiB-s pico |
| --- | --- | --- | --- | --- | --- | --- |
| Web | 30 | 27.000 | 54.000 | 32 | 28.800 | 57.600 |
| API, incluida réplica adicional | 30 | 27.000 | 54.000 | 34 | 30.600 | 61.200 |
| Worker continuo base | 720 | 648.000 | 1.296.000 | 720 | 648.000 | 1.296.000 |
| Total base con worker | 780 | 702.000 | 1.404.000 | 786 | 707.400 | 1.414.800 |
| Job alternativo, aislado | 72 | 64.800 | 129.600 | 72 | 64.800 | 129.600 |
| Total sustituyendo worker por Job | 132 | 118.800 | 237.600 | 138 | 124.200 | 248.400 |

Fórmulas: `vCPU-s = horas-réplica × 3.600 × 0,25`; `GiB-s = horas-réplica × 3.600 × 0,5`. Todas estas cantidades son activas; no hay horas idle en el supuesto base.

**Control del calendario:** web normal `30 + 690 = 720 h`; web pico `32 + 688 = 720 h`. La API base tiene los mismos tiempos y añade 2 horas-réplica durante el pico. No sumamos 31 días. El Job ocupa un 10 % del mes en vez de mantener el proceso vivo el 100 %; no deducir de esto que cualquier Job costará diez veces menos, porque hay franquicias y otras partidas.

## Después de la franquicia

La [facturación oficial](https://learn.microsoft.com/en-us/azure/container-apps/billing) incluye, por suscripción y mes natural, 180.000 vCPU-s, 360.000 GiB-s y 2 millones de peticiones HTTP externas. Son medidores distintos: no intercambiar sus unidades ni aplicar la franquicia por cada app.

| Escenario | vCPU-s después de franquicia | GiB-s después de franquicia | Peticiones externas | Peticiones después de franquicia |
| --- | --- | --- | --- | --- |
| Base normal con worker | 522.000 | 1.044.000 | 6.000 | 0 |
| Base pico con worker | 527.400 | 1.054.800 | 7.800 | 0 |
| Alternativa normal con Job | 0 | 0 | 6.000 | 0 |
| Alternativa pico con Job | 0 | 0 | 7.800 | 0 |

Para cada medidor: `facturable = máximo(0, consumo - franquicia disponible)`. El cómputo del Job participa en el total Consumption; no se le asigna otra franquicia. Si la calculadora ya la aplica, no volver a restarla.

Peticiones normales: `30 × 200 = 6.000`. Pico: `29 × 200 + 2.000 = 7.800`. Las llamadas web → API dentro del entorno no se suman al medidor HTTP externo, aunque sí consumen cómputo. Una API llamada desde el navegador cambiaría esa hipótesis. Jobs no tienen ingress HTTP.

## Precios por consultar

No inventar importes. La tabla se completa con la [calculadora de Azure](https://azure.microsoft.com/en-us/pricing/calculator/) y se guarda su exportación con región, moneda, SKU y condiciones. Una cantidad pendiente no vale cero.

| Precio o selección | Valor | Uso |
| --- | --- | --- |
| Precio activo por vCPU-s, `Pcpu` | Consultar en la calculadora a fecha X | Multiplicar por vCPU-s facturables |
| Precio activo por GiB-s, `Pmem` | Consultar en la calculadora a fecha X | Multiplicar por GiB-s facturables |
| Precio por millón de peticiones, `Phttp` | Consultar en la calculadora a fecha X | Multiplicar por peticiones facturables / 1.000.000 |
| Azure SQL, SKU y modalidad exactos | Elegir con Yamel y consultar a fecha X | Mismo nivel en normal y pico; 1 GB de datos no determina capacidad |
| Azure SQL, cómputo, almacenamiento y copias | Consultar en la calculadora a fecha X | Registrar qué incluye el nivel y qué se cobra aparte |
| Registro, nivel y 1 GB de imágenes | Consultar en la calculadora a fecha X | Tarea posterior; puede tener coste fijo |
| Key Vault, 300 / 330 operaciones | Consultar en la calculadora a fecha X | Tarea posterior; comprobar unidad de cobro |
| Telemetría, 0,30 / 0,34 GB y retención elegida | Consultar en la calculadora a fecha X | Tarea posterior; no duplicar ingesta |
| Egreso, 1 / 1,2 GB | Consultar en la calculadora a fecha X | Tarea posterior; comprobar destino y franquicia |

Con franquicia disponible, cómputo y peticiones de la alternativa Job tienen cantidad facturable cero según estos supuestos, **no coste total de aplicación cero**. El escenario base con worker continuo da:

- Normal: `522.000 × Pcpu + 1.044.000 × Pmem`.
- Pico: `527.400 × Pcpu + 1.054.800 × Pmem`.

Añadir SQL para obtener el **subtotal de clase** y luego los apoyos para el total estimado. No añadir de nuevo almacenamiento o copias ya incluidos en la tarifa SQL. Si se usa oferta gratuita, registrar límites y respuesta al agotarlos. Si la calculadora usa 730 horas normalizadas, ajustar o declarar la diferencia respecto al mes de 720 horas de este ejercicio.

## Preguntas para la revisión

- ¿Puede la caducidad tolerar cinco minutos más el tiempo de arranque y proceso? La frecuencia debe satisfacer la regla, no solo el coste.
- ¿Qué sucede si una ejecución dura más que el intervalo o se repite tras fallar? `parallelism = 1` no garantiza exclusión entre ejecuciones distintas.
- ¿Cuánto cambia si el Job tarda 60 s? Pasa a 144 h; el normal suma 204 h, 183.600 vCPU-s y 367.200 GiB-s, antes de franquicia.
- ¿Puede la web bajar a cero si mantiene circuitos Interactive Server abiertos? Hay que medir; no dar por cumplidas las horas supuestas.
- ¿Necesitamos mínimo 1 para disponibilidad? Recalcular y comprobar condiciones idle; no convertir automáticamente todas las horas sin usuarios en idle.
- ¿Qué falta para un presupuesto real? Capacidad medida, nivel SQL elegido, tarifas vigentes, otros consumos de la suscripción, operación, permisos, red y requisitos de recuperación.

**Cierre esperado:** Driss explica las unidades, distingue gratuito de pendiente y sabe qué hipótesis comprobar. No se exige acertar un importe que aún no se ha consultado.
