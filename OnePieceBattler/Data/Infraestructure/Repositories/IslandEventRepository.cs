using OnePieceBattler.Models;
namespace OnePieceBattler.Data.Repositories
{
    public class IslandEventRepository
    {
        private readonly ApplicationDbContext _context;
        public IslandEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IslandEvent GetIslandEventById(int eventId)
        {
            return _context.IslandEvents.Find(eventId);
        }    
        public void UpdateIslandEvent(IslandEvent islandEvent)
        {
            _context.IslandEvents.Update(islandEvent);
            _context.SaveChanges();
        }
    }
}