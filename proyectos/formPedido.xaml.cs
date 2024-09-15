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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_DB_GestionPedidos.proyectos
{
    /// <summary>
    /// Lógica de interacción para formPedido.xaml
    /// </summary>
    public partial class formPedido : Page
    {
        private int idCliente;
        SqlConnection miConexionSql;
        
        public formPedido(int idCliente)
        {            
            InitializeComponent();
            
            this.idCliente = idCliente;
            string miConexion = ConfigurationManager.ConnectionStrings["WPF_DB_GestionPedidos.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);

            
        }

        private void EnviarFormulario_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow volver = new NavigationWindow();

            miConexionSql.Open();

            try
            {            
                string consulta = $"INSERT INTO pedido(idCliente, cantidadArticulo, fechaPedido, formaPago, montoTotal) VALUES (@idCliente, @cantidadArticulo, @fechaPedido, @formaPago, @montoTotal)";
                
                SqlCommand comando = new SqlCommand(consulta, miConexionSql);
                
                comando.Parameters.AddWithValue("@idCliente", idCliente);                
                comando.Parameters.AddWithValue("@cantidadArticulo", int.Parse(CantidadArticulos.Text));                
                comando.Parameters.AddWithValue("@fechaPedido", DateTime.Parse(FechaPedido.Text));                
                comando.Parameters.AddWithValue("@formaPago", FormaPago.Text);                
                comando.Parameters.AddWithValue("@montoTotal", decimal.Parse(MontoTotal.Text));
                
                comando.ExecuteNonQuery();
                
                CantidadArticulos.Clear();                
                FechaPedido.Clear();                
                FormaPago.Clear();                
                MontoTotal.Clear();                
            }
            
            catch (Exception ex)            
            {
            
                MessageBox.Show(ex.Message);                
            }
            
            finally            
            {
            
                miConexionSql.Close();
                
            }
            if (string.IsNullOrWhiteSpace(CantidadArticulos.Text) ||
               string.IsNullOrWhiteSpace(FechaPedido.Text) ||
               string.IsNullOrWhiteSpace(FormaPago.Text) ||
               string.IsNullOrWhiteSpace(MontoTotal.Text)
                )
            {
                
                MessageBox.Show("Complete todos los campos para " +
                    "poder enviar el formulario");
            }
            else
            {
                MessageBox.Show("Has guardado el pedido correctamente");
                Window.GetWindow(this)?.Close();
            }


        }
    }
}
