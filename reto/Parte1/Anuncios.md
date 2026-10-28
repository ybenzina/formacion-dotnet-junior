# 📢 **Reto CourtConnect · Parte I — Fundamentos**

Retomamos la formación con un reto en **tres partes** (Día 1 → Día 23), unas **4 h/día**. El proyecto real tiene prioridad 💪

🏀 **El proyecto:** CourtConnect, una app para quedar a jugar a street basketball: canchas, partidos con plazas y jugadores que se apuntan. En la Parte III llegan los torneos con pago. Repo nuevo: `DeemSoft/court-connect` (lo creas tú en el ejercicio 1).

🎯 **Objetivo**
Tocar a mano las piezas de una app .NET actual para poder **supervisar** el código que genere la IA, y acabar con un MVP desplegado que puedas enseñar.

🗓️ **Parte I (días 1 → 8): sin prisa**
1. **Días 1–2** – Repo + dominio + xUnit
2. **Días 3–4** – EF Core + SQL Server en Docker
3. **Días 5–6** – API con ASP.NET Core
4. **Día 7** – Tests de integración + GitHub Actions
5. **Día 8** – SonarCloud + **demo 1** 🎤

🗣️ **Tarea extra de descubrimiento:** habla 30–45 min con 2 o 3 personas con las que juegas. ¿Qué falla hoy con Instagram? Preguntas en el enunciado del dominio.

👨‍🏫 **Domingo después del Día 3:** masterclass de arquitectura.
🔜 **Parte II (días 9 → 16):** web con Blazor, login y roles, panel del organizador, Docker.
🔜 **Parte III (días 17 → 23):** torneos y pago con Spec-Driven Development, despliegue en Azure.

🤖 **Regla de IA**
Primero lo intentas tú, después comparas con la IA (sección «Comparación con IA» en cada PR). El `AGENTS.md` la deja en modo tutor: explica y da pistas, no soluciones.

📚 **Material**
- Enunciados: `formacion-dotnet-junior/reto/Parte1/`
- Dominio y plantillas: `docs/court-connect/`
- Flujo de Git: `ambit-escola/docs/methodology/git.md`

🚦 **Calidad**
Desde el ejercicio 5, el quality gate de SonarQube Cloud es **obligatorio para fusionar**: cobertura ≥ 80 % y duplicación ≤ 3 %, solo sobre lo que añades o cambias. Detalle en `docs/court-connect/calidad.md`.

📌 **En cada PR**
- [ ] Rama desde `main` actualizado
- [ ] `dotnet build` y `dotnet test` OK
- [ ] «Qué / Por qué / Cómo se ha comprobado / Uso de IA»
- [ ] `Closes #N` y horas reales en la issue

👨‍🏫 **Día 8:** demo de 30 min desde un clon limpio y preguntas de «explícame esta pieza». Hasta entonces, reuniones semanales de seguimiento normales.
