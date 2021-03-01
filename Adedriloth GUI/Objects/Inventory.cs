using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// The Inventory is object, used to contains a collection of Items
    /// Support container object to check item insided, add more items or take items out
    /// </summary>
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Check if the Inventory contain a certain item in itself
        /// </summary>
        /// <param name="itemId">Id of the item which will be search</param>
        /// <returns>return true if the item is found and false if unfound</returns>
        public bool HasItem(string itemId)
        {
            bool result = false;
            foreach (Item i in _items)
            {
                if (i.AreYou(itemId))
                    result = true;
            }
            return result;
        }

        /// <summary>
        /// Put/Add a particular item inside the caller's invetory
        /// </summary>
        /// <param name="itm">the itm item which is added</param>
        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        /// <summary>
        /// Search through all the items inside the inventory and return the item found
        /// also delete the item found inside the inventory
        /// </summary>
        /// <param name="id">id of Item which will be searched</param>
        /// <returns>return item if found or return null if unfound</returns>
        public Item Take(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    _items.Remove(i);
                    return i;
                }
            }
            return null;
        }

        /// <summary>
        /// Search through all the items inside the inventory and return the item found
        /// </summary>
        /// <param name="id">id of Item which will be searched</param>
        /// <returns>return item if found or return null if unfound</returns>
        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                    return i;
            }
            return null;
        }

        /// <summary>
        /// Return the description of all the items in the inventory
        /// </summary>
        public string ItemList
        {
            get
            {
                string itemReturn = "";

                foreach (Item i in _items)
                    itemReturn += Environment.NewLine + "\t" + i.ShortDescription;
                if (itemReturn == "")
                    itemReturn = "Nothing";
                return itemReturn;
            }
        }
    }
}
