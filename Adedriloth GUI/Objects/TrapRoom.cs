using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Special Location, which reduce hero health
    /// </summary>
    public class TrapRoom : Location
    {
        private bool _hasHero = false;

        public TrapRoom(string[] ids, string name) : base(ids, name, "A Trap Room Filled with Fire! Player loose 10 health in every 10 seconds")
        { }

        public override string Arrive(Hero p)
        {
            _hasHero = true;
            p.HitTaken(10);
            return "Clicked! You're in Trapped Room! Danger!!!. Warning Health deducted!";
        }
    }
}
