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
using Program.Model;

namespace Program.UI
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private MainWindow _userWin;
        public AddUser(MainWindow userWin)
        {
            InitializeComponent();
            _userWin = userWin;
        }

        #region AddBtn Event
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var _bl = new BLUser();
            if (_nameTextbox.Text == string.Empty)
            {
                MessageBox.Show("Name cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_chargeTextbox.Text == string.Empty)
            {
                MessageBox.Show("Charge cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_codeTextbox.Text == String.Empty)
            {
                MessageBox.Show("Code cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_usernameTextbox.Text == String.Empty || _usernameTextbox.Text.Length < 4)
            {
                MessageBox.Show("Username cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_passwordTextbox.Text == String.Empty || _passwordTextbox.Text.Length < 6)
            {
                MessageBox.Show("Password cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //Setting a new User for the AddUser Method
            var user = new User();
            user.RoleId = Convert.ToInt32(RoleBox.SelectedValue);
            user.Name = _nameTextbox.Text;
            user.Charge = _chargeTextbox.Text;
            user.CodeUser = _codeTextbox.Text;
            user.Username = _usernameTextbox.Text;
            user.Password = _passwordTextbox.Text; 
            user.Key =_keyTextbox.Text;
            user.Rfid = _rfidTextbox.Text;
            user.Comment = _commentTextbox.Text;
            //Add User
            _bl.AddUser(user);
            MessageBox.Show("User Added Successfully", "Info", MessageBoxButton.OK);
            //Update Data
            _userWin._userGrid.DataContext = _bl.GetUser();

            //Clear the textbox
            Clear();

        }

        #endregion

        #region Normal Events
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Helper Methods
        public void Clear()
        {
            _nameTextbox.Text = String.Empty;
            _chargeTextbox.Text = String.Empty;
            _codeTextbox.Text = String.Empty;
            _usernameTextbox.Text = String.Empty;
            _passwordTextbox.Text = String.Empty;
            _keyTextbox.Text = String.Empty;
            _rfidTextbox.Text = String.Empty;
            _commentTextbox.Text = String.Empty;
        }

        #endregion

        private void RoleBox_Loaded(object sender, RoutedEventArgs e)
        {
            var _bl = new BLUser();
            RoleBox.DataContext = _bl.GetRoleName();
            RoleBox.DisplayMemberPath = _bl.GetRoleName().Tables[0].Columns["Descripcion"].ToString();
            RoleBox.SelectedValuePath = _bl.GetRoleName().Tables[0].Columns["Id"].ToString();
        }
    }
}
