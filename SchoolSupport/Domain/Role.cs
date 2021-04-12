using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Role
    {
        public int role_id { get; set; }
        public string role_name { get; set; }
        public string role_description { get; set; }

        public Role() { }
        public Role(int prole_id, string prole_name, string prole_description)
        {
            role_id = prole_id;
            role_name = prole_name;
            role_description = prole_description;
        }

        public override string ToString()
        {
            return role_id + " - " + role_name + " - " + role_description;
        }
    }
}
