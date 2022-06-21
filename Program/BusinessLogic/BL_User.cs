using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Data;
using Program.Model;

namespace Program.BusinessLogic
{
    public class BL_User
    {
        public DataSet GetUser()
        {
            var _data = new DataConnection();
            return _data.UpdateUser();
        }

        
        public void AddUser(InternalUser u)
        {
            var a = new InternalUser 
            {
                Name = u.Name , 
                Charge = u.Charge ,
                CodeUser = u.CodeUser ,
                Username = u.Username ,
                Password = u.Password ,
                Key = u.Key ,
                Rfid = u.Rfid ,
                DateModified = u.DateModified ,
                Comment = u.Comment ,
                IsActive = u.IsActive ,
            };
            var Data = new DataConnection();
            try
            {
                Data.AddUser(a);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }

    public class InternalUser : User
    {
    }


}
