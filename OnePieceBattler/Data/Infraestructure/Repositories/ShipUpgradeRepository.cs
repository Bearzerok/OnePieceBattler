using OnePieceBattler.Models;
namespace OnePieceBattler.Data.Repositories
{
    public class ShipUpgradeRepository
    {
        private readonly ApplicationDbContext _context;
        public ShipUpgradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ShipUpgrade GetShipUpgradeById(int id)
        {
            return _context.ShipUpgrades.Find(id);
        }
        public void UpdateShipUpgrade(ShipUpgrade shipUpgrade)
        {
            _context.ShipUpgrades.Update(shipUpgrade);
            _context.SaveChanges();
        }
        public void addShipUpgrade(ShipUpgrade shipUpgrade)
        {
            _context.ShipUpgrades.Add(shipUpgrade);
            _context.SaveChanges();
        }
    }
}