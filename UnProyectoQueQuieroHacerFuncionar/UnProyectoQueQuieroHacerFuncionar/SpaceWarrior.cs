using System;
using System.Collections.Generic;
using System.Text;

namespace UnProyectoQueQuieroHacerFuncionar
{
    class SpaceWarrior : Person
    {
        private double ataqueRayo = Utils.GetRandom(0.3, 0.6);
        private double ataquefisico = Utils.GetRandom(0.1, 0.8);
        private double dodgecapacity = Utils.GetRandom(0.2, 0.4);
        private double blockcapacity = Utils.GetRandom(0.4, 0.9);


        public SpaceWarrior(string name) : base(name, Race.SPACE_WARRIOR, Utils.GetRandom(1000.0, 2000.0), Utils.GetRandom(0.1, 0.9))
        {


        }
        public SpaceWarrior(string name, Race race) : base(name, race) 
        {

        }


        protected virtual double GetDamageFactor()
        {
            return 1.0;
        }
        public override void Attack(Person oponent)
        {
            int ia = Utils.GetRandomInt(0, 1);
            double attack_random = Utils.GetRandom(0, 1);

            switch (ia)
            {
                //ataque con rayo
                case 0:
                    PerformAttack(oponent, 100, ataqueRayo, 300.0 * GetDamageFactor(), 25.0 * GetDamageFactor());
                    break;

                default:
                    PerformAttack(oponent, 5.0, ataquefisico, 7.0 * GetDamageFactor(), 2.0 * GetDamageFactor());
                    break;
            }

        }




        public override double GetDodgeValue()
        {
            return dodgecapacity;
        }
        public override double GetBlockValue()
        {
            return blockcapacity;
        }
    }
}
