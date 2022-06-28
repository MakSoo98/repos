using System;
using System.Collections.Generic;
using System.Text;

namespace madmax_pero_que_funciona
{
    abstract public class GameObject
    {
        private string name;
        private double position;
        protected int PausedTurnsCount = 0;


        public string Name
        {
            get { return name; }
        }
        public double Position
        {
            get { return position; }
        }

        public abstract ObjectType GetObjectType();
        public void Pause(int turns)
        {
            PausedTurnsCount += turns;
        }

        public abstract void Simulate(IRace race);


        public GameObject(string name,double position)
        {
            this.name = name;
            this.position = position;
        }
        public virtual bool IsAlive()
        {
            return true;
        }
        public void Displace(double displacement)
        { this.position += displacement; }

        public virtual bool isCar()
        {
            return false;
        }

    }

    public enum ObjectType
    {
        PUDDLE,
        BOMB,
        SPRINTCAR,
        TRICK_CAR
    }
    public abstract class Obstacle : GameObject
    {
        
        public Obstacle(string name,double position):base(name,position)
        {

        }
        
        

    }
    public abstract class Car : GameObject
    {
        protected double finetunning;
        public Car(string name,double finetunning):base(name,0.0)
        {
            this.finetunning = finetunning;
        }
        public double Getfinetunning()
        {
            return finetunning;
        }
        public override bool isCar()
        {
            return true;
        }
        


    }
     //Obstaculos
    public class Puddle : Obstacle    
    {
        public Puddle(string name, double position) : base(name, position)
        {

        }
        public override ObjectType GetObjectType()
        {
            return ObjectType.PUDDLE;
        }
        public override void Simulate(IRace race)
        {
            for(int i=0;i<race.GetObjectCount();i++)
            {
                var obj = race.GetObjectAt(i);
                if (obj != this && Utils.GetDistance(Position,obj.Position)<=20)
                {
                    if(Utils.GetRandom(0.0,100.0)<20.0)
                    {
                        obj.Pause(Utils.GetRandomInt(1, 3));
                    }
                }
            }
        }

    }

    public class Bomb : Obstacle
    {
        private int explodeCount;
        public Bomb(string name, double position, int explodeCount) : base(name, position)
        {
            this.explodeCount = explodeCount;
        }
        public override ObjectType GetObjectType()
        {
            return ObjectType.BOMB;
        }
        public override bool IsAlive()
        {
            return explodeCount >= 0;
        }
        public override void Simulate(IRace race)
        {
            explodeCount--;
            if (explodeCount == 0)
            {for (int i = 0; i < race.GetObjectCount(); i++)
            {
                var obj = race.GetObjectAt(i);
                if (obj != this && Utils.GetDistance(Position, obj.Position) <= 50)
                {
                        obj.Displace(Utils.GetRandom(-50.00,50.00));
                }
            }
        } }
            

    }

    //Coches

    public class SprintCar : Car
    {
        public SprintCar(string name, double position) : base(name, position)
        {

        }
        public override ObjectType GetObjectType()
        {
            return ObjectType.SPRINTCAR;
        }
        public override void Simulate(IRace race)
        {
            if (PausedTurnsCount == 0)
            {
                Displace(15.00 + Getfinetunning()); 
            if(Utils.GetRandom(0,100)<60)
            { Displace(5); }
            }
            else
            {
                PausedTurnsCount--;
            }
                    

            
            
        }

    }
    public class TrickyCar : Car
    {
        public TrickyCar(string name, double position) : base(name, position)
        {

        }
        public override ObjectType GetObjectType()
        {
            return ObjectType.TRICK_CAR;
        }
        private GameObject GetBehindCar(IRace race)
        {
            int min_index = -1;
            double min_distance = double.MaxValue;
            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < race.GetObjectCount(); i++)
            {
                var obj = race.GetObjectAt(i);
                if (obj != this && obj.Position < Position && obj.isCar() == true)
                {
                    var dis = Utils.GetDistance(obj.Position,Position);
                    if (dis < min_distance)
                    {
                        min_distance = dis;
                        min_index = i;
                    }
                }
            }
            if(min_index < 0)
            { return null; }
            return race.GetObjectAt(min_index);
        }
        public override void Simulate(IRace race)
        {
            if (race == null)
                return;
            if (PausedTurnsCount == 0)
            {
                Displace(18.00 + Getfinetunning());
                if (Utils.GetRandom(0,100) < 70)
                {
                    if(Utils.GetRandom(0,100)<30)
                    {
                        GameObject obj = GetBehindCar(race);
                        if (obj != null)
                        {
                            obj.Pause(1);
                        }
                    }
                }
            }
            else
            {
                PausedTurnsCount--;
            }
        }

    }
}
