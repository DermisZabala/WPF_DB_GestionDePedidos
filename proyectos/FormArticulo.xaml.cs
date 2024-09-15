using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WPF_DB_GestionPedidos.proyectos
{
    /// <summary>
    /// Lógica de interacción para FormArticulo.xaml
    /// </summary>
    public partial class FormArticulo : Page
    {
        SqlConnection miConexionSql;
        public FormArticulo()
        {
            InitializeComponent();

            string miConexion = ConfigurationManager.ConnectionStrings["WPF_DB_GestionPedidos.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);
        }
        private void IrInicio_Click(object sender, RoutedEventArgs e)
        {
            // Crear una nueva instancia de MainWindow
            MainWindow mainWindow = new MainWindow();

            // Mostrar MainWindow
            mainWindow.Show();

            // Cerrar el NavigationWindow actual (si es necesario)
            // Si la Page está dentro de un NavigationWindow, lo puedes cerrar así:
            Window.GetWindow(this)?.Close();
        }

        private void IrFormularioCliente_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("proyectos/FormCliente.xaml", UriKind.Relative));

        }

        private void EnviarFormulario_Click(object sender, RoutedEventArgs e)
        {
            completarCampos();
        }

        private void completarCampos()
        {
            miConexionSql.Open();

            string consulta = "INSERT INTO Articulo(Seccion, nombreArticulo, precio, fecha, paisOrigen) VALUES (@seccion, @nombreArticulo, @precio, @fecha, @paisOrigen)";

            SqlCommand comando = new SqlCommand(consulta, miConexionSql);

            if (string.IsNullOrWhiteSpace(NombreSeccion.Text)||
                string.IsNullOrWhiteSpace(NombreArticulo.Text)||
                string.IsNullOrWhiteSpace(PrecioArticulo.Text)||
                string.IsNullOrWhiteSpace(FechaArticulo.Text))
            {
                MessageBox.Show("Debe rellenar la todos los campos");
            }

            string fechaPattern = @"^\d{2}-\d{2}-\d{4}$";
            if (!Regex.IsMatch(FechaArticulo.Text, fechaPattern))
            {
                MessageBox.Show("La fecha debe tener el formato DD-MM-AAAA.");
                return;
            }

            comando.Parameters.AddWithValue("@seccion", NombreSeccion.Text);
            comando.Parameters.AddWithValue("@nombreArticulo", NombreArticulo.Text);

            SqlMoney precio;
            try
            {
                precio = SqlMoney.Parse(PrecioArticulo.Text);
                double precio1 = (precio.ToDouble());
                Math.Round(precio1, 2);
                comando.Parameters.AddWithValue("@precio", precio1);
            }
            catch (FormatException)
            {
                // Manejar el error de formato aquí
                MessageBox.Show("El valor que ha ingresado en el precio es invalido");
            }

            DateTime fecha;
            try 
            {
                DateTime.TryParse(FechaArticulo.Text, out fecha);
                comando.Parameters.AddWithValue("@fecha", fecha);
            }
            catch(FormatException)
            {
                // Manejar el error de formato aquí
                MessageBox.Show("La fecha no es correcta, el formato es el siguiente:" +
                    "\nDD-MM-AAAA");
            }

            comando.Parameters.AddWithValue("@paisOrigen", PaisDeOrigen.Text);

            comando.ExecuteNonQuery();

            miConexionSql.Close();            
        }
    }
}
