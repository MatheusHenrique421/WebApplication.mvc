using Microsoft.EntityFrameworkCore;
using WebApplication.mvc.Models;

namespace WebApplication.mvc.Data
{
	public class ContextBase : DbContext
	{
		public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

		#region Db set's
		public DbSet<Instrutor> Instrutor { get; set; }
		public DbSet<Inscrito> Inscrito { get; set; }
		public DbSet<Live> Live { get; set; }
		public DbSet<Inscricao> Inscricoes { get; set; }
		#endregion

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Cada live poderá ter diversos inscritos.
			modelBuilder.Entity<Live>().HasMany(live => live.Inscritos).WithOne(inscrios => inscrios.Live);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(connectionString: @"Server=MHS421;Database=teste;Trusted_Connection=True;");
				base.OnConfiguring(optionsBuilder);
			}
		}

	}
}


