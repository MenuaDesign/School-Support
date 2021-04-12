using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Question
    {
        public int question_id { get; set; }
        public string question_description { get; set; }

        public Question() { }
        public Question(int pquestion_id, string pquestion_description)
        {
            question_id = pquestion_id;
            question_description = pquestion_description;
        }

        public override string ToString()
        {
            return question_id + " - " + question_description;
        }
    }
}
