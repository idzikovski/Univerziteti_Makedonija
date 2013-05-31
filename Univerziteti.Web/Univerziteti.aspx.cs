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
    public partial class Univerziteti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUniverziteti();
            }
        }

        private void BindUniverziteti()
        {            
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                List<Univerzitet> univerziteti = sql.UniverzitetSelectAll();

                rptUniverziteti.DataSource = univerziteti;
                rptUniverziteti.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}