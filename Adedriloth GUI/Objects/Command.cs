using System;
namespace Adedriloth_GUI
{
    /// <summary>
    /// The Command which Hero can make
    /// </summary>
	public abstract class Command : IdentifiableObject
	{
        //TODO desc?
		public Command(string[] ids) : base(ids)
		{
		}

		public abstract string Execute(Hero stu, string[] text);
	}
}
