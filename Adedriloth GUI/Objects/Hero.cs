using System;
namespace Adedriloth_GUI
{
    /// <summary>
    /// Hero knows its Level and hero type, has its inventory
    /// He is able to locate things in his inventory and able to be destroyed
    /// </summary>
	public class Hero : Character, IHaveInventory, CanCauseDamage
	{
        private Level _level;
        private Inventory _inventory;
        private string _heroType;
        
        //Aggregation: the 2nd object can be created outside and can be passed to the 1st object e.g. location vs hero, location can be exist dependent
        //with hero, we don't just create location inside Hero only but create many location and swap them around. Delete the hero, location objects
        //still exists. However, level object is different, we don't create level object in program.cs but in a Hero object ONLY, delete Hero object
        //There won't be no more level object -> composition
        
        public Hero(string[] ids, string name) : base (ids, name, "A Brave hero with a mission to save the Aderiloth from the hand of the Enemy")
        {
            _inventory = new Inventory();
            _level = new Level();
            Health = 100;
        }

        /// <summary>
        /// Hero Type
        /// </summary>
		public string HeroType
		{
			get
			{
				return _heroType;
			}
            set
            {
                _heroType = value;
            }
		}

        /// <summary>
        /// Find and return Item
        /// </summary>
        /// <param name="id">Item's id</param>
        /// <returns></returns>
        public GameObject LocateSth(string id)
        {
            if (AreYou(id))
                return this;
            else if (_inventory.Fetch(id) == null)
                return Location.LocateSth(id);
            return _inventory.Fetch(id);
        }
        
        /// <summary>
        /// Hero's Full Description: Name, Hero Type, Items in Inventory, Location
        /// </summary>
        public override string FullDescription
        {
            get
            {
                return ("Name: " + Name + Environment.NewLine + "Hero Type: " + _heroType
                    + Environment.NewLine + "Damage: " + Damage +
                    Environment.NewLine + "Level: " + Level.CurrentLev +
                    Environment.NewLine + "You are carrying " + _inventory.ItemList
                    + Environment.NewLine + "You are at: " + Location.Name + Environment.NewLine + "Your HP: " + Health);
            }
        }

        /// <summary>
        /// Hero's Inventory
        /// </summary>
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
            set
            {
                _inventory = value;
            }
        }

        public Level Level { get => _level; set => _level = value; }

        /// <summary>
        /// Return Message when hero die
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override int Destroyed(Character c)
        {
            GameManager.Instance.EndCurrentState();
            return 0;
        }
        
        /// <summary>
        /// Attack the enemy
        /// </summary>
        /// <param name="c">target</param>
        /// <returns>result of attack</returns>
        public override string Hit(Character c)
        {
            string _result = "";
            if (IsAlive)
            {
                Enemy e = c as Enemy;
                if (e != null)
                {
                    e.HitTaken(Damage);
                    _result = e.Name + " is hitted by default punch. Enemy loose " + Damage + " health";
                }
                else
                    _result = "The target is not Enemy.";
            }
            else
            {
                _result = "Hero is dead! Can't attack";
                Destroyed(this);
            }
            return _result;
        }
    }
}
