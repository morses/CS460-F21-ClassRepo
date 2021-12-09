using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Game.DAL.Abstract;
using Game.Models;

namespace Game.DAL.Concrete
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(GameDbContext ctx) : base(ctx)
        { }

        public IEnumerable<Ability> GetAbilities(int id)
        {
            // your implementation here


            return new List<Ability>();
        }

        public IEnumerable<Ability> GetMissingAbilities(int id, IEnumerable<Ability> allAbilities)
        {
            // your implementation here

            
            return new List<Ability>();
        }

        // There are no tests for this method
        public int LevelUp(int id)
        {
            // your implementation here

            
            return -1;
        }
    }
}