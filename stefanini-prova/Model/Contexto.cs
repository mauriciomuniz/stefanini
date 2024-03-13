using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace stefanini_prova.Model
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            :base(options)
        { 
        

        }

        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);

        }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Contexto>();

            builder.UseNpgsql("User ID=stefaniniprova;Password=stefaniniprova;Host=localhost;Port=5432;Database=stefaniniprova",
                x => x.MigrationsHistoryTable("__ef_historico_migrations"));

            return new Contexto(builder.Options);
        }
    }

}
