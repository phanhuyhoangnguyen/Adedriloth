using System;
using System.Collections.Generic;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Type of Spell that cause explosion on the target and cause damage
    /// </summary>
    public class Explosion : Spell
    {
        public Explosion(SkillLevel skillLev) : base(new string[] { "explose" }, "explose", skillLev, "Healing Spell")
        {
        }

        /// <summary>
        /// Effect of the Spell, process on the target
        /// </summary>
        /// <param name="sHero"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string Cast(Object sHero, Object obj)
        {
            SpellHero s = sHero as SpellHero;
            Enemy e = obj as Enemy;
            string result = "obj was not a Enemy";

            if (e is Enemy)
            {
                if (sHero is SpellHero)
                {
                    if (CastingChance())
                    {
                        e.HitTaken(e.Health/2);
                        return result = "Success! " + e.FullDescription;
                    }
                }
                result += "the obj is not Spell Hero";
            }
            return result += "Casting Fail!";
        }
    }
}
