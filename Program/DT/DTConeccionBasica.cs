using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Program.DT
{
    public static class DTConeccionBasica
    {
        private static string _datosConeccion = "Server=localhost; port=3306;UID=alejandro;password=115320162abc;database=Estrella5";
        public static MySqlConnection Coneccion()
        {
            MySqlConnection con = new MySqlConnection(_datosConeccion);
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
    }
}
