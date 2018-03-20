using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_moduller_dersekle : System.Web.UI.UserControl
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

        if (!IsPostBack)
        {
            if (Request["d"] != null)
            {
                doldur();
            }
        }
    }

    protected void doldur()
    {

        cmdKomut = new SqlCommand("Select * From tbl_Videolar Where ID = '" + Request["d"] + "'", dbBag);
        dtrData = cmdKomut.ExecuteReader();
        if (dtrData.Read())
        {
            txtVideoAdi.Text = dtrData["videoAdi"].ToString();
            dropKategoriler.SelectedValue = dtrData["KatID"].ToString();
            txtVideoAciklamasi.Text = dtrData["Aciklama"].ToString();
            txtVideoIframe.Text = dtrData["Iframe"].ToString();

        }
        dtrData.Close();

    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        if (Request["d"] == null)
        {
            cmdKomut = new SqlCommand("Insert Into tbl_Videolar(VideoAdi,KatID,Aciklama,Iframe) Values(@VideoAdi,@KatID,@Aciklama,@Iframe)", dbBag);
        }
        else
        {
            cmdKomut = new SqlCommand("Update tbl_Videolar SET VideoAdi=@VideoAdi,KatID=@KatID,Aciklama=@Aciklama,Iframe=@Iframe Where ID = '" + Request["d"] + "'", dbBag);
        }

        cmdKomut.Parameters.AddWithValue("@VideoAdi", txtVideoAdi.Text);
        cmdKomut.Parameters.AddWithValue("@KatID", dropKategoriler.SelectedValue);
        cmdKomut.Parameters.AddWithValue("@Aciklama", txtVideoAciklamasi.Text);
        cmdKomut.Parameters.AddWithValue("@Iframe", txtVideoIframe.Text);

        cmdKomut.ExecuteReader();

        lblUyari.Text = "İçerik başarı ile düzenlendi.";
    }
}