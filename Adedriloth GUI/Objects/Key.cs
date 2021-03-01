using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Key knows its keycode, can be used to unlock the door
    /// </summary>
    public class Key : Item//, UsableItem
    {
        private string _keyCode;

        public Key(string[] ids, string name) : base(ids, name, "A key to unlock door")
        {
            _keyCode = ids[0];
        }

        public virtual string Use(Door d)
        {
            return d.Unlock(this);
        }

        public string KeyCode
        {
            get
            {
                return _keyCode;
            }
            set
            {
                _keyCode = value;
            }
        }
    }
}
