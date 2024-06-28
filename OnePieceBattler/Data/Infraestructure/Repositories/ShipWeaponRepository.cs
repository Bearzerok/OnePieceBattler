using OnePieceBattler.Models;

namespace OnePieceBattler.Data.Repositories
{
    public class ShipWeaponRepository
    {
        private readonly ApplicationDbContext _context;
        public ShipWeaponRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ShipWeapon GetShipWeaponById(int id)
        {
            return _context.ShipWeapons.Find(id);
        }

        public void UpdateShipWeapon(ShipWeapon shipWeapon)
        {
            _context.ShipWeapons.Update(shipWeapon);
            _context.SaveChanges();
        }
        public void addShipWeapon(ShipWeapon shipWeapon)
        {
            _context.ShipWeapons.Add(shipWeapon);
            _context.SaveChanges();
        }
    }
}