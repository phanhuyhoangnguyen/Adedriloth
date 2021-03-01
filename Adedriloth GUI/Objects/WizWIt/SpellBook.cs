using System;
using System.Collections.Generic;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Spell Book contain a collection of a spell. Spell Book is responsible for add more spell inside
    /// or Fetch some certain spell
    /// </summary>
	public class SpellBook
	{
        private List<Spell> _spellList = new List<Spell>();

		public void AddSpell(Spell s)
		{
			_spellList.Add(s);
		}

		public Spell Fetch(string Spellid)
		{
			foreach (Spell s in _spellList)
			{
				if (s.AreYou(Spellid))
					return s;
			}
			return null;		}
	}
}
