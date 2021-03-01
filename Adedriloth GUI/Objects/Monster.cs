using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// The normal enemy has all the details about himself 
    /// (health, the location, Its able to attack, hits taken and if its destroyed)
    /// </summary>
    public class Monster : Enemy
    {
        Weapon _weapon = new Dagger(new string[] { "dagger" }, "dagger", 5, "A Small-Sharp Blade");

        public Monster(string name, EnemyType type, string desc) : base( name, type, desc)
        {
            Health = 10;
        }
        
        /// <summary>
        /// Attack the hero
        /// </summary>
        /// <param name="c">Hero</param>
        /// <returns>Result of attack</returns>
        public override string Hit(Character c)
        {
            string _result="";
            if (IsAlive)
            {
                Hero h = c as Hero;
                if (h != null)
                {
                    _weapon.Hit(c);
                    _result = "You has been hitted. You lost " + _weapon.Damage + " health";
                }
                else
                    _result = "The target is not hero!";
            }
            else
            {
                _result = "The " + Name + " is dead!" + " +" + Destroyed(this) + " exp";
            }
            return _result;
        }
    }
}
