using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public interface IHaveInventory
    {
        // interface: the use of interface is to support the inheritance, interface help to enforce and classif the object have similar characteristic
        // e.g. Bag is Item and so does the key. However, key, like some the other items can be used but bag can not. To solve this, we need interface Useable
        GameObject LocateSth(string id);

        Inventory Inventory { get; }
    }
}
