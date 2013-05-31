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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            //List<Vraboten> listaVraboteni= sql.VraboteniSelectAll();

            //ddlProba.DataTextField = "Ime";
            //ddlProba.DataValueField = "Id";

            //ddlProba.DataSource = listaVraboteni;
            //ddlProba.DataBind();

            //int id=sql.KontaktInsert("Proben kontakt");

            //txtProba.Text = id.ToString();

            sql.FakultetUpdate(1, "sasdasdasdasdasda", "asdadasa", "Slikaaa", 14, 14, 6);

        }
    }
}
