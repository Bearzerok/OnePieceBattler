using OnePieceBattler.Data;
using OnePieceBattler.Models;

namespace OnePieceBattler.Application.UseCases.BattleUseCases
{
    public class EndBattle
    {
        private readonly BattleRepository _battleRepository;
        private readonly CharacterRepository _characterRepository;

        public EndBattle(BattleRepository battleRepository, CharacterRepository characterRepository)
        {
            _battleRepository = battleRepository;
            _characterRepository = characterRepository;
        }

        public void Execute(Battle battle)
        {
            battle.Player2Health = 0;
            battle.IsBattleOver = true;
            var character = _characterRepository.GetCharacterById(battle.Player1.Id);
            battle.Player1Health = character.Health;
            battle.Player2Health = character.Health;
            battle.IsBattleOver = false;
            _battleRepository.UpdateBattle(battle);
        }
    }
}