using System;
using System.Collections.Generic;
using System.Text;

namespace UnProyectoQueQuieroHacerFuncionar
{
    class SuperSaiyajin : SpaceWarrior
    {
        public SuperSaiyajin(string name) : base(name,Race.SUPERSAIYAJIN)
         {


         }
    
        public override void Attack(Person oponent)
        { 
            int num_attacks = Utils.GetRandomInt(1, 3);
            for(int i = 0; i < num_attacks; i++)
            {
            
                base.Attack(oponent);
           
            }

        }
        protected override double GetDamageFactor()
        {
            return 2.0;
        }
    }
    




    
}
