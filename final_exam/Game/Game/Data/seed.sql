INSERT INTO [CharacterClass] (Name)
    VALUES
    ('Assassin'),
    ('Fighter'),
    ('Mage'),
    ('Marksman'),
    ('Barbarian'),
    ('Shaman');

INSERT INTO [Weapon] (Name)
    VALUES
    ('Sword'),
    ('Rapier'),
    ('Hatchet'),
    ('Spear'),
    ('Great Axe'),
    ('Bow'),
    ('Musket'),
    ('Fire Staff'),
    ('Ice Gauntlet');
    
INSERT INTO [Ability] (Name, Damage, Cooldown)
    VALUES
    ('Throw' ,10,10),
    ('Strike',30,15),
    ('Sweep' ,15,5),
    ('Evade' ,0,5),
    ('Block' ,5,10),
    ('Poison',40,50),
    ('Rapid' ,25,25),
    ('Fire'  ,35,40);

INSERT INTO [Character] (Created, Level, Health, CharacterClassID)
    VALUES
    ('2021-12-04 12:15:44',3 ,40 ,1),
    ('2021-12-03 15:00:00',9 ,23 ,3),
    ('2021-12-02 03:56:11',15,75 ,5),
    ('2021-11-25 07:23:08',11,52 ,5),
    ('2021-11-25 20:10:23',22,300,6);

INSERT INTO [CharacterWeapon] (Mastery, CharacterID, WeaponID)
    VALUES
    (10,1,9),
    (5 ,1,5),
    (8 ,2,2),
    (16,2,3),
    (4 ,3,1),
    (30,3,2),
    (15,4,7),
    (20,4,6),
    (30,5,4),
    (35,5,8),
    (40,5,6);

INSERT INTO [CharacterAbility] (AssignDate, CharacterID, AbilityID)
    VALUES
    ('2021-12-04 13:15:44',1,1),
    ('2021-12-04 18:10:04',1,8),
    ('2021-12-04 11:02:00',2,3),
    ('2021-12-05 15:00:30',2,2),
    ('2021-12-03 04:56:11',3,7),
    ('2021-12-04 03:26:15',3,8),
    ('2021-11-26 07:23:23',4,4),
    ('2021-11-27 21:23:00',4,7),
    ('2021-11-28 17:23:57',4,2),
    ('2021-11-27 20:30:24',5,3),
    ('2021-11-28 21:50:13',5,1),
    ('2021-11-29 22:12:33',5,6),
    ('2021-11-30 22:00:53',5,8);