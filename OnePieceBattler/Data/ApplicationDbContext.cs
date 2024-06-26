using Microsoft.EntityFrameworkCore;
using OnePieceBattler.Models;
// The ApplicationDbContext.cs file should be configured to define the context class that Entity Framework Core will use to interact with the database. This file should include DbSet properties for each model you want to query and save to the database. Additionally, it can be configured to seed initial data if necessary.
namespace OnePieceBattler.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(){}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties for each model
        public DbSet<Character> Characters { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Battle> Battles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Luffy", Description= "Monkey D. Luffy",ImagePath= "/images/characters/luffy.png", Health = 100, AttackPower = 20, DefensePower = 10},
                new Character {Id = 2, Name = "Zoro", Description = "Zoro the Pirate Hunter", ImagePath = "/images/characters/zoro.png", Health = 200, DefensePower= 10},
                new Character { Id = 3, Name = "Marco", Description= "Marco the Phoenix, Hybrid From",ImagePath= "/images/characters/marco_hybrid.png", Health = 100, AttackPower = 20, DefensePower = 10},
                new Character {Id = 4, Name = "Gol D. Roger", Description = "Gol D. Roger, The Pirate King", ImagePath = "/images/characters/roger.png", Health = 200, DefensePower= 10},
                new Character {Id = 5, Name = "Donquixote Doflaming", Description= "Heavenly Yaksha",ImagePath= "/images/characters/doflamingo.png", Health = 100, AttackPower = 20, DefensePower = 10},
                new Character {Id = 6, Name = "Marco", Description = "Marco the Phoenix, Zoan Form", ImagePath = "/images/characters/marco_zoan.png", Health = 200, DefensePower= 10}
            );
            modelBuilder.Entity<Move>().HasData(
                new Move { Id = 1, Name= "Punch", MovePower= 10},
                new Move { Id = 2, Name= "Slash", MovePower= 20}
            );
        }
    }
}
//This ApplicationDbContext.cs file is now configured to interact with the database, seed initial data, and provide DbSet properties for querying and updating data. Make sure to adjust the namespaces (YourNamespace) accordingly to match your project structure.