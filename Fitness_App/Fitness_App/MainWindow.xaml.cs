using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Fitness_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Conexion.Open();

        }
        public IUser theuser = new User();
        public IDatabase database = new Database();
        public void SelectItem(TabItem tabItem)
        {
            MainControl.SelectedItem = tabItem;
        }
        
       
        private void Registrarse_P1(object sender, RoutedEventArgs e)
        {

            SelectItem(Registro);
        }

        private void Iniciar_Sesion_P1(object sender, RoutedEventArgs e)
        {
            SelectItem(Inicio_Sesion);
        }
        private void Iniciar_Sesion_P2(object sender, RoutedEventArgs e)
        {
            SelectItem(Inicio_Sesion);
        }
        private void Crear_Cuenta_P2(object sender, RoutedEventArgs e)
        {
            string Nick, Nombre, Apellido, Correo, Contraseña, Descripcion;
            double Peso;
            int Edad;
            int Scorepoints = 0;

            bool halt = false;
            while (halt == false)
            {
                try
                {
                    Nick = N_Usuario.Text;

                    Nombre = NombreBox.Text;

                    Apellido = ApellidoBox.Text;

                    Correo = CorreoBox.Text;

                    Contraseña = ContraseñaBox.Text;

                    Peso = Convert.ToDouble(PesoBox.Text);

                    Edad = Convert.ToInt32(EdadBox.Text);

                    Descripcion = DescripciónBox.Text;
                }
                catch
                {
                    MessageBox.Show("Uno o varios datos están mal puestos");
                    halt = true;

                }
                Nick = N_Usuario.Text;

                Nombre = NombreBox.Text;

                Apellido = ApellidoBox.Text;

                Correo = CorreoBox.Text;

                Contraseña = ContraseñaBox.Text;

                Peso = Convert.ToDouble(PesoBox.Text);

                Edad = Convert.ToInt32(EdadBox.Text);

                Descripcion = DescripciónBox.Text;


                User newuser = new User(Nick, Nombre, Apellido, Correo, Contraseña, Peso, Edad, Descripcion, Scorepoints);
              
                try
                {
                    database.UserAlreadyExists(newuser);
                }
                catch
                {
                    MessageBox.Show("Este Usuario ya fue creado!!");
                    halt = true;
                }
                try
                {
                    database.Registrer(newuser);
                    MessageBox.Show("Usuario creado!!");
                    halt = true;
                }
                catch
                {
                    MessageBox.Show("Hubo un error inesperado!");
                    halt = true;
                }

 
            }
            SelectItem(Inicio_Sesion);
            
            

        }
        private void Iniciar_Sesion_P3(object sender, RoutedEventArgs e)
        {
            string Nick;
            string Contraseña;
            try
            {
                Nick = NusuarioLogin.Text;
                Contraseña = ContraseñaLogin.Text;

            }
            catch
            {
                MessageBox.Show("tipo de datos mal introducido!!");
            }
            Nick = NusuarioLogin.Text;
            Contraseña = ContraseñaLogin.Text;
            User newuser = new User(Nick,Contraseña);
            try
            {
                database.login(newuser);
                MessageBox.Show("ha entrado con exito!");
               
            }
            catch
            {
                MessageBox.Show("Datos incorrectos =(");
            }
            Fitness_App.Window1 window1 = new Window1();
            window1.Show();
            newuser.scorepoints = +1;
            Conexion.Close();
        }

        private void Registrase_P3(object sender, RoutedEventArgs e)
        {
            SelectItem(Registro);
        }

        private void ContraseñaOlvidada(object sender, RoutedEventArgs e)
        {
            SelectItem(Recover_password);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string correousuario;
            correousuario = Recoverbox.Text;

            try
            {
                database.RecoverPassWrd(correousuario);
            }
            catch
            {
                MessageBox.Show("No se reconoce el correo!!");
            }
            MessageBox.Show("Se ha enviado un codigo de recuperación a tu correo, (en verdad no)");
            MessageBox.Show(database.RecoverPassWrd(correousuario));

            SelectItem(Inicio);
        }
    }
}
