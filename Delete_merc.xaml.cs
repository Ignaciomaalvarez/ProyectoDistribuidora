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
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Gestion
{
    /// <summary>
    /// Interaction logic for Delete_merc.xaml
    /// </summary>
    public partial class Delete_merc : Window
    {
        public Delete_merc()
        {
            InitializeComponent();

            muestra_delete();
        }


        private void muestra_delete()
        {

            ConnectionDB connection = new ConnectionDB();

            string consulta = "select * from Mercaderias as MuestraInfo";

            SqlDataAdapter miadapatadorsql = new SqlDataAdapter(consulta, connection.Connection);

            using (miadapatadorsql)
            {
                DataTable mydatable = new DataTable();

                miadapatadorsql.Fill(mydatable);

                Muestraprod_delete.DisplayMemberPath = "MuestraInfo";
                Muestraprod_delete.SelectedValuePath = "id";
                Muestraprod_delete.ItemsSource = mydatable.DefaultView;



            }





        }

        private void bt_select_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ConnectionDB connection = new ConnectionDB();

                string consulta = "select * from Mercaderias where id = @IdDeleteprod";
                SqlCommand mysqlcommand = new SqlCommand(consulta, connection.Connection);
                SqlDataAdapter mysqladapter = new SqlDataAdapter(mysqlcommand);


                using (mysqladapter)
                {

                    mysqlcommand.Parameters.AddWithValue("@IdDeleteprod", tb_id.Text);

                    DataTable mydatable = new DataTable();

                    mysqladapter.Fill(mydatable);


                    tb_tipoproducto.Text = mydatable.Rows[0]["Tipo_Producto"].ToString();
                    tb_producto.Text = mydatable.Rows[0]["Nombre"].ToString();
                    tb_cantidad.Text = mydatable.Rows[0]["cantidad"].ToString();
                    tb_precio.Text = mydatable.Rows[0]["precio"].ToString();






                }
            }
            catch (Exception)
            {


                MessageBox.Show("Por favor escriba un valor de id en el campo id");
            }

        }

        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ConnectionDB connection = new ConnectionDB();
                string consulta = " delete from Mercaderias where id = @IdDeleteprod";
                SqlCommand mysqlcommand = new SqlCommand(consulta, connection.Connection);

                connection.Connection.Open();
                mysqlcommand.Parameters.AddWithValue("@IdDeleteprod", tb_id.Text);

                string question = "¿esta seguro que desea Elimar?";
                string caption = "";
                MessageBoxIcon icon = MessageBoxIcon.Exclamation;
                MessageBoxButton button = MessageBoxButton.YesNo;
                DialogResult result;


                result = System.Windows.Forms.MessageBox.Show(question, caption, (MessageBoxButtons)button, icon);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    mysqlcommand.ExecuteNonQuery();

                    connection.Connection.Close();


                    MessageBox.Show("Producto Eliminado");




                }

                muestra_delete();

                tb_id.Text = "";
                tb_tipoproducto.Text = "";
                tb_producto.Text = "";
                tb_cantidad.Text = "";
                tb_precio.Text = "";

            }
            catch (Exception)
            {

                MessageBox.Show("Por favor escriba un valor de id en el campo id");



            }
        }
    }
}
