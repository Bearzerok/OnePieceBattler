using OnePieceBattler.Models;
using OnePieceBattler.Application.Services.CharacterServices;
using OnePieceBattler.Data;

namespace OnePieceBattler.Application.UseCases.BattleUseCases
{
    public class StartBattle
    {
        private readonly BattleRepository _battleRepository;
        private readonly MoveRepository _moveRepository;
        private readonly CharacterService _characterService;  

        public StartBattle(BattleRepository battleRepository, MoveRepository moveRepository, CharacterService characterService)
        {
            _battleRepository = battleRepository;
            _moveRepository = moveRepository;
            _characterService = characterService;
        }
        public Battle Execute (int player1Id)
        {
            var battle = _battleRepository.GetBattleByCharacters(player1Id);

            if (battle == null)
            {
                var moves = _moveRepository.GetMoves();
                battle = _characterService.CreateRandomBattle(player1Id, moves);
                _battleRepository.AddBattle(battle);
            } else
            {
            var moves = _moveRepository.GetMoves();
            battle.Moves = moves;
            _battleRepository.UpdateBattle(battle);
            }
            Console.WriteLine("Returning battle with Id: " + battle.Id + "for player1Id: " + player1Id);
            return battle;
        }
    }
}