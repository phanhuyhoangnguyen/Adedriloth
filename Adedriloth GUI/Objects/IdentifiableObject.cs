using System;
using System.Linq;
using System.Collections.Generic;

namespace Adedriloth_GUI
{
	public class IdentifiableObject
	{
		private List<string> _idents;

		public IdentifiableObject(string[] ids)
		{
			_idents = new List<string>(ids);
		}

		public bool AreYou(string id)
		{
			return(_idents.Contains(id, StringComparer.OrdinalIgnoreCase));
		}

        public string FirstId
        {
            get
            {
                if (_idents.Count == 0)
                    return "";
                else
                    return _idents[0];
            }
        }

        public void AddIdentifier(string id)
        {
            _idents.Add(id.ToLower());
        }

        public string SecondId
        {
            get
            {
                if (!(_idents.Count >= 1))
                    return "";
                else
                    return _idents[1];
            }
        }
    }
}
