using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Lógica de interacción para FormCliente.xaml
    /// </summary>
    public partial class FormCliente : Page
    {
        SqlConnection miConexionSql;
        public FormCliente()
        {
            InitializeComponent();


            string miConexion = ConfigurationManager.ConnectionStrings["WPF_DB_GestionPedidos.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;
            
            miConexionSql = new SqlConnection(miConexion);

            //muestraDatos();
        }

        private void CampoNombre()
        {
            
            string consulta = "Insert Into Cliente(nombre, direccion, poblacion, telefono) Values (@nombre, @direccion, @poblacion, @telefono)";

            SqlCommand sqlComando = new SqlCommand(consulta, miConexionSql);

            SqlDataAdapter miAdactador = new SqlDataAdapter(sqlComando);

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(NombreCliente.Text) ||
                string.IsNullOrWhiteSpace(DireccionCliente.Text) ||
                string.IsNullOrWhiteSpace(PoblacionCliente.Text) ||
                string.IsNullOrWhiteSpace(NumeroDeTelefono.Text)
                ) 
            {
                MessageBox.Show("Por favor, rellena todos los campos.");
                return;
            }

            // Validar formato del teléfono
            string telefonoPattern = @"^\d{3}-\d{3}-\d{4}$";
            if (!Regex.IsMatch(NumeroDeTelefono.Text, telefonoPattern))
            {
                MessageBox.Show("El número de teléfono debe tener el formato 000-000-0000.");
                return;
            }

            miConexionSql.Open();

            try
            {
                sqlComando.Parameters.AddWithValue("@nombre", NombreCliente.Text);
                sqlComando.Parameters.AddWithValue("@direccion", DireccionCliente.Text);
                sqlComando.Parameters.AddWithValue("@poblacion", PoblacionCliente.Text);
                sqlComando.Parameters.AddWithValue("@telefono", NumeroDeTelefono.Text);



                int rowsAffected = sqlComando.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Datos insertados correctamente.");
                    NombreCliente.Clear();
                    DireccionCliente.Clear();
                    PoblacionCliente.Clear();
                    NumeroDeTelefono.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            finally
            { 
                miConexionSql.Close();
            }

        }

        private void EnviarFormulario_Click(object sender, RoutedEventArgs e)
        {
            CampoNombre();
        }

        /*private void muestraDatos()
        {
            miConexionSql.Open();

            string consulta = "SELECT * FROM cliente";

            SqlDataAdapter miAdactador = new SqlDataAdapter(consulta, miConexionSql);

            DataTable tablaPedido = new DataTable();

            miAdactador.Fill(tablaPedido);

            //miListBox.DisplayMemberPath = "nombre";

            //miListBox.SelectedValuePath = "Id";

            //miListBox.ItemsSource = tablaPedido.DefaultView;

            miConexionSql.Close();
        }*/        

        private void IrA_Inicio_Click(object sender, RoutedEventArgs e)
        {
            // Crear una nueva instancia de MainWindow
            MainWindow mainWindow = new MainWindow();

            // Mostrar MainWindow
            mainWindow.Show();

            // Cerrar el NavigationWindow actual (si es necesario)
            // Si la Page está dentro de un NavigationWindow, lo puedes cerrar así:
            Window.GetWindow(this)?.Close();
        }

        private void IrFormularioArticulo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("proyectos/FormArticulo.xaml", UriKind.Relative));
        }
    }
}
