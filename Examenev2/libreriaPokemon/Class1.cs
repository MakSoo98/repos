using System;

namespace libreriaPokemon
{
    public class Spell
    {
        private string name;
        private string description;
        private int power_consuption;
        private type ptype;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Power_Consuption
        {
            get { return power_consuption; }
            set { power_consuption = value; }
        }
        public type GetType
        {
            get { return ptype; }
            set { ptype = value; }
        }
        public Spell(string Name, string Description, int Power_Consuption, type GetType)
        {
            name = Name;
            description = Description;
            power_consuption = Power_Consuption;
            ptype = GetType;
        }
    }
    public enum type
    {
        FIRE,
        WATER,
        PLANT
    }
    public class Pokemon
    {
        private string name;
        private string description;
        private int start_energy_level;
        private int expended_energy;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Start_Energy_Level
        {
            get { return start_energy_level; }
            set { start_energy_level = value; }
        }
        public int Expended_energy
        {
            get { return expended_energy; }
            set { expended_energy = value; }
        }
    }


}
