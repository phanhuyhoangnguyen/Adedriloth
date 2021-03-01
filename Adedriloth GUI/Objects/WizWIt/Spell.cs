using System;
using System.Collections.Generic;
namespace Adedriloth_GUI
{
    /// <summary>
    /// Spell know its Skill Level, its description
    /// </summary>
	public abstract class Spell : GameObject
	{
        //To identify if it's Healeasy or HealHard, ...
        private SkillLevel _skillLev;

        //to search these spellType in a list

        public Spell(string[] ids, string name, SkillLevel sKill, string desc) : base(ids, name, desc)
        {
            _skillLev = sKill;
        }

        public abstract string Cast(Object h, Object obj);

        /// <summary>
        /// Calculate the successful chance when a spell is casting and return whether the spell is casted success or not
        /// </summary>
        /// <returns>return true if spell is casted success and return false if not</returns>
        public bool CastingChance()
        {
            Random r = new Random();

            int finalSuccess = (int)_skillLev;

            int spellDiceRoll = r.Next(1,4);

            if (spellDiceRoll + finalSuccess > 5)
                return true;
            return false;
        }

        public int SkillLevel
        {
            get
            {
                return (int)_skillLev;
            }
        }

        public override string ShortDescription
        {
            get
            {
                return Name + " " + "(" + _skillLev.ToString() + ")";
            }
        }
    }
}
