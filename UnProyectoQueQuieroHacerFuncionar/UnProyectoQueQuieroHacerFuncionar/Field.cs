using System;
using System.Collections.Generic;
using System.Text;

namespace UnProyectoQueQuieroHacerFuncionar
{
    public class Field : IField
    {
        List<Person> Character = new List<Person>();
        public Field()
        {

        }
        Person CreateCharacter(string name, Race race)
        {
            switch(race)
            {
                case Race.HUMAN:
                    return new Human(name);
                case Race.SPACE_WARRIOR:
                    return new SpaceWarrior(name);
                case Race.SUPERSAIYAJIN:
                    return new SuperSaiyajin(name);
                default:
                    return new Human(name);

            }
        }
        void AddCharacter(string name, Race race)
        {
            Character.Add(CreateCharacter(name, race));
        }

        public void Init()
        {
            while(Character.Count < 16 )
            {
                string name = "Persona " + Utils.GetRandomInt(0, 1000);
                switch (Utils.GetRandomInt(0,2))
                {
                    case 0:
                        AddCharacter(name,Race.HUMAN);
                        break;
                    case 1:
                        AddCharacter(name, Race.SPACE_WARRIOR);
                            break;
                    case 2:
                        AddCharacter(name, Race.SUPERSAIYAJIN);
                        break;

                }
                
            }
        }
        Person PerformEncounter(Person a, Person b)
        {
            Person winner = null;
            int turn = 0;

            a.SaveEnergy(a);
            b.SaveEnergy(b);

            while (winner == null)
            {
                turn = +1;
                if ((turn % 2) == 0)
                    a.Attack(b);
                else
                    b.Attack(a);
                if (a.Energy <= 0.0)
                    winner = b;
                if (b.Energy <= 0.0)
                    winner = a;
            }
            a.LoadEnergy();
            b.LoadEnergy();

            return winner;
        }
        string EncounterToString(Person a, Person b, Person winner)
        {
            string ret = a.Name + " vs " + b.Name + " winner = " +winner.Name;
            
            return ret;
        }
        public List<string> Execute()
        {
            List<string> ret = new List<string>();
            List<Person> list = new List<Person>(Character);

            while(list.Count > 1)
            {
                List<Person> WinnersList = new List<Person>();
                for (int i = 0; i < list.Count; i+=2)
                {
                    Person c1 = list[i];
                    Person c2 = list[i + 1];
                    Person winner = PerformEncounter(c1, c2);
                    string res = EncounterToString(c1, c2, winner);
                    WinnersList.Add(winner);
                    ret.Add(res);
                }
                list = WinnersList;
            }
            ret.Add("El ganador es " + list[0].Name);
            return ret;
        }
          public void Visit(Visitor visitor)
        {
            if (visitor == null)
                return;
            foreach (Person p in Character)
                visitor(p);
        }
        void main()
        {
            IField f = new Field();
            f.Init();
            f.Visit((p) => {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.GetRace);
                Console.WriteLine(p.Energy);
            });
        }

    }
     
}
