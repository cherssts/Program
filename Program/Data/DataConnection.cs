using MySql.Data.MySqlClient;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Program.Model;

namespace Program.Data
{
    public class DataConnection
    {
        /// <summary>
        /// The Private Function in which will provide connection string
        /// deny acces from other classes
        /// </summary>
        /// <returns></returns>
        private static MySqlConnection GetConnection()
        {
            string conString = "Server=localhost;port=3306;UID=root;password=115320162abc;database=Estrella5";
            var con = new MySqlConnection(conString);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            return con;
        }

        public void AddUser(User user)
        {
            MySqlConnection con = GetConnection();
            string input = $"Insert into `usuario` values(null,{user.Name},{user.Charge},{user.CodeUser},{user.Username},{user.Password},{user.Key},{user.Rfid},{user.DateModified},{user.Comment},{user.IsActive})";
            MySqlCommand cmd = new MySqlCommand(input, con);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// The Function in which will be incharge to 
        /// get the data for use
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"> To warn User that 
        /// Table or Database doesnot exist</exception>
        public DataSet UpdateUser()
        {
            DataSet ds;
            MySqlConnection con = GetConnection();

            MySqlCommand cmd = new MySqlCommand("Select * From `usuario`", con);
            ds = new DataSet();
            cmd.ExecuteNonQuery();
            var adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds, "UserTable");
            con.Close();

            return ds;

        }
    }
}
