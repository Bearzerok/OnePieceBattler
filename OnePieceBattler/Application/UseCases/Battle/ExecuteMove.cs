using OnePieceBattler.Models;

namespace OnePieceBattler.Application.UseCases.BattleUseCases
{
    public class ExecuteMove
    {
        public int Execute(Battle battle, Move move)
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