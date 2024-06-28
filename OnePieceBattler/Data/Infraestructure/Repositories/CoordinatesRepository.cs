using OnePieceBattler.Models;
namespace OnePieceBattler.Data.Repositories
{
    public class CoordinatesRepository
    {
        private readonly ApplicationDbContext _context;

        public CoordinatesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Coordinates GetCoordinatesById(int id)
        {
            return _context.Coordinates.Find(id);
        }
        public Coordinates GetCoordinatesByIslandId(int islandId)
        {
            return _context.Coordinates.FirstOrDefault(c => c.IslandId == islandId);
        }
        public Coordinates GetCoordinatesByShipId(int shipId)
        {
            return _context.Coordinates.FirstOrDefault(c => c.ShipId == shipId);
        }

        public Coordinates SetCoordinatesAndShipId(int coordinatesId, int shipId)
        {
            var coordinates = GetCoordinatesById(coordinatesId);
            coordinates.ShipId = shipId;
            _context.SaveChanges();
            return coordinates;
        }
        public Coordinates SetCoordinatesAndIslandId(int coordinatesId, int islandId)
        {
            var coordinates = GetCoordinatesById(coordinatesId);
            coordinates.IslandId = islandId;
            _context.SaveChanges();
            return coordinates;
        }
    }
}