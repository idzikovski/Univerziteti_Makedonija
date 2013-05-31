using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Univerziteti.DataProvider;
using Univerziteti.BussinesObjects;
using System.Data;

namespace Univerziteti.Web
{
    public partial class UniverzitetDetails : System.Web.UI.Page
    {
        private int UniverzitetId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkQUeryString();
                BindUniverzitet();
            }
        }

        private void BindUniverzitet()
        {
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                Univerzitet univerzitet = sql.UniverzitetSelectByKey(UniverzitetId);
                Vraboten rektor = sql.VrabotenSelectByKey(univerzitet.Rektor);

                if (univerzitet != null)
                {
                    lblUniverzitetIme.InnerText = univerzitet.Ime;
                    lblOpis.InnerText = univerzitet.Opis;

                    if (!string.IsNullOrEmpty(univerzitet.Slika))
                    {
                        imgUniverzitetSlika.Src = univerzitet.Slika;
                    }
                    else
                    {
                        imgUniverzitetSlika.Visible = false;
                    }

                    List<Telefon> telefoni = sql.TelefoniByKontaktId(univerzitet.KontaktId);

                    rptTelefoni.DataSource = telefoni;
                    rptTelefoni.DataBind();

                    List<Adresa> adresi = sql.AdresaByKontaktId(univerzitet.KontaktId);

                    rptAdresi.DataSource = adresi;
                    rptAdresi.DataBind();

                    List<Email> emails = sql.EmailByKontaktId(univerzitet.KontaktId);

                    rptEmails.DataSource = emails;
                    rptEmails.DataBind();

                    List<Fakultet> fakulteti = sql.FakultetSelectByUniverzitetId(univerzitet.Id);

                    rptFakulteti.DataSource = fakulteti;
                    rptFakulteti.DataBind();

                    DataSet vraboteni = sql.RabotiNaUniverzitetByUniverzitetId(univerzitet.Id);

                    rptVraboteni.DataSource = vraboteni;
                    rptVraboteni.DataBind();

                    List<Vraboten> prorektori = sql.VrabotenProRektorJoinByUniId(univerzitet.Id);

                    rptProrektori.DataSource = prorektori;
                    rptProrektori.DataBind();

                    aRektor.HRef = "VrabotenDetails.aspx?id=" + rektor.Id.ToString();
                    lblRektor.InnerText = rektor.Ime + " " + rektor.Prezime;


                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void checkQUeryString()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
                    {
                        if (!int.TryParse(Request.QueryString["id"], out UniverzitetId))
                        {
                            Response.Redirect("Default.apsx");
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.apsx");
                    }
                }
                else
                {
                    Response.Redirect("Default.apsx");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}