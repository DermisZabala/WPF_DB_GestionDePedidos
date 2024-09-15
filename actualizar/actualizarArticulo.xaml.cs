using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
    /// Lógica de interacción para actualizarArticulo.xaml
    /// </summary>
    public partial class actualizarArticulo : Window
    {
        private int idArticulo;

        SqlConnection miConexionSQL;
        public actualizarArticulo(int idArticulo)
        {
            InitializeComponent();

            this.idArticulo = idArticulo;

            string miConexion = ConfigurationManager.ConnectionStrings["WPF_DB_GestionPedidos.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

            miConexionSQL = new SqlConnection(miConexion);
        }

        private void EnviarFormulario_Click(object sender, RoutedEventArgs e)
        {
            miConexionSQL.Open();

            try
            {
                string consulta = "UPDATE Articulo SET Seccion = @seccion, nombreArticulo = @nombreArticulo, precio = @precio, fecha = @fecha, paisOrigen = @paisOrigen WHERE Id = " + idArticulo;

                SqlCommand miComando = new SqlCommand(consulta, miConexionSQL);

                miComando.Parameters.AddWithValue("@seccion", ActualizarSeccion.Text);

                miComando.Parameters.AddWithValue("@nombreArticulo", NombreArticulo.Text);

                /*SqlMoney precio;
                
                precio = SqlMoney.Parse(PrecioArticulo.Text);
                
                double precio1 = (precio.ToDouble());
                
                Math.Round(precio1, 2);
                
                miComando.Parameters.AddWithValue("@precio", precio1);                

                DateTime fecha;
                    
                DateTime.TryParse(FechaArticulo.Text, out fecha);
                
                miComando.Parameters.AddWithValue("@fecha", fecha);*/

                miComando.Parameters.AddWithValue("@precio", SqlMoney.Parse( PrecioArticulo.Text));

                miComando.Parameters.AddWithValue("@fecha", DateTime.Parse(FechaArticulo.Text));

                miComando.Parameters.AddWithValue("@paisOrigen", PaisOrigen.Text);

                miComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                miConexionSQL.Close();
            }
            this.Close();
        }
    }
}
