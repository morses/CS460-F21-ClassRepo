CREATE TABLE [Character] (
  [ID]               int      PRIMARY KEY IDENTITY(1, 1),
  [Created]          datetime NOT NULL,
  [Level]            int      NOT NULL,
  [Health]           int      NOT NULL,
  [CharacterClassID] int      NOT NULL
);

CREATE TABLE [CharacterClass] (
  [ID]   int          PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(30) NOT NULL
);

CREATE TABLE [Ability] (
  [ID]       int          PRIMARY KEY IDENTITY(1, 1),
  [Name]     nvarchar(50) NOT NULL,
  [Damage]   int          NOT NULL,
  [Cooldown] int          NOT NULL
);

CREATE TABLE [CharacterAbility] (
  [ID]          int      PRIMARY KEY IDENTITY(1, 1),
  [AssignDate]  datetime NOT NULL,
  [CharacterID] int      NOT NULL,
  [AbilityID]   int      NOT NULL
);

CREATE TABLE [Weapon] (
  [ID]   int          PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50) NOT NULL
);

CREATE TABLE [CharacterWeapon] (
  [ID]          int PRIMARY KEY IDENTITY(1, 1),
  [Mastery]     int NOT NULL,
  [CharacterID] int NOT NULL,
  [WeaponID]    int NOT NULL
);

ALTER TABLE [Character]         ADD CONSTRAINT [Fk_Character_CClass_ID]   FOREIGN KEY ([CharacterClassID]) REFERENCES [CharacterClass] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [CharacterAbility]  ADD CONSTRAINT [Fk_CAbility_Character_ID] FOREIGN KEY ([CharacterID])      REFERENCES [Character]      ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [CharacterAbility]  ADD CONSTRAINT [Fk_CAbility_Ability_ID]   FOREIGN KEY ([AbilityID])        REFERENCES [Ability]        ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [CharacterWeapon]   ADD CONSTRAINT [Fk_CWeapon_Character_ID]  FOREIGN KEY ([CharacterID])      REFERENCES [Character]      ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [CharacterWeapon]   ADD CONSTRAINT [Fk_CWeapon_Weapon_ID]     FOREIGN KEY ([WeaponID])         REFERENCES [Weapon]         ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
