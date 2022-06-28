using System;
using System.Collections.Generic;

namespace UnProyectoQueQuieroHacerFuncionar
{
    class Program
    {
        
        static void Main()
        {
            IField Torneo = new Field();
            Torneo.Init();
            List<string> results = Torneo.Execute();
            for (int i= 0; i <results.Count;i++)
            {
                Console.WriteLine(results[i]);
            }
            

        }

    
        
       

        

    }
    
    

}
