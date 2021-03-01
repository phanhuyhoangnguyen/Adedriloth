namespace Adedriloth_GUI
{
    public class Bullet: CanCauseDamage
    {
        private int _damage = 10;
           
        public string Hit(Character e)
        {
            e.HitTaken(_damage);
            return "Target is hitted by weapon. Enemy loose " + _damage + " health";
        }

        private int Damage
        {
            get
            {
                return _damage;
            }
        }
    }
}