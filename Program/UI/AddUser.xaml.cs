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
using Program.BusinessLogic;
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var _bl = new BL_User();
            if (_nameTextbox.Text == string.Empty)
            {
                MessageBox.Show("Name cannot be Empty","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            if (_chargeTextbox.Text == string.Empty)
            {
                MessageBox.Show("Charge cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(_codeTextbox.Text == String.Empty)
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
            var user = new User(_nameTextbox.Text,_chargeTextbox.Text, _codeTextbox.Text,
                _usernameTextbox.Text, _passwordTextbox.Text,_keyTextbox.Text, _rfidTextbox.Text,_commentTextbox.Text);
            //Add User
            _bl.AddUser(user);
            MessageBox.Show("User Added Successfully","Info",MessageBoxButton.OK);
            //Update Data
            _userWin._userGrid.DataContext = _bl.GetUser();

            //Clear the textbox
            Clear();

        }

        public void Clear()
        {
            _nameTextbox.Text = String.Empty;
            _chargeTextbox.Text = String.Empty;
            _codeTextbox.Text = String.Empty;
            _usernameTextbox.Text= String.Empty;
            _passwordTextbox.Text = String.Empty;
            _keyTextbox.Text = String.Empty;
            _rfidTextbox.Text = String.Empty;
            _commentTextbox.Text = String.Empty;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
