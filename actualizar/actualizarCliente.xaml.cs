using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WPF_DB_GestionPedidos.actualizar
{
    /// <summary>
    /// Lógica de interacción para actualizarCliente.xaml
    /// </summary>
    public partial class actualizarCliente : Window
    {
        int id;

        SqlConnection miConexionSql;
        public actualizarCliente(int id)
        {
            InitializeComponent();

            this.id = id;

            string miConexion = ConfigurationManager.ConnectionStrings["WPF_DB_GestionPedidos.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);
        }

        private void EnviarFormulario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                miConexionSql.Open();

                string consulta = "UPDATE Cliente SET nombre = @nombre, direccion = @direccion, poblacion = @poblacion, telefono = @telefono WHERE Id = " + id;

                SqlCommand cmd = new SqlCommand(consulta, miConexionSql);

                cmd.Parameters.AddWithValue("@nombre", ActualizarNombreCliente.Text);
                cmd.Parameters.AddWithValue("@direccion", DireccionCliente.Text);
                cmd.Parameters.AddWithValue("@poblacion", PoblacionCliente.Text);
                cmd.Parameters.AddWithValue("@telefono", NumeroDeTelefono.Text);

                // Ejecutar la consulta
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error vuelva a intentarlo" + ex.ToString());
            }
            finally
            {
                miConexionSql.Close();
                
            }
            
            this.Close();
        }
        
    }
}
