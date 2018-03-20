using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_moduller_derslistele : System.Web.UI.UserControl
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

    protected void rptDersDuzenle_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "sil")
        {
            cmdKomut = new SqlCommand("Delete From tbl_Videolar Where ID ='" + e.CommandArgument + "' ", dbBag);
            cmdKomut.ExecuteNonQuery();

            rptDersDuzenle.DataBind();
        }
    }
}