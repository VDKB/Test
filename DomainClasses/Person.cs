using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses
{
	[Table("Person")]
	public class Person : IEntity
	{
		[Column("ID")]
		public int ID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("FirstName")]
		public string FirstName { get; set; }
		[Column("DateOfBirth")]
		public DateTime DateOfBirth { get; set; }
		[Column("Email")]
		public string Email { get; set; }
		[Column("Street")]
		public string Street { get; set; }
		[Column("Number")]
		public string Number { get; set; }
		[Column("PhoneNumber")]
		public string PhoneNumber { get; set; }
		[Column("LanguageID")]
		public int LanguageID { get; set; }
		public virtual Language Language { get; set; }
		[Column("CityID")]
		public int CityID { get; set; }
		public virtual City City { get; set; }
	}
}