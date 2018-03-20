using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_moduller_siparisler : System.Web.UI.UserControl
{
    SqlConnection dbBag = new SqlConnection();
    SqlCommand cmdKomut;
    SqlDataReader dtrData;
    SqlDataAdapter dtrAdaprt;

    baglanti baglan = new baglanti();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (dbBag.State == ConnectionState.Closed)
        {
            dbBag = baglan.baglan();
        }
    }

    protected void rptSiparisListe_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "goster")
        {
            Panel pnl = (Panel)e.Item.FindControl("pnlGizli");

            if (pnl.Visible)
            {
                pnl.Visible = false;
            }
            else
            {
                pnl.Visible = true;
            }
        }
    }

    public string SiparisDetay(string sipID) {

        string[] urunler = sipID.Split(',');

        string donen = "";

        for (int i = 0; i < urunler.Length; i++)
        {

            cmdKomut = new SqlCommand("Select * From tbl_Kategoriler Where ID = '" + urunler[i] + "'", dbBag);
            dtrData = cmdKomut.ExecuteReader();
            if (dtrData.Read())
            {
                donen += "<a href=\"yonetim?v=kategori&d=" + dtrData["ID"] + "\" target=\"_blank\">" + dtrData["VideoAdi"].ToString() + "</a>" + ", ";
            }
            dtrData.Close();
        }

        return donen;

    }
}