using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Univerziteti.DataProvider;
using Univerziteti.BussinesObjects;

namespace Univerziteti.Web
{
    public partial class VrabotenDetails : System.Web.UI.Page
    {
        private int VrabotenId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkQUeryString();
                BindVraboten();
            }
        }

        private void BindVraboten()
        {
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                Vraboten vraboten = sql.VrabotenSelectByKey(VrabotenId);

                if (vraboten != null)
                {
                    lblVrabotenIme.InnerText = vraboten.Ime+" "+vraboten.Prezime;
                    lblOpis.InnerText = vraboten.Opis;

                    if (!string.IsNullOrEmpty(vraboten.Slika))
                    {
                        imgVrabotenSlika.Src = vraboten.Slika;
                    }
                    else
                    {
                        imgVrabotenSlika.Visible = false;
                    }

                    List<Telefon> telefoni = sql.TelefoniByKontaktId(vraboten.KontaktId);

                    rptTelefoni.DataSource = telefoni;
                    rptTelefoni.DataBind();

                    List<Email> emails = sql.EmailByKontaktId(vraboten.KontaktId);

                    rptEmails.DataSource = emails;
                    rptEmails.DataBind();

                    List<Univerzitet> univerziteti = sql.UniverzitetRabotiVoUniJoinByVrabId(vraboten.Id);
                    
                    rptUniverzieti.DataSource = univerziteti;
                    rptUniverzieti.DataBind();

                    List<Fakultet> fakulteti = sql.FakultetRabotiNaFaksJoinByVrabId(vraboten.Id);

                    rptFakulteti.DataSource = fakulteti;
                    rptFakulteti.DataBind();
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
                        if (!int.TryParse(Request.QueryString["id"], out VrabotenId))
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