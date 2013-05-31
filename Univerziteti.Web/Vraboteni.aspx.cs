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
    public partial class Vraboteni : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVraboteni();
            }
        }

        private void BindVraboteni()
        {
            try
            {
                SqlDataAccess sql = new SqlDataAccess();

                List<Vraboten> vraboteni = sql.VraboteniSelectAll();
                
                rptVraboteni.DataSource = vraboteni;
                rptVraboteni.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}