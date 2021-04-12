using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Answer
    {
        public int answer_id { get; set; }
        public string answer_discription { get; set; }
        public int answer_user_id { get; set; }

        public Answer() { }
        public Answer(int panswer_id, string panswer_discription, int panswer_user_id)
        {
            answer_id = panswer_id;
            answer_discription = panswer_discription;
            answer_user_id = panswer_user_id;
        }

        public override string ToString()
        {
            return answer_id + " - " + answer_discription + " - " + answer_user_id;
        }
    }
}
