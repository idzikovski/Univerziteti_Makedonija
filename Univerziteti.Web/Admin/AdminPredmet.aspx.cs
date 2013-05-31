using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Univerziteti.DataProvider;
using Univerziteti.BussinesObjects;
using System.IO;

namespace Univerziteti.Web.Admin
{
    public partial class AdminPredmet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAccess sql = new SqlDataAccess();
                List<Predmet> Predmeti = sql.PredmetiSelectAll();

                gvPredmeti.DataSource = Predmeti;
                gvPredmeti.DataBind();
            }
        }

        protected void btnVnesi_Click(object sender, EventArgs e)
        {
            string Programa = "";
            int Krediti;
            SqlDataAccess sql = new SqlDataAccess();

            if (fuPrograma.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fuPrograma.FileName);
                    fuPrograma.SaveAs(Server.MapPath("~/Programi/") + filename);
                    Programa = "~/Programi/" + filename;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            try
            {
                Krediti=Convert.ToInt32(txtKrediti.Text);
            }
            catch (Exception ex)
            {
                Krediti=0;
            }


            if (txtIme.Text != "")
                sql.PredmetInsert(txtIme.Text, txtOpis.Text, txtFond.Text, Krediti, Programa);

            
            lblInfo.Text = "Записот е успешно запишан";

            List<Predmet> Predmeti = sql.PredmetiSelectAll();

            gvPredmeti.DataSource = Predmeti;
            gvPredmeti.DataBind();
        }

        protected void gvPredmeti_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Predmet> Predmeti = sql.PredmetiSelectAll();

            gvPredmeti.EditIndex = e.NewEditIndex;
            gvPredmeti.DataSource = Predmeti;
            gvPredmeti.DataBind();
        }

        protected void gvPredmeti_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Predmet> Predmeti = sql.PredmetiSelectAll();

            gvPredmeti.EditIndex = -1;
            gvPredmeti.DataSource = Predmeti;
            gvPredmeti.DataBind();
        }

        protected void gvPredmeti_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id, Krediti;
            string Ime, Opis, Fond, Programa;
            SqlDataAccess sql = new SqlDataAccess();

            Id = Convert.ToInt32(gvPredmeti.Rows[e.RowIndex].Cells[0].Text);

            TextBox tb = (TextBox)gvPredmeti.Rows[e.RowIndex].Cells[1].Controls[0];
            Ime = tb.Text;

            tb = (TextBox)gvPredmeti.Rows[e.RowIndex].Cells[2].Controls[0];
            Opis = tb.Text;

            tb = (TextBox)gvPredmeti.Rows[e.RowIndex].Cells[3].Controls[0];
            Fond = tb.Text;

            tb = (TextBox)gvPredmeti.Rows[e.RowIndex].Cells[4].Controls[0];
            try
            {
                Krediti=Convert.ToInt32(tb.Text);
            }
            catch (Exception ex)
            {
                Krediti=0;
            }

            tb = (TextBox)gvPredmeti.Rows[e.RowIndex].Cells[5].Controls[0];
            Programa = tb.Text;

            sql.PredmetUpdate(Id, Ime, Opis, Fond, Krediti, Programa);

            List<Predmet> Predmeti = sql.PredmetiSelectAll();

            gvPredmeti.EditIndex = -1;
            gvPredmeti.DataSource = Predmeti;
            gvPredmeti.DataBind();
        }

        protected void gvPredmeti_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvPredmeti.Rows[e.RowIndex].Cells[0].Text);

            sql.PredmetDelete(Id);

            List<Predmet> Predmeti = sql.PredmetiSelectAll();
            gvPredmeti.DataSource = Predmeti;
            gvPredmeti.DataBind();
        }
    }
}