using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ticket
    {
        public int ticket_id { get; set; }
        public string ticket_naam { get; set; }
        public int ticket_subject_id { get; set; }
        public DateTime ticket_date { get; set; }
        public int ticket_user_id { get; set; }
        public int ticket_question_id { get; set; }
        public int ticket_status_id { get; set; }
        public DateTime ticket_status_date { get; set; }
        public int ticket_answer_id { get; set; }

        public string user_name { get; set; }

        public string user_role { get; set; }

        public string status_description { get; set; }

        public string ticket_question_description { get; set; }

        public int answer_id { get; set; }

        public string answer_description { get; set; }

        public DateTime answer_date { get; set; }

        public int subject_id { get; set; }

        public string subject_description { get; set; }


        public Ticket() {}
        public Ticket(int pticket_id, string pticket_naam, int pticket_subject_id, DateTime pticket_date, string puser_name, string puser_role, string pstatus_description, string pquestion_description, DateTime panswer_date, string panswer_description, int pticket_question_id, int pticket_status_id, int pticket_user_id, DateTime pticket_status_date, int panswer_id)
        {
            ticket_id = pticket_id;
            ticket_naam = pticket_naam;
            ticket_subject_id = pticket_subject_id;
            ticket_date = pticket_date;
            ticket_user_id = pticket_user_id;
            ticket_status_date = pticket_status_date;
            user_name = puser_name;
            status_description = pstatus_description;
            ticket_question_description = pquestion_description;
            answer_description = panswer_description;
            answer_date = panswer_date;
            ticket_question_id = pticket_question_id;
            ticket_status_id = pticket_status_id;
            answer_id = panswer_id;
        }

        public Ticket(int pticket_id, string pticket_naam, int pticket_subject_id, DateTime pticket_date, string puser_name, string puser_role, string pstatus_description, string pquestion_description, DateTime panswer_date, string panswer_description, int pticket_question_id, int pticket_status_id, int pticket_user_id, DateTime pticket_status_date)
        {
            ticket_id = pticket_id;
            ticket_naam = pticket_naam;
            ticket_subject_id = pticket_subject_id;
            ticket_date = pticket_date;
            ticket_user_id = pticket_user_id;
            ticket_status_date = pticket_status_date;
            user_name = puser_name;
            status_description = pstatus_description;
            ticket_question_description = pquestion_description;
            answer_description = panswer_description;
            answer_date = panswer_date;
            ticket_question_id = pticket_question_id;
            ticket_status_id = pticket_status_id;
        }

        public Ticket(int psubject_id, string psubject_description)
        {
            subject_id = psubject_id;
            subject_description = psubject_description;
        }

        /*public override string ToString()
        {
            return ticket_naam + " - " + ticket_subject_id + " - " + ticket_date + " - " + ticket_user_id + " - " + ticket_status_date;
        }*/

    }
}
