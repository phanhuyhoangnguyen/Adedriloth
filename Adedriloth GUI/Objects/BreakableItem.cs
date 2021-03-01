using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// BreakableKey is kind of a key, that use to unlock door, however, after use once, it automatically disappear
    /// </summary>
    public class BreakableKey : Key, Disposable
    {
        private bool _notBroken = true;
        /// <summary>
        /// Initialize the KeyCode from the ID
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="name"></param>
        public BreakableKey(string[] ids, string name) : base(ids, name)
        {
            KeyCode = ids[0];
        }

        /// <summary>
        /// Pass itself as an object to the door to unlock it
        /// </summary>
        /// <param name="d">door object, which will be unlock</param>
        /// <returns></returns>
        public override string Use(Door d)
        {
            string result = "The Stone is broken! You can't use it anymore";
            if (_notBroken)
            {
                result = d.Unlock(this);
                _notBroken = false;
            }
            return result;
        }

        public bool Usable
        {
            get
            {
                return _notBroken;
            }
        }

    }
}
