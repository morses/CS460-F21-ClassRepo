using System;
using System.Collections.Generic;
using System.Linq;
using Game.Models;

namespace GameTests
{
    public class FakeData
    {
        public static readonly List<Weapon> Weapons = new List<Weapon>
        {
            new Weapon { Id = 1, Name = "Sword"},
            new Weapon { Id = 2, Name = "Rapier"},
            new Weapon { Id = 3, Name = "Hatchet"},
            new Weapon { Id = 4, Name = "Spear"},
            new Weapon { Id = 5, Name = "Great Axe"},
            new Weapon { Id = 6, Name = "Bow"},
            new Weapon { Id = 7, Name = "Musket"},
            new Weapon { Id = 8, Name = "Fire Staff"},
            new Weapon { Id = 9, Name = "Ice Gauntlet"}
        };

        public static readonly List<CharacterClass> CharacterClasses = new List<CharacterClass>
        {
            new CharacterClass { Id = 1, Name = "Assassin" },
            new CharacterClass { Id = 2, Name = "Fighter"},
            new CharacterClass { Id = 3, Name = "Mage"},
            new CharacterClass { Id = 4, Name = "Marksman"},
            new CharacterClass { Id = 5, Name = "Barbarian"},
            new CharacterClass { Id = 6, Name = "Shaman"}
        };

        public static readonly List<Character> Characters = new List<Character>
        {
            new Character { Id = 1, Created = DateTime.Parse("2021-12-04 12:15:44"), Level = 3 , Health = 40 , CharacterClassId = 1, Name = "Millia Rage"},
            new Character { Id = 2, Created = DateTime.Parse("2021-12-03 15:00:00"), Level = 9 , Health = 23 , CharacterClassId = 3, Name = "Haruka Sawamura"},
            new Character { Id = 3, Created = DateTime.Parse("2021-12-02 03:56:11"), Level = 15, Health = 75 , CharacterClassId = 5, Name = "Athena Asamiya"},
            new Character { Id = 4, Created = DateTime.Parse("2021-11-25 07:23:08"), Level = 11, Health = 52 , CharacterClassId = 5, Name = "Jak"},
            new Character { Id = 5, Created = DateTime.Parse("2021-11-25 20:10:23"), Level = 22, Health = 300, CharacterClassId = 6, Name = "Kanji Tatsumi"},
            new Character { Id = 6, Created = DateTime.Parse("2022-11-25 20:10:23"), Level = 5,  Health = 4,  CharacterClassId = 2, Name = "No Name"}   // Character with no abilities
        };

        public static readonly List<CharacterWeapon> CharacterWeapons = new List<CharacterWeapon>
        {
            new CharacterWeapon { Id = 1, Mastery = 10, CharacterId = 1,  WeaponId = 9},
            new CharacterWeapon { Id = 2, Mastery = 5 , CharacterId = 1,  WeaponId = 5},
            new CharacterWeapon { Id = 3, Mastery = 8 , CharacterId = 2,  WeaponId = 2},
            new CharacterWeapon { Id = 4, Mastery = 16, CharacterId = 2,  WeaponId = 3},
            new CharacterWeapon { Id = 5, Mastery = 4 , CharacterId = 3,  WeaponId = 1},
            new CharacterWeapon { Id = 6, Mastery = 30, CharacterId = 3,  WeaponId = 2},
            new CharacterWeapon { Id = 7, Mastery = 15, CharacterId = 4,  WeaponId = 7},
            new CharacterWeapon { Id = 8, Mastery = 20, CharacterId = 4,  WeaponId = 6},
            new CharacterWeapon { Id = 9, Mastery = 30, CharacterId = 5,  WeaponId = 4},
            new CharacterWeapon { Id = 10, Mastery = 35, CharacterId = 5, WeaponId = 8},
            new CharacterWeapon { Id = 11, Mastery = 40, CharacterId = 5, WeaponId = 6}
        };

        public static readonly List<Ability> Abilities = new List<Ability>
        {
            new Ability { Id = 1, Name = "Throw" , Damage = 10, Cooldown = 10},
            new Ability { Id = 2, Name = "Strike", Damage = 30, Cooldown = 15},
            new Ability { Id = 3, Name = "Sweep" , Damage = 15, Cooldown = 5 },
            new Ability { Id = 4, Name = "Evade" , Damage = 0 , Cooldown = 5 },
            new Ability { Id = 5, Name = "Block" , Damage = 5 , Cooldown = 10},
            new Ability { Id = 6, Name = "Poison", Damage = 40, Cooldown = 50},
            new Ability { Id = 7, Name = "Rapid" , Damage = 25, Cooldown = 25},
            new Ability { Id = 8, Name = "Fire"  , Damage = 35, Cooldown = 40}
        };

        public static readonly List<CharacterAbility> CharacterAbilities = new List<CharacterAbility>
        {
            new CharacterAbility { Id = 1, AssignDate = DateTime.Parse("2021-12-04 13:15:44"),  CharacterId = 1, AbilityId = 1},
            new CharacterAbility { Id = 2, AssignDate = DateTime.Parse("2021-12-04 18:10:04"),  CharacterId = 1, AbilityId = 8},
            new CharacterAbility { Id = 3, AssignDate = DateTime.Parse("2021-12-04 11:02:00"),  CharacterId = 2, AbilityId = 3},
            new CharacterAbility { Id = 4, AssignDate = DateTime.Parse("2021-12-05 15:00:30"),  CharacterId = 2, AbilityId = 2},
            new CharacterAbility { Id = 5, AssignDate = DateTime.Parse("2021-12-03 04:56:11"),  CharacterId = 3, AbilityId = 7},
            new CharacterAbility { Id = 6, AssignDate = DateTime.Parse("2021-12-04 03:26:15"),  CharacterId = 3, AbilityId = 8},
            new CharacterAbility { Id = 7, AssignDate = DateTime.Parse("2021-11-26 07:23:23"),  CharacterId = 4, AbilityId = 4},
            new CharacterAbility { Id = 8, AssignDate = DateTime.Parse("2021-11-27 21:23:00"),  CharacterId = 4, AbilityId = 7},
            new CharacterAbility { Id = 9, AssignDate = DateTime.Parse("2021-11-28 17:23:57"),  CharacterId = 4, AbilityId = 2},
            new CharacterAbility { Id = 10, AssignDate = DateTime.Parse("2021-11-27 20:30:24"), CharacterId = 5, AbilityId = 3},
            new CharacterAbility { Id = 11, AssignDate = DateTime.Parse("2021-11-28 21:50:13"), CharacterId = 5, AbilityId = 1},
            new CharacterAbility { Id = 12, AssignDate = DateTime.Parse("2021-11-29 22:12:33"), CharacterId = 5, AbilityId = 6},
            new CharacterAbility { Id = 13, AssignDate = DateTime.Parse("2021-11-30 22:00:53"), CharacterId = 5, AbilityId = 8}
        };

        static FakeData()
        {
            // Still need to set the navigation properties, so do it from the id's
            Characters.ForEach(c =>
            {
                c.CharacterClass = CharacterClasses.Single(cc => cc.Id == c.CharacterClassId);            // to one
                c.CharacterAbilities = CharacterAbilities.Where(ca => ca.CharacterId == c.Id).ToList();   // to many
                c.CharacterWeapons = CharacterWeapons.Where(cw => cw.CharacterId == c.Id).ToList();       // to many
            });

            CharacterClasses.ForEach(cc =>
            {
                cc.Characters = Characters.Where(c => c.CharacterClassId == cc.Id).ToList();
            });

            Weapons.ForEach(w =>
            {
                w.CharacterWeapons = CharacterWeapons.Where(cw => cw.WeaponId == w.Id).ToList();
            });

            CharacterWeapons.ForEach(cw =>
            {
                cw.Character = Characters.Single(c => c.Id == cw.CharacterId);
                cw.Weapon = Weapons.Single(w => w.Id == cw.WeaponId);
            });

            Abilities.ForEach(a =>
            {
                a.CharacterAbilities = CharacterAbilities.Where(ca => ca.AbilityId == a.Id).ToList();
            });

            CharacterAbilities.ForEach(ca =>
            {
                ca.Character = Characters.Single(c => c.Id == ca.CharacterId);
                ca.Ability = Abilities.Single(a => a.Id == ca.AbilityId);
            });
        }
    }
}