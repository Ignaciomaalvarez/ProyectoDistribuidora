using System;
using System.Collections.Generic;
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

namespace Gestion
{
    /// <summary>
    /// Interaction logic for Update_merc.xaml
    /// </summary>
    public partial class Update_merc : Window
    {
        public Update_merc()
        {
            InitializeComponent();
            Muestra_MercUpdate();






        }




        private void Muestra_MercUpdate()
        {

            ConnectionDB connection = new ConnectionDB();

            string consulta = "select * from Mercaderias as MuestraInfo";


            SqlDataAdapter miadapatadorsql = new SqlDataAdapter(consulta, connection.Connection);

            using (miadapatadorsql)
            {
                DataTable mydatable = new DataTable();

                miadapatadorsql.Fill(mydatable);

                MuestraMercUpdate.DisplayMemberPath = "MuestraInfo";
                MuestraMercUpdate.SelectedValuePath = "id";
                MuestraMercUpdate.ItemsSource = mydatable.DefaultView;


                
            }




        }

      


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // TbTipoproducto.Text = MuestraMercUpdate.Columns[0].GetCellContent(MuestraMercUpdate.SelectedIndex).ToString();

               // [MuestraMercUpdate.SelectedIndex]["Tipo_Producto"].ToString();

        }


        //TODO
        //Ver como sacar el id para hacer el update.
        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            ConnectionDB connection = new ConnectionDB();

            string consulta = "Update Mercaderias set Nombre=@Nombre, cantidad=@cantidad, precio=@precio where id = " + MuestraMercUpdate.SelectedItem.ToString();

            SqlCommand mysqlcommand = new SqlCommand(consulta, connection.Connection);
            connection.Connection.Open();

           // mysqlcommand.Parameters.AddWithValue("@Tipo_Producto", TbTipoproducto.Text);
            mysqlcommand.Parameters.AddWithValue("@Nombre", TbNombre.Text);
            mysqlcommand.Parameters.AddWithValue("@cantidad", TbCantidad.Text);
            mysqlcommand.Parameters.AddWithValue("@precio", TbPrecio.Text);

            mysqlcommand.ExecuteNonQuery();

            connection.Connection.Close();

            Muestra_MercUpdate();
        }
    }
}
