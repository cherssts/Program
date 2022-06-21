using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model
{
    public class User
    {
        #region properties
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

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private string _rfid;

        public string Rfid
        {
            get { return _rfid; }
            set { _rfid = value; }
        }


        private DateTime _dateModified;

        public DateTime DateModified
        {
            get { return _dateModified; }
            set { _dateModified = value; }
        }


        private string _comment;

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        private int _isActive;

        public int IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

#endregion
        public User(string name, string charge, 
            string codeUser, string username,  
            string password,  string key,  string rfid, 
            string comment)
        {
            Name = name;
            Charge = charge;
            CodeUser = codeUser;
            Username = username;
            Password = password;
            Key = key;
            Rfid = rfid;
            Comment = comment;
        }
        public User()
        {

        }
    }
}
