using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class Dagger : Weapon, CanCauseDamage
    {
        public Dagger(string[] ids, string name, int damage, string desc) : base(ids, name, desc)
        {
            Damage = damage;
        }

        public override string Hit(Character e)
        {
            e.HitTaken(Damage);
            return "Target is hitted by weapon. Target loose " + Damage + " health";
        }
    }
}
