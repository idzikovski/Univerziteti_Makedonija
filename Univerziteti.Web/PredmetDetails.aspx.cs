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
    public partial class PredmetDetails : System.Web.UI.Page
    {
        private int PredmetId;

        protected void Page_Load(object sender, EventArgs e)
        {
            checkQUeryString();
            BindPredmet();
        }

        private void BindPredmet()
        {
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                Predmet predmet = sql.PredmetSelectByKey(PredmetId);

                if (predmet != null)
                {
                    lblPredmetIme.InnerText = predmet.Ime;
                    lblOpis.InnerText = predmet.Opis;

                    lblFond.InnerText = predmet.Fond;

                    lblKrediti.InnerText = predmet.Krediti.ToString();

                    if (!string.IsNullOrEmpty(predmet.Programa))
                    {
                        aPrograma.HRef = predmet.Programa;
                    }
                    else
                    {
                        divPrograma.Visible = false;
                    }


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
                        if (!int.TryParse(Request.QueryString["id"], out PredmetId))
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