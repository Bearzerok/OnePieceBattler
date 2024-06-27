namespace OnePieceBattler.Models
{
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    public class Battle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Character Player1 { get; set; }
        public Character Player2 { get; set; }
        public int Player1Health { get; set; }
        public int Player2Health { get; set; }
        public bool IsPlayer1Turn { get; set; }
        public bool IsBattleOver { get; set; }
        public List<Move> Moves { get; set; } 
    }
}