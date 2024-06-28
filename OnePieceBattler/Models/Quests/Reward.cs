using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePieceBattler.Models
{
    public class Reward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for the reward
        public RewardType Type { get; set; } // Type of reward (e.g., Item, Experience, Gold)
        public int Quantity { get; set; } // Quantity of the reward
        public string Description { get; set; } // Description of the reward

        //TODO: Add foreign key to Item and other models
    }

    public enum RewardType
    {
        Item,
        Experience,
        Gold,
        Character
    }
}