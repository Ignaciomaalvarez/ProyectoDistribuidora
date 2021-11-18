using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Gestion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
          string connection = ConfigurationManager.ConnectionStrings["Gestion.Properties.Settings.Gestion_distConnectionString"].ConnectionString;

           miConeccion = new SqlConnection(connection);

        }
        SqlConnection miConeccion;

        private void btGestionMerc_Click(object sender, RoutedEventArgs e)
        {
            GestionMerc wgestionmerc = new GestionMerc();

            wgestionmerc.ShowDialog();

            

        }
    }

}
