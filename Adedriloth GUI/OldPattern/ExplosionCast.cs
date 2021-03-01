using System;
namespace Adedriloth_GUI
{
    //TeleportingCast inherit from SpellCast because it is a spell casting, it is not a command
    //Of course we can treat it as a command, however this is not a good way of designing program
    public class ExplosionCast : SpellCast
    {
        public ExplosionCast() : base(new string[] { "explose" })
        {
        }

        public override string Execute(SpellHero h, string[] text)
        {
            string _result = "Invalid Attack Command!: Cast Eplose the Enemy X";
            string _enemyName = text[4];
            Enemy _target;
            Spell _spellFetch;

            if (text.Length != 5)
            {
                return _result;
            }
            else
            {
                if (text[3] != "enemy")
                    _result = "Invalid Attack Command!: Cast eplose the Enemy X";
                else
                {
                    _spellFetch = FetchSpell(h, "explose");
                    if (_spellFetch == null)
                        return "You haven't learned this spell";
                    _target = FetchEnemy(_enemyName);
                    if (_target == null)
                        return "There is no enemy like that.";
                    else if (AttackAble(h, _target))
                        _result = ExploseThisEnemy(h, _target, _spellFetch);
                }
                return _result;
            }
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
            //return (GameController.EnemySelecting(eId) as Enemy);
        }

        private string ExploseThisEnemy(SpellHero stu, Enemy e, Spell spell)
        {
            return spell.Cast(stu,e);
        }
    }
}
