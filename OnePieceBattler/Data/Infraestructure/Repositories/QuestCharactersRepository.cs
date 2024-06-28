using OnePieceBattler.Models;

namespace OnePieceBattler.Data.Repositories
{
    public class QuestCharactersRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestCharactersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public QuestCharacters GetQuestCharactersById(int id)
        {
            return _context.QuestCharacters.Find(id);
        }

        public void UpdateQuestCharacters(QuestCharacters questCharacters)
        {
            _context.QuestCharacters.Update(questCharacters);
            _context.SaveChanges();
        }

        public QuestCharacters GetQuestCharactersByQuestId(int questId)
        {
            return _context.QuestCharacters.FirstOrDefault(qc => qc.QuestId == questId);
        }

    }
}