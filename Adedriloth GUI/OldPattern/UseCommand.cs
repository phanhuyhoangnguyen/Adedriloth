using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class UseKeyCommand : Command
    {
        public UseKeyCommand() : base(new string[] { "use" })
        {

        }
        public override string Execute(Hero h, string[] text)
        {
            string targetId = "Invalid Command Format!";
            string searchItem = text[1];

            if (text.Length != 4)
            {
                return targetId;
            }
            else
            {
                if (text[0] != "use")
                    targetId = "Error in use input";
                else if (text[2] != "on")
                    targetId = "How do you want to use?";
                else
                {
                    targetId = text[3];
                    if (FetchItem(h, searchItem) == null)
                        return "You don't have " + searchItem;
                    return UseItemOn(FetchItem(h, searchItem), FetchDoorNearBy(h, targetId));
                }
                // target is now a door
                return null; 
            }
        }

        private Key FetchItem(Hero p, string itemId)
        {
            if (!(p.LocateSth(itemId) is GameObject))
                return null;
            else
                return p.LocateSth(itemId) as Key;
        }

        public Door FetchDoorNearBy(Hero p, string doorId)
        {
            if(p.Location.LocatePath(doorId) != null)
                return p.Location.LocatePath(doorId) as Door;
           return null;
        }

        private string UseItemOn(Key item, Door door)
        {
            return item.Use(door);
        }
    }
}

