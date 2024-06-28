using OnePieceBattler.Models;

namespace OnePieceBattler.Data.Repositories
{
    public class RewardRepository
    {
        private readonly ApplicationDbContext _context;

        public RewardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Reward GetRewardById(int id)
        {
            return _context.Rewards.Find(id);
        }

        public void UpdateReward(Reward reward)
        {
            _context.Rewards.Update(reward);
            _context.SaveChanges();
        }

        public void addReward(Reward reward)
        {
            _context.Rewards.Add(reward);
            _context.SaveChanges();
        }
    }
}