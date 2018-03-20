using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class admin_moduller_videogiris : System.Web.UI.UserControl
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

    protected void doldur() {

        cmdKomut = new SqlCommand("Select * From tbl_Kategoriler Where ID = '" + Request["d"] + "'", dbBag);
        dtrData = cmdKomut.ExecuteReader();
        if (dtrData.Read())
        {
            txtVideoAdi.Text = dtrData["videoAdi"].ToString();
            txtFiyat.Text = dtrData["Fiyat"].ToString();
            txtOnizlemeIframe.Text = dtrData["Foto"].ToString();
            txtKisaOzet.Text = dtrData["VideoKisaAciklamasi"].ToString();
            txtDetayliOzet.Text = dtrData["VideoAciklamasi"].ToString();
        }
        dtrData.Close();

    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        string strUrl = ToSafeUrl(txtVideoAdi.Text);

        if (Request["d"] == null)
        {
            cmdKomut = new SqlCommand("Insert Into tbl_Kategoriler(VideoAdi,URL,Foto,VideoAciklamasi,VideoKisaAciklamasi,Fiyat,Tarih) Values(@VideoAdi,@URL,@Foto,@VideoAciklamasi,@VideoKisaAciklamasi,@Fiyat,@Tarih)", dbBag);
        }
        else
        {
            cmdKomut = new SqlCommand("Update tbl_Kategoriler SET VideoAdi=@VideoAdi,URL=@URL,Foto=@Foto,VideoAciklamasi=@VideoAciklamasi,VideoKisaAciklamasi=@VideoKisaAciklamasi,Fiyat=@Fiyat Where ID = '" + Request["d"] + "'", dbBag);
        }
                
        cmdKomut.Parameters.AddWithValue("@VideoAdi", txtVideoAdi.Text);
        cmdKomut.Parameters.AddWithValue("@URL", strUrl);
        cmdKomut.Parameters.AddWithValue("@Foto", txtOnizlemeIframe.Text);
        cmdKomut.Parameters.AddWithValue("@VideoAciklamasi", txtDetayliOzet.Text);
        cmdKomut.Parameters.AddWithValue("@VideoKisaAciklamasi", txtKisaOzet.Text);
        cmdKomut.Parameters.AddWithValue("@Fiyat", txtFiyat.Text);

        if (Request["d"] == null)
        {
            cmdKomut.Parameters.AddWithValue("@Tarih", DateTime.Now);
        }
        
        cmdKomut.ExecuteNonQuery();

        lblUyari.Text = "İçerik başarı ile düzenlendi.";
    }

    public string ToSafeUrl(string Text)
    {
        return Regex.Replace(Regex.Replace(Regex.Replace(string.Concat(Text.ToLower().Where(p => char.IsLetterOrDigit(p) || char.IsWhiteSpace(p) || p == '-')), @"\s+", " "), @"\s$", ""), @"\s", "-").ToString().Replace("...", "");
    }

    public string trkcKRKTR(string Text) {

        return Text.Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ı", "i").Replace("ö", "o").Replace("ç", "c");

    }

}