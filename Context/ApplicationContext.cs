using CapPlacement.Models;
using CapPlacement.Enums;
using Microsoft.EntityFrameworkCore;

namespace CapPlacement.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Stage>().HasData(
                new Stage
                {
                    StageType = StageType.Applied,
                    StageName = "Applied",
                }
            );
        }

        public DbSet<ProgramDetail> Programs { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public DbSet<Application> Applications { get; set; }
    }
}
