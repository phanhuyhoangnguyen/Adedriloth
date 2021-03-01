using System;
using System.Collections.Generic;
namespace Adedriloth_GUI
{
    /// <summary>
    /// Game Object class will be used to represent anything that the player can interact with
    /// </summary>
	public class GameObject : IdentifiableObject
	{
        private string _description;
        private string _name;

		public GameObject(string[] ids, string name, string desc) : base (ids)
		{
			_name = name;
            _description = desc;
        }

        /// <summary>
        /// The Name of the object
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// The Short Version Description of the object included: Name and Id
        /// </summary>
        public virtual string ShortDescription
        {
            get
            {
                return (Name + "(" + FirstId + ")");
            }
        }

        /// <summary>
        /// The Long Version Description of the Object
        /// </summary>
        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }
    }
}
