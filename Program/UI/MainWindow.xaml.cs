using System;
using System.Collections.Generic;
using System.Data;
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
using Program.BusinessLogic;
using Program.Data;
using Program.UI;

namespace Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL_User user = new BL_User();
        DataConnection dc = new DataConnection();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void _userGrid_Loaded(object sender, RoutedEventArgs e)
        {
            _userGrid.DataContext = user.GetUser();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var a = new AddUser();
            a.ShowDialog();
        }
    }
}
