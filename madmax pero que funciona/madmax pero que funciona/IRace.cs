using System;
using System.Collections.Generic;
using System.Text;

namespace madmax_pero_que_funciona
{
     public interface IRace
    {
         void Init(double distante);

        List<GameObject> Simulate();

        int GetObjectCount();

        GameObject GetObjectAt(int index);

    }
}
