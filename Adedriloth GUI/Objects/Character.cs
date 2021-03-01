using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Abstract Class for moveable objects: Hero and Enemy, has health and able to destroy
    /// </summary>
    public abstract class Character : GameObject
    {
        private int _damage;
        private int _health;
        private Location _location;
        private bool _isAlive = true;
        
        //Because the relationship of Character and Location is Aggression, hence, the character don't create the location in itself but rather pass
        //location object into it
        public Character(string[] ids, string name, string desc) : base(ids, name, desc)
        {
        }

        /// <summary>
        /// The health of the character
        /// </summary>
        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                _health = value;
            }
        }

        /// <summary>
        /// The Location of the character
        /// </summary>
        public Location Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }

        }

        /// <summary>
        /// Abstract for the child class
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public abstract string Hit(Character c);

        /// <summary>
        /// Abstract method for deverrided class
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public abstract int Destroyed(Character c);

        /// <summary>
        /// Damage the character and if the hp is lower than 0, destroy itself
        /// </summary>
        /// <param name="damage">the amount of damge, which deduce the character health</param>
        public void HitTaken(int damage)
        {
            if ((_health -= damage) <= 0)
            {
                _health = 0;
                _isAlive = false;
            }
        }

        /// <summary>
        /// Damage of the character
        /// </summary>
        public int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }

            set
            {
                _isAlive = value;
            }
        }
    }
}
