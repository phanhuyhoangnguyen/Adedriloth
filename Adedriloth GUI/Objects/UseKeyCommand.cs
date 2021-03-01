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
            string _targetId;
            string _searchItem = text[1];
            string _result = "Invalid Command Format!: Use (Item) On (Object)";
            Key _itemFetch;
            Door _doorFetch;

            if (text.Length == 4 && text[2] == "on")
            {
                _targetId = text[3];
                _itemFetch = FetchItem(h, _searchItem);
                if (_itemFetch != null)
                {
                    _doorFetch = FetchDoorNearBy(h, _targetId);
                    if (_doorFetch == null)
                        return "I can't find that door";
                     _result = UseItemOn(_itemFetch, _doorFetch);
                }
                else
                    return _result = "You don't have " + _searchItem;
            }
            return _result;
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

