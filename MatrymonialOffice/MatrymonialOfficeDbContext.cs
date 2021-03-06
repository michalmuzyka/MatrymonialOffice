using System.Linq;
using System.Windows.Forms.VisualStyles;
using Bogus;
using MatrymonialOffice.Data;
using Microsoft.EntityFrameworkCore;

namespace MatrymonialOffice
{
    public class MatrymonialOfficeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:partykliner.database.windows.net,1433;Initial Catalog=PartyKLINerDB;Persist Security Info=False;User ID=elitmownia;Password=Test1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = 1;
            var stock = new Faker<User>()
                .RuleFor(m => m.Id, f => ids++)
                .RuleFor(m => m.Name, f => f.Person.FullName)
                .RuleFor(m => m.Age, f => f.Random.Int(18, 100))
                .RuleFor(m => m.Attractiveness, f => f.Random.Int(0,10))
                .RuleFor(m => m.Height, f => f.Random.Int(130, 230))
                .RuleFor(m => m.Earnings, f => f.Random.Int(0, 100000))
                .RuleFor(m => m.Gender, f => f.PickRandom<Gender>())
                .RuleFor(m => m.Education, f => f.PickRandom<Education>())
                .RuleFor(m => m.Profession, f => f.PickRandom<Profession>())
                .RuleFor(m => m.Religion, f => f.PickRandom<Religion>())
                .RuleFor(m => m.Longitude, f => f.Address.Longitude(20.617532, 21.417532))
                .RuleFor(m => m.Latitude, f => f.Address.Latitude(51.829675, 52.629675))
                .RuleFor(m => m.FamilyImportance, f => f.Random.Int(0, 5))
                .RuleFor(m => m.CarrerImportance, f => f.Random.Int(0, 5))
                .RuleFor(m => m.HobbyImportance, f => f.Random.Int(0, 5))
                .RuleFor(m => m.TravellingImportance, f => f.Random.Int(0, 5))
                .RuleFor(m => m.SpiritualityImportance, f => f.Random.Int(0, 5))
                .RuleFor(m => m.PartyingImportance, f => f.Random.Int(0, 5))
                .RuleFor(m => m.SelfImprovementImportance, f => f.Random.Int(0, 5));

            // generate 100 items
            modelBuilder
                .Entity<User>()
                .HasData(stock.GenerateBetween(1000, 1000));
        }

        public DbSet<User> Users { get; set; }
    }
}
