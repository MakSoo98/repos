using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness_App
{
    public class User : IUser
    {
        
        private string Nick;
        private string NombreUsuario;
        private string Apellidos;
        private string Correo;
        private string Contraseña;
        private double Peso;
        private int Edad;
        private string Descripción;
        private int ScorePoints;

        public int Score()
        {
            //Sin Hacer
            return 0;
        }
        public int GetScore()
        {
            //Sin Hacer
            return 0;
        }
        public int GetTotal()
        {
            //Sin Hacer
            return 0;
        }

        
        public string nick
        {
            get { return Nick; }
            set { value = Nick; }
        }
        public string nombreusuario
        {
            get { return NombreUsuario; }
            set { value = NombreUsuario; }
        }
        public string apellidos
        {
            get { return Apellidos; }
           set { value = Apellidos; }
        }
        public string correo
        {
            get { return Correo; }
            set { value = Correo; }
        }
        public string contraseña
        {
            get { return Contraseña; }
            set { value = Contraseña; }
        }
        public double peso
        {
            get { return Peso; }
            set { value = Peso; }
        }
        public int edad
        {
            get { return Edad; }
            set { value = Edad; }
        }
        public string descripcion
        {
            get { return Descripción; }
            set { value = Descripción; }
        }
        public int scorepoints
        {
            get { return ScorePoints; }
            set { value = ScorePoints; }
        }
        public User( string nick, string nombreusuario, string apellidos, string correo, string contraseña, double peso, int edad, string descripcion,int scorepoints)
        {
            
            this.Nick = nick;
            this.NombreUsuario = nombreusuario;
            this.Apellidos = apellidos;
            this.Correo = correo;
            this.Contraseña = contraseña;
            this.Peso = peso;
            this.Edad = edad;
            this.Descripción = descripcion;
            this.ScorePoints = scorepoints;


        }
        public User()
        {

        }
        public User(string nick, string contraseña)
        {
            this.Nick = nick;
            this.Contraseña = contraseña;
        }
        
        
    }
}
