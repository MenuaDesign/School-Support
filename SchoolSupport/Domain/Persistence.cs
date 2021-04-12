using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Web.Security;

namespace Domain
{
	class Persistence
	{

		private string _connString;
		private MySqlConnection _conn;
		private MySqlCommand _cmd;

		public void ConnectieMaken(string psql)
		{
			_connString = "server = localhost; user id = root; Password = Test123); database=schoolsupport;";
			_conn = new MySqlConnection(_connString);
			_cmd = new MySqlCommand(psql, _conn);
		}

		public int Login(string user_email, string user_password)
		{
			string sql = "SELECT* FROM schoolsupport.user where (user_email = @email) and user_password = @password";
			ConnectieMaken(sql);
			_cmd.Parameters.AddWithValue("@email", user_email);
			string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(user_password, "SHA1");
			_cmd.Parameters.AddWithValue("@password", hash);
			_conn.Open();
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.Read())
			{
				return Convert.ToInt32(dr["user_id"]);
			}
			else
			{
				return 0;
			}
		}

		public bool Available(string user_email)
		{

			string sql = "SELECT* FROM schoolsupport.user where user_email = @email;";
			bool available;
			ConnectieMaken(sql);
			_cmd.Parameters.AddWithValue("@email", user_email);
			_conn.Open();
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.HasRows)
			{
				available = false;
			}
			else
			{
				available = true;
			}
			_conn.Close();
			return available;
		}

		public string Register(string email, string password, string name)
		{
			bool available = Available(email);
			string sql = "INSERT INTO schoolsupport.user (user_email, user_password, user_name) VALUES (@email, @password, @name);";
			_cmd = new MySqlCommand(sql, _conn);
			_cmd.Parameters.AddWithValue("@email", email);
			string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
			_cmd.Parameters.AddWithValue("@password", hash);
			_cmd.Parameters.AddWithValue("@name", name);
			_conn.Open();
			_cmd.ExecuteNonQuery();
			if (available == true)
			{
				return "true";
			}
			else
			{
				return "Email is already in use.";
			}

		}
		public string userName(int puser_id)
		{
			string username = null;
			ConnectieMaken("userName");
			_cmd.Parameters.AddWithValue("u_id", puser_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.Read())
			{
				username = dr[1].ToString();
			}
			_conn.Close();
			return username;
		}

		public string userRole(int puser_id)
		{
			string userrole = null;
			ConnectieMaken("userName");
			_cmd.Parameters.AddWithValue("u_id", puser_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.Read())
			{
				userrole = dr[2].ToString();
			}
			_conn.Close();
			return userrole;
		}

		public int myTicketsCount(int puser_id)
		{
			int user_id = 0;
			ConnectieMaken("myTicketsCount");
			_cmd.Parameters.AddWithValue("user_id", puser_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.Read())
			{
				user_id = Convert.ToInt16(dr[0]);
			}
			_conn.Close();
			return user_id;
		}

		public int newTicketsCount()
		{
			int i = 0;
			ConnectieMaken("newTicketsCount");
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.Read())
			{
				i = Convert.ToInt16(dr[0]);
			}
			_conn.Close();
			return i;
		}

		public int openTicketsCount()
		{
			int i = 0;
			ConnectieMaken("openTicketsCount");
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.Read())
			{
				i = Convert.ToInt16(dr[0]);
			}
			_conn.Close();
			return i;
		}

		public int solvedTicketsCount()
		{
			int i = 0;
			ConnectieMaken("solvedTicketsCount");
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.Read())
			{
				i = Convert.ToInt16(dr[0]);
			}
			_conn.Close();
			return i;
		}
		public List<Ticket> readtableticket()
		{
			List<Ticket> ticket = new List<Ticket>();
			Ticket tt;
			ConnectieMaken("Question");
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			while (dr.Read())
			{
				tt = new Ticket();
				tt.ticket_id = Convert.ToInt16(dr["ticket_id"]);
				tt.ticket_naam = dr["ticket_naam"].ToString();
				tt.subject_description = dr["subject_description"].ToString();
				tt.ticket_date = Convert.ToDateTime(dr["ticket_date"]);
				tt.user_name = dr["user_name"].ToString();
				tt.status_description = dr["status_description"].ToString();
				tt.ticket_question_description = dr["ticket_question_description"].ToString();
				ticket.Add(tt);
			}

			_conn.Close();
			return ticket;

		}
		public List<Ticket> readtableticketantwoord(int ticket_id)
		{
			List<Ticket> ticket = new List<Ticket>();
			Ticket tt;
			ConnectieMaken("Answer");
			_cmd.Parameters.AddWithValue("@t_id", ticket_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			while (dr.Read())
			{
				tt = new Ticket();
				tt.ticket_id = Convert.ToInt16(dr["ticket_id"]);
				tt.answer_date = Convert.ToDateTime(dr["answer_date"]);
				tt.user_name = dr["user_name"].ToString();
				tt.answer_description = dr["answer_description"].ToString();
				tt.answer_id = Convert.ToInt16(dr["answer_id"]);
				ticket.Add(tt);
			}
			_conn.Close();
			return ticket;

		}
		public void readtableticketquestionbewerken(int pticket_id, int pticket_subject_id, string pticket_naam, string pticket_question)
		{
			ConnectieMaken("editQuestion");
			_cmd.Parameters.AddWithValue("t_id", pticket_id);
			_cmd.Parameters.AddWithValue("t_subject_id", pticket_subject_id);
			_cmd.Parameters.AddWithValue("t_naam", pticket_naam);
			_cmd.Parameters.AddWithValue("q_description", pticket_question);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();
		}

		public void readtableticketantwoordbewerken(int panswer_id, string panswer_description)
		{
			ConnectieMaken("editAntwoord");
			_cmd.Parameters.AddWithValue("a_id", panswer_id);
			_cmd.Parameters.AddWithValue("a_description", panswer_description);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();
		}

		public void readtableticketvraagverwijderen(int pticket_id)
		{
			ConnectieMaken("deleteQuestion");
			_cmd.Parameters.AddWithValue("t_id", pticket_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();
		}

		public void readtableticketantwoordverwijderen(int panswer_id)
		{
			ConnectieMaken("deleteAntwoord");
			_cmd.Parameters.AddWithValue("a_id", panswer_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();
		}

		public void insertQuestion(string pt_question, string pt_naam, string pt_subject_id, int pt_user_id)
		{
			ConnectieMaken("insertQuestion");
			_cmd.Parameters.AddWithValue("t_user_id", pt_user_id);
			_cmd.Parameters.AddWithValue("t_Question", pt_question);
			_cmd.Parameters.AddWithValue("t_Naam", pt_naam);
			_cmd.Parameters.AddWithValue("t_Subject_id", pt_subject_id);
			_cmd.Parameters.AddWithValue("t_date", DateTime.Now);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();
		}

		public void insertAnswer(string pa_description, int pa_ticket_id, int pt_user_id)
		{
			ConnectieMaken("insertAnswer");
			_cmd.Parameters.AddWithValue("a_description", pa_description);
			_cmd.Parameters.AddWithValue("a_user_id", pt_user_id);
			_cmd.Parameters.AddWithValue("a_ticket_id", pa_ticket_id);
			_cmd.Parameters.AddWithValue("a_date", DateTime.Now);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();
		}



		public List<Ticket> readtableSubject()
		{
			List<Ticket> subject = new List<Ticket>();
			Ticket tt;
			ConnectieMaken("Subject");
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			while (dr.Read())
			{
				tt = new Ticket();
				tt.subject_id = Convert.ToInt16(dr["subject_id"]);
				tt.subject_description = dr["subject_description"].ToString();
				subject.Add(tt);
			}
			_conn.Close();
			return subject;

		}
		public void StatusSolved(int ticket_id)
		{
			ConnectieMaken("statusSolved");
			_cmd.Parameters.AddWithValue("t_id", ticket_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();

		}

		public List<Ticket> myTickets(int user_id)
		{
			List<Ticket> ticket = new List<Ticket>();
			Ticket tt;
			ConnectieMaken("myTickets");
			_cmd.Parameters.AddWithValue("@u_id", user_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			while (dr.Read())
			{
				tt = new Ticket();
				tt.ticket_id = Convert.ToInt16(dr["ticket_id"]);
				tt.ticket_naam = dr["ticket_naam"].ToString();
				tt.subject_description = dr["subject_description"].ToString();
				tt.ticket_date = Convert.ToDateTime(dr["ticket_date"]);
				tt.user_name = dr["user_name"].ToString();
				tt.status_description = dr["status_description"].ToString();
				tt.ticket_question_description = dr["ticket_question_description"].ToString();
				ticket.Add(tt);
			}

			_conn.Close();
			return ticket;

		}

		public List<Ticket> newTickets()
		{
			List<Ticket> ticket = new List<Ticket>();
			Ticket tt;
			ConnectieMaken("newTickets");
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			while (dr.Read())
			{
				tt = new Ticket();
				tt.ticket_id = Convert.ToInt16(dr["ticket_id"]);
				tt.ticket_naam = dr["ticket_naam"].ToString();
				tt.subject_description = dr["subject_description"].ToString();
				tt.ticket_date = Convert.ToDateTime(dr["ticket_date"]);
				tt.user_name = dr["user_name"].ToString();
				tt.status_description = dr["status_description"].ToString();
				tt.ticket_question_description = dr["ticket_question_description"].ToString();
				ticket.Add(tt);
			}

			_conn.Close();
			return ticket;

		}

		public List<Ticket> openTickets()
		{
			List<Ticket> ticket = new List<Ticket>();
			Ticket tt;
			ConnectieMaken("openTickets");
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			while (dr.Read())
			{
				tt = new Ticket();
				tt.ticket_id = Convert.ToInt16(dr["ticket_id"]);
				tt.ticket_naam = dr["ticket_naam"].ToString();
				tt.subject_description = dr["subject_description"].ToString();
				tt.ticket_date = Convert.ToDateTime(dr["ticket_date"]);
				tt.user_name = dr["user_name"].ToString();
				tt.status_description = dr["status_description"].ToString();
				tt.ticket_question_description = dr["ticket_question_description"].ToString();
				ticket.Add(tt);
			}
			_conn.Close();
			return ticket;

		}

		public List<Ticket> solvedTickets()
		{
			List<Ticket> ticket = new List<Ticket>();
			Ticket tt;
			ConnectieMaken("solvedTickets");
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			while (dr.Read())
			{
				tt = new Ticket();
				tt.ticket_id = Convert.ToInt16(dr["ticket_id"]);
				tt.ticket_naam = dr["ticket_naam"].ToString();
				tt.subject_description = dr["subject_description"].ToString();
				tt.ticket_date = Convert.ToDateTime(dr["ticket_date"]);
				tt.user_name = dr["user_name"].ToString();
				tt.status_description = dr["status_description"].ToString();
				tt.ticket_question_description = dr["ticket_question_description"].ToString();
				ticket.Add(tt);
			}
			_conn.Close();
			return ticket;

		}

		public void editName(int puser_id, string puser_name)
		{
			ConnectieMaken("editName");
			_cmd.Parameters.AddWithValue("u_id", puser_id);
			_cmd.Parameters.AddWithValue("u_name", puser_name);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();
		}

		public void editEmail(int puser_id, string puser_email)
		{
			ConnectieMaken("editEmail");
			_cmd.Parameters.AddWithValue("u_id", puser_id);
			_cmd.Parameters.AddWithValue("u_email", puser_email);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();
		}

		public string getEmail(int puser_id)
		{
			string email = "";
			ConnectieMaken("getEmail");
			_cmd.Parameters.AddWithValue("u_id", puser_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.Read())
			{
				email = dr[0].ToString();
			}
			_conn.Close();
			return email;
		}

		public void editPassword(int puser_id, string puser_nPassword)
		{
			ConnectieMaken("editPassword");
			_cmd.Parameters.AddWithValue("u_id", puser_id);
			_cmd.Parameters.AddWithValue("u_nPassword", puser_nPassword);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			_cmd.ExecuteNonQuery();
			_conn.Close();
		}

		public bool confirmPassword(string user_confPassword)
		{
			string sql = "SELECT* FROM schoolsupport.user where user_password = @confPassword;";
			bool available;
			ConnectieMaken(sql);
			string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(user_confPassword, "SHA1");
			_cmd.Parameters.AddWithValue("@confPassword", hash);
			_conn.Open();
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.HasRows)
			{
				available = false;
			}
			else
			{
				available = true;
			}
			_conn.Close();
			return available;
		}

		public string getPassword(int puser_id)
		{
			string password = "";
			ConnectieMaken("getPassword");
			_cmd.Parameters.AddWithValue("u_id", puser_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			if (dr.Read())
			{
				password = dr[0].ToString();
			}
			_conn.Close();
			return password;
		}

		public List<Ticket> filterName(string puser_name)
		{
			List<Ticket> ticket = new List<Ticket>();
			Ticket tt;
			ConnectieMaken("filterNaam");
			_cmd.Parameters.AddWithValue("u_name", puser_name);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			while (dr.Read())
			{
				tt = new Ticket();
				tt.ticket_id = Convert.ToInt16(dr["ticket_id"]);
				tt.ticket_naam = dr["ticket_naam"].ToString();
				tt.subject_description = dr["subject_description"].ToString();
				tt.ticket_date = Convert.ToDateTime(dr["ticket_date"]);
				tt.user_name = dr["user_name"].ToString();
				tt.status_description = dr["status_description"].ToString();
				tt.ticket_question_description = dr["ticket_question_description"].ToString();
				ticket.Add(tt);
			}

			_conn.Close();
			return ticket;

		}

		public List<Ticket> filterSubject(int psubject_id)
		{
			List<Ticket> ticket = new List<Ticket>();
			Ticket tt;
			ConnectieMaken("filterSubject");
			_cmd.Parameters.AddWithValue("t_subject", psubject_id);
			_conn.Open();
			_cmd.CommandType = System.Data.CommandType.StoredProcedure;
			MySqlDataReader dr = _cmd.ExecuteReader();
			while (dr.Read())
			{
				tt = new Ticket();
				tt.ticket_id = Convert.ToInt16(dr["ticket_id"]);
				tt.ticket_naam = dr["ticket_naam"].ToString();
				tt.subject_description = dr["subject_description"].ToString();
				tt.ticket_date = Convert.ToDateTime(dr["ticket_date"]);
				tt.user_name = dr["user_name"].ToString();
				tt.status_description = dr["status_description"].ToString();
				tt.ticket_question_description = dr["ticket_question_description"].ToString();
				ticket.Add(tt);
			}

			_conn.Close();
			return ticket;
		}


	}
}