using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Professor> Professores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }
    }
}
public class Professor
{
    public int ProfessorId { get; set; } // Chave Primária
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public string Bio { get; set; }
}