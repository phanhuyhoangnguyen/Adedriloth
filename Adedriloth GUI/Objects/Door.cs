using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Door can block the move ability of hero, required the Hero to unlock it before able to move through
    /// </summary>
    public class Door : Path
    {
        private string _keyCode;
        private bool _locked = true; 

        /// <summary>
        /// initialize the keycode based on its id
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="dest"></param>
        public Door(string[] ids, Location dest) : base(ids, dest)
        {
            _keyCode = ids[2];
        }

        /// <summary>
        /// Checking for the valid key, correct key code and unlock the door
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Unlock(GameObject key)
        {
            Key k = key as Key;
            if (k != null)
            {
                if (k.KeyCode == _keyCode)
                {
                    _locked = false;
                    return "The door is unlocked";
                }
                return "Wrong Key.";
            }
            return "This isn't a key:";
        }

        /// <summary>
        /// Move the player to the desired destination, if the door is unlock
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override string MoveTo(Hero p)
        {
            if (_locked)
                return "Door is locked, use " + _keyCode +" to open";
            p.Location = Destination;
            return p.Location.ToString();
        }

        /// <summary>
        /// Return the locking state of the door
        /// </summary>
        public bool IsLocked
        {
            get
            {
                return _locked;
            }

            set
            {
                _locked = value;
            }
        }
    }
}
