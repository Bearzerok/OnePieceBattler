using OnePieceBattler.Models;

namespace OnePieceBattler.Data.Repositories
{
    public class QuestLogRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public QuestLog GetQuestLogById(int id)
        {
            return _context.QuestLogs.Find(id);
        }

        public void addQuestLog(QuestLog questLog)
        {
            _context.QuestLogs.Add(questLog);
            _context.SaveChanges();
        }

    }
}