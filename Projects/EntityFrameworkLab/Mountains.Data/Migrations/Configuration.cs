using Mountains.Models;

namespace Mountains.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mountains.Data.MountainsContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Mountains.Data.MountainsContext context)
        {
            if (!context.Countries.Any())
            {
                Country bulgaria = new Country()
                {
                    Name = "Bulgaria",
                    CountryCode = "BG"
                };
                context.Countries.Add(bulgaria);

                Country germany = new Country()
                {
                    Name = "Germany",
                    CountryCode = "GR"
                };
                context.Countries.Add(germany);

                Mountain rila = new Mountain()
                {
                    Name = "Rila",
                    Countries = {bulgaria},
                };
                context.Mountains.Add(rila);

                Mountain rhodopes = new Mountain()
                {
                    Name = "Rhodopes",
                    Countries = { bulgaria }
                };
                context.Mountains.Add(rhodopes);

                Mountain pirin = new Mountain()
                {
                    Name = "Pirin",
                    Countries = { bulgaria },
                    
                };
                context.Mountains.Add(pirin);

                Peak musala = new Peak()
                {
                    Name = "Musala",
                    Elevation = 2925,
                    Mountain = rila
                };
                context.Peaks.Add(musala);

                Peak malyovica = new Peak()
                {
                    Name = "Malyovica",
                    Elevation = 2729,
                    Mountain = rila
                };
                context.Peaks.Add(malyovica);

                Peak vihrin = new Peak()
                {
                    Name = "Vihrin",
                    Elevation = 2914,
                    Mountain = pirin
                };
                context.Peaks.Add(vihrin);
                context.SaveChanges();
            }
        }
    }
}
