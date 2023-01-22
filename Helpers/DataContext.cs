using Microsoft.EntityFrameworkCore;
using webapiCrud.Models.Todo;

namespace WebApi.Helpers;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("webapiCrudDatabase"));
    }

    public DbSet<Todo> Todos { get; set; }
}