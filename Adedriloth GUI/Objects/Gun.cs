using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    public class Gun: Weapon, CanCauseDamage
    {
        private List<Bullet> _bulletList = new List<Bullet>();

        //private int _dmgCount = 0;
        private int _bulletsNo = 0;

        public Gun(string[] ids, string name, int bulletnumber, string desc) : base(ids, name, desc)
        {
            _bulletsNo = bulletnumber;
            for (int i = 0; i < _bulletsNo; i++)
            {
                AddBullet(new Bullet());
            }
        }

        public override string Hit(Character e)
        {
            string _result = null;

            if (_bulletList.Count != 0)
            {
                foreach (Bullet n in _bulletList)
                {

                    _result = n.Hit(e);
                    RemoveBullet(n);
                    return _result;
                }
            }

            else
                _result = "Out of bullet";
            return _result;
        }

        public override string FullDescription {
            get
            {
                return base.FullDescription + ": " + _bulletsNo + " bullets";
            }
        }

        private void AddBullet(Bullet e)
        {
            _bulletList.Add(e);
        }

        private void RemoveBullet(Bullet e)
        {
            _bulletList.Remove(e);
        }
    }
}
