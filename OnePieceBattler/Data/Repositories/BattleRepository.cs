using System.Linq;
using OnePieceBattler.Models;
using Microsoft.EntityFrameworkCore;

namespace OnePieceBattler.Data
{
    public class BattleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly CharacterRepository _characterRepository;

        public BattleRepository(ApplicationDbContext context, CharacterRepository characterRepository)
        {
            _context = context;
            _characterRepository = characterRepository;
        }

        public Battle CreateRandomBattle(int player1Id,List<Move> moves)
        {
            var player1 = _characterRepository.GetCharacterById(player1Id);
            var player2 = _characterRepository.GetRandomCharacter(new int[] { player1Id });


            if (player1 == null || player2 == null)
            {
                throw new Exception("Player not found");
            }

            var battle = new Battle
            {
                    Player1 = player1,
                    Player2 = player2,
                    Player1Health = player1.Health,
                    Player2Health = player2.Health,
                    IsPlayer1Turn = true,
                    Moves = moves
            };

            return battle;
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