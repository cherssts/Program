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
        public DataSet GetUser()
        {
            var _data = new DTUserConnection();
            return _data.GetUser();
        }

        
        public void AddUser(User u)
        {
           
            var Data = new DTUserConnection();
            try
            {
                Data.AddUser(u);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void UpdateUser(int id ,User u)
        {
            var Data = new DTUserConnection();
            Data.UpdateUser(id ,u);
        }
    }




}
