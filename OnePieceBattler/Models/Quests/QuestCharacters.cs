using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePieceBattler.Models
{
    public class QuestCharacters
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int QuestCharactersId { get; set; }
    public List<Character>? QuestGivers { get; set; }
    public List<Character>? QuestReceivers { get; set; }
    public int QuestId { get; set; }
    public Quest? Quest { get; set; }
    }
}