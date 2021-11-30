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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

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

      


    


        
        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ConnectionDB connection = new ConnectionDB();

                string consulta = "Update Mercaderias set Tipo_Producto=@Tipo_Producto, Nombre=@Nombre, cantidad=@cantidad, precio=@precio where id = " + Tb_id.Text;

                SqlCommand mysqlcommand = new SqlCommand(consulta, connection.Connection);
                connection.Connection.Open();

                mysqlcommand.Parameters.AddWithValue("@Tipo_Producto", TbTipoproducto.Text);
                mysqlcommand.Parameters.AddWithValue("@Nombre", TbNombre.Text);
                mysqlcommand.Parameters.AddWithValue("@cantidad", TbCantidad.Text);
                mysqlcommand.Parameters.AddWithValue("@precio", TbPrecio.Text);

                //mysqlcommand.ExecuteNonQuery();

                //connection.Connection.Close();


                string question = "¿esta seguro que desea actualizar?";
                string caption = "";
                MessageBoxIcon icon = MessageBoxIcon.Exclamation;
                MessageBoxButton button = MessageBoxButton.YesNo;
                DialogResult result;


               result= System.Windows.Forms.MessageBox.Show(question,caption, (MessageBoxButtons)button, icon);
                if(result== System.Windows.Forms.DialogResult.Yes)
                {

                    mysqlcommand.ExecuteNonQuery();

                    connection.Connection.Close();


                    MessageBox.Show("Registro actualizado");
                }
                
                
                Muestra_MercUpdate();


                Tb_id.Text = "";
                TbTipoproducto.Text = "";
                TbNombre.Text = "";
                TbCantidad.Text = "";
                TbPrecio.Text = "";
            }

            catch (Exception)
            {
                MessageBox.Show("Por favor escriba un valor de id en el campo id");


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ConnectionDB connection = new ConnectionDB();

                string consulta = "select * from Mercaderias where id = @IdActualizaprod";
                SqlCommand mysqlcommand = new SqlCommand(consulta, connection.Connection);
                SqlDataAdapter mysqladapter = new SqlDataAdapter(mysqlcommand);


                using (mysqladapter)
                {
                    mysqlcommand.Parameters.AddWithValue("@IdActualizaprod", Tb_id.Text);

                    DataTable mydatable = new DataTable();

                    mysqladapter.Fill(mydatable);


                    TbTipoproducto.Text = mydatable.Rows[0]["Tipo_Producto"].ToString();

                    TbNombre.Text = mydatable.Rows[0]["Nombre"].ToString();

                    TbCantidad.Text = mydatable.Rows[0]["cantidad"].ToString();

                    TbPrecio.Text = mydatable.Rows[0]["precio"].ToString();
                }

            }

            catch (Exception)
            {

                MessageBox.Show("Por favor escriba un valor valido de id en el campo id");


            }
        }
    }
}
