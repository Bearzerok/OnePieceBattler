using Microsoft.AspNetCore.Mvc;
using OnePieceBattler.Application.Services.CharacterServices;
using OnePieceBattler.Application.UseCases.BattleUseCases; 
using OnePieceBattler.Data;

namespace OnePieceBattler.Controllers
{
    public class BattleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CharacterRepository _characterRepository;
        private readonly BattleRepository _battleRepository;
        private readonly MoveRepository _moveRepository;
        private readonly CharacterService _characterService;
        private readonly EndBattle _endBattle;
        
        private readonly ExecuteMove _executeMove;
        private readonly StartBattle _startBattle;
        private readonly BattleAction _battleAction;

        public BattleController(ApplicationDbContext context)
        {
            _context = context;
            _characterRepository = new CharacterRepository(_context);
            _battleRepository = new BattleRepository(_context);
            _moveRepository = new MoveRepository(_context);
            _characterService = new CharacterService(_characterRepository);
            _endBattle = new EndBattle(_battleRepository, _characterRepository);
            _executeMove = new ExecuteMove();
            _startBattle = new StartBattle(_battleRepository, _moveRepository, _characterService);
            _battleAction = new BattleAction(_battleRepository, _moveRepository, _executeMove, _endBattle);
        }
        public IActionResult Battle(int player1Id)
        {
            var battle = _startBattle.Execute(player1Id);
            return View(battle);
        }

        [HttpPost]
        public IActionResult? ExecuteMove(int battleId, int moveId)
        {

            var result = _battleAction.Execute(battleId, moveId);
            if (result.IsRedirect)
            {
                return RedirectToAction(result.ActionName, result.ControllerName, result.RouteValues);
            } else{
                throw new Exception("Could not redirect to the specified action after executing move!" + result.ActionName + " " + result.ControllerName + " " + result.RouteValues);
            }
        }
    }
}