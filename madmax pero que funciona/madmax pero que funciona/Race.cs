using System;
using System.Collections.Generic;
using System.Text;

namespace madmax_pero_que_funciona
{
    public class Race : IRace
    {
        private List<GameObject> objectList = new List<GameObject>();
        private double distance;
        public void Init(double distance)
        {
            this.distance = distance;
            for(int i = 0; i <20;i++)
            {
                int r = Utils.GetRandomInt(0, 1);
                if(r==0)
                { objectList.Add(new SprintCar("Coche" + i,00)); }
                else
                {
                    objectList.Add(new TrickyCar("Coche" + i, 00));
                }
            }
            for(int i = 0; i<2; i++)
            {
                objectList.Add(new Puddle("charco" + i, Utils.GetRandom(0.0, distance - 0.2))) ;
            }
            int bomb_count = Utils.GetRandomInt(10, 20);
            for (int i = 0; i < bomb_count; i++)
            {
                objectList.Add(new Bomb("bomba" + i, Utils.GetRandom(0.0, distance - 0.2),Utils.GetRandomInt(0,5)));
            }
        }
        public  List<GameObject> Simulate()
        {
            List<GameObject> ret = new List<GameObject>();
            while (ret.Count == 0)
            {
                //se entra aqui por cada nuevo turno
                for (int i= 0; i < GetObjectCount(); i++ )
                {
                    var obj = GetObjectAt(i);

                    if(obj.IsAlive()== false)
                    {
                        objectList.RemoveAt(i);
                        i--;
                        continue;
                    }

                    obj.Simulate(this);
                    if (obj.Position >= distance)
                        ret.Add(obj);
                }
            }
            return ret;
        }
        public int GetObjectCount()
        {
            return objectList.Count;
        }
        public  GameObject GetObjectAt(int index)
        {
            if (0 <= index && index < objectList.Count )
            { return objectList[index]; }
            return null;
            
        }
    }
}
