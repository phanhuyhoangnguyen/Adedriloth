using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look", "see" })
        { }

        public override string Execute(Hero p, string[] text)
        {
            string _result = "Wrong Format! The command must be: " + Environment.NewLine + "Look" + Environment.NewLine + "Look at ..." + Environment.NewLine + "Look at ... in ...";
            string _searchTarget = p.Location.FirstId;
            IHaveInventory container = null;

            if (!(text.Length == 1 || text.Length == 3 || text.Length == 5))
            {

                return _result;
            }
            else
            {
                if (text.Length == 1)
                    container = p.Location;
                else if (text.Length == 3 && text[1] == "at")
                {
                    container = p;
                    _searchTarget = text[2];
                }

                else if (text.Length == 5 && text[3] == "in")
                {
                    _searchTarget = text[4];
                    container = FetchContainer(p, _searchTarget);
                    if (container == null)
                        return _result = "There is no " + _searchTarget;
                }
                else
                    return _result = "Wrong command format";
                
                _result = LookAtIn(_searchTarget, container);
                return _result;
            }
        }

        //We use the IHaveInventory type instead of GameObject is because we want to reject dealing with the data type gameObject for things which don't have inventory
        //Because we need to distince and treat the object differently, that's why we need IHaveInventory interface
        //To Check/find if that is the container or not, using the p
        private IHaveInventory FetchContainer(Hero p, string containerId)
        {
            if (!(p.LocateSth(containerId) is GameObject))
                return null;
            else
                // we can use "as" only when the object is polymorphism
                //function Locage(containerId) is executed by the player p, this help us to locate the object if it's a container or just an item
                return p.LocateSth(containerId) as IHaveInventory;
            //This is advantage of interface IHaveInventory, instead of return p.Locate as GameObject, we are able to return Player as IHaveInventory type to treat it differently
        }

        //The association relationship is the oject 1 can declare an object of the object 2 to use the object 2's function for the sake of removing the duplication code
        //for example, this class command need the IHaveInventory container to provide and support for its function
        //Find the item inside the cointainer just found in the above
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            //This is to check even when the container is valid, is there that item inside
            if (container.LocateSth(thingId) != null)
                return container.LocateSth(thingId).FullDescription;
            else
                return "There is no" + thingId;
        }
    }
}
