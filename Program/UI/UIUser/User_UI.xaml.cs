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
using Program.UI.UIUser;

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

        #region Local Events
        private void _DataLoaded(object sender, RoutedEventArgs e)
        {
            _userGrid.DataContext = user.GetUser();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _userGrid.DataContext = user.SearchUser(SearchBox.Text);

        }
        #endregion

        #region Open New Window Events
        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUser a = new AddUser(this);
            a.ShowDialog();
            
        }

        private void UpdateBtnClick(object sender, RoutedEventArgs e)
        {
            UpdateUser update = new UpdateUser(this);
            
            DataRowView rowView = (DataRowView)((Button)e.Source).DataContext;
            update.id = Convert.ToInt32(rowView[0]);
            var a = user.UpdateInfo((int)update.id);
            
            update.NameUptTextbox.Text = a.Tables["UpdateInfo"].Rows[0]["Nombre"].ToString();
            update.ChargeUptTextbox.Text = a.Tables["UpdateInfo"].Rows[0]["Cargo"].ToString();
            update.CodeUserUptTextbox.Text = a.Tables["UpdateInfo"].Rows[0]["Codusuario"].ToString();
            update.UsernameUptTextbox.Text = a.Tables["UpdateInfo"].Rows[0]["Username"].ToString();
            update.PasswordUptTextbox.Text = a.Tables["UpdateInfo"].Rows[0]["Password"].ToString();
            update.KeyUptTextbox.Text = a.Tables["UpdateInfo"].Rows[0]["Clave"].ToString();
            update.RfidUptTextbox.Text = a.Tables["UpdateInfo"].Rows[0]["Numero_rfid"].ToString();
            update.CommentUptTextbox.Text = a.Tables["UpdateInfo"].Rows[0]["Comentario"].ToString();
            
            update.ShowDialog();
        }

        #endregion

        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = (DataRowView)((Button)e.Source).DataContext;

            user.DeleteUser(Convert.ToInt32(rowView[0]));
            _userGrid.DataContext = user.GetUser();
        }


    }
}
