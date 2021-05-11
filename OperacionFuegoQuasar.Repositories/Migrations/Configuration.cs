using OperacionFuegoQuasar.Model;
using OperacionFuegoQuasar.Transversal;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OperacionFuegoQuasar.Repositories.Context";
        }


        protected override void Seed(Context context)
        {
            foreach(var satellite in Data.satellites)
            {

                context.Satellites.AddOrUpdate(satellite);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
