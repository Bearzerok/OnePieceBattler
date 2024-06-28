using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnePieceBattler.Models
{
    public class Coordinates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Latitude { get; set; } // Latitude of the island
        public double Longitude { get; set; } // Longitude of the island
        public int? ShipId { get; set; } // ID of the ship at these coordinates
        public int? IslandId { get; set; } // ID of the island at these coordinates

    }
}