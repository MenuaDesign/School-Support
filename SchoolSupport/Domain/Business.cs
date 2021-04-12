using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Domain
{
    public class Business
    {
        Persistence _persistence = new Persistence();

        public int Login(string user_email, string user_password)
        {
            return _persistence.Login(user_email, user_password);
        }

        public bool Available(string user_email)
        {
            return _persistence.Available(user_email);
        }

        public bool confirmPassword(string user_confPassword)
        {
            return _persistence.confirmPassword(user_confPassword);
        }

        public string Register(string user_email, string user_password, string user_name)
        {
            return _persistence.Register(user_email, user_password, user_name);
        }

        public List<Ticket> readTablereadTableTicket()
        {
            return _persistence.readtableticket();
        }

        public List<Ticket> readTableticketAntwoord(int ticket_id)
        {
            return _persistence.readtableticketantwoord(ticket_id);
        }

        public void readTableTicketQuestionBewerken(int pticket_id, int pticket_subject, string pticket_naam, string pticket_question)
        {
            _persistence.readtableticketquestionbewerken(pticket_id, pticket_subject, pticket_naam, pticket_question);
        }

        public void readTableTicketAntwoordBewerken(int panswer_id, string panswer_description)
        {
            _persistence.readtableticketantwoordbewerken(panswer_id, panswer_description);
        }

        public void readTableTicketVraagVerwijderen(int pticket_id)
        {
            _persistence.readtableticketvraagverwijderen(pticket_id);
        }

        public void readTableTicketAntwoordVerwijderen(int panswer_id)
        {
            _persistence.readtableticketantwoordverwijderen(panswer_id);
        }

        public string username(int puser_id)
        {
            return _persistence.userName(puser_id);
        }

        public string userRole(int puser_id)
        {
            return _persistence.userRole(puser_id);
        }

        public void insertQuestion(string pt_question, string pt_naam, string pt_subject, int pt_user_id)
        {
            _persistence.insertQuestion(pt_question, pt_naam, pt_subject, pt_user_id);
        }

        public List<Ticket> readTableSubject()
        {
            return _persistence.readtableSubject();
        }

        public void insertAnswer(string pa_description, int pa_ticket_id, int pt_user_id)
        {
            _persistence.insertAnswer(pa_description, pa_ticket_id, pt_user_id);
        }

        public void StatusSolved(int ticket_id)
        {
            _persistence.StatusSolved(ticket_id);
        }

        public int myTicketsCount(int puser_id)
        {
            return _persistence.myTicketsCount(puser_id);
        }

        public int newTicketsCount()
        {
            return _persistence.newTicketsCount();
        }

        public int openTicketsCount()
        {
            return _persistence.openTicketsCount();
        }

        public int solvedTicketsCount()
        {
            return _persistence.solvedTicketsCount();
        }

        public List<Ticket> myTickets(int user_id)
        {
            return _persistence.myTickets(user_id);
        }

        public List<Ticket> newTickets()
        {
            return _persistence.newTickets();
        }

        public List<Ticket> openTickets()
        {
            return _persistence.openTickets();
        }

        public List<Ticket> solvedTickets()
        {
            return _persistence.solvedTickets();
        }

        public void editName(int puser_id, string puser_name)
        {
            _persistence.editName(puser_id, puser_name);
        }

        public void editEmail(int puser_id, string puser_email)
        {
            _persistence.editEmail(puser_id, puser_email);
        }

        public string getEmail(int puser_id)
        {
            return _persistence.getEmail(puser_id);
        }

        public void editPassword(int puser_id, string puser_nPassword)
        {
            _persistence.editPassword(puser_id, puser_nPassword);
        }

        public string getPassword(int puser_id)
        {
            return _persistence.getPassword(puser_id);
        }

        public List<Ticket> filterName(string puser_name)
        {
            return _persistence.filterName(puser_name);
        }

        public List<Ticket> filterSubject(int psubject_id)
        {
            return _persistence.filterSubject(psubject_id);
        }

    }
}
