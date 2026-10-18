# 📢 **Reto CourtConnect · Semana 7 — Del dominio a la API con CI**

Retomamos la formación con un reto de **2 semanas** (19 → 30 oct), unas **4 h/día**. El proyecto real tiene prioridad 💪

🎯 **Objetivo**
Tocar a mano las piezas de una app .NET actual para poder **supervisar** el código que genere la IA. No hace falta dominarlas: hay que saber explicar qué hace cada una.

🏀 **El proyecto:** CourtConnect, campus de baloncesto con plazas, jugadores e inscripciones. Repo nuevo: `DeemSoft/court-connect` (lo creas tú el lunes).

🛠️ **Plan de la semana**
1. **L 19** – Repo + dominio + xUnit
2. **M 20** – EF Core + SQL Server en Docker
3. **X 21** – API con ASP.NET Core
4. **J 22** – Tests de integración + GitHub Actions
5. **V 23** – SonarCloud + **demo 1** 🎤

🤖 **Regla de IA**
Primero lo intentas tú, después comparas con la IA (sección «Comparación con IA» en cada PR). El `AGENTS.md` la deja en modo tutor: explica y da pistas, no soluciones.

📚 **Material**
- Enunciados: `formacion-dotnet-junior/Semana7/`
- Dominio y plantillas: `docs/court-connect/`
- Flujo de Git: `ambit-escola/docs/methodology/git.md`

🚦 **Calidad**
Desde el viernes, el quality gate de SonarQube Cloud es **obligatorio para fusionar**: cobertura ≥ 80 % y duplicación ≤ 3 %, solo sobre lo que añades o cambias. Detalle en `docs/court-connect/calidad.md`.

📌 **En cada PR**
- [ ] Rama desde `main` actualizado
- [ ] `dotnet build` y `dotnet test` OK
- [ ] «Qué / Por qué / Cómo se ha comprobado / Uso de IA»
- [ ] `Closes #N` y horas reales en la issue

👨‍🏫 **Viernes:** demo de 30 min desde un clon limpio y preguntas de «explícame esta pieza».
