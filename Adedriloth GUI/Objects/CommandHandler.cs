using System;
using System.Collections.Generic;

namespace Adedriloth_GUI
{
    /// <summary>
    /// command processor will contain a list of Command objects (one of each kind of Command). 
    /// This can be used to execute the user's commands. When execute "a command" is
    /// given to the Command Processor, it searches for a command that is identified by the first word,
    /// then tells it to execute the text.
    /// </summary>
	public class CommandHandler
	{
        private List<Command> _cmdList;
        
        
        public CommandHandler()
        {
            _cmdList = new List<Command>();
            AddCmdList(new LookCommand());
            AddCmdList(new MoveCommand());
            AddCmdList(new UseKeyCommand());
            AddCmdList(new ExitCommand());
            AddCmdList(new PutCommand());
            AddCmdList(new SwitchCommand());
            AddCmdList(new AttackCommand());
        }

        /// <summary>
        /// searches for a command that is identified by the first word,
        /// then tells it to execute the text
        /// </summary>
        /// <param name="stu"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public string Execute(Hero stu, string[] cmd)
		{
			foreach (Command c in _cmdList)
				if (c.AreYou(cmd[0]))
					return c.Execute(stu, cmd);
			return "Input Command";
		}
        
        /// <summary>
        /// Add different type of command into command list
        /// </summary>
        /// <param name="c">Command c is added in command list</param>
		public void AddCmdList(Command c)
		{
			_cmdList.Add(c);
		}
	}
}
