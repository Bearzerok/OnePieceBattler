using OnePieceBattler.Data;

namespace OnePieceBattler.Application.Services.Character
{
    public class MoveService
    {
        private readonly MoveRepository _moveRepository;

        public MoveService(MoveRepository moveRepository)
        {
            _moveRepository = moveRepository;
        }
    }
}