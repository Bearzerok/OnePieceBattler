using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnePieceBattler.Models
{
    public class Island
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for the island
        public string Name { get; set; } // Name of the island
        public string Description { get; set; } // Description of the island
        public Climate Climate { get; set; } // Climate of the island (e.g., Tropical, Desert, Arctic)
        public Terrain Terrain { get; set; } // Terrain of the island (e.g., Mountainous, Flat, Forest, Sea)
        public List<Character> Inhabitants { get; set; } // List of characters living on the island
        public List<Quest> AvailableQuests { get; set; } // List of quests available on the island
        public List<Item> AvailableItems { get; set; } // List of items that can be found on the island
        public List<IslandEvent> Events { get; set; } // List of events happening on the island
        public string ImagePath { get; set; } // Path to the image representing the island
        public bool IsDiscoveredByCharacter { get; set; } // Indicates if the island has been discovered by the player
        public Coordinates Coordinates { get; set; } // Coordinates of the island on the world map
    }
    public enum Climate{

        Tropical,
        Desert,
        Arctic,
        Temperate,
        Mediterranean,
        Subarctic,
        Subtropical,
        Tundra,
        IceCap,
        Highland,
        Savanna,
        Rainforest,
        Monsoon,
        Steppe,
        Taiga,
        Chaparral,
        Alpine,
        Boreal,
        Grassland,
        Wetland,
        Swamp,
    }
    public enum Terrain {
        Mountainous,
        Flat,
        Forest,
        Sea,
        Desert,
        Tundra,
        Swamp,
        Wetland,
        Grassland,
        Savanna,
        Rainforest,
        Taiga,
        Chaparral,
        Alpine,
        Highland,
        Mediterranean,
        Temperate,
        Arctic,
        Volcanous,
        Fire}
}

