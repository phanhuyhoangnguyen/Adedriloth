using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Type of Hero: attack melee damage
    /// </summary>
    public class MeleeHero : Hero
    {
        //private List<Weapon> _weaponList = new List<Weapon>();

        private Weapon _weapon = new Dagger(new string[] { "dagger" }, "dagger", 7, "A Small-Sharp Blade");

        public MeleeHero() : base(new string[] { "Assasin", "me" }, "Darius")
        {
            //_weaponList.Add(new Dagger(new string[] { "dagger" }, "dagger", 5, "A Small-Sharp Blade"));
            HeroType = "Melee Hero - A Close-Combat Hero";
            Damage = _weapon.Damage;
        }

        public override string Hit(Character c)
        {
            string _result = "";
            if (IsAlive)
            {
                Enemy e = c as Enemy;
                if (e != null)
                {
                    //_weaponList[0].Hit(e);
                    _weapon.Hit(e);
                    _result = e.Name + " is hitted by default punch. Enemy loose " + _weapon.Damage + " health";
                }
                else
                    _result = "The target is not Enemy.";
            }
            else
                _result = "Hero is dead! Can't attack";
            return _result;
        }

        public override string FullDescription
        {
            get
            {
                return base.FullDescription + Environment.NewLine + "Weapon: " + _weapon.Name;
            }
        }

        /*public void AddWeapon(Weapon w)
        {
            _weaponList.Add(w);
        }

        public Weapon FetchWeapon(string id)
        {
            foreach (Weapon w in _weaponList)
            {
                if (w.AreYou(id))
                    return w;
            }
            return null;
        }*/
    }
}
