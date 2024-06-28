using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePieceBattler.Models
{
    public class QuestLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for the quest log entry
        public string Action { get; set; } // Description of the action or event
        public DateTime Timestamp { get; set; } // Timestamp of when the action or event occurred
        //TODO: Add foreign key to Quest and other models
    }
}