ALTER TABLE [Character]         DROP CONSTRAINT [Fk_Character_CClass_ID]   ;
ALTER TABLE [CharacterAbility]  DROP CONSTRAINT [Fk_CAbility_Character_ID] ;
ALTER TABLE [CharacterAbility]  DROP CONSTRAINT [Fk_CAbility_Ability_ID]   ;
ALTER TABLE [CharacterWeapon]   DROP CONSTRAINT [Fk_CWeapon_Character_ID]  ;
ALTER TABLE [CharacterWeapon]   DROP CONSTRAINT [Fk_CWeapon_Weapon_ID]     ;

DROP TABLE [Character];
DROP TABLE [CharacterClass];
DROP TABLE [Ability];
DROP TABLE [CharacterAbility];
DROP TABLE [Weapon];
DROP TABLE [CharacterWeapon];