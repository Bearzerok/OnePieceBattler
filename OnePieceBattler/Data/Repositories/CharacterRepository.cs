using OnePieceBattler.Models;
using System;
using System.Linq;

namespace OnePieceBattler.Data
{
    public class CharacterRepository
    {
        private readonly ApplicationDbContext _context;

        public CharacterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Character GetCharacterById(int playerId)
        {
            Character character = _context.Characters.FirstOrDefault(c => c.Id == playerId);
            Console.WriteLine("Returning character with Id: " + character?.Id);
            if (character == null)
            {
                throw new ArgumentException("Character with Id: " + character?.Id + "not found");
            }
            return character;
        }

        public Character? GetRandomCharacter(int[]? excludeIds = null)
        {
            IQueryable<Character> query = _context.Characters;

            if (excludeIds != null)
            {
                query = query.Where(c => !excludeIds.Contains(c.Id));
            }

            int count = query.Count();
            Console.WriteLine("Returning random character from " + count + " characters");

            if (count == 0)
            {
                throw new ArgumentException("Character not found");
            }

            int index = new Random().Next(count);
            return query.Skip(index).FirstOrDefault();
        }

        public IQueryable<Character> GetAllCharacters()
        {
            return _context.Characters;
        }

        public void DeleteCharacter(int id)
        {
            var character = _context.Characters.FirstOrDefault(c => c.Id == id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                _context.SaveChanges();
            }
        }

        public void UpdateCharacter(Character updatedCharacter)
        {
            // Retrieve the character from the database
            var character = _context.Characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

            if (character != null)
            {
                // Update the properties of the character
                character.Name = updatedCharacter.Name;
                character.Description = updatedCharacter.Description;
                character.ImagePath = updatedCharacter.ImagePath;
                character.Health = updatedCharacter.Health;
                character.AttackPower = updatedCharacter.AttackPower;
                character.DefensePower = updatedCharacter.DefensePower;
                character.ArmamentHakiPower = updatedCharacter.ArmamentHakiPower;
                character.ObservationHakiPower = updatedCharacter.ObservationHakiPower;
                character.ConquerorHakiPower = updatedCharacter.ConquerorHakiPower;

                // Save the changes to the database
                _context.SaveChanges();
            }
        }

        public void AddCharacter(Character newCharacter)
        {
            _context.Characters.Add(newCharacter);
            _context.SaveChanges();
        }

        public void AddCharacters(Character[] newCharacters)
        {
            _context.Characters.AddRange(newCharacters);
            _context.SaveChanges();
        }

        public List<Character> GetCharactersByIds(int[] ids = null)
        {
            if (ids == null)
            {
                return _context.Characters.ToList();
            }
            else
            {
                return _context.Characters.Where(c => ids.Contains(c.Id)).ToList();
            }
        }

    }
}