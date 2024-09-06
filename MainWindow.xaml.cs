using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Data;

namespace WPF_DB_GestionPedidos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection miConexionSQL;

        public MainWindow()
        {
            InitializeComponent();

            string miConexion = ConfigurationManager.ConnectionStrings["WPF_DB_GestionPedidos.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;
            
            miConexionSQL = new SqlConnection(miConexion);

            MuestraClientes();

            PedidosCompletos();
        }

        private void MuestraClientes()
        {
            miConexionSQL.Open();
            
            string consulta = "SELECT * FROM Cliente";

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, miConexionSQL);

            DataTable tablaCliente = new DataTable();

            adaptador.Fill(tablaCliente);
                        
            ListaCliente.DisplayMemberPath = "nombre";

            ListaCliente.SelectedValuePath = "Id";
            
            ListaCliente.ItemsSource = tablaCliente.DefaultView;
            
            miConexionSQL.Close();
        }

        private void ListaCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            MuestraPedidos();
            
        }

        private void MuestraPedidos()
        {
            string consultaPEDIDO = "SELECT * FROM Pedido objP INNER JOIN Cliente objC ON " +
                "objC.Id = objP.IdCliente WHERE objC.Id = @ClienteId";

            SqlCommand sqlComando = new SqlCommand(consultaPEDIDO, miConexionSQL);

            SqlDataAdapter miAdactador = new SqlDataAdapter(sqlComando);

            DataTable TablaPedido = new DataTable();

            // Añadir el parámetro el valor 
            miAdactador.SelectCommand.Parameters.AddWithValue("@ClienteId", ListaCliente.SelectedValue);

            miAdactador.Fill(TablaPedido);

            ListaPedidos.DisplayMemberPath = "Id";
            
            ListaPedidos.SelectedValuePath = "IdCliente";
            
            ListaPedidos.ItemsSource = TablaPedido.DefaultView;
            
        }

        private void PedidosCompletos()
        {
            string consulta = "SELECT CONCAT(Id, ' ', IdCliente, ' ', fechaPedido) AS INFOPEDIDO FROM pedido";

            SqlDataAdapter miAdactadorSql = new SqlDataAdapter(consulta, miConexionSQL);

            DataTable TablaPedidoCompleta = new DataTable();
            
                        
            miAdactadorSql.Fill(TablaPedidoCompleta);

            // Contar los pedidos
            //contador.TryParse(Cantidad, out contador);

            Cantidad.Content = TablaPedidoCompleta.Rows.Count;

            

            // Añadir una fila personalizada al final con el mensaje
            //DataRow newRow = TablaPedidoCompleta.NewRow();
            //newRow["INFOPEDIDO"] = $"Se han realizado {contador} pedidos";
            //TablaPedidoCompleta.Rows.Add(newRow);

            PedidoCompletos.DisplayMemberPath = $"INFOPEDIDO";            

            PedidoCompletos.SelectedValuePath = "Id";

            PedidoCompletos.ItemsSource = TablaPedidoCompleta.DefaultView;

        }

        private void EliminarPedido_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
