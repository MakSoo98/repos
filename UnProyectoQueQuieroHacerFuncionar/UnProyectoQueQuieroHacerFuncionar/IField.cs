using System;
using System.Collections.Generic;
using System.Text;

namespace UnProyectoQueQuieroHacerFuncionar
{
    public delegate void Visitor(Person person);

    public interface IField
    {
        void Init();
        List<string> Execute();
        public void Visit(Visitor visitor);
    }
}
