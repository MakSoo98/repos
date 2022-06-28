using System;
using System.Collections.Generic;

namespace madmax_pero_que_funciona
{
    class Program
    {
        static void Main()
        {
            IRace newrace = new Race();
            newrace.Init(80000);
            List<GameObject> gameObjects = newrace.Simulate();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                Console.WriteLine(gameObjects[i]);
            }
        }
        
    }
}
