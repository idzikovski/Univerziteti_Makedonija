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
    public partial class FakultetDetails : System.Web.UI.Page
    {
        private int FakultetId;

        protected void Page_Load(object sender, EventArgs e)
        {
            checkQUeryString();
            BindFakultet();
        }

        private void BindFakultet()
        {
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                Fakultet fakultet = sql.FakultetSelectByKey(FakultetId);
                Vraboten dekan = sql.VrabotenSelectByKey(fakultet.Dekan);

                if (fakultet != null)
                {
                    lblFakultetIme.InnerText = fakultet.Ime;
                    lblOpis.InnerText = fakultet.Opis;

                    if (!string.IsNullOrEmpty(fakultet.Slika))
                    {
                        imgFakultetSlika.Src = fakultet.Slika;
                    }
                    else
                    {
                        imgFakultetSlika.Visible = false;
                    }

                    List<Telefon> telefoni = sql.TelefoniByKontaktId(fakultet.KontaktId);

                    rptTelefoni.DataSource = telefoni;
                    rptTelefoni.DataBind();

                    List<Adresa> adresi = sql.AdresaByKontaktId(fakultet.KontaktId);

                    rptAdresi.DataSource = adresi;
                    rptAdresi.DataBind();

                    List<Email> emails = sql.EmailByKontaktId(fakultet.KontaktId);

                    rptEmails.DataSource = emails;
                    rptEmails.DataBind();

                    List<Nasoka> nasoki = sql.NasokaSelectByFakultetId(fakultet.Id);

                    rptNasoki.DataSource = nasoki;
                    rptNasoki.DataBind();

                    DataSet vraboteni = sql.RabotiNaFaksByFaksId(fakultet.Id);

                    rptVraboteni.DataSource = vraboteni;
                    rptVraboteni.DataBind();

                    List<Vraboten> prodekani = sql.VrabotenProDekanJoinByUniId(fakultet.Id);

                    rptProdekani.DataSource = prodekani;
                    rptProdekani.DataBind();

                    aDekan.HRef = "VrabotenDetails.aspx?id=" + dekan.Id.ToString();
                    lblDekan.InnerText = dekan.Ime + " " + dekan.Prezime;


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
                        if (!int.TryParse(Request.QueryString["id"], out FakultetId))
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