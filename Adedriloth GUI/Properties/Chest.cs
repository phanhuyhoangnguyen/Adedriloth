using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class Chest : Item, IHaveInventory
    {
        private Inventory _inventory;

        // the error appear because you're basically calling base () without passing an actual value
        public Chest(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject LocateSth(string id)
        {
            if (AreYou(id))
                return this;
            return _inventory.Fetch(id);
        }
        
        public override string FullDescription
        {
            get
            {
                return ("In the " + Name + " you can see:" + _inventory.ItemList);
            }

        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
