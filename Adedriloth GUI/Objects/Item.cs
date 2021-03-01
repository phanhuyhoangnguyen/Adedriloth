using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Item can be interacted which Hero in certain way: put in, take out from the Inventory
    /// </summary>
    public class Item : GameObject
    {
        public Item(string[] ids, string name, string desc) :
        base(ids, name, desc)
        {
        }
    }
}
