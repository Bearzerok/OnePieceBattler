using OnePieceBattler.Models;
namespace OnePieceBattler.Data.Repositories
{
    public class QuestObjectiveRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestObjectiveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public QuestObjective GetQuestObjectiveById(int id)
        {
            return _context.QuestObjectives.Find(id);
        }

        public void UpdateQuestObjective(QuestObjective questObjective)
        {
            _context.QuestObjectives.Update(questObjective);
            _context.SaveChanges();
        }

        public void addQuestObjective(QuestObjective questObjective)
        {
            _context.QuestObjectives.Add(questObjective);
            _context.SaveChanges();
        }
        
    }
}