using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Casting Command is a special kind-of command, which help Spell-type hero to cast different type of spell
    /// </summary>
    public class CastingProcessor : Command
    {
        //TODO make casting command that only accept the spell hero
        private List<SpellCast> _spellCastList;

        public CastingProcessor() : base(new string[] { "cast" })
        {
            _spellCastList = new List<SpellCast>();
        }

        /// <summary>
        /// Process the command and tell the valid spell cast to execute the its effect
        /// </summary>
        /// <param name="h">Hero h, who specify the casting command</param>
        /// <param name="text">The command</param>
        /// <returns>resutls of the casting command</returns>
        public override string Execute(Hero h, string[] text)
        {
            SpellHero s = h as SpellHero;
            if (s != null)
            {
                foreach (SpellCast c in _spellCastList)
                    if (c.AreYou(text[1]))
                        return c.Execute(s, text);
                return "There is no Spell Casting like that";
            }
            return "You're not Spell-Type Hero";
        }
            
        /// <summary>
        /// Add all the Spell Casting Command in the Spell Cast List
        /// </summary>
        /// <param name="s"></param>
        public void AddSpellCastList(SpellCast s)
        {
        _spellCastList.Add(s);
        }
    }
}
