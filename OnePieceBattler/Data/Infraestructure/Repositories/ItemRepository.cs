using Microsoft.EntityFrameworkCore;
using OnePieceBattler.Models;

namespace OnePieceBattler.Data.Repositories
{
    public class ItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Item GetItemById(int id)
        {
            return _context.Items.Find(id);
        }
        
        public Item GetItemByName(string name)
        {
            return _context.Items.FirstOrDefault(i => i.Name == name);
        }

        public void updateItem(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
    }
}