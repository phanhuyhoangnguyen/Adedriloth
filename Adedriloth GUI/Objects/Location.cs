using System;
using System.Collections.Generic;

namespace Adedriloth_GUI
{

    /// <summary>
    /// Location knows what it contain, which path the hero can go to
    /// </summary>
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private string _arrive = "You've arrived!!";

        private List<Path> _pathList;
        private List<Enemy> _eneList;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _pathList = new List<Path>();
            _eneList = new List<Enemy>();
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        /// <summary>
        /// check if it is player/container or not, if not then execute to search in the 
        /// inventory and return that item/object; every object have their own function description
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GameObject LocateSth(string id)
        {

            if (AreYou(id))
                return this;
            //
            else if (_inventory.Fetch(id) != null)
                return _inventory.Fetch(id);
            return null;
        }

        public void AddPath(Path p)
        {
            _pathList.Add(p);
        }

        public Path LocatePath(string PathId)
        {
            foreach (Path p in _pathList)
                if (p.AreYou(PathId))
                    return p;
            return null;
        }

        public string PathList
        {
            get
            {
                string PathReturn = "";
                foreach (Path p in _pathList)
                {
                    PathReturn += Environment.NewLine + "\t" + p.FirstId + " (" + p.Destination.Name + ")";

                }
                return PathReturn;
            }
        }

        public string EnemyList
        {
            get
            {
                string EnemyReturn = "";
                if (_eneList.Count != 0)
                {
                    foreach (Enemy p in _eneList)
                    {
                        EnemyReturn += Environment.NewLine + "\t" + p.FirstId + " (" + p.Name + ")";

                    }
                }
                else
                    EnemyReturn += "No Enemy!";

                return EnemyReturn;
            }
        }


        public override string FullDescription
        {
            get
            {
                return base.FullDescription + Environment.NewLine + "There is: " + _inventory.ItemList + " on the floor" + Environment.NewLine + "You can move to:" + PathList
                    + Environment.NewLine + "There is: " + EnemyList;
            }
        }

        public List<Enemy> EneList { get => _eneList; set => _eneList = value; }

        public virtual string Arrive(Hero p)
        {
            return _arrive;
        }

       public void AddEnemy(Enemy e)
        {
            _eneList.Add(e);
        }

        public void RemoveEnemy (Enemy e)
        {
            _eneList.Remove(e);
        }

        public Enemy FetchEnemy (string id)
        {
            foreach (Enemy e in _eneList)
            {
                if (e.AreYou(id))
                    return e;
            }
            return null;
        }
    }
}