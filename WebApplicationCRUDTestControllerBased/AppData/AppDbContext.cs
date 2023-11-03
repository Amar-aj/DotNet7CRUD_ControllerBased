using Microsoft.EntityFrameworkCore;
using WebApplicationCRUDTestControllerBased.Models;

namespace WebApplicationCRUDTestControllerBased.AppData;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
    {

    }
    public DbSet<Student> Students { get; set; }
}
