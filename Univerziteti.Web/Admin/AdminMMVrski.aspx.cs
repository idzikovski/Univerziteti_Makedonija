using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Univerziteti.DataProvider;
using Univerziteti.BussinesObjects;
using System.Data;

namespace Univerziteti.Web.Admin
{
    public partial class AdminMMVrski : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                SqlDataAccess sql = new SqlDataAccess();
                List<Univerzitet> Univerziteti = sql.UniverzitetSelectAll();
                List<Fakultet> Fakulteti = sql.FakultetSelectAll();
                List<Nasoka> Nasoki = sql.NasokiSelectAll();
                List<Predmet> Predmeti = sql.PredmetiSelectAll();
                DataSet ImePrezime = sql.VraboteniSelectImePrezime();
                DataSet RabVoUni = sql.RabotiVoUniJoinAll();
                DataSet ProRektori = sql.ProRektorJoinAll();
                DataSet RabNaFaks = sql.RabotiNaFaksJoinAll();
                DataSet ProDekani = sql.ProDekanJoinAll();
                DataSet NP = sql.NasokaPredmetJoinAll();

                ddlUniRab.DataSource = Univerziteti;
                ddlUniRab.DataTextField = "Ime";
                ddlUniRab.DataValueField = "Id";
                ddlUniRab.DataBind();

                ddlVrabRabUni.DataSource = ImePrezime;
                ddlVrabRabUni.DataTextField = "ImePrezime";
                ddlVrabRabUni.DataValueField = "Id";
                ddlVrabRabUni.DataBind();

                ddlUniProRekt.DataSource = Univerziteti;
                ddlUniProRekt.DataTextField = "Ime";
                ddlUniProRekt.DataValueField = "Id";
                ddlUniProRekt.DataBind();

                ddlVrabProRekt.DataSource = ImePrezime;
                ddlVrabProRekt.DataTextField = "ImePrezime";
                ddlVrabProRekt.DataValueField = "Id";
                ddlVrabProRekt.DataBind();

                ddlFakRab.DataSource = Fakulteti;
                ddlFakRab.DataTextField = "Ime";
                ddlFakRab.DataValueField = "Id";
                ddlFakRab.DataBind();

                ddlVrabRabFak.DataSource = ImePrezime;
                ddlVrabRabFak.DataTextField = "ImePrezime";
                ddlVrabRabFak.DataValueField = "Id";
                ddlVrabRabFak.DataBind();

                ddlFakProDek.DataSource = Fakulteti;
                ddlFakProDek.DataTextField = "Ime";
                ddlFakProDek.DataValueField = "Id";
                ddlFakProDek.DataBind();

                ddlVrabProDek.DataSource = ImePrezime;
                ddlVrabProDek.DataTextField = "ImePrezime";
                ddlVrabProDek.DataValueField = "Id";
                ddlVrabProDek.DataBind();

                ddlNasokaNP.DataSource = Nasoki;
                ddlNasokaNP.DataTextField = "Ime";
                ddlNasokaNP.DataValueField = "Id";
                ddlNasokaNP.DataBind();

                ddlPredmetNP.DataSource = Predmeti;
                ddlPredmetNP.DataTextField = "Ime";
                ddlPredmetNP.DataValueField = "Id";
                ddlPredmetNP.DataBind();

                gvRabUni.DataSource = RabVoUni;
                gvRabUni.DataBind();

                gvProrektori.DataSource = ProRektori;
                gvProrektori.DataBind();

                gvRabFak.DataSource = RabNaFaks;
                gvRabFak.DataBind();

                gvProdekani.DataSource = ProDekani;
                gvProdekani.DataBind();

                gvNP.DataSource = NP;
                gvNP.DataBind();
                
            }
        }

        protected void btnRabUni_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int flag=0;
            try
            {
                flag=sql.RabotiVoUniInsert(ddlUniRab.SelectedValue, ddlVrabRabUni.SelectedValue, txtUniPozicija.Text);
            }
            catch (Exception ex)
            {
                
            }

            if (flag != 0)
                lblRabUni.Text = "Записот е успешно запишан.";
            else lblRabUni.Text = "Записот веќе постои.";

            DataSet RabVoUni = sql.RabotiVoUniJoinAll();
            gvRabUni.DataSource = RabVoUni;
            gvRabUni.DataBind();

        }

        protected void gvRabUni_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int UniverzitetId = Convert.ToInt32(gvRabUni.Rows[e.RowIndex].Cells[0].Text);
            int VrabotenId = Convert.ToInt32(gvRabUni.Rows[e.RowIndex].Cells[2].Text);

            sql.RabotiVoUniDelete(UniverzitetId, VrabotenId);

            DataSet RabVoUni = sql.RabotiVoUniJoinAll();

            gvRabUni.DataSource = RabVoUni;
            gvRabUni.DataBind();
        }

        protected void gvProrektori_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int UniverzitetId = Convert.ToInt32(gvProrektori.Rows[e.RowIndex].Cells[0].Text);
            int VrabotenId = Convert.ToInt32(gvProrektori.Rows[e.RowIndex].Cells[2].Text);

            sql.ProRektorDelete(UniverzitetId, VrabotenId);

            DataSet ProRektori = sql.ProRektorJoinAll();
            gvProrektori.DataSource = ProRektori;
            gvProrektori.DataBind();
        }

        protected void btnProrektori_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int flag = 0;
            try
            {
                flag = sql.ProRektorInsert(ddlUniProRekt.SelectedValue, ddlVrabProRekt.SelectedValue);
            }
            catch (Exception ex)
            {
                
            }

            if (flag != 0)
                lblProrektori.Text = "Записот е успешно запишан.";
            else lblProrektori.Text = "Записот веќе постои";

            DataSet ProRektori = sql.ProRektorJoinAll();
            gvProrektori.DataSource = ProRektori;
            gvProrektori.DataBind();
        }

        protected void btnRabFak_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int flag = 0;
            try
            {
                flag = sql.RabotiNaFaksInsert(ddlFakRab.SelectedValue, ddlVrabRabFak.SelectedValue, txtInstitut.Text, txtFakPozicija.Text);
            }
            catch (Exception ex)
            {
                
            }

            if (flag != 0)
                lblRabFak.Text = "Записот е успешно запишан.";
            else lblRabFak.Text = "Записот веќе постои";

            DataSet RabNaFaks = sql.RabotiNaFaksJoinAll();
            gvRabFak.DataSource = RabNaFaks;
            gvRabFak.DataBind();
        }

        protected void gvRabFak_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            SqlDataAccess sql = new SqlDataAccess();
            int FakultetId = Convert.ToInt32(gvRabFak.Rows[e.RowIndex].Cells[0].Text);
            int VrabotenId = Convert.ToInt32(gvRabFak.Rows[e.RowIndex].Cells[2].Text);

            sql.RabotiNaFaksDelete(FakultetId, VrabotenId);

            DataSet RabNaFaks = sql.RabotiNaFaksJoinAll();
            gvRabFak.DataSource = RabNaFaks;
            gvRabFak.DataBind();
        }

        protected void btnProdekani_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int flag = 0;
            try
            {
                flag = sql.ProDekanInsert(ddlFakProDek.SelectedValue, ddlVrabProDek.SelectedValue);
            }
            catch (Exception ex)
            {
                
            }

            if (flag != 0)
                lblProdekani.Text = "Записот е успешно запишан.";
            else lblProdekani.Text = "Записот веќе постои";

            DataSet ProDekani = sql.ProDekanJoinAll();
            gvProdekani.DataSource = ProDekani;
            gvProdekani.DataBind();
        }

        protected void gvProdekani_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int FakultetId = Convert.ToInt32(gvProdekani.Rows[e.RowIndex].Cells[0].Text);
            int VrabotenId = Convert.ToInt32(gvProdekani.Rows[e.RowIndex].Cells[2].Text);

            sql.ProDekanDelete(FakultetId, VrabotenId);

            DataSet ProDekani = sql.ProDekanJoinAll();
            gvProdekani.DataSource = ProDekani;
            gvProdekani.DataBind();
        }

        protected void btnNP_Click(object sender, EventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int flag = 0;
            try
            {
                flag = sql.NasokaPredmetInsert(ddlPredmetNP.SelectedValue, ddlNasokaNP.SelectedValue);
            }
            catch (Exception ex)
            {

            }

            if (flag != 0)
                lblNP.Text = "Записот е успешно запишан.";
            else lblNP.Text = "Записот веќе постои";

            DataSet NP = sql.NasokaPredmetJoinAll();
            gvNP.DataSource = NP;
            gvNP.DataBind();
        }

        protected void gvNP_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlDataAccess sql = new SqlDataAccess();
            int NasokaId = Convert.ToInt32(gvNP.Rows[e.RowIndex].Cells[0].Text);
            int PredmetId = Convert.ToInt32(gvNP.Rows[e.RowIndex].Cells[2].Text);

            sql.NasokaPredmetDelete(PredmetId, NasokaId);

            DataSet NP = sql.NasokaPredmetJoinAll();
            gvNP.DataSource = NP;
            gvNP.DataBind();
        }
    }
}