# Snippets de código - CourtConnect

## Entity Event (Domain)
```csharp
public class Event
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid? LocationId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public int? MaxPlayers { get; private set; }
    public Guid? CreatedByUserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
```

## DbContext
```csharp
public class CourtConnectDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RSVP> RSVPs { get; set; }
}
```

## IEventRepository
```csharp
public interface IEventRepository
{
    Task<Event?> GetByIdAsync(Guid id);
    Task<IEnumerable<Event>> GetUpcomingAsync(int page = 1, int pageSize = 20);
    Task AddAsync(Event ev);
    Task UpdateAsync(Event ev);
    Task DeleteAsync(Guid id);
}
```
