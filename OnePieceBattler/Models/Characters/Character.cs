using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePieceBattler.Models
{
    public class Character{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        [Required]
        public string Name {get; set;} 
        [Required]
        public string Description{get; set;}
        [Required]
        public string ImagePath{get; set;}
        public int Health{get; set;}
        public int AttackPower{get; set;}
        public int CriticalAttackMultiplier{get; set;}
        public int DefensePower {get; set;}
        public int ArmamentHakiPower{get; set;}
        public int ObservationHakiPower{ get; set;}
        public int ConquerorHakiPower{get;set;}
        public string? DevilFruit{get; set;}
        public DevilFruitType DevilFruitType{get; set;}
        public bool? IsAwakened{get; set;}
        public int Speed{get; set;}
        public int BattleIq{get; set;}
        public int Luck{get; set;}
        public int Bounty{get; set;}
        public List<Move>? Moves{get; set;}
        public List<Character>? Nakamas{get; set;}
        public int Level{get; set;}
        public int Experience{get; set;}
        public float Gold{get; set;}
        public int ExperienceToNextLevel{get; set;}
        public int ExperienceToNextLevelBase{get; set;}
        public List<Item>? Inventory{get; set;}
        public bool IsDefeated{get; set;}
        public string ?CrewName{get; set;}
        public string ?CrewRole{get; set;}
        public string ?JollyRogerImagePath{get; set;}
        public int CharacterVersion{get; set;}
        public int IsDefinitiveVersion{get; set;}
        public bool IsPlayable{get; set;}
        public bool IsMaxLevel{get; set;}
        // Navigation property for related Quests
        public ICollection<Quest>? Quests { get; set; }
}

public enum DevilFruitType{
    Paramecia,
    Zoan,
    MythicalZoan,
    Logia
}
}