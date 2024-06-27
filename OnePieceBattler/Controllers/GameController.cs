using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnePieceBattler.Data;
using OnePieceBattler.Models;

namespace OnePieceBattler.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CharacterRepository _characterRepository;
        private readonly BattleRepository _battleRepository;
        private readonly MoveRepository _moveRepository;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
            _characterRepository = new CharacterRepository(_context);
            _battleRepository = new BattleRepository(_context, _characterRepository);
            _moveRepository = new MoveRepository(_context);
        }

        public IActionResult Index()
        {
            var characters = _characterRepository.GetCharactersByIds();
            return View(characters);
        }

        public IActionResult Battle(int player1Id)
        {
            var battle = _battleRepository.GetBattleByCharacters(player1Id);

            if (battle == null)
            {
                var moves = _moveRepository.GetMoves();
                battle = _battleRepository.CreateRandomBattle(player1Id, moves);
                _battleRepository.AddBattle(battle);
            } else
            {
            var moves = _moveRepository.GetMoves();
            battle.Moves = moves;
            _battleRepository.UpdateBattle(battle);
            }

            Console.WriteLine("Returning battle with Id: " + battle.Id);
            return View(battle);
        }

        [HttpPost]
        public IActionResult ExecuteMove(int battleId, int moveId)
        {
            var battle = _battleRepository.GetBattleById(battleId);

            var move = _moveRepository.GetMoveById(moveId);

            if (battle == null || move == null)
            {
                return NotFound();
            }

            if (battle.IsPlayer1Turn)
            {
                battle.Player2Health = MoveDamage(battle, move);
                battle.IsPlayer1Turn = !battle.IsPlayer1Turn;

                if (battle.Player1Health <= 0)
                {
                    _battleRepository.DeleteBattle(battleId);
                    Console.WriteLine("You lost the battle!, Game Over!");

                    return RedirectToAction("Index");
                }
                else if (battle.Player2Health <= 0)
                {
                    EndBattle(battle);
                    Console.WriteLine("You won the battle!, Heading to BattleOver page!");
                    return RedirectToAction("BattleOver", new { player1Id = battle.Player1.Id });
                }

                

                var randomMove = _moveRepository.GetMoveById(2);
                if (randomMove != null)
                {
                    battle.Player1Health = MoveDamage(battle, randomMove);
                    battle.IsPlayer1Turn = !battle.IsPlayer1Turn;

                    if (battle.Player1Health <= 0)
                    {
                        _battleRepository.DeleteBattle(battleId); 
                        Console.WriteLine("You lost the battle!, Game Over!");
                        return RedirectToAction("Index");
                     }
                    else if (battle.Player2Health <= 0)
                     {
                        EndBattle(battle);
                        Console.WriteLine("You won the battle!, Heading to BattleOver page!");
                        return RedirectToAction("BattleOver", new { player1Id = battle.Player1.Id });
                     }
                }
            } else
            {
                battle.IsPlayer1Turn = !battle.IsPlayer1Turn;

                    var randomMove = _moveRepository.GetMoveById(2);
                    if (randomMove != null)
                    {
                        battle.Player1Health = MoveDamage(battle, randomMove);

                        if (battle.Player1Health <= 0)
                        {
                            _battleRepository.DeleteBattle(battleId);
                            Console.WriteLine("You lost the battle!, Game Over!");
                            return RedirectToAction("Index");
                        }
                        else if (battle.Player2Health <= 0)
                        {
                            EndBattle(battle);
                            Console.WriteLine("You won the battle!, Heading to BattleOver page!");
                            return RedirectToAction("BattleOver", new { player1Id = battle.Player1.Id});
                        }
                    }
            }

            _battleRepository.UpdateBattle(battle);
            Console.WriteLine("Move executed!");
            return RedirectToAction("Battle", new { player1Id = battle.Player1.Id });
        }

        private void EndBattle(Battle battle)
        {
            battle.Player2Health = 0;
            battle.IsBattleOver = true;
            var character = _characterRepository.GetCharacterById(battle.Player1.Id);
                battle.Player1Health = character.Health;
                battle.Player2Health = character.Health;
            battle.IsBattleOver = false;
            _battleRepository.UpdateBattle(battle);
        }

        private int MoveDamage(Battle battle, Move move)
        {   
            if (battle.IsPlayer1Turn)
            {
                battle.Player2Health -= move.MovePower;
                return battle.Player2Health;
            }
            else
            {
                battle.Player1Health -= move.MovePower;
                return battle.Player1Health;
            }
        }
    }
}

