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
    public partial class Fakulteti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFakulteti();
            }
        }

        private void BindFakulteti()
        {
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                DataSet fakulteti = sql.FakultetUniverzitetJoinAll();

                rptFakulteti.DataSource = fakulteti;
                rptFakulteti.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}