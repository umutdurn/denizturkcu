using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class detay : System.Web.UI.Page
{
     SqlConnection dbBag = new SqlConnection();
    SqlCommand cmdKomut;
    SqlDataReader dtrData;
    SqlDataAdapter dtrAdaprt;

    baglanti baglan = new baglanti();

    IList<string> segmentler = HttpContext.Current.Request.GetFriendlyUrlSegments();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (dbBag.State == ConnectionState.Closed)
        {
            dbBag = baglan.baglan();
        }

        if (!IsPostBack)
        {
            urunGetir();
        }
    }

    protected void urunGetir() {

        dtrAdaprt = new SqlDataAdapter("Select * From tbl_Kategoriler Where URL = '" + segmentler[0] + "'",dbBag);
        DataTable dtTable = new DataTable();
        dtrAdaprt.Fill(dtTable);

        rptListeleme.DataSource = dtTable;
        rptListeleme.DataBind();

    }

    protected void rptListeleme_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "satinal")
        {
            string urunIdler = "";

            if (Request.Cookies["urunler"]!= null)
            {
                urunIdler = Request.Cookies["urunler"]["ID"].ToString();
            }

            Response.Cookies["urunler"]["ID"] += urunIdler + "," + e.CommandArgument.ToString();
            Response.Cookies["urunler"].Expires = DateTime.Now.AddDays(5);

            Response.Redirect(Page.ResolveUrl("~/") + "sepet");
        }
    }
}