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
    public partial class AdminVraboten : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAccess sql = new SqlDataAccess();
                
                List<Vraboten> Vraboteni = sql.VraboteniSelectAll();
                gvVraboteni.DataSource = Vraboteni;
                gvVraboteni.DataBind();

               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Slika="";
            SqlDataAccess sql = new SqlDataAccess();
            int KontaktId = sql.KontaktInsert(txtIme.Text + " " + txtPrezime.Text);

            if (txtEmail.Text != "")
                sql.EmailInsert(txtEmail.Text, KontaktId);
            if (txtTelefon.Text != "")
                sql.TelefonInsert(txtIme.Text + " " + txtPrezime.Text, txtTelefon.Text, KontaktId);

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
                sql.VrabotenInsert(txtIme.Text, txtPrezime.Text, txtOpis.Text, Slika, KontaktId);

            if (Slika != "")
            {
                imgSlika.ImageUrl =Slika;
                imgSlika.Visible = true;
            }
            lblInfo.Text = "Записот е успешно запишан";

            List<Vraboten> Vraboteni = sql.VraboteniSelectAll();

            gvVraboteni.DataSource = Vraboteni;
            gvVraboteni.DataBind();

        }

        protected void gvVraboteni_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Telefon> Telefoni = sql.TelefoniByKontaktId(Convert.ToInt32(gvVraboteni.SelectedRow.Cells[5].Text));
            List<Email> Email = sql.EmailByKontaktId(Convert.ToInt32(gvVraboteni.SelectedRow.Cells[5].Text));
            
            gvTelefoni.DataSource = Telefoni;
            gvTelefoni.DataBind();
            gvTelefoni.Visible = true;

            gvEmail.DataSource = Email;
            gvEmail.DataBind();
            gvEmail.Visible = true;

            lblIme.Text=gvVraboteni.SelectedRow.Cells[1].Text+" "+gvVraboteni.SelectedRow.Cells[2].Text;
            lblBroj.Visible = true;
            lblEmail.Visible = true;
            lblOpis.Visible = true;
            btnEmailV.Visible = true;
            btnVnesiTel.Visible = true;
            txtTelefonBroj.Visible = true;
            txtTelefonOpis.Visible = true;
            txtEmailAdresa.Visible = true;

            gvVraboteni.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDE4EC");
        }

        protected void gvVraboteni_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Vraboten> Vraboteni = sql.VraboteniSelectAll();

            gvVraboteni.EditIndex = e.NewEditIndex;
            gvVraboteni.DataSource = Vraboteni;
            gvVraboteni.DataBind();
        }

        protected void gvVraboteni_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<Vraboten> Vraboteni = sql.VraboteniSelectAll();

            gvVraboteni.EditIndex = -1;
            gvVraboteni.DataSource = Vraboteni;
            gvVraboteni.DataBind();
        }

        protected void gvVraboteni_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id, KontaktId;
            string Ime, Prezime, Opis, Slika;
            SqlDataAccess sql = new SqlDataAccess();

            Id = Convert.ToInt32(gvVraboteni.Rows[e.RowIndex].Cells[0].Text);

            TextBox tb = (TextBox)gvVraboteni.Rows[e.RowIndex].Cells[1].Controls[0];
            Ime = tb.Text;

            tb = (TextBox)gvVraboteni.Rows[e.RowIndex].Cells[2].Controls[0];
            Prezime = tb.Text;

            tb = (TextBox)gvVraboteni.Rows[e.RowIndex].Cells[3].Controls[0];
            Opis = tb.Text;

            tb = (TextBox)gvVraboteni.Rows[e.RowIndex].Cells[4].Controls[0];
            Slika = tb.Text;

            KontaktId = Convert.ToInt32(gvVraboteni.Rows[e.RowIndex].Cells[5].Text);

            sql.VrabotenUpdate(Id, Ime, Prezime, Opis, Slika, KontaktId);


            List<Vraboten> Vraboteni = sql.VraboteniSelectAll();

            gvVraboteni.EditIndex = -1;
            gvVraboteni.DataSource = Vraboteni;
            gvVraboteni.DataBind();

        }

        protected void gvVraboteni_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id=Convert.ToInt32(gvVraboteni.Rows[e.RowIndex].Cells[0].Text);

            sql.VrabotenDelete(Id);

            List<Vraboten> Vraboteni = sql.VraboteniSelectAll();

            gvVraboteni.EditIndex = -1;
            gvVraboteni.DataSource = Vraboteni;
            gvVraboteni.DataBind();

        }

        protected void gvTelefoni_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvTelefoni.Rows[e.RowIndex].Cells[0].Text);

            sql.TelefonDelete(Id);

            List<Telefon> Telefoni = sql.TelefoniByKontaktId(Convert.ToInt32(gvVraboteni.SelectedRow.Cells[5].Text));

            gvTelefoni.DataSource = Telefoni;
            gvTelefoni.DataBind();
        }

        protected void gvEmail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int Id = Convert.ToInt32(gvEmail.Rows[e.RowIndex].Cells[0].Text);

            sql.EmailDelete(Id);

            List<Email> Emails = sql.EmailByKontaktId(Convert.ToInt32(gvVraboteni.SelectedRow.Cells[5].Text));

            gvEmail.DataSource = Emails;
            gvEmail.DataBind();
        }

        protected void btnVnesiTel_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            if (txtTelefonBroj.Text!="")
                sql.TelefonInsert(txtTelefonOpis.Text, txtTelefonBroj.Text, Convert.ToInt32(gvVraboteni.SelectedRow.Cells[5].Text));

            List<Telefon> Telefoni = sql.TelefoniByKontaktId(Convert.ToInt32(gvVraboteni.SelectedRow.Cells[5].Text));

            gvTelefoni.DataSource = Telefoni;
            gvTelefoni.DataBind();

        }

        protected void btnEmailV_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            if (txtEmailAdresa.Text != "")
                sql.EmailInsert(txtEmailAdresa.Text, Convert.ToInt32(gvVraboteni.SelectedRow.Cells[5].Text));

            List<Email> Emails = sql.EmailByKontaktId(Convert.ToInt32(gvVraboteni.SelectedRow.Cells[5].Text));

            gvEmail.DataSource = Emails;
            gvEmail.DataBind();
        }
    }
}