using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Fifa.Core.Models;

namespace Fifa.Core.Repositories.Impl
{
    public class MainContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStats> UserStats { get; set; }

        // TODO: remove this hack
#if DEBUG
        static  MainContext()
        {
            //�� ���� ��� ������. ������ ��� ���-�� ����� ����� � ������ �� ��������� ���� � ����� ���� ������.
            // thats why I wrote remove this hack! :)
            // btw this is not production code yet, is it?
            //Database.SetInitializer(new DropCreateDatabaseAlways<MainContext>());
        }
#endif

        public MainContext()
            : base("name=fifa")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
