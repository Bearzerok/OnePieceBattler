using System.Linq;
using OnePieceBattler.Models;
using Microsoft.EntityFrameworkCore;

namespace OnePieceBattler.Data
{
    public class BattleRepository
    {
        private readonly ApplicationDbContext _context;

        public BattleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Battle?GetBattleByCharacters(int player1Id)
        {
            var battle = _context.Battles
                .Include(b => b.Player1)
                .Include(b => b.Player2)
                .FirstOrDefault(b => b.Player1.Id == player1Id);

            Console.WriteLine("Returning battle with Id: " + battle?.Id);
            return battle;
        }

        public Battle? GetBattleById(int battleId)
        {
            var battle = _context.Battles
                .Include(b => b.Player1)
                .Include(b => b.Player2)
                .FirstOrDefault(b => b.Id == battleId);



            return battle;
        }

        public IQueryable<Battle> GetAllBattles()
        {
            return _context.Battles
                .Include(b => b.Player1)
                .Include(b => b.Player2);
        }

        public void AddBattle(Battle battle)
        {
            _context.Battles.Add(battle);
            _context.SaveChanges();
        }

        public void UpdateBattle(Battle updatedBattle)
        {
            _context.Battles.Update(updatedBattle);
            _context.SaveChanges();
        }

        public void DeleteBattle(int id)
        {
            var battle = _context.Battles.FirstOrDefault(b => b.Id == id);
            if (battle != null)
            {
                _context.Battles.Remove(battle);
                _context.SaveChanges();
            }
        }
    }
}