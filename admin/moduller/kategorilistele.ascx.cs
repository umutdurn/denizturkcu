using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_moduller_kategorilistele : System.Web.UI.UserControl
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

    protected void rptKategoriDuzenle_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "sil")
        {
            cmdKomut = new SqlCommand("Delete From tbl_Kategoriler Where ID ='" + e.CommandArgument + "' ", dbBag);
            cmdKomut.ExecuteNonQuery();

            rptKategoriDuzenle.DataBind();
        }
    }
}