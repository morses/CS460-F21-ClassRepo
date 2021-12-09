using System;
using System.Collections.Generic;
using Game.Models;

namespace Game.DAL.Abstract
{
    public interface ICharacterRepository : IRepository<Character>
    {
        /// <summary>
        /// Get all the abilities that the given Character currently has.
        /// </summary>
        /// <param name="id">PK id of the character to retrieve abilities for</param>
        /// <returns>List of abilities sorted in alphabetical order by Name </returns>
        IEnumerable<Ability> GetAbilities(int id);

        /// <summary>
        /// Get all the remaining abilities that the given Character DOES NOT have.  These are
        /// abilities appearing in the database that the given character does not have. />
        /// </summary>
        /// <param name="id">PK id of the character</param>
        /// <param name="allAbilities">All the abilities currently in the database</param>
        /// <returns>List of unacquired abilities sorted in alphabetical order by Name </returns>
        IEnumerable<Ability> GetMissingAbilities(int id, IEnumerable<Ability> allAbilities);

        /// <summary>
        /// Level up this character.  One invokation of this method increments the given Character's
        /// Level by 1.
        /// </summary>
        /// <param name="id">PK id of the character</param>
        /// <returns>The new Level value</returns>
        int LevelUp(int id);
    }
}