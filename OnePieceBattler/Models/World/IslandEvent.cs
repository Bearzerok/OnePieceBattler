using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePieceBattler.Models
{
    public class IslandEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for the event
        public string Name { get; set; } // Name of the event
        public string Description { get; set; } // Description of the event
        public EventType Type { get; set; } // Type of event (e.g., Natural Disaster, Festival, Pirate Attack)
        public DateTime StartTime { get; set; } // Start time of the event
        public DateTime EndTime { get; set; } // End time of the event
    }
        public enum EventType
    {
        NaturalDisaster,
        Festival,
        PirateAttack,
        TradeEvent
    }
}