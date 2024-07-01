using Microsoft.AspNetCore.Mvc;
using OnePieceBattler.Data;
using OnePieceBattler.Application.UseCases.CharacterUseCases;

namespace OnePieceBattler.Presentation.Controllers
{
    public class BattleOverController: Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GetCharacterBattleOver _getCharacterBattleOver;

        public BattleOverController(ApplicationDbContext context)
        {
            _context = context;
            _getCharacterBattleOver = new GetCharacterBattleOver(new CharacterRepository(_context));
        }

        public IActionResult BattleOver(int player1Id)
        {
            var character = _getCharacterBattleOver.Execute(player1Id);
            Console.WriteLine("Returning character to with id " + character.Id + " name " + character.Name + " health " + character.Health + " experience " + character.Experience +" to battle over view!");
            try {
                return View(character);
            } catch 
            {
                throw new Exception("Could not send character to battle over view!");
            }

        }
        
    }
}