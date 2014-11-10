using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses
{
	[Table("City")]
	public class City : IEntity
	{
		public City()
		{
		this.Persons = new HashSet<Person>();
		}

		[Column("ID")]
		public int ID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("PostalCode")]
		public string PostalCode { get; set; }

		public virtual ICollection<Person> Persons { get; set; }
	}
}