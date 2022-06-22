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
    public class BL_User
    {
        public DataSet GetUser()
        {
            var _data = new DTCrudConnection();
            return _data.UpdateUser();
        }

        
        public void AddUser(User u)
        {
            var a = new User() 
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
            var Data = new DTCrudConnection();
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




}
