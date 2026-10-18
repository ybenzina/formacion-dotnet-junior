# Modelo de datos — CourtConnect (versión anterior)

> Modelo de la primera versión de CourtConnect (quedadas y RSVP). El reto usa un dominio nuevo (ver `../enunciado-dominio.md`) y crea el esquema con migraciones de EF Core. Este modelo e `init.sql` quedan como referencia para comparar.

## Entidades principales (resumen)
- **User**
  - Id (GUID)
  - UserName
  - DisplayName
  - Email
  - Phone
  - CreatedAt

- **Location**
  - Id
  - Name
  - Address
  - Latitude
  - Longitude

- **Event**
  - Id
  - Title
  - Description
  - LocationId
  - StartDate
  - EndDate
  - MaxPlayers
  - CreatedByUserId
  - CreatedAt
  - IsPublic

- **RSVP**
  - Id
  - EventId
  - UserId
  - Status (Going, Maybe, Cancelled)
  - CreatedAt

## Relaciones
- Event → Location (1:1 via LocationId)
- Event → User (CreatedByUserId)
- Event ← RSVP (1:N)
- User ← RSVP (1:N)

## Archivos
- `docs/data-model/er_diagram.png` (se puede añadir el diagrama en png)
- `docs/data-model/init.sql` - script DDL inicial (Plantilla)
