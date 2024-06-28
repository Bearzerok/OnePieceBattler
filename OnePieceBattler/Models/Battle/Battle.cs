using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnePieceBattler.Models
{
    public class Battle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Character Player1 { get; set; } = new Character();
        [Required]
        public Character Player2 { get; set; } = new Character();
        public int Player1Health { get; set; }
        public int Player2Health { get; set; }
        public bool IsPlayer1Turn { get; set; }
        public bool IsBattleOver { get; set; }
        [Required]
        public List<Move> Moves { get; set; } = new List<Move>();
    }
}