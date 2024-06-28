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
        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<Island> Islands { get; set; }
        public DbSet<IslandEvent> IslandEvents { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipWeapon> ShipWeapons { get; set; }
        public DbSet<ShipUpgrade> ShipUpgrades { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestObjective> QuestObjectives { get; set; }
        public DbSet<QuestCharacters> QuestCharacters { get; set; }
        public DbSet<QuestLog> QuestLogs{ get; set; }
        public DbSet<Reward> Rewards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestCharacters>()
            .HasKey(qc => qc.QuestCharactersId);

            // Configure the relationship between Quest and Character
            modelBuilder.Entity<Quest>()
                .HasOne(q => q.AssignedCharacter)
                .WithMany(c => c.Quests)
                .HasForeignKey(q => q.CharacterId)
                .OnDelete(DeleteBehavior.Restrict); // Or DeleteBehavior.Cascade if you want deletion cascading
            
            // Configure the relationship between Quest and QuestCharacters
            modelBuilder.Entity<Quest>()
                .HasOne(q => q.QuestCharacters)
                .WithOne(qc => qc.Quest)
                .HasForeignKey<QuestCharacters>(qc => qc.QuestId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<QuestCharacters>()
            .HasMany(qc => qc.QuestReceivers)
            .WithMany()
            .UsingEntity(j => j.ToTable("QuestCharacter_Receivers"));



            base.OnModelCreating(modelBuilder);

            // Seed data needs primary keys to be set
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Luffy", Description= "Monkey D. Luffy",ImagePath= "/images/characters/luffy.png", Health = 100, AttackPower = 20, DefensePower = 10},
                new Character {Id = 2,Name = "Zoro", Description = "Zoro the Pirate Hunter", ImagePath = "/images/characters/zoro.png", Health = 200, DefensePower= 10},
                new Character { Id = 3,Name = "Marco", Description= "Marco the Phoenix, Hybrid From",ImagePath= "/images/characters/marco_hybrid.png", Health = 100, AttackPower = 20, DefensePower = 10},
                new Character {Id = 4,Name = "Gol D. Roger", Description = "Gol D. Roger, The Pirate King", ImagePath = "/images/characters/roger.png", Health = 200, DefensePower= 10},
                new Character {Id = 5,Name = "Donquixote Doflaming", Description= "Heavenly Yaksha",ImagePath= "/images/characters/doflamingo.png", Health = 100, AttackPower = 20, DefensePower = 10},
                new Character {Id = 6,Name = "Marco", Description = "Marco the Phoenix, Zoan Form", ImagePath = "/images/characters/marco_zoan.png", Health = 200, DefensePower= 10}
            );
            modelBuilder.Entity<Move>().HasData(
                new Move { Id= 1, Name= "Punch", MovePower= 10},
                new Move { Id = 2,Name= "Slash", MovePower= 20}
            );

             modelBuilder.Entity<Quest>().HasData(
                new Quest
                {
                    Id = 1,
                    Title = "Find the One Piece",
                    Description = "Embark on a journey to find the legendary One Piece treasure.",
                    Status = QuestStatus.NotStarted,
                    CharacterId = 1 // Assign to Luffy
                },
                new Quest
                {
                    Id = 2,
                    Title = "Train with Mihawk",
                    Description = "Train with the world's greatest swordsman to improve sword skills.",
                    Status = QuestStatus.NotStarted,
                    CharacterId = 2 // Assign to Zoro
                }
            );



        }
    }
}
//This ApplicationDbContext.cs file is now configured to interact with the database, seed initial data, and provide DbSet properties for querying and updating data. Make sure to adjust the namespaces (YourNamespace) accordingly to match your project structure.