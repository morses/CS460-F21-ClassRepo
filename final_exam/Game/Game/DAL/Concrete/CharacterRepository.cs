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
        // A new version of this file will be available just prior to the exam.  Replace this file with that one.

        public CharacterRepository(GameDbContext ctx) : base(ctx)
        { }
    }
}