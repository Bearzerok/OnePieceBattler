using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnePieceBattler.Models
{
    public class ShipUpgrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for the upgrade
        public string Name { get; set; } // Name of the upgrade
        public string Description { get; set; } // Description of the upgrade
        public UpgradeType Type { get; set; } // Type of upgrade (e.g., Speed, Durability, Weapons)
        public double EffectValue { get; set; } // Value of the effect provided by the upgrade
        //TODO: Add foreign key to Ship and other models
    }

    public enum UpgradeType
    {
        Speed,
        Durability,
        Weapons,
        CargoCapacity,
        CrewCapacity
    }

}