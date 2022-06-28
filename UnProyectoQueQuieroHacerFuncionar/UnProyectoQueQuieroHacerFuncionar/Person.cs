using System;
using System.Collections.Generic;
using System.Text;

namespace UnProyectoQueQuieroHacerFuncionar
{
    public enum Race
    {
        HUMAN,
        SPACE_WARRIOR,
        SUPERSAIYAJIN,
        NAMEKIAN
    }

     public abstract class Person
    {
        private string name;
        private Race race;
        private double energy;
        private double dodgedesire;

        public abstract void Attack(Person oponent);
        public abstract double GetDodgeValue();
        public abstract double GetBlockValue();

          public Person(string name, Race race, double energy, double dodgedesire)
        {
            this.name = name;
            this.race = race;
            this.energy = Utils.GetRandom(1000.0, 2000.0);
            this.dodgedesire = Utils.GetRandom(0.1, 0.9);
        }
         public Person(string name, Race race)
            //esto lo he sacado de la manga
        {
           
        }
        
        public string Name
        {
            get { return name; }
            
        }
         public Race GetRace
        {
            get { return race; }
            
        }
        public double Energy
        {
            get { return energy; }
        }
        public void DropEnergy(double amount)
        {
            energy -= amount;
        }
        public bool WantsDodge()
        {
            return Utils.GetRandom(0.0, 1.0) < dodgedesire;
            
        }
        protected void PerformAttack(Person oponent, double AttackEnergy, double Attackcapacity,
            double FullDamage, double MinDamage)
        {
            double attack_random = Utils.GetRandom(0.0, 1.0);
            DropEnergy(AttackEnergy);
            if (attack_random < Attackcapacity)
            {
                if (oponent.WantsDodge())
                {

                    if (Utils.GetRandom(0, 1) > oponent.GetDodgeValue())
                    {
                        oponent.DropEnergy(FullDamage);
                    }
                    else
                    {
                        if (Utils.GetRandom(0, 1) > oponent.GetBlockValue())
                            oponent.DropEnergy(MinDamage);
                        else
                            oponent.DropEnergy(FullDamage);
                    }
                }
            }
        }
        private double savedEnergy;

        public void SaveEnergy(Person p)
        {
             savedEnergy = p.Energy; 
        }
        public void  LoadEnergy()
        {
            energy = savedEnergy;
        }









    }
    class Human : Person
    {
        private double ataquefisico = Utils.GetRandom(0.1, 0.8);
        private double dodgecapacity = Utils.GetRandom(0.4, 0.6);
        private double blockcapacity = Utils.GetRandom(0.7,0.9);


        public Human(string name) : base(name, Race.HUMAN,Utils.GetRandom(1000.0 , 2000.0), Utils.GetRandom(0.1, 0.9))
      {


      }
        public override void Attack(Person oponent)
        {
            double attack_random = Utils.GetRandom(0.0, 1.0);

            DropEnergy(1);
            if (attack_random < ataquefisico)
            {
                if (oponent.WantsDodge())
                {
                    if(Utils.GetRandom(0,1)>oponent.GetDodgeValue())
                    {
                        oponent.DropEnergy(3.0);
                    }
                    else
                    {
                        if(Utils.GetRandom(0, 1) > oponent.GetBlockValue())
                        {
                            oponent.DropEnergy(0.5);
                            
                        }
                        else
                        {
                            oponent.DropEnergy(3.0);
                        }

                    }
                }
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




          



    

