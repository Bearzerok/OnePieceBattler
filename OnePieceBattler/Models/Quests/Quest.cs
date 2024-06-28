using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePieceBattler.Models
{
    public class Quest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for the quest
        public string Title { get; set; } // Title of the quest
        public string Description { get; set; } // Detailed description of the quest
        public QuestType Type { get; set; } // Type of quest (e.g., Main, Side, Repeatable)
        public QuestStatus Status { get; set; } // Current status of the quest (e.g., NotStarted, InProgress, Completed)
        public List<QuestObjective> Objectives { get; set; } // List of objectives to complete the quest
        public List<Reward> ?Rewards { get; set; } // List of rewards for completing the quest
        public DateTime? StartTime { get; set; } // Time when the quest was started
        public DateTime? EndTime { get; set; } // Time when the quest was completed
        public int ExperienceReward { get; set; } // Experience points awarded for completing the quest
        public int GoldReward { get; set; } // Gold awarded for completing the quest
        public List<Item> ?ItemRewards { get; set; } // Items awarded for completing the quest
        public string ?Location { get; set; } // Location where the quest takes place
        public string ?PrerequisiteQuest { get; set; } // Id or Title of prerequisite quest, if any
        public string ?StoryLine { get; set; } // Storyline or lore associated with the quest
        public int RequiredLevel { get; set; } // Minimum level required to start the quest
        public bool IsRepeatable { get; set; } // Indicates if the quest can be repeated
        public List<QuestLog> ?QuestLogs { get; set; } // Logs of quest progression
        // Foreign key to Character
        public int? CharacterId { get; set; }
        // Info of the character assigned to the quest
        public Character? AssignedCharacter { get; set; }
        public QuestCharacters ?QuestCharacters { get; set; }
    }

    public enum QuestType
    {
        Main,
        Side,
        Repeatable,
        Achievement
    }

    public enum QuestStatus
    {
        NotStarted,
        InProgress,
        Completed
    }
}