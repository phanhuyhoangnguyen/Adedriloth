using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Spell Hero is a type of hero, which is able to cast spell
    /// </summary>
    public class SpellHero : Hero
    {
        private SpellBook _spellBook;
    
        public SpellHero() : base (new string[] { "Ryze", "me" },"Ryze")
        {
            _spellBook = new SpellBook();
            
            HeroType = "Spell Master - A Spell-Casting Hero ";
            Damage = 5;
        }

        /// <summary>
        /// Search and return the spell if found, else return null
        /// </summary>
        /// <param name="spellId">Id of Spell need to be searched</param>
        /// <returns>return the spell if found or null if unfound</returns>
        public Spell LocateSpell(string spellId)
        {
            if (_spellBook.Fetch(spellId) != null)
                return _spellBook.Fetch(spellId);
            return null;
        }

        /// <summary>
        /// The Spell Book of Hero
        /// </summary>
        public SpellBook SpellBook
        {
            get
            {
                return _spellBook;
            }
        }


    }
}
