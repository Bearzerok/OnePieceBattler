using OnePieceBattler.Models;
using OnePieceBattler.Data;

namespace OnePieceBattler.Application.UseCases.BattleUseCases
{
    
    public class BattleAction
    {
        private readonly BattleRepository _battleRepository;
        private readonly MoveRepository _moveRepository;   
        private readonly ExecuteMove _executeMove;
        private readonly EndBattle _endBattle;

        public BattleAction(BattleRepository battleRepository, MoveRepository moveRepository, ExecuteMove executeMove, EndBattle endBattle)
        {
            _battleRepository = battleRepository;
            _moveRepository = moveRepository;
            _executeMove = executeMove;
            _endBattle = endBattle;
        }

        public BattleResult Execute(int battleId, int moveId)
        {
            var battle = _battleRepository.GetBattleById(battleId);

            var move = _moveRepository.GetMoveById(moveId);

            if (battle == null || move == null)
            {
                throw new Exception("Battle or Move not found!");
            }

            if (battle.IsPlayer1Turn)
            {
                battle.Player2Health = _executeMove.Execute(battle, move);
                battle.IsPlayer1Turn = !battle.IsPlayer1Turn;

                if (battle.Player1Health <= 0)
                {
                    _battleRepository.DeleteBattle(battleId);
                    Console.WriteLine("You lost the battle!, Game Over!");

                    return new BattleResult { IsRedirect = true, ActionName= "Index", ControllerName = "Index" };
                }
                else if (battle.Player2Health <= 0)
                {
                    _endBattle.Execute(battle);
                    Console.WriteLine("You won the battle!, Heading to BattleOver page!");
                    return new BattleResult { IsRedirect = true, ActionName= "BattleOver", ControllerName = "BattleOver", RouteValues = new { player1Id = battle.Player1.Id } };
                }

                

                var randomMove = _moveRepository.GetMoveById(2);
                if (randomMove != null)
                {
                    battle.Player1Health = _executeMove.Execute(battle, randomMove);
                    battle.IsPlayer1Turn = !battle.IsPlayer1Turn;

                    if (battle.Player1Health <= 0)
                    {
                        _battleRepository.DeleteBattle(battleId); 
                        Console.WriteLine("You lost the battle!, Game Over!");
                        return new BattleResult { IsRedirect = true, ActionName= "Index", ControllerName = "Index" };
                     }
                    else if (battle.Player2Health <= 0)
                     {
                        _endBattle.Execute(battle);
                        Console.WriteLine("You won the battle!, Heading to BattleOver page!");
                        return new BattleResult { IsRedirect = true, ActionName= "BattleOver", ControllerName = "BattleOver", RouteValues = new { player1Id = battle.Player1.Id } };
                     }
                }
            } else
            {
                battle.IsPlayer1Turn = !battle.IsPlayer1Turn;

                    var randomMove = _moveRepository.GetMoveById(2);
                    if (randomMove != null)
                    {
                        battle.Player1Health = _executeMove.Execute(battle, randomMove);

                        if (battle.Player1Health <= 0)
                        {
                            _battleRepository.DeleteBattle(battleId);
                            Console.WriteLine("You lost the battle!, Game Over!");
                            return new BattleResult { IsRedirect = true, ActionName= "Index", ControllerName = "Index" };
                        }
                        else if (battle.Player2Health <= 0)
                        {
                            _endBattle.Execute(battle);
                            Console.WriteLine("You won the battle!, Heading to BattleOver page!");
                            return new BattleResult { IsRedirect = true, ActionName= "BattleOver", ControllerName = "BattleOver", RouteValues = new { player1Id = battle.Player1.Id } };
                        }
                    }
            }

            _battleRepository.UpdateBattle(battle);
            Console.WriteLine("Move executed!");
            return new BattleResult{IsRedirect = true, ActionName = "Battle", ControllerName = "Battle", RouteValues = new { player1Id = battle.Player1.Id }, Battle = battle};
        }
    }
}