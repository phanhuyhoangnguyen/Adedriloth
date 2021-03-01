using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class Path : IdentifiableObject
    {
        private Location _pathDestin;
        public Path(string[] ids, Location dest) : base(ids)
        {
            _pathDestin = dest;
        }

        public Location Destination
        {
            get
            {
                return _pathDestin;
            }
        }

        public virtual string MoveTo(Hero p)
        {
            p.Location = Destination;
            return p.Location.ToString();
        }
    }
}
