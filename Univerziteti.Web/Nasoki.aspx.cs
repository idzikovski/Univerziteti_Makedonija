using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Univerziteti.DataProvider;
using System.Data;

namespace Univerziteti.Web
{
    public partial class Nasoki : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindNasoki();
        }

        private void BindNasoki()
        {
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                DataSet nasoki = sql.NasokaFakultetJoinAll();

                rptNasoki.DataSource = nasoki;
                rptNasoki.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}