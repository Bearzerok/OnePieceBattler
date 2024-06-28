using OnePieceBattler.Models;

namespace OnePieceBattler.Data.Repositories
{
    public class QuestRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Quest GetQuestById(int id)
        {
            return _context.Quests.Find(id);
        }

        public Quest GetQuestBytTitle(string title)
        {
            return _context.Quests.FirstOrDefault(q => q.Title == title);
        }

        public List<Quest> GetQuestsByCharacterId(int characterId)
        {
            return _context.Quests.Where(q => q.CharacterId == characterId).ToList();
        }

        public void UpdateQuest(Quest quest)
        {
            _context.Quests.Update(quest);
            _context.SaveChanges();
        }

        public void addQuest(Quest quest)
        {
            _context.Quests.Add(quest);
            _context.SaveChanges();
        }
    }
}