using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "take" })
        { }

        public override string Execute(Hero s, string[] text)
        {
            string _container = null;
            string _result = null;
            string _searchItem = text[1];
            Item _itemFetch = null;
            IHaveInventory _fromInven = null;
            IHaveInventory _toInven = null;


            if (text.Length == 6 && text[2] == "from" && text[4] == "to")
            {
                _fromInven = FetchItemContainer(s, text[3]);
                if (_fromInven != null)
                {
                    _itemFetch = TakeItemFrom(s, text[1], _fromInven);
                    if (_itemFetch == null)
                        _result = "I can't find " + _searchItem;
                    else
                    {
                        _toInven = FetchContainer(s, text[5]);
                        if (_toInven == null)
                            return "There is no " + text[5] + " in this location";
                        _result = PutThingIn(_itemFetch, _toInven);
                    }
                }
                else
                    _result = "There is no " + text[3] + " in this location";
            }
            else
                _result = "Wrong Format Take/Put Command: Put/Take (Item) from (X) to (Y)";
            return _result;
        }

        private Item TakeItemFrom(Hero p, string itemId, IHaveInventory container)
        {
            return container.Inventory.Take(itemId) as Item;
        }

        private string PutThingIn(Item thingId, IHaveInventory p)
        {
            p.Inventory.Put(thingId);
            return "Item has been added!";
        }

        private IHaveInventory FetchItemContainer(Hero p, string containerId)
        {
            return p.LocateSth(containerId) as IHaveInventory;
        }
        private IHaveInventory FetchContainer(Hero p, string containerId)
        {
            if (!(p.LocateSth(containerId) is GameObject))
                return null;
            else
                return p.LocateSth(containerId) as IHaveInventory;
        }
    }
}