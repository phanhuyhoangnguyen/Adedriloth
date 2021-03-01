using System;
namespace Adedriloth_GUI
{
    //TeleportingCast inherit from SpellCast because it is a spell casting, it is not a command
    //Of course we can treat it as a command, however this is not a good way of designing program
    public class TeleportingCast : SpellCast
	{
		public TeleportingCast() : base(new string[] { "teleport", "jump" })
		{
		}

		public override string Execute(SpellHero s, string[] text)
		{
			string result = "Spell Cast is incorrect!";
			string _locName = text[3];
            Spell _spellFetch;

            if (text.Length != 4)
			{
				return result;
			}
			else
			{
				if (text[2]!="to")
					result = "You mean 'Teleport to'?";
				else
				{
                    _spellFetch = FetchSpell(s, "teleport");
                    if (_spellFetch == null)
                        return "You haven't learned this spell";
                    result = text[2];
					if (FetchLocation(_locName) == null)
						return "There is no Location like that on the map";
                    FetchLocation(_locName);
                    result = TeleportHeroTo(s, FetchLocation(_locName), FetchSpell(s, "teleport"));
                }
                return result;
			}
		}

		private Location FetchLocation(string locId)
		{
			if (!(GameManager.Instance.LocateLocation(locId) is GameObject))
				return null;
			else
				return GameManager.Instance.LocateLocation(locId);
		}

		private string TeleportHeroTo(SpellHero stu, Location s, Spell spell)
		{
			return spell.Cast(stu, s);
		}
    }
}
