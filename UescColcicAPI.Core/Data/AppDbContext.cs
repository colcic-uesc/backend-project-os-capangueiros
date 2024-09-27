using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Professor> Professores { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<StudentSkill> StudentSkills { get; set; }
    public DbSet<ProjectSkill> ProjectSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentSkill>()
            .HasKey(ss => new { ss.StudentId, ss.SkillId });

        modelBuilder.Entity<ProjectSkill>()
            .HasKey(ps => new { ps.ProjectId, ps.SkillId });

        modelBuilder.Entity<StudentSkill>()
            .HasOne(ss => ss.Student)
            .WithMany(s => s.StudentSkills)
            .HasForeignKey(ss => ss.StudentId);

        modelBuilder.Entity<StudentSkill>()
            .HasOne(ss => ss.Skill)
            .WithMany(s => s.StudentSkills)
            .HasForeignKey(ss => ss.SkillId);

        modelBuilder.Entity<ProjectSkill>()
            .HasOne(ps => ps.Project)
            .WithMany(p => p.ProjectSkills)
            .HasForeignKey(ps => ps.ProjectId);

        modelBuilder.Entity<ProjectSkill>()
            .HasOne(ps => ps.Skill)
            .WithMany(s => s.ProjectSkills)
            .HasForeignKey(ps => ps.SkillId);
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

public class Student
{
    public int StudentId { get; set; } // Chave Primária
    public string Registration { get; set; } // Chave Única
    public string Name { get; set; }
    public string Email { get; set; }
    public string Course { get; set; }
    public string Bio { get; set; }

    public ICollection<StudentSkill> StudentSkills { get; set; }
}

public class Project
{
    public int ProjectId { get; set; } // Chave Primária
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int ProfessorId { get; set; } // Chave Estrangeira
    public Professor Professor { get; set; }

    public ICollection<ProjectSkill> ProjectSkills { get; set; }
}

public class Skill
{
    public int SkillId { get; set; } // Chave Primária
    public string Title { get; set; }
    public string Description { get; set; }

    public ICollection<StudentSkill> StudentSkills { get; set; }
    public ICollection<ProjectSkill> ProjectSkills { get; set; }
}

public class StudentSkill
{
    public int StudentId { get; set; } // Chave Primária, Chave Estrangeira
    public Student Student { get; set; }

    public int SkillId { get; set; } // Chave Primária, Chave Estrangeira
    public Skill Skill { get; set; }

    public int Weight { get; set; }
}

public class ProjectSkill
{
    public int ProjectId { get; set; } // Chave Primária, Chave Estrangeira
    public Project Project { get; set; }

    public int SkillId { get; set; } // Chave Primária, Chave Estrangeira
    public Skill Skill { get; set; }

    public int Weight { get; set; }
}