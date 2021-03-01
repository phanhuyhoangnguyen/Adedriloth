using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// SpellCast is similar to Command, however, Command is general action which can be perform for any type of hero
    /// Meanwhile Spellcast is designed only for Spell Hero. By Abstraction, Casting a spell is not a command, it is a Spell casting
    /// </summary>
    public abstract class SpellCast : IdentifiableObject
    {
        public SpellCast(string[] ids) : base(ids)
		{
        }

        public abstract string Execute(SpellHero s, string[] text);
        
        /// <summary>
        /// Locate spell which the Spell Hero has learned
        /// </summary>
        /// <param name="s"></param>
        /// <param name="spellId"></param>
        /// <returns></returns>
        public Spell FetchSpell(SpellHero s, string spellId)
        {
            if (!(s.LocateSpell(spellId) is GameObject))
                return null;
            else
                return s.LocateSpell(spellId);
        }
    }
}
