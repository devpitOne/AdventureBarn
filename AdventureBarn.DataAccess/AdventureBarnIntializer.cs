using System.Data.Entity;

namespace AdventureBarn.DataAccess
{
    public class AdventureBarnInitializer : DropCreateDatabaseIfModelChanges<AdventureBarnContext>
    {
        protected override void Seed(AdventureBarnContext context)
        {
            //If we wanted some permanent default values, such as database enumerations
            //we could put them here, however I would always use database scripts
            context.SaveChanges();
        }
    }
}

