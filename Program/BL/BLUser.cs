using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.DT;
using Program.Model;

namespace Program.BL
{
    public class BLUser
    {
        /// <summary>
        /// Just Get the User From the Database
        /// </summary>
        /// <returns></returns>
        public DataSet GetUser()
        {
            var _data = new DTUserConnection();
            return _data.GetUser();
        }

        /// <summary>
        /// Get the Data from the Add User Window and
        /// Passes the Data to DataConnection <see cref="DTUserConnection"/>
        /// </summary>
        /// <param name="u"> <see cref="User"/></param>
        /// <exception cref="Exception"></exception>
        public void AddUser(User u)
        {
           
            var _data = new DTUserConnection();
            try
            {
                _data.AddUser(u);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /// <summary>
        /// Basically is to Update User info taking in
        /// <see cref="User"/> Type Data
        /// </summary>
        /// <param name="id"> Just the Id</param>
        /// <param name="u"> <see cref="User"/></param>
        public void UpdateUser(int id ,User u )
        {

            var _data = new DTUserConnection();
            _data.UpdateUser(id ,u);
        }

        /// <summary>
        /// Basically Get the Id and Delete Data.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteUser(int id)
        {
            var _data = new DTUserConnection();
            try
            {
                _data.DeleteUser(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Search the information based on the 
        /// Name
        /// </summary>
        /// <param name="input"></param>
        public DataSet SearchUser(string input)
        {
            var _data = new DTUserConnection();
            return _data.SearchName(input);
        }


        public DataSet UpdateInfo(int id)
        {
            var _data = new DTUserConnection();
            return _data.GetUpdateInfo(id);
        }




        public DataSet GetRoleName()
        {
            var _data = new DTUserConnection();
            return _data.GetRoleNames();
        }
    }
}
