using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Type of Weapon, which can cause a certain damage for the object, which is hitted
    /// </summary>
    public abstract class Weapon : Item, CanCauseDamage
    {
        private int damage;
        public Weapon(string[] ids, string name, string desc) : base(ids, name, desc)
        {
        }

        public int Damage { get => damage; set => damage = value; }

        /// <summary>
        /// Hit a certain enemy and reduce its health
        /// </summary>
        /// <param name="e">Targetted enemy e, which is hitted</param>
        public abstract string Hit(Character e);
    }
}
