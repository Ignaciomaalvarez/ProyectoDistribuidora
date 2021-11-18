using System;
using System.Collections.Generic;
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

namespace Gestion
{
    /// <summary>
    /// Interaction logic for Insert_Merc.xaml
    /// </summary>
    public partial class Insert_Merc : Window
    {
        public Insert_Merc()
        {
            InitializeComponent();
        }

        private void TipoProducto_Loaded(object sender, RoutedEventArgs e)
        {
            TipoProducto.Items.Add("Aceite");
            TipoProducto.Items.Add("Vino");
            TipoProducto.Items.Add("Cerveza");
        }

        private void InsertaProducto()
        {

            ConnectionDB connection = new ConnectionDB();
            String consulta = "insert into Mercaderias (Tipo_Producto,Nombre, Cantidad,Precio) values(@Tipo_Producto,@Nombre,@Cantidad,@Precio)";

            SqlCommand MySqlCommad = new SqlCommand(consulta, connection.Connection);

            connection.Connection.Open();

            MySqlCommad.Parameters.AddWithValue("@Tipo_Producto", TipoProducto.SelectedValue);
            MySqlCommad.Parameters.AddWithValue("@Nombre", Nombre.Text);
            MySqlCommad.Parameters.AddWithValue("@Cantidad", Cantidad.Text);
            MySqlCommad.Parameters.AddWithValue("@Precio", Precio.Text);

            MySqlCommad.ExecuteNonQuery();
            connection.Connection.Close();
            MessageBox.Show("Registro Agregado");
            TipoProducto.SelectedValue = "";
            Nombre.Text = "";
            Cantidad.Text = "";
            Precio.Text = "";
            
        }

        private void InsertarMercaderia_Click(object sender, RoutedEventArgs e)
        {
            InsertaProducto();
        }
    }
}
