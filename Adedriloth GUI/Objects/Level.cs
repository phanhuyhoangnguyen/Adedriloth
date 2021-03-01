using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class Level
    {
        private int _exp = 0;

        private int _currentLev = 1;

        private int _nextLev = 10;

        public int CurrentLev { get => _currentLev; set => _currentLev = value; }
        internal int NextLev { get => _nextLev; set => _nextLev = value; }

        public void AddExp(int exp, Hero h)
        {
            _exp += exp;
            if (_exp >= h.Level.NextLev)
            {
                _currentLev++;
                _nextLev = _currentLev * 100;
                OutputManager.Instance.Output += "Congratulation! Your Level is UP!" + Environment.NewLine + "Level: " + _currentLev;
            }

        }
    }
}
