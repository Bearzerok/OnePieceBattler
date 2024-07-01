using OnePieceBattler.Data;
using OnePieceBattler.Models;

namespace OnePieceBattler.Application.Services.CharacterServices
{
    public class CharacterService
    {
        private readonly CharacterRepository _characterRepository;

        public CharacterService(CharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public Battle CreateRandomBattle(int player1Id, List<Move> moves)
        {
            var player1 = _characterRepository.GetCharacterById(player1Id);
            var player2 = _characterRepository.GetRandomCharacter(new int[] { player1Id });

            if (player1 == null || player2 == null)
            {
                throw new Exception("Player not found to create random battle");
            }

            var battle = new Battle
            {
                Player1 = player1,
                Player2 = player2,
                Player1Health = player1.Health,
                Player2Health = player2.Health,
                IsPlayer1Turn = true,
                Moves = moves
            };

            return battle;

        }    
    }
}