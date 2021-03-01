using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class OutputManager
    {
        private static OutputManager _instance;

        private string _messageRetn;

        public static OutputManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new OutputManager();
                return _instance;
            }
        }

        public string Output
        {
            get
            {
                return _messageRetn;
            }

            set
            {
                _messageRetn += value + Environment.NewLine;
            }
        }

        public void Clear()
        {
            _messageRetn = null;
        }

    }
}
