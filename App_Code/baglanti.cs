using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// baglanti için özet açıklama
/// </summary>
public class baglanti
{
    public baglanti()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }

    public SqlConnection baglan() {

        string cumlecik = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        SqlConnection baglanti = new SqlConnection(cumlecik);
        baglanti.Open();

        return baglanti;

    }
    
}