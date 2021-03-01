using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Hero p, string[] text)
        {
            string _result = "Invalid Command's Format: Move to X";
            Path _pathSearch = null;

            if (!(text.Length == 3))
            {
                return _result;
            }
            else
            {
                if (!(text[0] == "move" || text[0] == "go" || text[0] == "head" || text[0] == "leave"))
                    _result = "Error in move input";
                else if (text[1] != "to")
                    _result = "Where do you want to 'move to'?";
                else
                {
                    _pathSearch = FetchPath(p.Location, text[2]);
                    if (_pathSearch != null)
                    {
                        //check if the path is a door or not first
                        if (IsADoor(_pathSearch) is Door)
                            return MovePlayerOver(p, _pathSearch as Door);
                        else
                           return MovePlayerTo(p, _pathSearch);
                        //if the location can't be found, the it return I can't find that loc
                    }

                    return "There is no path to " + text[2] + " at current location";
                    
                    //This is only executed when location is found -> move the player to that  location
                }
                return _result;
            }
        }

        private Path FetchPath(Location loc, string locId)
        {
            if (loc.LocatePath(locId) is Door)
                return loc.LocatePath(locId) as Door;
            else if (loc.LocatePath(locId) is Path)
                return loc.LocatePath(locId);
            else                
                return null;
        }

        private Door IsADoor(Path p)
        {
            if (p is Door)
                return p as Door;
            return null;
        }

        private string MovePlayerTo(Hero p, Path pathDestin)
        {
            pathDestin.MoveTo(p);
            return pathDestin.Destination.Arrive(p) + Environment.NewLine + "You're at " + p.Location.FullDescription ;
        }

        //Check if the current location is capable to move to that direction
        private string MovePlayerOver(Hero p, Door pathDestin)
        {
            //by default, the door is locked, which mean the condition is
            pathDestin.MoveTo(p);
            
            if (pathDestin.IsLocked)
                return "You can't move there. " + pathDestin.MoveTo(p);
            //pathDestin.MoveTo(p);
            return pathDestin.Destination.Arrive(p) + Environment.NewLine + "You're at " + p.Location.FullDescription;
        }
    }
}
