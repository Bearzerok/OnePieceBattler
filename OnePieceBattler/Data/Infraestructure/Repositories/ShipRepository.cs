using OnePieceBattler.Models;

namespace OnePieceBattler.Data.Repositories
{
    public class ShipRepository
    {
        private readonly ApplicationDbContext _context;

        public ShipRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public Ship? GetShipByCharacterId(Character character)
        {
            return _context.Ships.FirstOrDefault(q => q.Crew.Contains(character));
        }

        public void UpdateShip(Ship ship)
        {
            _context.Ships.Update(ship);
            _context.SaveChanges();
        }



        public void addShip(Ship ship)
        {
            _context.Ships.Add(ship);
            _context.SaveChanges(); 
    }
    }
}