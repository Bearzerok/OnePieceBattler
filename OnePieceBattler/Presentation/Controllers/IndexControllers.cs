using Microsoft.AspNetCore.Mvc;
using OnePieceBattler.Data;


namespace OnePieceBattler.Controllers
{
    public class IndexController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CharacterRepository _characterRepository;

        public IndexController(ApplicationDbContext context)
        {
            _context = context;
            _characterRepository = new CharacterRepository(_context);
        }

        public IActionResult Index()
        {
            var characters = _characterRepository.GetCharactersByIds();
            if (characters == null)
            {
                throw new Exception("Characters not found");
            }

            return View(characters);
        }
    }
}