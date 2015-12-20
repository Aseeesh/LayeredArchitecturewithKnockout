using Nimble.Data.Configuration;
using Nimble.Models.Entity;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Nimble.Data
{

    public class Entities : DbContext
    {

        public Entities()
            : base("Entities")
        {
            // Database.SetInitializer<MineEntities>(new DropCreateDatabaseIfModelChanges<MineEntities>());
        }
        public DbSet<Employee> Employee { get; set; }
     


        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Configurations.Add(new EmployeeConfiguration()); 


        }
    }

}
