using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class AttackCommand : Command
    {
        /// <summary>
        /// Attack Command receive the user's input and process to tell the hero attack the enemy
        /// Either using the default attack or using the weapon
        /// </summary>
        public AttackCommand() : base(new string[] { "Attack", "kill" })
        {
        }

        /// <summary>
        /// Process the attack command and return the result of attack
        /// </summary>
        /// <param name="h">hero</param>
        /// <param name="text">command</param>
        /// <returns>result of attack</returns>
        public override string Execute(Hero h, string[] text)
        {
            string _result = null;
            Enemy _target;
            CanCauseDamage _attacker = h as CanCauseDamage;

            if (text.Length == 3 || text.Length == 5)
            {
                if (text[1] != "enemy")
                    _result = "Invalid Attack Command!: Attack Enemy (X)";
                else
                {
                    string _enemyName = text[2];
                    _target = FetchEnemy (h, _enemyName);
                    if (_target != null && EnemyManager.Instance.AttackAble(_target))
                    {
                        if (text.Length == 3)
                            _attacker = h as CanCauseDamage;
                        else if (text.Length == 5)
                        {
                            if (text[3] != "using")
                                _result = "Do you mean: Attack Enemy X 'using' W?";

                            else
                            {
                                _attacker = FetchAttacker(h, text[4]);
                                if (_attacker != null)
                                    return _result = AttackThisEnemy(_attacker, _target);
                                _result = "Can't find the " + text[4] + "!";
                            }
                            return _result;
                        }
                        _result = AttackThisEnemy(_attacker, _target);
                    }
                    else
                        _result = "There is no enemy like that.";
                }
            }
            else
            {
                _result = "Invalid Attack Command!: Attack Enemy (X) using (W)";
            }
            return _result;
        }

        /// <summary>
        /// Fetch Enemy In Location
        /// </summary>
        /// <param name="eId">Targeted Enemy</param>
        /// <returns>Enemy Found</returns>
        private Enemy FetchEnemy(Hero h, string eId)
        {
            if (!(h.Location.FetchEnemy(eId) is GameObject))
                return null;
            else
                return (h.Location.FetchEnemy(eId) as Enemy);
        }

        /// <summary>
        /// Fetch things that cause damage
        /// </summary>
        /// <param name="h">hero</param>
        /// <param name="wId">ID of things that cause damage</param>
        /// <returns></returns>
        private CanCauseDamage FetchAttacker(Hero h, string wId)
        {
            if (h.LocateSth(wId) != null)
                return h.LocateSth(wId) as CanCauseDamage;
            return null;
        }

        /// <summary>
        /// Hit the targetted enemy and return result of attack
        /// </summary>
        /// <param name="h">thing that cause damage</param>
        /// <param name="eneFound">targetted enemy</param>
        /// <returns>result of attack</returns>
        private string AttackThisEnemy(CanCauseDamage h, Enemy eneFound)
        {
            return GameManager.Instance.AttackController(h, eneFound) + Environment.NewLine + eneFound.FullDescription;
        }
    }
}
