using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Univerziteti.DataProvider;
using System.Data;
using Univerziteti.BussinesObjects;

namespace Univerziteti.Web
{
    public partial class Predmeti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPredmeti();
        }

        private void BindPredmeti()
        {
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                List<Predmet> predmeti = sql.PredmetiSelectAll();

                rptPredmeti.DataSource = predmeti;
                rptPredmeti.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}