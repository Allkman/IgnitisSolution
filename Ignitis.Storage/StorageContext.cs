using Ignitis.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ignitis.Storage
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options) { }

        public DbSet<PowerPlant> PowerPlants { get; set; }
        public void Seed()
        {
            Seeds.PowerPlantsSeed.Seed(this);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PowerPlantConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
