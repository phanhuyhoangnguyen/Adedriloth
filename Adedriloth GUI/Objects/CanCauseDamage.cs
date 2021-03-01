using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Interface for object which can attack/hit the others
    /// </summary>
    public interface CanCauseDamage
    {
        string Hit(Character c);
    }
}
