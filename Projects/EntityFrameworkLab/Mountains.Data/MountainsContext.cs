using System.Data.Entity;
using Mountains.Data.Migrations;
using Mountains.Models;

namespace Mountains.Data
{
    public class MountainsContext : DbContext
    {
        
        public MountainsContext()
            : base("name=MountainsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MountainsContext, Configuration>());
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Peak> Peaks  { get; set; }
        public virtual DbSet<Mountain> Mountains{ get; set; }
    }

    
}