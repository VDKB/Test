using System.Data.Entity;

namespace BaseDataLayer
{
	public class BaseContext<T> : DbContext where T : DbContext
	{
		static BaseContext()
		{
			Database.SetInitializer<T>(null);
		}
		protected BaseContext()
			: base("name=TestDatabase")
		{ }

	}
}
