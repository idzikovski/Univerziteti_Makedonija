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
    public partial class AdminFakultet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAccess sql = new SqlDataAccess();

                List<Fakultet> Fakulteti = sql.FakultetSelectAll();
                gvFakulteti.DataSource = Fakulteti;
                gvFakulteti.DataBind();

                ddlDekan.DataSource = sql.VraboteniSelectImePrezime().Tables[0];
                ddlDekan.DataTextField = "ImePrezime";
                ddlDekan.DataValueField = "Id";
                ddlDekan.DataBind();

                ddlUniverzitet.DataSource = sql.UniverzitetSelectAll();
                ddlUniverzitet.DataTextField = "Ime";
                ddlUniverzitet.DataValueField = "Id";
                ddlUniverzitet.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Slika="";
            SqlDataAccess sql = new SqlDataAccess();
            int KontaktId = sql.KontaktInsert(txtIme.Text);

            if (txtEmail.Text != "")
                sql.EmailInsert(txtEmail.Text, KontaktId);
            if (txtTelefon.Text != "")
                sql.TelefonInsert(txtIme.Text, txtTelefon.Text, KontaktId);
            if (txtAdresa.Text != "")
                sql.AdresaInsert(txtAdresa.Text, KontaktId);

            if (fuSlika.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fuSlika.FileName);
                    fuSlika.SaveAs(Server.MapPath("~/Images/") + filename);
                    Slika = "~/Images/" + filename;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            if (txtIme.Text != "")
                sql.FakultetInsert(txtIme.Text, txtOpis.Text, Slika, ddlDekan.SelectedValue, KontaktId, ddlUniverzitet.SelectedValue);

            if (Slika != "")
            {
                imgSlika.ImageUrl =Slika;
                imgSlika.Visible = true;
            }
            lblInfo.Text = "Записот е успешно запишан";

            List<Fakultet> Fakulteti = sql.FakultetSelectAll();

            gvFakulteti.DataSource = Fakulteti;
            gvFakulteti.DataBind();

        }

        protected void gvFakulteti_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Telefon> Telefoni = sql.TelefoniByKontaktId(Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));
            List<Email> Email = sql.EmailByKontaktId(Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));
            List<Adresa> Adresi = sql.AdresaByKontaktId(Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));
            
            gvTelefoni.DataSource = Telefoni;
            gvTelefoni.DataBind();
            gvTelefoni.Visible = true;

            gvEmail.DataSource = Email;
            gvEmail.DataBind();
            gvEmail.Visible = true;

            gvAdresa.DataSource = Adresi;
            gvAdresa.DataBind();
            gvAdresa.Visible = true;

            lblIme.Text=gvFakulteti.SelectedRow.Cells[1].Text;
            lblBroj.Visible = true;
            lblEmail.Visible = true;
            lblOpis.Visible = true;
            btnEmailV.Visible = true;
            btnVnesiTel.Visible = true;
            txtTelefonBroj.Visible = true;
            txtTelefonOpis.Visible = true;
            txtEmailAdresa.Visible = true;

            lblAdresa.Visible = txtAdresaV.Visible = BtnAdresaV.Visible = true;

            gvFakulteti.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDE4EC");
        }

        protected void gvFakulteti_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Fakultet> Fakulteti = sql.FakultetSelectAll();

            gvFakulteti.EditIndex = e.NewEditIndex;
            gvFakulteti.DataSource = Fakulteti;
            gvFakulteti.DataBind();
        }

        protected void gvFakulteti_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Fakultet> Fakulteti = sql.FakultetSelectAll();

            gvFakulteti.EditIndex = -1;
            gvFakulteti.DataSource = Fakulteti;
            gvFakulteti.DataBind();
        }

        protected void gvFakulteti_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id, KontaktId, Dekan, UniverzitetId;
            string Ime, Opis, Slika;
            SqlDataAccess sql = new SqlDataAccess();

            Id = Convert.ToInt32(gvFakulteti.Rows[e.RowIndex].Cells[0].Text);

            TextBox tb = (TextBox)gvFakulteti.Rows[e.RowIndex].Cells[1].Controls[0];
            Ime = tb.Text;

            tb = (TextBox)gvFakulteti.Rows[e.RowIndex].Cells[2].Controls[0];
            Opis = tb.Text;

            tb = (TextBox)gvFakulteti.Rows[e.RowIndex].Cells[3].Controls[0];
            Slika = tb.Text;

            DropDownList ddl = (DropDownList)gvFakulteti.Rows[e.RowIndex].Cells[4].Controls[1];
            Dekan = Convert.ToInt32(ddl.SelectedValue);

            ddl = (DropDownList)gvFakulteti.Rows[e.RowIndex].Cells[5].Controls[1];
            UniverzitetId = Convert.ToInt32(ddl.SelectedValue);

            tb = (TextBox)gvFakulteti.Rows[e.RowIndex].Cells[6].Controls[0];
            KontaktId =Convert.ToInt32(tb.Text);

            sql.FakultetUpdate(Id, Ime, Opis, Slika, Dekan, KontaktId, UniverzitetId);

            List<Fakultet> Fakulteti = sql.FakultetSelectAll();

            gvFakulteti.EditIndex = -1;
            gvFakulteti.DataSource = Fakulteti;
            gvFakulteti.DataBind();

        }

        protected void gvFakulteti_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id=Convert.ToInt32(gvFakulteti.Rows[e.RowIndex].Cells[0].Text);

            sql.FakultetDelete(Id);

            List<Fakultet> Fakulteti = sql.FakultetSelectAll();

            gvFakulteti.EditIndex = -1;
            gvFakulteti.DataSource = Fakulteti;
            gvFakulteti.DataBind();

        }

        protected void gvTelefoni_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvTelefoni.Rows[e.RowIndex].Cells[0].Text);

            sql.TelefonDelete(Id);

            List<Telefon> Telefoni = sql.TelefoniByKontaktId(Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));

            gvTelefoni.DataSource = Telefoni;
            gvTelefoni.DataBind();
        }

        protected void gvEmail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvEmail.Rows[e.RowIndex].Cells[0].Text);

            sql.EmailDelete(Id);

            List<Email> Emails = sql.EmailByKontaktId(Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));

            gvEmail.DataSource = Emails;
            gvEmail.DataBind();
        }

        protected void btnVnesiTel_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            if (txtTelefonBroj.Text!="")
                sql.TelefonInsert(txtTelefonOpis.Text, txtTelefonBroj.Text, Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));

            List<Telefon> Telefoni = sql.TelefoniByKontaktId(Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));

            gvTelefoni.DataSource = Telefoni;
            gvTelefoni.DataBind();

        }

        protected void btnEmailV_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            if (txtEmailAdresa.Text != "")
                sql.EmailInsert(txtEmailAdresa.Text, Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));

            List<Email> Emails = sql.EmailByKontaktId(Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));

            gvEmail.DataSource = Emails;
            gvEmail.DataBind();
        }

        protected void BtnAdresaV_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            if (txtAdresaV.Text != "")
                sql.AdresaInsert(txtAdresaV.Text, Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));

            List<Adresa> Adresi = sql.AdresaByKontaktId(Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));

            gvAdresa.DataSource = Adresi;
            gvAdresa.DataBind();
        }

        protected void gvAdresa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvAdresa.Rows[e.RowIndex].Cells[0].Text);

            sql.AdresaDelete(Id);

            List<Adresa> Adresi = sql.AdresaByKontaktId(Convert.ToInt32(gvFakulteti.SelectedRow.Cells[6].Text));

            gvAdresa.DataSource = Adresi;
            gvAdresa.DataBind();
        }
    }
}