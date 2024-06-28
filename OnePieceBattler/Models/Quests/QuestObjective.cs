using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePieceBattler.Models
{
    public class QuestObjective
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for the objective
        public string Description { get; set; } // Description of the objective
        public ObjectiveType Type { get; set; } // Type of objective (e.g., Collect, Defeat, Explore)
        public int TargetId { get; set; } // ID of the target (e.g., item ID, character ID, location ID)
        public int CurrentProgress { get; set; } // Current progress of the objective
        public int RequiredProgress { get; set; } // Required progress to complete the objective
        public bool IsCompleted { get; set; } // Indicates if the objective is completed
    }

    public enum ObjectiveType
    {
        Collect,
        Defeat,
        Explore,
        Escort,
        Deliver
    }
}
