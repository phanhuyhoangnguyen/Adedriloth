using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class UseCommand : Command
    {
        public UseCommand() : base(new string[] { "use" })
        {

        }
        public override string Execute(Hero h, string[] text)
        {
            string _result = "Invalid Command Format!: Use (Item) On (Object)";
            /*string _searchItem = text[1];
            Item _itemFetch;
            Object _target;

            if (text.Length != 4)
            {
                return _result;
            }
            else
            {
                if (text[0] != "use")
                    _result = "Error in use input";
                else if (text[2] != "on")
                    _result = "How do you want to use?";
                else
                {
                    _itemFetch = FetchItem(h, _searchItem);
                    if (_itemFetch is Weapon)
                        return "Wrong Command! You should make a attack command";
                    if (_itemFetch != null)
                    {
                        _target= FetchObject(_target);
                        if (_target == null)
                            return "There is no enemy like that.";
                        else if (Usable(h, _target))
                            return UseItemOn(_itemFetch, _target);
                    }
                    _result = "You don't have " + _searchItem;
                }*/
                return _result;
            }
        /*}

        private Item FetchItem(Hero p, string itemId)
        {
            if (!(p.LocateSth(itemId) is GameObject))
                return null;
            else
                return p.LocateSth(itemId) as Item;
        }

        public Door FetchObject(Hero p, string doorId)
        {
            if (p.Location.LocatePath(doorId) != null)
                return p.Location.LocatePath(doorId) as Door;
            return null;
        }

        private string UseItemOn(Key item, Door door)
        {
            return item.Use(door);
        }*/
    }
}

