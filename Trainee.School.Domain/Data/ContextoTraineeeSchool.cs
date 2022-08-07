using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trainee.School.Domain.Entidades;

namespace Trainee.School.Domain.Data
{
    public class ContextoTraineeeSchool: DbContext
    {
        public ContextoTraineeeSchool(DbContextOptions<ContextoTraineeeSchool> options):base(options) { }
        public DbSet<Aluno> Aluno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
        }

    }
}
