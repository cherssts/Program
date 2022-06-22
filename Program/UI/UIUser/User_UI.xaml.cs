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
using Program.BL;
using Program.DT;
using Program.UI;

namespace Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BLUser user = new BLUser();
        DTUserConnection dc = new DTUserConnection();
        
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void _DataLoaded(object sender, RoutedEventArgs e)
        {
            _userGrid.DataContext = user.GetUser();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUser a = new AddUser(this);
            a.ShowDialog();
            
        }
    }
}
