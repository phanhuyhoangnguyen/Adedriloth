using System;
namespace Adedriloth_GUI
{
    /// <summary>
    /// Teleportation is a type of spell, which help the hero move to any targeted location when the cast is success.
    /// </summary>
	public class Teleportation : Spell
	{
        /// <summary>
        /// Initialize the Teleporatino identifier, name and description
        /// </summary>
        /// <param name="sLev"></param>
		public Teleportation(SkillLevel sLev) : base(new string[] { "teleport" }, "teleport", sLev, "Spell help Player to Teleport")
        {
		}

        /// <summary>
        /// check if the Cast is success, then move the hero to targeted location
        /// else, move the player to random location and return the result
        /// </summary>
        /// <param name="h">hero which is affected by this spell</param>
        /// <param name="obj">Targetted Location, which hero want to teleport to</param>
        /// <returns></returns>
        public override string Cast(Object sHero, Object location)
        {
            SpellHero s = sHero as SpellHero;
            string result = "obj was not a location";

            if (location is Location)
            {
                if (sHero is SpellHero)
                {
                    if (CastingChance())
                    {
                        s.Location = (Location)location;
                        return result = "Success!";
                    }
                }
                result += "the obj is not Spell Hero";
            }
            return result += "Casting Fail!";
        }
    }
}
