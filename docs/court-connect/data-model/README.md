# Modelo de datos - CourtConnect

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
