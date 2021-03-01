using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Switching command allow user to switch hero
    /// </summary>
    public class SwitchCommand : Command
    {
        public SwitchCommand() : base(new string[] { "switch", "choose" })
        {
        }

        public override string Execute(Hero s, string[] text)
        {
            string result = "";
            
            if (!(text.Length == 3 && text[0] == "switch" && text[2]== "hero"))
            {
                result = "Command Format is incorrect: Switch The Hero";
            }
            
            else
            {
               result = SwitchTheHero();
            }
            return result;
        }

        private string SwitchTheHero()
        {
            string _result;
            if (HeroManager.Instance.CurrentHero.Location.AreYou("home"))
            {
                HeroManager.Instance.SwitchHero();
                _result = "Successful!" + Environment.NewLine + HeroManager.Instance.CurrentHero.FullDescription;
            }
            else
                _result = "You can only switch hero at home";
            return _result;
        }
    }
}
