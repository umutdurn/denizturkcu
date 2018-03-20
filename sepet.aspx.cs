using denizturkcu;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sepet : System.Web.UI.Page
{
    SqlConnection dbBag = new SqlConnection();
    SqlCommand cmdKomut;
    SqlDataReader dtrData;
    SqlDataAdapter dtrAdaprt;

    baglanti baglan = new baglanti();

    public static String odendiMi = "";

    protected bool CanRemoveExternalLogins
    {
        get;
        private set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (dbBag.State == ConnectionState.Closed)
        {
            dbBag = baglan.baglan();
        }

        if (!IsPostBack)
        {
            sptGetir();
        }

        if (odendiMi.Equals("success", StringComparison.OrdinalIgnoreCase))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('İşleminiz başarıyla gerçekleşti.')", true);

            odendiMi = "";
        }
    }
        
    protected void sptGetir() {

        if (Request.Cookies["urunler"] != null)
        {
            string[] idler = Request.Cookies["urunler"]["ID"].ToString().Split(',');

            DataTable dtTable = new DataTable();

            dtTable.Columns.Add("ID", typeof(string));
            dtTable.Columns.Add("VideoAdi", typeof(string));
            dtTable.Columns.Add("VideoKisaAciklamasi", typeof(string));
            dtTable.Columns.Add("Fiyat", typeof(string));

            double toplamFiyat = 0;

            for (int i = 0; i < idler.Length; i++)
            {
                cmdKomut = new SqlCommand("Select * From tbl_Kategoriler Where ID = '" + idler[i] + "'", dbBag);
                dtrData = cmdKomut.ExecuteReader();
                if (dtrData.Read())
                {
                    dtTable.Rows.Add(dtrData["ID"].ToString(), dtrData["VideoAdi"].ToString(), dtrData["VideoKisaAciklamasi"].ToString(), dtrData["Fiyat"].ToString());

                    toplamFiyat += Convert.ToDouble(dtrData["Fiyat"].ToString());
                }
                dtrData.Close();
            }

            ViewState["toplam"] = toplamFiyat;

            rptSepet.DataSource = dtTable;
            rptSepet.DataBind();
        }
    }

    protected void rptSepet_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "urunsil")
        {
            string idler = Request.Cookies["urunler"]["ID"].ToString();

            idler = idler.Replace("," + e.CommandArgument.ToString(), "");

            Response.Cookies["urunler"]["ID"] = idler;
            Response.Cookies["urunler"].Expires = DateTime.Now.AddDays(5);

            Response.Redirect(Page.ResolveUrl("~/") + "sepet");
        }
    }

    protected void btnIleri_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["Uye"] != null)
        {
            pnlOdeme.Visible = true;
        }
        else
        {
            Response.Redirect("Account/Login");
        }
    }

    protected void btnKrediKarti_Click(object sender, EventArgs e)
    {

        Options options = new Options();
        options.ApiKey = "ti6ojKaIOuC4DIG0JhQcp8smy38XAye5";
        options.SecretKey = "iwaY7TqVtBAc1B4jZY4kHWllkW25xMPr";
        options.BaseUrl = "https://api.iyzipay.com";

        CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
        request.Locale = Locale.TR.ToString();
        request.ConversationId = "123456789";
        request.Price = "1";
        request.PaidPrice = "1.2";
        request.Currency = Currency.TRY.ToString();
        request.BasketId = "B67832";
        request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
        request.CallbackUrl = HttpContext.Current.Request.Url.AbsoluteUri;

        List<int> enabledInstallments = new List<int>();
        enabledInstallments.Add(2);
        enabledInstallments.Add(3);
        enabledInstallments.Add(6);
        enabledInstallments.Add(9);
        request.EnabledInstallments = enabledInstallments;

        Buyer buyer = new Buyer();
        buyer.Id = "BY789";
        buyer.Name = "John";
        buyer.Surname = "Doe";
        buyer.GsmNumber = "+905350000000";
        buyer.Email = "email@email.com";
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.Ip = "85.34.78.112";
        buyer.City = "Istanbul";
        buyer.Country = "Turkey";
        buyer.ZipCode = "34732";
        request.Buyer = buyer;

        Address shippingAddress = new Address();
        shippingAddress.ContactName = "Jane Doe";
        shippingAddress.City = "Istanbul";
        shippingAddress.Country = "Turkey";
        shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        shippingAddress.ZipCode = "34742";
        request.ShippingAddress = shippingAddress;

        Address billingAddress = new Address();
        billingAddress.ContactName = "Jane Doe";
        billingAddress.City = "Istanbul";
        billingAddress.Country = "Turkey";
        billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        billingAddress.ZipCode = "34742";
        request.BillingAddress = billingAddress;

        List<BasketItem> basketItems = new List<BasketItem>();
        BasketItem firstBasketItem = new BasketItem();
        firstBasketItem.Id = "BI101";
        firstBasketItem.Name = "Binocular";
        firstBasketItem.Category1 = "Collectibles";
        firstBasketItem.Category2 = "Accessories";
        firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
        firstBasketItem.Price = "0.3";
        basketItems.Add(firstBasketItem);

        BasketItem secondBasketItem = new BasketItem();
        secondBasketItem.Id = "BI102";
        secondBasketItem.Name = "Game code";
        secondBasketItem.Category1 = "Game";
        secondBasketItem.Category2 = "Online Game Items";
        secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        secondBasketItem.Price = "0.5";
        basketItems.Add(secondBasketItem);

        BasketItem thirdBasketItem = new BasketItem();
        thirdBasketItem.Id = "BI103";
        thirdBasketItem.Name = "Usb";
        thirdBasketItem.Category1 = "Electronics";
        thirdBasketItem.Category2 = "Usb / Cable";
        thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
        thirdBasketItem.Price = "0.2";
        basketItems.Add(thirdBasketItem);
        request.BasketItems = basketItems;

        CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);

        Response.Write(checkoutFormInitialize.CheckoutFormContent);

        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", checkoutFormInitialize.CheckoutFormContent);

        odendiMi = checkoutFormInitialize.Status;
    }

    protected void siparisKayit() {

        string idler = Request.Cookies["urunler"]["ID"].ToString();
        string nick = Request.Cookies["Uye"]["KullaniciAdi"].ToString();

        cmdKomut = new SqlCommand("Insert Into tbl_Siparisler(Nick,Sepet,ToplamFiyat,Tarih,Durum) Values(@Nick,Sepet,ToplamFiyat,Tarih,Durum)", dbBag);
        cmdKomut.Parameters.AddWithValue("@Nick", nick);
        cmdKomut.Parameters.AddWithValue("@Sepet", idler);
        cmdKomut.Parameters.AddWithValue("@ToplamFiyat", ViewState["toplam"].ToString());
        cmdKomut.Parameters.AddWithValue("@Tarih", DateTime.Now);
        cmdKomut.Parameters.AddWithValue("@Durum", "1");

        cmdKomut.ExecuteNonQuery();
        

    }
}