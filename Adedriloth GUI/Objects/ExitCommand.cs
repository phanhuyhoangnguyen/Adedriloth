using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Handle Exit Command
    /// </summary>
    public class ExitCommand : Command
    {
        public ExitCommand() : base(new string[] { "x", "exit" })
        {
        }

        //Execute the command by processing its words/elements in arrays
        /// <summary>
        /// Process the command and produce the result
        /// </summary>
        /// <param name="p">the hero who make the command</param>
        /// <param name="text">the command</param>
        /// <returns></returns>
        public override string Execute(Hero p, string[] text)
        {
            if (text[0] == "exit" || text[0] == "x")
                GameManager.Instance.EndCurrentState();
                return "exit";
            return "There is no command like that";
        }
    }
}
