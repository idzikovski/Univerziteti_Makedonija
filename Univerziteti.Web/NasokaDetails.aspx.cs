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
    public partial class NasokaDetails : System.Web.UI.Page
    {
        private int NasokaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            checkQUeryString();
            BindNasoka();
        }

        private void BindNasoka()
        {
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                Nasoka nasoka = sql.NasokaSelectByKey(NasokaId);

                if (nasoka != null)
                {
                    lblNasokaIme.InnerText = nasoka.Ime;
                    lblOpis.InnerText = nasoka.Opis;

                    List<Predmet> predmeti = sql.PredmetNasokaPredmetJoinByNasokaId(nasoka.Id);

                    rptPredmeti.DataSource = predmeti;
                    rptPredmeti.DataBind();

                  
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
                        if (!int.TryParse(Request.QueryString["id"], out NasokaId))
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