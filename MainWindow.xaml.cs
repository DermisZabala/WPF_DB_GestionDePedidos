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
using WPF_DB_GestionPedidos.proyectos;
using WPF_DB_GestionPedidos.actualizar;

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

            MuestraArticulos();

            PedidosCompletos();

        }

        private void MuestraClientes()
        {
            miConexionSQL.Open();
            try
            {
                string consulta = "SELECT * FROM Cliente";

                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, miConexionSQL);

                DataTable tablaCliente = new DataTable();

                adaptador.Fill(tablaCliente);

                ListaCliente.DisplayMemberPath = "nombre";

                ListaCliente.SelectedValuePath = "Id";

                ListaCliente.ItemsSource = tablaCliente.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                miConexionSQL.Close();
            }
        }

        private void ListaCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaCliente.SelectedValue != null)
            {
                MuestraPedidos();
            }
            
        }

        private void MuestraPedidos()
        {
            try
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
            catch (Exception ex) {

                MessageBox.Show("Error");
            }

        }

        private void PedidosCompletos()
        {
            try
            {
                string consulta = "SELECT *, CONCAT(Id, ' \t', IdCliente, ' \t', formaPago, ' \t', montoTotal, '     \t', fechaPedido) AS INFOPEDIDO FROM pedido";

                SqlDataAdapter miAdactadorSql = new SqlDataAdapter(consulta, miConexionSQL);

                DataTable TablaPedidoCompleta = new DataTable();


                miAdactadorSql.Fill(TablaPedidoCompleta);

                Cantidad.Content = TablaPedidoCompleta.Rows.Count;

                PedidoCompletos.DisplayMemberPath = $"INFOPEDIDO";

                PedidoCompletos.SelectedValuePath = "Id";

                PedidoCompletos.ItemsSource = TablaPedidoCompleta.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void EliminarPedido_Click(object sender, RoutedEventArgs e)
        {
            miConexionSQL.Open();
            try
            {
                string consultaEliminar = "DELETE FROM pedido WHERE Id=@IDPEDIDO";

                SqlCommand sqlComando = new SqlCommand(consultaEliminar, miConexionSQL);

                sqlComando.Parameters.AddWithValue("@IDPEDIDO", PedidoCompletos.SelectedValue);

                sqlComando.ExecuteNonQuery();

                PedidosCompletos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"VUELVA A INTENTARLO \nHubo un error seleccione un pedido para eliminarlo");
            }
            finally
            {
                miConexionSQL.Close();
            }
        }

        public void IrFormularioCliente_Click(object sender, RoutedEventArgs e)
        {
            // Crear una nueva instancia de NavigationWindow
            NavigationWindow navigationWindow = new NavigationWindow();

            // Navegar a la página
            navigationWindow.Source = new Uri("proyectos/FormCliente.xaml", UriKind.Relative);

            // Mostrar el NavigationWindow
            navigationWindow.Show();

            // Cerrar la ventana actual si lo deseas
            this.Close();
        }

        private void EliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "DELETE FROM CLIENTE WHERE Id = @ClienteId";
            
            SqlCommand SqlComando = new SqlCommand(consulta, miConexionSQL);
            
            miConexionSQL.Open();

            SqlComando.Parameters.AddWithValue("@ClienteId", ListaCliente.SelectedValue);           

            SqlComando.ExecuteNonQuery();
            
            miConexionSQL.Close();
            
            MuestraClientes();
        }

        private void IrFormularioArticulo_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navegar = new NavigationWindow();

            navegar.Source = new Uri("proyectos/FormArticulo.xaml", UriKind.Relative);

            navegar.Show();

            this.Close();
        }

        private void actualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            actualizarCliente ActualizarCliente = new actualizarCliente((int)ListaCliente.SelectedValue);

            try
            {
                string consulta = "SELECT * FROM Cliente WHERE Id = @CLIENTEID";

                SqlCommand miComando = new SqlCommand(consulta, miConexionSQL);

                SqlDataAdapter miAdaptador = new SqlDataAdapter(miComando);

                DataTable tablaCliente = new DataTable();

                miComando.Parameters.AddWithValue("@CLIENTEID", ListaCliente.SelectedValue);

                miAdaptador.Fill(tablaCliente);

                //NombreCliente
                ActualizarCliente.ActualizarNombreCliente.Text = tablaCliente.Rows[0]["nombre"].ToString();

                ActualizarCliente.DireccionCliente.Text = tablaCliente.Rows[0]["direccion"].ToString();

                ActualizarCliente.PoblacionCliente.Text = tablaCliente.Rows[0]["poblacion"].ToString();

                ActualizarCliente.NumeroDeTelefono.Text = tablaCliente.Rows[0]["telefono"].ToString();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Ha cometido un error debe seleccionar un cliente");
            }

            ActualizarCliente.Show();
        }        

        private void MuestraArticulos()
        {
            miConexionSQL.Open();
            try
            {
                string consulta = "SELECT *, CONCAT(Seccion, ' \t', nombreArticulo) AS INFOARTICULO FROM Articulo";

                SqlDataAdapter miAdactador = new SqlDataAdapter(consulta, miConexionSQL);

                DataTable tablaArticulo = new DataTable();

                miAdactador.Fill(tablaArticulo);

                ListaArticulos.DisplayMemberPath = "INFOARTICULO";

                ListaArticulos.SelectedValuePath = "Id";

                ListaArticulos.ItemsSource = tablaArticulo.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorcito papa" + ex.ToString());
            }
            finally
            {
                miConexionSQL.Close();
            }
        }

        private void EliminaArticulo_Click(object sender, RoutedEventArgs e)
        {
            miConexionSQL.Open();

            try
            {
                string consulta = "DELETE FROM Articulo WHERE Id=@ARTICULOID";

                SqlCommand miComando = new SqlCommand(consulta, miConexionSQL);

                miComando.Parameters.AddWithValue("@ARTICULOID", ListaArticulos.SelectedValue);

                miComando.ExecuteNonQuery();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                miConexionSQL.Close();
            }

            MuestraArticulos();
        }

        private void actualizarArticulo_Click(object sender, RoutedEventArgs e)
        {
            actualizarArticulo actualizaArticulo = new actualizarArticulo((int)ListaArticulos.SelectedValue);

            actualizaArticulo.Show();

            miConexionSQL.Open();

            try
            {
                string consulta = "SELECT * FROM Articulo WHERE Id = @IDARTICULO";

                SqlCommand miComando = new SqlCommand(consulta, miConexionSQL);

                SqlDataAdapter miAdaptador = new SqlDataAdapter(miComando);

                DataTable tablaArticulo = new DataTable();

                miComando.Parameters.AddWithValue("@IDARTICULO", ListaArticulos.SelectedValue);

                miAdaptador.Fill(tablaArticulo);

                actualizaArticulo.ActualizarSeccion.Text = tablaArticulo.Rows[0]["Seccion"].ToString();
                actualizaArticulo.NombreArticulo.Text = tablaArticulo.Rows[0]["nombreArticulo"].ToString();
                actualizaArticulo.PrecioArticulo.Text = tablaArticulo.Rows[0]["precio"].ToString();
                actualizaArticulo.FechaArticulo.Text = tablaArticulo.Rows[0]["fecha"].ToString();
                actualizaArticulo.PaisOrigen.Text = tablaArticulo.Rows[0]["paisOrigen"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido una excepcion. \nMas info: \n {ex.ToString()}");
            }
            finally
            {
                miConexionSQL.Close();
            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            MuestraClientes();
            MuestraArticulos();
        }

        private void AgregarPedido_Click(object sender, RoutedEventArgs e)
        {
            int idCliente = (int)ListaCliente.SelectedValue;

            formPedido Cliente = new formPedido(idCliente);

            NavigationWindow navegarPedido = new NavigationWindow();

            // Navegar directamente a la instancia de formPedido en lugar de la URI
            navegarPedido.Navigate(Cliente);

            navegarPedido.Show();
        }
    }
}
