using OnePieceBattler.Models;

namespace OnePieceBattler.Data.Repositories
{
    public class IslandRepository
    {
        private readonly ApplicationDbContext _context;

        public IslandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Island GetIslandById(int id)
        {
            return _context.Islands.Find(id);
        }

        public Island GetIslandByName(string name)
        {
            return _context.Islands.FirstOrDefault(i => i.Name == name);
        }

        public void UpdateIsland(Island island)
        {
            _context.Islands.Update(island);
            _context.SaveChanges();
        }

    }
}