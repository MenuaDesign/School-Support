using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Status
    {
        public int status_id { get; set; }
        public string status_description { get; set; }

        public Status() { }
        public Status(int pstatus_id, string pstatus_description)
        {
            status_id = pstatus_id;
            status_description = pstatus_description;
        }

        public override string ToString()
        {
            return status_id + " - " + status_description;
        }
    }
}
