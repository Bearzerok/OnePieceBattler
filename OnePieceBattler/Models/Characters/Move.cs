using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePieceBattler.Models
{
public class Move
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public int MovePower { get; set; }
    public int SelfDamage { get; set; }
    public int MoveAccuracy { get; set; }
    public string ?MoveType { get; set; }
    public bool MovePriority { get; set; }
    public int MoveCooldown { get; set; }
    public List<Character> ?MoveExclusiveCharacters { get; set; }
    public string ?Effect { get; set; }
    public string ?ImagePath { get; set; }
    public int NumberOfTargets { get; set; }
    public int NumberOfHits { get; set; }
    public int MoveLuck { get; set; }
    public int MoveCriticalHitChance { get; set; }
}

}