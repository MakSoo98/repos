using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace Fitness_App
{
    public class Database : IDatabase
    {
        /*public void GetPost()
        { }
        public void GetRanking()
        { }
        public void GetFriends()
        { }*/
        public  void Registrer(User newuser)
        {

            string InsertProcedure = "INSERT INTO FITNESSBASE.dbo.CLASSUSER (Nick,NombreUsuario,Apellidos,Correo,Contraseña,Peso,Edad,Descripcion,ScorePoints) " +
                "VALUES (' " + newuser.nick + "' ,'" + newuser.nombreusuario + "' ,'" + newuser.apellidos + "' ,'" + newuser.correo + "' ,'" + newuser.contraseña + "' ,'" + newuser.peso + "' ,'" + newuser.edad + "' ,'" + newuser.descripcion + "' ,'" + "0" + "' );";
            SqlCommand sqlCommand = new SqlCommand(InsertProcedure,Conexion.Sqlcon);
            sqlCommand.ExecuteNonQuery();
            
        }
        public  bool login(User newuser)
        {
            string Insertprocedure = " SELECT dbo.fn_Login ('"+ newuser.nick+" ','"+ newuser.contraseña+ "');";
            SqlCommand sqlCommand = new SqlCommand(Insertprocedure, Conexion.Sqlcon);
            sqlCommand.ExecuteNonQuery();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if(sqlDataReader.Read())
            {
                bool result = Convert.ToBoolean(sqlDataReader.Read());
                return result;
            }
            return false;
        }

        public  bool UserAlreadyExists(User newuser)
        {
            
            string procedure = "SELECT Count(NombreUsuario) FROM FITNESSBASE.dbo.CLASSUSER WHERE Nick = '"+newuser.nick+"' ;";
            SqlCommand commandprocedure = new SqlCommand(procedure, Conexion.Sqlcon);
            SqlDataReader readprocedure = commandprocedure.ExecuteReader();
            if(readprocedure.Read())
            {
                bool result = Convert.ToBoolean(readprocedure.GetValue(0));
                return result;

            }
            return false;
           

        }
        public  string RecoverPassWrd(string correousuario)
        {
            string procedure = "SELECT Contraseña FROM FITNESSBASE.dbo.CLASSUSER WHERE Correo = '"+correousuario+"'; ";
            SqlCommand command = new SqlCommand(procedure, Conexion.Sqlcon);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string result = Convert.ToString(reader.GetString(0));
                return result;
            }
            return "";

            

        }
        //podria crear un procedimiento para los comandos SQL con un string como parametro, pero me esta ocupando demasiado tiempo la practica y quiero entregarla ya.
    }
}
