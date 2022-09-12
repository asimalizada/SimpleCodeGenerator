using System.Data.Entity;
using Entities.Concrete;

namespace DataAccess.Concrete
{
	public class MainContext
	{
		#region DbSets

		public DbSet<Ox> Oxen { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Check> Checks { get; set; }
		public DbSet<Temp> Temps { get; set; }
		public DbSet<Test> Tests { get; set; }

		#endregion
	}
}