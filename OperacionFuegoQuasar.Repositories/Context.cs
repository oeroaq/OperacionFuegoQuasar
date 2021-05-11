using OperacionFuegoQuasar.Model;
using System;
using System.Data.Entity;

namespace OperacionFuegoQuasar.Repositories
{
    public class Context : DbContext
    {
        private readonly static string server = Environment.GetEnvironmentVariable("DB_HOST");
        private readonly static string database = Environment.GetEnvironmentVariable("DB_DATABASE");
        private readonly static string user = Environment.GetEnvironmentVariable("DB_USER");
        private readonly static string password = Environment.GetEnvironmentVariable("DB_PASS");

        public Context() : base($"Server={server};Database={database};User Id={user};Password={password};")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
        }

        public DbSet<Satellite> Satellites { get; set; }
        public DbSet<MessageSatellite> MessagesSatellites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
