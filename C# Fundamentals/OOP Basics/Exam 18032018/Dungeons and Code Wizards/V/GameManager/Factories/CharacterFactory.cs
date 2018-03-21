using System;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.GameManager.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            Faction charFaction;

            switch (faction)
            {
                case "CSharp":
                    charFaction = Faction.CSharp;
                    break;

                case "Java":
                    charFaction = Faction.Java;
                    break;

                default:
                    throw new ArgumentException(string.Format(Output.InvalidFaction, faction));
            }

            switch (type)
            {
                case "Warrior":
                    return new Warrior(name, charFaction);

                case "Cleric":
                    return new Cleric(name, charFaction);

                default:
                    throw new ArgumentException(string.Format(Output.InvalidCharType, type));
            }
        }
    }
}