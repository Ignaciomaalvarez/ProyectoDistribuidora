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

    public partial class GestionMerc : Window
    {
        

        public GestionMerc()
        {
            InitializeComponent();

           
            
            MuestraProductos();

        }
        
        private void MuestraProductos()
        {
            ConnectionDB connection = new ConnectionDB();
          
            string consulta = "select * from Mercaderias as MuestraInfo";
            

            SqlDataAdapter miadapatadorsql = new SqlDataAdapter(consulta,connection.Connection);
           
            using (miadapatadorsql)
            {
                DataTable mydatable = new DataTable();

                miadapatadorsql.Fill(mydatable);

                MuestraMercaderia.DisplayMemberPath = "MuestraInfo";
                MuestraMercaderia.SelectedValuePath = "id";
                MuestraMercaderia.ItemsSource = mydatable.DefaultView;





            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Insert_Merc wInsert_merc = new Insert_Merc();

            wInsert_merc.ShowDialog();

            if (wInsert_merc.IsActive==false)
            {

                MuestraProductos();

            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Update_merc wupdate_Merc = new Update_merc();
            wupdate_Merc.ShowDialog();

        }
    }
}
