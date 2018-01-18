using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.DbModels.Models;

namespace Examination.DbModels.DataContext
{
    public class ExaminationContext : DbContext
    {
        public ExaminationContext()
            : base("name=ExaminationDbConectionString")
        {

        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Goal>()
                        .HasRequired(c => c.Lesson)
                        .WithMany(c=>c.Goals)
                        .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
