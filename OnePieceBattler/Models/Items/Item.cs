using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePieceBattler.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public string Effect { get; set; }
        public int Power { get; set; }
        public string ImagePath { get; set; }
    }

    public enum ItemType
    {
        Consumable,
        Equipment,
        KeyItem
    }
}