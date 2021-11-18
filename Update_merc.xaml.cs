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
    }
}
