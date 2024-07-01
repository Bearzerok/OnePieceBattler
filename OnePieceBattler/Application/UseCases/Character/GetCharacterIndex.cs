using OnePieceBattler.Data;
using OnePieceBattler.Models;

namespace OnePieceBattler.Application.UseCases.CharacterUseCases{
    public class GetCharacterIndex{
        private readonly CharacterRepository _characterRepository;

        public GetCharacterIndex(CharacterRepository characterRepository){
            _characterRepository = characterRepository;
        }

        public List<Character> Execute(){
            var characters = _characterRepository.GetCharactersByIds();
            if (characters == null)
            {
                throw new Exception("Characters not found to display index page");
            }
            
            return characters;
            
        }
    }
}