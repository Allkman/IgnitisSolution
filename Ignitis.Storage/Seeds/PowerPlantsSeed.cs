using Ignitis.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ignitis.Storage.Seeds
{
    internal class PowerPlantsSeed
    {
        public static readonly List<PowerPlant> SeedPowerPlants = new()
        {
            new PowerPlant
            {
                Id = Guid.Parse("63CF771B-4159-4394-8A7D-700408BDC9B9"),
                Owner = "Vardenis Pavardenis",
                Power = 9.6M,
                ValidFrom = DateTimeOffset.UtcNow.AddYears(-2),
                ValidTo = DateTimeOffset.UtcNow.AddYears(-1),
            },
            new PowerPlant
            {
                Id = Guid.Parse("EA0E25D8-E02F-40DC-BA28-6D0EC65A9D35"),
                Owner = "Ignitis Energy",
                Power = 150.3M,
                ValidFrom = DateTimeOffset.UtcNow.AddYears(-1),
                ValidTo = DateTimeOffset.UtcNow.AddDays(-20),
            },
            new PowerPlant
            {
                Id = Guid.Parse("5A078DD7-28C9-4B5C-AA74-2AF75E12B167"),
                Owner = "Kaunas Power",
                Power = 75.5M,
                ValidFrom = DateTimeOffset.UtcNow.AddMonths(-18),
                ValidTo = DateTimeOffset.UtcNow.AddDays(-200),
            },
            new PowerPlant
            {
                Id = Guid.Parse("4ACF96DC-E84C-449A-A3CC-EE2AEE2F5BD0"),
                Owner = "Vilnius Energy",
                Power = 120.0M,
                ValidFrom = DateTimeOffset.UtcNow.AddYears(-3),
                ValidTo = DateTimeOffset.UtcNow.AddDays(-50),
            },
            new PowerPlant
            {
                Id = Guid.Parse("23FBAB01-342E-441C-B244-A5610E963AC4"),
                Owner = "Panevezys Power",
                Power = 60.2M,
                ValidFrom = DateTimeOffset.UtcNow.AddMonths(-6),
                ValidTo = DateTimeOffset.UtcNow.AddMonths(-3),
            },
            new PowerPlant
            {
                Id = Guid.Parse("23FBAB01-342E-441C-B244-A5610E963AD4"),
                Owner = "Lithuania Energy",
                Power = 200.0M,
                ValidFrom = DateTimeOffset.UtcNow.AddYears(-4),
                ValidTo = DateTimeOffset.UtcNow.AddMonths(-1),
            },
            new PowerPlant
            {
                Id = Guid.Parse("23FBAB01-342E-441C-B244-A5610E963AC1"),
                Owner = "Solaris Energy",
                Power = 45.1M,
                ValidFrom = DateTimeOffset.UtcNow.AddMonths(-3),
                ValidTo = null
            },
            new PowerPlant
            {
                Id = Guid.Parse("23FBAB01-342E-441C-B244-A5610E963AC9"),
                Owner = "WindPower Ltd",
                Power = 90.7M,
                ValidFrom = DateTimeOffset.UtcNow.AddYears(-2),
                ValidTo = null
            },
            new PowerPlant
            {
                Id = Guid.Parse("23FBAB01-342E-441C-B244-A5610E963AA4"),
                Owner = "HydroEnergy",
                Power = 110.0M,
                ValidFrom = DateTimeOffset.UtcNow.AddMonths(-12),
                ValidTo = null
            },
            new PowerPlant
            {
                Id = Guid.Parse("23FBAB01-342E-441C-B244-A5610E963AB4"),
                Owner = "Renewable Power Co",
                Power = 130.5M,
                ValidFrom = DateTimeOffset.UtcNow.AddYears(-1),
                ValidTo = null
            }
        };

        public static void Seed(StorageContext context)
        {
            var tableExists = context.Database
                .SqlQuery<int>($"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'POWERPLANTS'")
                .ToList().Any();

            if (!tableExists)
            {
                throw new InvalidOperationException("PowerPlants table does not exist in the database.");
            }

            foreach (var seedPowerPlant in SeedPowerPlants)
            {
                var existingPowerPlant = context.PowerPlants
                    .IgnoreQueryFilters()
                    .FirstOrDefault(p => p.Id == seedPowerPlant.Id);

                if (existingPowerPlant != null)
                {
                    existingPowerPlant.Owner = seedPowerPlant.Owner;
                    existingPowerPlant.Power = seedPowerPlant.Power;
                    existingPowerPlant.ValidFrom = seedPowerPlant.ValidFrom;
                    existingPowerPlant.ValidTo = seedPowerPlant.ValidTo;
                }
                else
                {
                    context.PowerPlants.Add(seedPowerPlant);
                }
            }

            context.SaveChanges();
        }
    }
}
