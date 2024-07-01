namespace OnePieceBattler.Models
{
    public class BattleResult
{
    public bool IsRedirect { get; set; }
    public string ActionName { get; set; }
    public string ControllerName { get; set; }
    public object RouteValues { get; set; }
    public Battle Battle { get; set; }
}
}