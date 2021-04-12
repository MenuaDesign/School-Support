using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;

namespace Index.Dashboard
{
    public partial class Index : System.Web.UI.Page
    {
        Business _business = new Business();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblName.Text = _business.username(Convert.ToInt32(Session["user_id"]));
                lblmytickets.Text = _business.myTicketsCount(Convert.ToInt32(Session["user_id"])).ToString(); 
                lblnewtickets.Text = _business.newTicketsCount().ToString();
                lblopentickets.Text = _business.openTicketsCount().ToString();
                lblsolvedTickets.Text = _business.solvedTicketsCount().ToString();

                gvVraag.DataSource = _business.myTickets(Convert.ToInt32(Session["user_id"]));
                gvVraag.DataBind();

                lblName.Text = _business.username(Convert.ToInt32(Session["user_id"]));
                ddlSubjectAdd.DataValueField = "subject_id";
                ddlSubjectAdd.DataTextField = "subject_description";
                ddlSubjectAdd.DataSource = _business.readTableSubject();
                ddlSubjectAdd.DataBind();
            }
        }
        protected void gvVraag_selected(Object sender, EventArgs e)
        {
            GridViewRow row = gvVraag.SelectedRow;
            string ticket_id = gvVraag.DataKeys[row.RowIndex].Value.ToString();
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt32(ticket_id));
            gvAntwoord.DataBind();
            lblrijnummer.Text = ticket_id;
            divaddanswer.Visible = true;

        }

        protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnRowUpdatingVraag(object sender, GridViewUpdateEventArgs e)
        {
            int user_id = Convert.ToInt32(Session["user_id"]);
            GridViewRow row = gvVraag.Rows[e.RowIndex];
            int ticket_id = Convert.ToInt32(gvVraag.DataKeys[row.RowIndex].Value.ToString());
            string naam = (row.FindControl("txtTicketNaam") as TextBox).Text;
            string subject = (gvVraag.Rows[e.RowIndex].FindControl("ddlSubject") as DropDownList).SelectedItem.Value;
            string question = (row.FindControl("txtQuestion") as TextBox).Text;
            _business.readTableSubject();
            _business.readTableTicketQuestionBewerken(ticket_id, Convert.ToInt16(subject), naam, question);
            gvVraag.EditIndex = -1;
            gvVraag.DataSource = _business.myTickets(user_id);
            gvVraag.DataBind();
        }
        protected void OnRowEditingVraag(object sender, GridViewEditEventArgs e)
        {
            int user_id = Convert.ToInt32(Session["user_id"]);
            gvVraag.EditIndex = e.NewEditIndex;
            gvVraag.DataSource = _business.myTickets(user_id);
            gvVraag.DataBind();

            DropDownList subjectlist = (DropDownList)gvVraag.Rows[e.NewEditIndex].FindControl("ddlSubject");
            subjectlist.DataValueField = "subject_id";
            subjectlist.DataTextField = "subject_description";
            subjectlist.DataSource = _business.readTableSubject();
            subjectlist.DataBind();
        }

        protected void OnRowCancelingEditVraag(object sender, EventArgs e)
        {
            int user_id = Convert.ToInt32(Session["user_id"]);
            gvVraag.EditIndex = -1;
            gvVraag.DataSource = _business.myTickets(user_id);
            gvVraag.DataBind();
        }

        protected void OnRowDeleteVraag(object sender, GridViewDeleteEventArgs e)
        {
            int user_id = Convert.ToInt32(Session["user_id"]);
            GridViewRow row = gvVraag.Rows[e.RowIndex];
            int ticket_id = Convert.ToInt32(gvVraag.DataKeys[row.RowIndex].Value.ToString());
            _business.readTableTicketVraagVerwijderen(ticket_id);
            gvVraag.EditIndex = -1;
            gvVraag.DataSource = _business.myTickets(user_id);
            gvVraag.DataBind();
            gvAntwoord.Visible = false;
            divaddanswer.Visible = false;
        }

        protected void OnRowUpdatingAntwoord(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvAntwoord.Rows[e.RowIndex];
            int answer_id = Convert.ToInt32(gvAntwoord.DataKeys[row.RowIndex].Value.ToString());
            string answer = (row.FindControl("txtAnswer") as TextBox).Text;
            _business.readTableTicketAntwoordBewerken(answer_id, answer);
            gvAntwoord.EditIndex = -1;
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt32(answer_id));
            gvAntwoord.DataBind();
            row = gvVraag.SelectedRow;
            string ticket_id = gvVraag.DataKeys[row.RowIndex].Value.ToString();
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt32(ticket_id));
            gvAntwoord.DataBind();
        }
        protected void OnRowEditingAntwoord(object sender, GridViewEditEventArgs e)
        {
            string answer_id = gvAntwoord.DataKeys[e.NewEditIndex].Value.ToString();
            gvAntwoord.EditIndex = e.NewEditIndex;
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt32(answer_id));
            gvAntwoord.DataBind();
            GridViewRow row = gvVraag.SelectedRow;
            string ticket_id = gvVraag.DataKeys[row.RowIndex].Value.ToString();
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt32(ticket_id));
            gvAntwoord.DataBind();
        }

        protected void OnRowCancelingEditAntwoord(object sender, EventArgs e)
        {
            GridViewRow row = gvVraag.SelectedRow;
            string ticket_id = gvVraag.DataKeys[row.RowIndex].Value.ToString();
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt32(ticket_id));
            gvAntwoord.DataBind();
            gvAntwoord.EditIndex = -1;
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt16(ticket_id));
            gvAntwoord.DataBind();
        }

        protected void OnRowDeleteAntwoord(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvAntwoord.Rows[e.RowIndex];
            int ticket_id = Convert.ToInt32(gvAntwoord.DataKeys[row.RowIndex].Value.ToString());
            _business.readTableTicketAntwoordVerwijderen(ticket_id);
            gvAntwoord.EditIndex = -1;
            gvAntwoord.DataSource = _business.readTableticketAntwoord(ticket_id);
            gvAntwoord.DataBind();
            row = gvVraag.SelectedRow;
            ticket_id = Convert.ToInt32(gvVraag.DataKeys[row.RowIndex].Value.ToString());
            gvAntwoord.DataSource = _business.readTableticketAntwoord(ticket_id);
            gvAntwoord.DataBind();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string t_question = txtticketquestion.Text;
            string t_naam = txtticketnaam.Text;
            string t_subject = ddlSubjectAdd.SelectedItem.Value;
            int user_id = Convert.ToInt32(Session["user_id"]);
            _business.insertQuestion(t_question, t_naam, t_subject, user_id);
            gvVraag.DataSource = _business.myTickets(user_id);
            gvVraag.DataBind();
        }

        protected void btnAddMain_Click(object sender, EventArgs e)
        {
            string a_answer = txtAnswer.Text;
            string a_ticket_id = lblrijnummer.Text;
            int user_id = Convert.ToInt32(Session["user_id"]);
            _business.insertAnswer(a_answer, Convert.ToInt16(a_ticket_id), user_id);
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt16(a_ticket_id));
            gvAntwoord.DataBind();
            if (chkbSolved.Checked)
            {
                _business.StatusSolved(Convert.ToInt16(a_ticket_id));
            }
            gvVraag.DataSource = _business.myTickets(user_id);
            gvVraag.DataBind();
        }

        protected void btnAddAnswer_Click(object sender, EventArgs e)
        {
        }

        protected void gvVraag_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVraag.PageIndex = e.NewPageIndex;
            int user_id = Convert.ToInt32(Session["user_id"]);
            gvVraag.DataSource = _business.myTickets(user_id);
            gvVraag.DataBind();
        }

        protected void btntickets_Click(object sender, EventArgs e)
        {
            gvTickets.Visible = false;
            int user_id = Convert.ToInt32(Session["user_id"]);
            gvVraag.DataSource = _business.myTickets(user_id);
            gvVraag.DataBind();
        }

        protected void gvTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTickets.PageIndex = e.NewPageIndex;
            int user_id = Convert.ToInt32(Session["user_id"]);
            gvTickets.DataSource = _business.myTickets(user_id);
            gvTickets.DataBind();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            btnAddmain.Visible = false;                          
            gvTickets.Visible = true;
            gvVraag.Visible = false;
            gvTickets.DataSource = _business.newTickets();
            gvTickets.DataBind();
        }

        protected void btnopen_Click(object sender, EventArgs e)
        {
            btnAddmain.Visible = false;
            gvTickets.Visible = true;
            gvVraag.Visible = false;
            gvTickets.DataSource = _business.openTickets();
            gvTickets.DataBind();
        }

        protected void btnsolved_Click(object sender, EventArgs e)
        {
            btnAddmain.Visible = false;
            gvTickets.Visible = true;
            gvVraag.Visible = false;
            gvTickets.DataSource = _business.solvedTickets();
            gvTickets.DataBind();
        }

        protected void gvTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvTickets.SelectedRow;
            string ticket_id = gvTickets.DataKeys[row.RowIndex].Value.ToString();
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt32(ticket_id));
            gvAntwoord.DataBind();
            lblrijnummer.Text = ticket_id;
            divaddanswer.Visible = true;
        }
    }
}