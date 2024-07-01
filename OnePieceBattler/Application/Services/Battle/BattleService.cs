using OnePieceBattler.Data;
using OnePieceBattler.Models;

namespace OnePieceBattler.Application.Services.BattleServices
{
    public class BattleService
    {
        private readonly BattleRepository _battleRepository;

        public BattleService(BattleRepository battleRepository)
        {
            _battleRepository = battleRepository;
        }
    }
}