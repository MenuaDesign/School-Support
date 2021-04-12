using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;

namespace presentationWeb
{
    public partial class Ticket : System.Web.UI.Page
    {
        Business _business = new Business();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string userrole = Session["user_role"].ToString();
                if (userrole == "Teacher" || userrole == "Admin")
                {
                    gvVraag.Visible = true;
                    gvVraagLeerling.Visible = false;
                    gvAntwoordLeerling.Visible = false;
                }
                else
                {
                    gvVraagLeerling.Visible = true;
                    gvVraag.Visible = false;
                    gvAntwoord.Visible = false;
                }
                gvVraag.DataSource = _business.readTablereadTableTicket();
                gvVraag.DataBind();
                gvVraagLeerling.DataSource = _business.readTablereadTableTicket();
                gvVraagLeerling.DataBind();
                lblName.Text = _business.username(Convert.ToInt32(Session["user_id"]));
                ddlSubjectAdd.DataValueField = "subject_id";
                ddlSubjectAdd.DataTextField = "subject_description";
                ddlSubjectAdd.DataSource = _business.readTableSubject();
                ddlSubjectAdd.DataBind();
                ddlSubjectFilter.DataValueField = "subject_id";
                ddlSubjectFilter.DataTextField = "subject_description";
                ddlSubjectFilter.DataSource = _business.readTableSubject();
                ddlSubjectFilter.DataBind();
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
            GridViewRow row = gvVraag.Rows[e.RowIndex];
            int ticket_id = Convert.ToInt32(gvVraag.DataKeys[row.RowIndex].Value.ToString());
            string naam = (row.FindControl("txtTicketNaam") as TextBox).Text;
            string subject = (gvVraag.Rows[e.RowIndex].FindControl("ddlSubject") as DropDownList).SelectedItem.Value;
            string question = (row.FindControl("txtQuestion") as TextBox).Text;
            gvVraag.Columns[0].Visible = true;
            gvVraag.Columns[1].Visible = true;
            gvVraag.Columns[2].Visible = false;
            gvVraag.Columns[3].Visible = false;
            _business.readTableSubject();
            _business.readTableTicketQuestionBewerken(ticket_id, Convert.ToInt16(subject), naam, question);
            gvVraag.EditIndex = -1;
            gvVraag.DataSource = _business.readTablereadTableTicket();
            gvVraag.DataBind();
        }
        protected void OnRowEditingVraag(object sender, GridViewEditEventArgs e)
        {
            gvVraag.Columns[0].Visible = false;
            gvVraag.Columns[1].Visible = false;
            gvVraag.Columns[2].Visible = true;
            gvVraag.Columns[3].Visible = true;
            gvVraag.EditIndex = e.NewEditIndex;
            gvVraag.DataSource = _business.readTablereadTableTicket();
            gvVraag.DataBind();

            DropDownList subjectlist = (DropDownList) gvVraag.Rows[e.NewEditIndex].FindControl("ddlSubject");
            subjectlist.DataValueField = "subject_id";
            subjectlist.DataTextField = "subject_description";
            subjectlist.DataSource = _business.readTableSubject();
            subjectlist.DataBind();
        }

        protected void OnRowCancelingEditVraag(object sender, EventArgs e)
        {
            gvVraag.Columns[0].Visible = true;
            gvVraag.Columns[1].Visible = true;
            gvVraag.Columns[2].Visible = false;
            gvVraag.Columns[3].Visible = false;
            gvVraag.EditIndex = -1;
            gvVraag.DataSource = _business.readTablereadTableTicket();
            gvVraag.DataBind();
        }

        protected void OnRowDeleteVraag(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvVraag.Rows[e.RowIndex];
            int ticket_id = Convert.ToInt32(gvVraag.DataKeys[row.RowIndex].Value.ToString());
            _business.readTableTicketVraagVerwijderen(ticket_id);
            gvVraag.EditIndex = -1;
            gvVraag.DataSource = _business.readTablereadTableTicket();
            gvVraag.DataBind();
            gvAntwoord.Visible = false;
            divaddanswer.Visible = false;
        }

        protected void OnRowUpdatingAntwoord(object sender, GridViewUpdateEventArgs e)
        {
            gvAntwoord.Columns[0].Visible = true;
            gvAntwoord.Columns[1].Visible = true;
            gvAntwoord.Columns[2].Visible = false;
            gvAntwoord.Columns[3].Visible = false;
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
            gvAntwoord.Columns[0].Visible = false;
            gvAntwoord.Columns[1].Visible = false;
            gvAntwoord.Columns[2].Visible = true;
            gvAntwoord.Columns[3].Visible = true;
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
            gvAntwoord.Columns[0].Visible = true;
            gvAntwoord.Columns[1].Visible = true;
            gvAntwoord.Columns[2].Visible = false;
            gvAntwoord.Columns[3].Visible = false;
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
            gvVraag.DataSource = _business.readTablereadTableTicket();
            gvVraag.DataBind();
            gvVraagLeerling.DataSource = _business.readTablereadTableTicket();
            gvVraagLeerling.DataBind();
        }

        protected void btnAddMain_Click(object sender, EventArgs e)
        {
            string a_answer = txtAnswer.Text;
            string a_ticket_id = lblrijnummer.Text;
            int user_id = Convert.ToInt32(Session["user_id"]);
            _business.insertAnswer(a_answer,Convert.ToInt16(a_ticket_id),user_id);
            gvAntwoord.DataSource = _business.readTableticketAntwoord(Convert.ToInt16(a_ticket_id));
            gvAntwoord.DataBind();
            gvAntwoordLeerling.DataSource = _business.readTableticketAntwoord(Convert.ToInt16(a_ticket_id));
            gvAntwoordLeerling.DataBind();
            if (chkbSolved.Checked)
            {
                _business.StatusSolved(Convert.ToInt16(a_ticket_id));
            }
            gvVraag.DataSource = _business.readTablereadTableTicket();
            gvVraag.DataBind();
            gvVraagLeerling.DataSource = _business.readTablereadTableTicket();
            gvVraagLeerling.DataBind();
        }

        protected void btnAddAnswer_Click(object sender, EventArgs e)
        {
        }

        protected void gvVraag_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVraag.PageIndex = e.NewPageIndex;

            gvVraag.DataSource = _business.readTablereadTableTicket();
            gvVraag.DataBind();
        }

        protected void gvVraagLeerling_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVraagLeerling.PageIndex = e.NewPageIndex;

            gvVraagLeerling.DataSource = _business.readTablereadTableTicket();
            gvVraagLeerling.DataBind();
        }

        protected void gvVraagLeerling_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvVraagLeerling.SelectedRow;
            string ticket_id = gvVraagLeerling.DataKeys[row.RowIndex].Value.ToString();
            gvAntwoordLeerling.DataSource = _business.readTableticketAntwoord(Convert.ToInt32(ticket_id));
            gvAntwoordLeerling.DataBind();
            lblrijnummer.Text = ticket_id;
            divaddanswerleerling.Visible = true;
        }

        protected void lbtnSubjectFilter_Click(object sender, EventArgs e)
        {
            string subject = ddlSubjectFilter.SelectedValue;
            gvVraag.DataSource = _business.filterSubject(Convert.ToInt16(subject));
            gvVraag.DataBind();
            gvVraagLeerling.DataSource = _business.filterSubject(Convert.ToInt16(subject));
            gvVraagLeerling.DataBind();
        }

        protected void lbtnFilters_Click(object sender, EventArgs e)
        {
            divFilters.Visible = true;
        }

        protected void lbtnCloseFilter_Click(object sender, EventArgs e)
        {
            divFilters.Visible = false;
            gvVraag.DataSource = _business.readTablereadTableTicket();
            gvVraag.DataBind();
            gvVraagLeerling.DataSource = _business.readTablereadTableTicket();
            gvVraagLeerling.DataBind();
        }

        protected void lbtnNameFilter_Click(object sender, EventArgs e)
        {
            string puser_name = txtNameFilter.Text;
            gvVraag.DataSource = _business.filterName(puser_name);
            gvVraag.DataBind();
            gvVraagLeerling.DataSource = _business.filterName(puser_name);
            gvVraagLeerling.DataBind();
        }
    }
}