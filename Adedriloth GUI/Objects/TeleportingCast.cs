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
			string result = null;
            Spell _spellFetch;
            Location _loc = null;

            if (text.Length == 5 && text[3] == "to")
			{
                string _locName = text[4];
                _spellFetch = FetchSpell(s, text[1]);
                if (_spellFetch == null)
                    return "You haven't learned this spell";
                _loc = FetchLocation(_locName);
                if (_loc == null)
                        return "There is no Location like that on the map";
                    result = TeleportHeroTo(s, _loc, _spellFetch);
            }
			else
			{
				
                result = "Wrong Spell Cast's format: Cast Teleport Spell to (X)";
			}
            return result;

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
            return spell.Cast(stu, s) + " " + stu.Location.FullDescription;
        }
    }
}
