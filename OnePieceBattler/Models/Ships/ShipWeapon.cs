using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnePieceBattler.Models
{
    public class ShipWeapon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for the weapon
        public string Name { get; set; } // Name of the weapon
        public string Description { get; set; } // Description of the weapon
        public double Damage { get; set; } // Damage dealt by the weapon
        public double Range { get; set; } // Range of the weapon
        public int AmmoCapacity { get; set; } // Ammo capacity of the weapon
        public int CurrentAmmo { get; set; } // Current ammo in the weapon
    }
}