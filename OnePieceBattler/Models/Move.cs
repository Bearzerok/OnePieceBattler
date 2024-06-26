namespace OnePieceBattler.Models
{
public class Move
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MovePower { get; set; }
        // Relación muchos a muchos con Batallas
}

}