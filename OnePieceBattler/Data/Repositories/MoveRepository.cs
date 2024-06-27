using System.Linq;
using OnePieceBattler.Models;
using Microsoft.EntityFrameworkCore;

namespace OnePieceBattler.Data{
    public class MoveRepository{
        private readonly ApplicationDbContext _context;
        public MoveRepository(ApplicationDbContext context){
            _context = context;
        }
        public Move GetMoveById(int id)
        {
            Move move = _context.Moves.Find(id);
            if (move == null)
            {
                throw new Exception($"Move with ID {id} not found.");
            }
            Console.WriteLine("Returning move with Id: " + move.Id);
            return move;
        }
        
        public List<Move> GetMoves()
        {
            return _context.Moves.ToList();
        }
    }

}