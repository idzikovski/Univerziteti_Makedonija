using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Univerziteti.DataProvider;
using Univerziteti.BussinesObjects;
using System.IO;
using System.Data;

namespace Univerziteti.Web.Admin
{
    public partial class AdminUniverzitet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAccess sql = new SqlDataAccess();
                List<Univerzitet> Univerziteti = sql.UniverzitetSelectAll();
                List<Vraboten> Vraboteni = sql.VraboteniSelectAll();

                gvUniverziteti.DataSource = Univerziteti;
                gvUniverziteti.DataBind();

                DataSet ImePrezime = sql.VraboteniSelectImePrezime();
                ddlVraboteni.DataSource = ImePrezime;
                ddlVraboteni.DataTextField = "ImePrezime";
                ddlVraboteni.DataValueField = "Id";
                ddlVraboteni.DataBind();
            }
        }

        protected void gvTelefoni_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvTelefoni.Rows[e.RowIndex].Cells[0].Text);

            sql.TelefonDelete(Id);

            List<Telefon> Telefoni = sql.TelefoniByKontaktId(Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            gvTelefoni.DataSource = Telefoni;
            gvTelefoni.DataBind();
        }

        protected void gvEmail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvEmail.Rows[e.RowIndex].Cells[0].Text);

            sql.EmailDelete(Id);

            List<Email> Emails = sql.EmailByKontaktId(Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            gvEmail.DataSource = Emails;
            gvEmail.DataBind();
        }

        protected void btnVnesiTel_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            if (txtTelefonBroj.Text != "")
                sql.TelefonInsert(txtTelefonOpis.Text, txtTelefonBroj.Text, Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            List<Telefon> Telefoni = sql.TelefoniByKontaktId(Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            gvTelefoni.DataSource = Telefoni;
            gvTelefoni.DataBind();
        }

        protected void btnEmailV_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            if (txtEmailAdresa.Text != "")
                sql.EmailInsert(txtEmailAdresa.Text, Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            List<Email> Emails = sql.EmailByKontaktId(Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            gvEmail.DataSource = Emails;
            gvEmail.DataBind();
        }

        protected void btnVnesi_Click(object sender, EventArgs e)
        {
            string Slika = "";
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
            {
                sql.UniverzitetInsert(txtIme.Text, txtOpis.Text, Slika, Convert.ToInt32(ddlVraboteni.SelectedValue), KontaktId);
                lblInfo.Text = "Записот е успешно запишан.";
            }

            if (Slika != "")
            {
                imgSlika.ImageUrl = Slika;
                imgSlika.Visible = true;
            }

            List<Univerzitet> Univerziteti = sql.UniverzitetSelectAll();

            gvUniverziteti.DataSource = Univerziteti;
            gvUniverziteti.DataBind();
        }

        protected void gvUniverziteti_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Telefon> Telefoni = sql.TelefoniByKontaktId(Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));
            List<Email> Email = sql.EmailByKontaktId(Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));
            List<Adresa> Adresi = sql.AdresaByKontaktId(Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            gvTelefoni.DataSource = Telefoni;
            gvTelefoni.DataBind();
            gvTelefoni.Visible = true;

            gvEmail.DataSource = Email;
            gvEmail.DataBind();
            gvEmail.Visible = true;

            gvAdresi.DataSource = Adresi;
            gvAdresi.DataBind();
            gvAdresi.Visible = true;

            lblIme.Text = gvUniverziteti.SelectedRow.Cells[1].Text;

            //lblIme.Visible = true;
            lblBroj.Visible = true;
            lblEmail.Visible = true;
            lblOpis.Visible = true;
            btnEmailV.Visible = true;
            btnVnesiTel.Visible = true;
            txtTelefonBroj.Visible = true;
            txtTelefonOpis.Visible = true;
            txtEmailAdresa.Visible = true;
            lblAdresa.Visible = true;
            txtAdresaVnes.Visible = true;
            btnAdresaVnes.Visible = true;

            gvUniverziteti.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDE4EC");
        }

        protected void gvUniverziteti_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Univerzitet> Univerziteti = sql.UniverzitetSelectAll();

            gvUniverziteti.EditIndex = e.NewEditIndex;
            gvUniverziteti.DataSource = Univerziteti;
            gvUniverziteti.DataBind();
        }

        protected void gvUniverziteti_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Univerzitet> Univerziteti = sql.UniverzitetSelectAll();

            gvUniverziteti.EditIndex = -1;
            gvUniverziteti.DataSource = Univerziteti;
            gvUniverziteti.DataBind();
        }

        protected void gvUniverziteti_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id, KontaktId, Rektor;
            string Ime, Opis, Slika;
            SqlDataAccess sql = new SqlDataAccess();

            Id = Convert.ToInt32(gvUniverziteti.Rows[e.RowIndex].Cells[0].Text);

            TextBox tb = (TextBox)gvUniverziteti.Rows[e.RowIndex].Cells[1].Controls[0];
            Ime = tb.Text;

            tb = (TextBox)gvUniverziteti.Rows[e.RowIndex].Cells[2].Controls[0];
            Opis = tb.Text;

            tb = (TextBox)gvUniverziteti.Rows[e.RowIndex].Cells[3].Controls[0];
            Slika = tb.Text;

            DropDownList ddl = (DropDownList)gvUniverziteti.Rows[e.RowIndex].Cells[4].Controls[1];
            Rektor = Convert.ToInt32(ddl.SelectedValue);


            KontaktId = Convert.ToInt32(gvUniverziteti.Rows[e.RowIndex].Cells[5].Text);

            sql.UniverzitetUpdate(Id, Ime, Opis, Slika, Rektor, KontaktId);


            List<Univerzitet> Univerziteti = sql.UniverzitetSelectAll();

            gvUniverziteti.EditIndex = -1;
            gvUniverziteti.DataSource = Univerziteti;
            gvUniverziteti.DataBind();
        }

        protected void gvUniverziteti_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvUniverziteti.Rows[e.RowIndex].Cells[0].Text);

            sql.UniverzitetDelete(Id);

            List<Univerzitet> Univerziteti = sql.UniverzitetSelectAll();

            gvUniverziteti.DataSource = Univerziteti;
            gvUniverziteti.DataBind();
        }

        protected void btnAdresaVnes_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            if (txtEmailAdresa.Text != "")
                sql.AdresaInsert(txtAdresaVnes.Text, Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            List<Adresa> Adresi = sql.AdresaByKontaktId(Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            gvAdresi.DataSource = Adresi;
            gvAdresi.DataBind();
        }

        protected void gvAdresi_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvAdresi.Rows[e.RowIndex].Cells[0].Text);

            sql.AdresaDelete(Id);

            List<Adresa> Adresi = sql.AdresaByKontaktId(Convert.ToInt32(gvUniverziteti.SelectedRow.Cells[5].Text));

            gvAdresi.DataSource = Adresi;
            gvAdresi.DataBind();
        }
    }
}