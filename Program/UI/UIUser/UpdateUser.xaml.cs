using System;
using System.Collections.Generic;
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
using Program.BL;
using Program.DT;
using Program.Model;

namespace Program.UI.UIUser
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        public int id { get; set; }
        private MainWindow _main;
        public UpdateUser(MainWindow main)
        {
            InitializeComponent();
            _main = main;
        }

        private void UpdateBtnClick(object sender, RoutedEventArgs e)
        {
            int _checked = 0;
            if(IsActive.IsChecked != true)
            {
                _checked = 0;
            }
            else
            {
                _checked = 1;
            }

            int RoleId;
            if(RoleBox.SelectedValue == null)
            {
                MessageBox.Show("Null");
                return;
            }
            else
            {
                RoleId = Convert.ToInt32(RoleBox.SelectedValue);

            }
            
            User u = new User(RoleId ,NameUptTextbox.Text,ChargeUptTextbox.Text,
                              CodeUserUptTextbox.Text,UsernameUptTextbox.Text,
                              PasswordUptTextbox.Text,KeyUptTextbox.Text,
                              RfidUptTextbox.Text,CommentUptTextbox.Text,
                              _checked);

            var bLUser = new BLUser();
            bLUser.UpdateUser(id, u);

            _main._userGrid.DataContext = bLUser.GetUser();


        }

        private void CloseWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Collapsed;
        }

        private void RoleBox_Loaded(object sender, RoutedEventArgs e)
        {
            var _bl = new BLUser();
            RoleBox.DataContext = _bl.GetRoleName();
            RoleBox.DisplayMemberPath = _bl.GetRoleName().Tables[0].Columns["Descripcion"].ToString();
            RoleBox.SelectedValuePath = _bl.GetRoleName().Tables[0].Columns["Id"].ToString();
        }
    }
}
