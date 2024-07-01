using Microsoft.AspNetCore.Mvc;
using OnePieceBattler.Application.UseCases.CharacterUseCases;
using OnePieceBattler.Data;


namespace OnePieceBattler.Controllers
{
    public class IndexController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GetCharacterIndex _getCharacterIndex;

        public IndexController(ApplicationDbContext context)
        {
            _context = context;
            _getCharacterIndex = new GetCharacterIndex(new CharacterRepository(_context));
        }

        public IActionResult Index()
        {
            var characters = _getCharacterIndex.Execute();
            return View(characters);
        }
    }
}