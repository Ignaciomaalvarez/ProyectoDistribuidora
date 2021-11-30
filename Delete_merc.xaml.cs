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


    }
}
