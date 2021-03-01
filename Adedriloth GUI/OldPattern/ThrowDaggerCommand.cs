using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class ThrowDaggerCommand : Command
    {
        public ThrowDaggerCommand() : base(new string[] { "Throw" })
        {
        }

        public override string Execute(Hero h, string[] text)
        {
            string _result = "Invalid Attack Command!: Throw Dagger to Enemy X";
            string _enemyName = text[4];
            Weapon _dagger;
            Enemy _target;

            if (text.Length != 5)
            {
                return _result;
            }
            else
            {
                if (text[1] != "dagger")
                    _result = "What do you want to throw?";
                else if (text[3] != "enemy")
                    _result = "Miss!";
                else
                {
                    _dagger = FetchDagger(text[1], h);
                    if (_dagger != null)
                    {
                        _target = FetchEnemy(_enemyName);
                        if (_target == null)
                            return "There is no enemy like that.";
                        else if (AttackAble(h, _target))
                            return AttackThisEnemy(_dagger, _target);
                    }
                    _result = "There is no dagger to throw!";
                }
                return _result;
            }
        }

        private Weapon FetchDagger(string dagger, Hero h)
        {
            //This is to check even when the container is valid, is there that item inside
            if (h.LocateSth(dagger) != null)
                return h.LocateSth(dagger) as Weapon;
            return null;
        }

        /// <summary>
        /// Fetch Enemy In Location
        /// </summary>
        /// <param name="eId">Targeted Enemy</param>
        /// <returns>Enemy Found</returns>
        private Enemy FetchEnemy(string eId)
        {
            if (!(GameManager.Instance.EnemySelecting(eId) is GameObject))
                return null;
            else
                return (GameManager.Instance.EnemySelecting(eId) as Enemy);
        }

        /// <summary>
        /// Check If enemy location is same with location
        /// </summary>
        /// <param name="h"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool AttackAble(Hero h, Enemy e)
        {
            if (e.Location == h.Location)
                return true;
            else
                return false;
        }

        private string AttackThisEnemy(Weapon d, Enemy eneFound)
        {
            //This is to check even when the container is valid, is there that item inside
            d.Hit(eneFound);
            return "Hit!\n " + eneFound.FullDescription;
        }
    }
}
