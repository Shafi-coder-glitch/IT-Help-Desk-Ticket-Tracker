using Microsoft.EntityFrameworkCore;

namespace HelpDeskWebNew;

public class HelpDeskContext : DbContext
{
    public HelpDeskContext(DbContextOptions<HelpDeskContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }
}
