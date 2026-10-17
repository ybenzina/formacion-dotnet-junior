# Calidad: el quality gate de SonarQube Cloud

En el reto, y después en el proyecto real, el **quality gate** de SonarQube Cloud es **bloqueante**: la rama `main` tiene la regla *Require status checks to pass*, así que un PR que no supere el gate **no se puede fusionar**.

En `court-connect` el análisis se conecta el viernes 23 (Semana 7, Ejercicio 5). A partir de ese PR, todos pasan por el gate. Los PR de lunes a jueves todavía no se analizan, pero sus criterios de aceptación ya están pensados para cumplirlo: así el viernes no hay sorpresas.

## Son dos checks, no uno

En cada PR aparecen dos verificaciones separadas, y el ruleset de `main` exige **las dos**:

| Check | Quién lo publica | Qué significa si falla |
|---|---|---|
| El job de la CI (por ejemplo, `Build and analyze`) | GitHub Actions | **No compila o fallan los tests.** Arréglalo en el código o en los tests |
| `SonarCloud Code Analysis` | La app de SonarQube Cloud, cuando el servidor termina de procesar el análisis | **El código funciona, pero no llega al listón de calidad.** Mira el informe: cobertura, duplicación, bugs o hotspots |

**Que la Action esté en verde no significa que el ejercicio esté aceptado.** El job solo compila, ejecuta los tests y *envía* el análisis; no espera al veredicto. El veredicto del quality gate es el segundo check, que llega unos minutos después. Comprueba siempre los dos.

## Solo cuenta lo que tú añades o cambias

El gate es el **Sonar way** por defecto y **solo mide el código nuevo**: lo que el PR añade o modifica respecto a `main`. El código que ya existía no cuenta. No se arrastra deuda anterior: lo que se pide es que **lo que tocas quede limpio**.

El objetivo es formativo, no punitivo. Si el gate falla, el análisis te dice exactamente qué línea y por qué: léelo como una revisión más.

## Umbrales

| Condición | Umbral |
|---|---|
| Fiabilidad del código nuevo | A (sin bugs Major o superiores) |
| Seguridad del código nuevo | A |
| Mantenibilidad del código nuevo | A |
| Cobertura del código nuevo | ≥ 80 % |
| Duplicación del código nuevo | ≤ 3 % |
| Security hotspots revisados | 100 % |

## Cómo cumplirlo sin pelearte con él

1. **Tests desde el principio.** Cada enunciado dice qué casos cubrir. Escríbelos con el código, no al final: llegar al 80 % el último día es mucho más caro.
2. **`[Theory]` con `[InlineData]` antes que `[Fact]` copiados.** Los tests también cuentan para la duplicación. Diez `[Fact]` casi iguales disparan la métrica; un `[Theory]` con diez filas, no.
3. **Extrae lo común.** Si dos métodos se parecen mucho, probablemente falta una función compartida. Si la duplicación es intencionada (por ejemplo, para comparar dos enfoques), dilo y justifícalo en el PR.
4. **Lo que compares con la IA no se sube.** Su versión va como comentario o en la sección «Comparación con IA» del PR, no como código en el repo.
5. **Excluye solo el código generado.** Las migraciones de EF Core las genera la herramienta, se repiten mucho y no se prueban con tests unitarios: se excluyen del análisis (`**/Migrations/**`). Cualquier otra exclusión hay que justificarla en el PR; excluir código para aprobar el gate no vale.
6. **Revisa los security hotspots.** No siempre son fallos: son puntos que una persona tiene que mirar. Márcalos como revisados con una explicación en SonarQube Cloud.
7. **Mira el análisis en local.** La extensión *SonarQube for IDE* de VS Code muestra muchos de los mismos problemas mientras escribes.

## Para quien redacta enunciados

- Todo ejercicio con código **pide tests explícitamente**, indicando qué casos cubrir, en cantidad suficiente para el 80 % de lo nuevo.
- Los ejercicios comparativos («resuélvelo con `lock`, luego con `Interlocked`…») generan bloques casi idénticos. Pide que se extraiga la parte común, o avisa de que la duplicación es intencionada y se justificará en el PR.
- Orienta los tests hacia `[Theory]` con `[InlineData]`.
- Incluye estos umbrales en los criterios de aceptación, para que se sepa de antemano contra qué se mide.
