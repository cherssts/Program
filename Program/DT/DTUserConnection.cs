﻿using MySql.Data.MySqlClient;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Program.Model;
using Program.DT;

namespace Program.DT
{
    public class DTUserConnection
    {
        /// <summary>
        /// The Private function in which will be referencing the
        /// Base Connection CS file <see cref="DTConeccionBasica"/>
        /// </summary>
        /// <returns> Return a MYSqlConnnection Type Value</returns>
        private static MySqlConnection GetConnection()
        {
            MySqlConnection con = DTConeccionBasica.Coneccion();
            return con;
        }

        /// <summary>
        /// Adds User to the Database
        /// </summary>
        /// <param name="user">Gets Same values to the class<see cref="User"/></param>
        public void AddUser(User user)
        {
            MySqlConnection con = GetConnection();
            string input = $"Insert into `usuario` values(null,'{user.Name}','{user.Charge}','{user.CodeUser}','{user.Username}','{user.Password}','{user.Key}','{user.Rfid}',now(),'{user.Comment}',1)";
            MySqlCommand cmd = new MySqlCommand(input, con);
            try
            {
                cmd.ExecuteNonQuery();
                
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        /// <summary>
        /// The Function in which will be incharge to 
        /// get the data for use
        /// </summary>
        /// <returns>Return the DataSet</returns>
        public DataSet GetUser()
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

        public void UpdateUser(int id,User u)
        {
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand($"Update `Usuario` Set `Nombre` = {u.Name}," +
                                                $" `Cargo` = {u.Charge}, `Codusuario`={u.CodeUser}," +
                                                $"`Username` = {u.Username}, `Password` = {u.Password}" +
                                                $"`Clave` = {u.Key}, `Numero_rfid` = {u.Rfid}," +
                                                $"`FechaModificado` = now() , `Comentario` ={u.Comment}," +
                                                $"`Activo` ={u.IsActive} where `Id` = {id} ", con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
    }
}