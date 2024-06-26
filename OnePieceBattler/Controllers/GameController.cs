using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnePieceBattler.Data;
using OnePieceBattler.Models;
using System;
using System.Linq;

namespace OnePieceBattler.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var characters = _context.Characters.ToList();
            return View(characters);
        }

        public IActionResult Battle(int player1Id)
        {
            var player1 = _context.Characters.Find(player1Id);
            if (player1 == null)
            {
                return NotFound();
            }

            var battle = _context.Battles
                .Include(b => b.Player1)
                .Include(b => b.Player2)
                .FirstOrDefault(b => b.Player1.Id == player1Id || b.Player2.Id == player1Id);
            Console.WriteLine(battle.Id);

            if (battle == null)
            {
                var charactersExceptPlayer1 = _context.Characters.Where(c => c.Id != player1Id).ToList();
                var randomIndex = new Random().Next(charactersExceptPlayer1.Count);
                var player2 = charactersExceptPlayer1[randomIndex];

                if (player2 == null)
                {
                    return NotFound();
                }

                // Obtener movimientos con IDs 1 y 2 desde la base de datos
                var movesFirst = _context.Moves.Where(m => m.Id == 1 || m.Id == 2).ToList();
                Console.WriteLine("NO DEBERÍA ENTRAR");


                battle = new Battle
                {
                    Player1 = player1,
                    Player2 = player2,
                    Player1Health = player1.Health,
                    Player2Health = player2.Health,
                    IsPlayer1Turn = true,
                };

                _context.Battles.Add(battle);
                _context.SaveChanges();
            }

            var moves = _context.Moves.Where(m => m.Id == 1 || m.Id == 2).ToList();

            Console.WriteLine(battle.Id);
            battle.Moves = moves;
            return View(battle);
        }

        [HttpPost]
        public IActionResult ExecuteMove(int battleId, int moveId)
        {
            Console.WriteLine("ENTRA EN EL EXECUTE");
            var battle = _context.Battles
                .Include(b => b.Player1)
                .Include(b => b.Player2)
                .FirstOrDefault(b => b.Id == battleId);

            var move = _context.Moves.Find(moveId);

            if (battle == null || move == null)
            {
                return NotFound();
            }

            if (battle.IsPlayer1Turn)
            {
                battle.Player2Health -= move.MovePower;
            }
            else
            {
                battle.Player1Health -= move.MovePower;
            }

            if (battle.Player1Health <= 0)
            {
                battle.Player1Health = 0;
                battle.IsBattleOver = true;
                _context.Battles.Update(battle);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (battle.Player2Health <= 0)
            {
                battle.Player2Health = 0;
                battle.IsBattleOver = true;
                _context.Battles.Update(battle);
                _context.SaveChanges();
                return RedirectToAction("BattleOver", new { player1Id = battle.Player1.Id });
            }
            else
            {
                battle.IsPlayer1Turn = !battle.IsPlayer1Turn;

                if (!battle.IsPlayer1Turn)
                {
                    var randomMove = _context.Moves.FirstOrDefault(m => m.Id == 2);
                    if (randomMove != null)
                    {
                        battle.Player1Health -= randomMove.MovePower;

                        if (battle.Player1Health <= 0)
                        {
                            battle.Player1Health = 0;
                            battle.IsBattleOver = true;
                            _context.Battles.Update(battle);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            battle.IsPlayer1Turn = !battle.IsPlayer1Turn;
                        }
                    }
                }

                _context.Battles.Update(battle);
                _context.SaveChanges();

                return RedirectToAction("Battle", new { player1Id = battle.Player1.Id });
            }
        }
    }
}
