using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model
{
    public class User
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _charge;

        public string Charge
        {
            get { return _charge; }
            set { _charge = value; }
        }

        private string _codeUser;

        public string CodeUser
        {
            get { return _codeUser; }
            set { _codeUser = value; }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }



    }
}
