using System.Data.Entity;
using BaseDataLayer;
using DomainClasses;
using DomainClasses.Mapping;

namespace PersonLayer
{
	public class PersonContext : BaseContext<PersonContext>
	{
		public DbSet<Person> Persons { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Language> Languages { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new PersonMapping());
			//modelBuilder.Entity<Language>();
			//modelBuilder.Entity<City>();
		}
	}
}
