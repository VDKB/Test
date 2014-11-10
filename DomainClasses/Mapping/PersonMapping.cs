using System.Data.Entity.ModelConfiguration;

namespace DomainClasses.Mapping
{
	public class PersonMapping : EntityTypeConfiguration<Person>
	{
		public PersonMapping()
		{
			HasRequired(f => f.Language).WithMany(f => f.Persons).HasForeignKey(f => f.LanguageID);
			HasRequired(f => f.City).WithMany(f => f.Persons).HasForeignKey(f => f.CityID);
		}
	}
}
