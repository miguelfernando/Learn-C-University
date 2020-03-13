using System.Data.Entity;

namespace appSchool.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=AppDbContext")
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
    }
}