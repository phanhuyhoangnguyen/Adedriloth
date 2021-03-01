using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// control and manage hero, allow the player to switch hero
    /// </summary>
    public class HeroManager
    {
        private static HeroManager _instance;

        private Hero _currentHero;
        private SpellHero _spellHero;
        private MeleeHero _meleeHero;

        /// <summary>
        /// create 2 hero object and assign the default hero to be the Spell Type
        /// </summary>
        private HeroManager()
        {
            _spellHero = new SpellHero();
            _meleeHero = new MeleeHero();
            _currentHero = _spellHero;
        }

        /// <summary>
        /// Apply the Singleton Patten, create object itself if the object doesn't exist
        /// </summary>
        public static HeroManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HeroManager();
                }
                return _instance;
            }
        }
        
        public Hero CurrentHero
        {
            get
            {
                return _currentHero;
            }
        }

        public SpellHero SpellHero
        {
            get
            {
                return _spellHero;
            }
        }

        /// <summary>
        /// Check and switch the hero
        /// </summary>
        public void SwitchHero()
        {
            if (_currentHero == _spellHero)
            {
                _currentHero = _meleeHero;
                _currentHero.Location = _spellHero.Location;
                _currentHero.Inventory = _spellHero.Inventory;
            }
            else
            {
                _currentHero = _spellHero;
                _currentHero.Location = _meleeHero.Location;
                _currentHero.Inventory = _meleeHero.Inventory;
            }
        }

        public void LevelUp(int exp)
        {
            _currentHero.Level.AddExp(exp, _currentHero);
        }
    }
}
