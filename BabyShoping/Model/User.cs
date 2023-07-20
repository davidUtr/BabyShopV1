using BabyShoping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyShoping.Model
{

    public class User
    {
        private string name;
        private string password;
        private string userName;
       
        public int id { get; set; }

       

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = HashCode.GetHashCode(value); }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        
  

 
        public User()
        {

        }
        public User(string name, string password, string username)
        {
            Name = name;
            Password = password;
            UserName = username;
            
     
            

        }
    }
}
