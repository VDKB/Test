using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses
{
	[Table("Language")]
	public class Language : IEntity
	{
		public Language()
		{
			this.Persons = new HashSet<Person>();
		}

		[Column("ID")]
		public int ID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		public virtual ICollection<Person> Persons { get; set; }
	}
}