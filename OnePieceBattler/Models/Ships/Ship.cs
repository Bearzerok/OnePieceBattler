using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnePieceBattler.Models
{
    public class Ship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for the ship
        public string Name { get; set; } // Name of the ship
        public string Description { get; set; } // Description of the ship
        public string Type { get; set; } // Type of ship (e.g., Sloop, Brigantine, Galleon)
        public int CrewCapacity { get; set; } // Maximum number of crew members
        public int CargoCapacity { get; set; } // Maximum cargo capacity
        public double Speed { get; set; } // Speed of the ship
        public double Durability { get; set; } // Durability of the ship (health)
        public double CurrentDurability { get; set; } // Current durability of the ship
        public List<ShipWeapon> Weapons { get; set; } // List of weapons equipped on the ship
        public List<Item> Cargo { get; set; } // List of items in the ship's cargo
        public List<Character> Crew { get; set; } // List of characters in the ship's crew
        public string ImagePath { get; set; } // Path to the image representing the ship
        public bool IsSunk { get; set; } // Indicates if the ship is sunk
        public Coordinates CurrentCoordinates { get; set; } // Current coordinates of the ship
        public DateTime LastMaintenance { get; set; } // Last maintenance date
        public List<ShipUpgrade> Upgrades { get; set; } // List of upgrades applied to the ship
    }
}