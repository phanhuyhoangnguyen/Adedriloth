using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class EnemyManager
    {
        private static EnemyManager _instance;

        private List<Enemy> _enemyList = new List<Enemy>();

        private Random r = new Random();
        
        /// <summary>
        /// Generating Enemy in particular room
        /// </summary>
        /// <param name="room"></param>
        public void EnemyGenerating(Location room)
        {
            switch (r.Next(0,2))
            {
                case 0:
                    GenerateGoblin(room);
                        break;

                default:
                    GenerateSlime(room);
                        break;
            }
        }
        /// <summary>
        /// Generating Slime Enemy
        /// </summary>
        /// <param name="room"></param>
        public void GenerateSlime(Location room)
        {
            Slime e = new Slime("Slime", EnemyType.Slime, 2, "A poinsonous monster");
            e.Location = room;
            _enemyList.Add(e);
            room.AddEnemy(e);
        }
        /// <summary>
        /// Generate Monster Enemy
        /// </summary>
        /// <param name="room"></param>
        public void GenerateGoblin(Location room)
        {
            Monster e = new Monster("Beast", EnemyType.Goblin, "A beast monster");
            e.Location = room;
            room.AddEnemy(e);
            _enemyList.Add(e);
        }

        public static EnemyManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EnemyManager();

                }
                return _instance;
            }
        }

        /// <summary>
        /// Remove Enemy when its die
        /// </summary>
        /// <param name="e"></param>
        public void RemoveEnemy(Enemy e)
        {
            e.Location.RemoveEnemy(e);
            _enemyList.Remove(e);
            
        }

        public string Attack()
        {
            string _result = null;
            List<Enemy> _attackable = new List<Enemy>();
            foreach (Enemy e in _enemyList)
                if(AttackAble(e))
                _attackable.Add(e);
            foreach(Enemy e in _attackable)
                _result +=e.Hit(HeroManager.Instance.CurrentHero) + Environment.NewLine;
            return _result;
        }

        public bool AttackAble(Enemy e)
        {
            if (e != null)
            {
                if (HeroManager.Instance.CurrentHero.Location == e.Location)
                    return true;
            }
            return false;
        }
    }
}
