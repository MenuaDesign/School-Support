using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class User
    {
        public int user_id { get; set; }
        public string user_password { get; set; }
        public string user_email { get; set; }
        public int user_role_id { get; set; }

        public User() { }
        public User(int puser_id, string puser_password, string puser_email, int puser_role_id)
        {

            user_id = puser_id;
            user_password = puser_password;
            user_email = puser_email;
            user_role_id = puser_role_id;

        }

        public override string ToString()
        {
            return user_id + " - " + user_password + " - " + user_email + " - " + user_role_id;
        }
    }
}
