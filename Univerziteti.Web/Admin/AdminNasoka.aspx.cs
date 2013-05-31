using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Univerziteti.DataProvider;
using System.IO;
using System.Data;
using Univerziteti.BussinesObjects;

namespace Univerziteti.Web.Admin
{
    public partial class AdminNasoka : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAccess sql = new SqlDataAccess();

                List<Nasoka> Nasoki = sql.NasokiSelectAll();
                gvNasoki.DataSource = Nasoki;
                gvNasoki.DataBind();

                ddlFakultet.DataSource = sql.FakultetSelectAll();
                ddlFakultet.DataTextField = "Ime";
                ddlFakultet.DataValueField = "Id";
                ddlFakultet.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();

            if (txtIme.Text != "")
                sql.NasokaInsert(txtIme.Text, txtOpis.Text, ddlFakultet.SelectedValue);

            lblInfo.Text = "Записот е успешно запишан";

            List<Nasoka> Nasoki = sql.NasokiSelectAll();

            gvNasoki.DataSource = Nasoki;
            gvNasoki.DataBind();

        }

        protected void gvNasoki_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Nasoka> Nasoki = sql.NasokiSelectAll();

            gvNasoki.EditIndex = e.NewEditIndex;
            gvNasoki.DataSource = Nasoki;
            gvNasoki.DataBind();
        }

        protected void gvNasoki_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Nasoka> Nasoki = sql.NasokiSelectAll();

            gvNasoki.EditIndex = -1;
            gvNasoki.DataSource = Nasoki;
            gvNasoki.DataBind();
        }

        protected void gvNasoki_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id, FakultetId;
            string Ime, Opis;
            SqlDataAccess sql = new SqlDataAccess();

            Id = Convert.ToInt32(gvNasoki.Rows[e.RowIndex].Cells[0].Text);

            TextBox tb = (TextBox)gvNasoki.Rows[e.RowIndex].Cells[1].Controls[0];
            Ime = tb.Text;

            tb = (TextBox)gvNasoki.Rows[e.RowIndex].Cells[2].Controls[0];
            Opis = tb.Text;

            FakultetId = Convert.ToInt32(gvNasoki.Rows[e.RowIndex].Cells[3].Text);

            sql.NasokaUpdate(Id, Ime, Opis, FakultetId);

            List<Nasoka> Nasoki = sql.NasokiSelectAll();

            gvNasoki.EditIndex = -1;
            gvNasoki.DataSource = Nasoki;
            gvNasoki.DataBind();

        }

        protected void gvNasoki_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id=Convert.ToInt32(gvNasoki.Rows[e.RowIndex].Cells[0].Text);

            sql.NasokaDelete(Id);

            List<Nasoka> Nasoki = sql.NasokiSelectAll();

            gvNasoki.EditIndex = -1;
            gvNasoki.DataSource = Nasoki;
            gvNasoki.DataBind();

        }
    }
}