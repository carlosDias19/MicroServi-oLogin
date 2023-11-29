
using DDD.Domain.ReportRadarContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<ClienteFuncionario>().HasKey(m => new { m.ClienteId, m.FuncionarioId});*/
            /*            //modelBuilder.Entity<Matricula>().HasKey(m => new { m.AlunoId, m.DisciplinaId });
                        modelBuilder.Entity<Aluno>()
                            .HasMany(e => e.Disciplinas)
                            .WithMany(e => e.Alunos)
                            .UsingEntity<Matricula>();*/


            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            /* modelBuilder.Entity<ClienteFuncionario>().UseTpcMappingStrategy();*/
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
