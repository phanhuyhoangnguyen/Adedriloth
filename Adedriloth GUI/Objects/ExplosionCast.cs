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
            string _result = null;
            Enemy _target = null;
            Spell _spellFetch;

            if (text.Length == 6 && text[4] == "enemy" && text[2] == "spell")
            {

                    _spellFetch = FetchSpell(h, "explose");
                if (_spellFetch == null)
                    _result = "You haven't learned this spell";
                else
                {
                    _target = FetchEnemy(h, text[5]);
                    if (_target != null && EnemyManager.Instance.AttackAble(_target))
                        _result = ExploseThisEnemy(h, _target, _spellFetch);
                    else
                        _result = "There is no enemy like that.";
                }
            }
            else
                _result = "Invalid Attack Command!: Cast Explose Spell to Enemy (X)";
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
        /// Cast the spell effect
        /// </summary>
        /// <param name="s">Hero</param>
        /// <param name="e">Targetted Enenmy</param>
        /// <param name="spell">Spell</param>
        /// <returns></returns>
        private string ExploseThisEnemy(SpellHero stu, Enemy e, Spell spell)
        {
            return spell.Cast(stu,e);
        }
    }
}
