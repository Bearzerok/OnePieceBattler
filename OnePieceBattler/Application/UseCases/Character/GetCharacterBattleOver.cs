using OnePieceBattler.Data;
using OnePieceBattler.Models;

namespace OnePieceBattler.Application.UseCases.CharacterUseCases
{
    public class GetCharacterBattleOver
    {
        private readonly CharacterRepository _characterRepository;

        public GetCharacterBattleOver(CharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public Character Execute(int player1Id)
        {
            var character = _characterRepository.GetCharacterById(player1Id);
            if (character == null)
            {
                throw new Exception("Characters not found after battleOver");
            } else {
                return character;
            }
        }
        
    }
}