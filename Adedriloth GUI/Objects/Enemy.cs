using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public abstract class Enemy : Character, CanCauseDamage
    {
        EnemyType _eneType;
        public Enemy(string name, EnemyType type, string desc) : base( new string[] { name } , name, desc)
        {
            _eneType = type;
        }

        /// <summary>
        /// Full Information of the Enemy: Name, HP
        /// </summary>
        public override string FullDescription
        {
            get
            {
                return "Enemy " + Name + Environment.NewLine + _eneType + Environment.NewLine + "HP: " + Health;
            }
        }

        /// <summary>
        /// Enemy died and removed out of the game
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override int Destroyed(Character c)
        {
            EnemyManager.Instance.RemoveEnemy(this);
            HeroManager.Instance.LevelUp((int)(_eneType));
            return (int)_eneType;

        }
    }
}
