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
    class Conexion
    {
        public static SqlConnection Sqlcon;

        public static void Open()
        {
            

            try
            {
                string nombre_servidor = Dns.GetHostName();


                Sqlcon = new SqlConnection("Data Source=DESKTOP-RICTIIG\\SQLEXPRESS;Initial Catalog=FITNESSBASE;Integrated Security=True;MultipleActiveResultSets=True");

                
                Sqlcon.Open();


            }
            catch (Exception)
            {

            }



        }
        public static void Close()
        {
            Sqlcon.Close();


        }
        public string cadena()
        {
            return Sqlcon.ConnectionString;
        }
        


    }
}
