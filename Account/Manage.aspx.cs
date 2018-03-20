using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using denizturkcu;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Account_Manage : System.Web.UI.Page
{

    SqlCommand cmdKomut = new SqlCommand();
    SqlConnection dbBag = new SqlConnection();
    SqlDataReader dtrData;
    SqlDataAdapter dtrAdapt;

    baglanti dbConn = new baglanti();

    protected string SuccessMessage
    {
        get;
        private set;
    }

    protected bool CanRemoveExternalLogins
    {
        get;
        private set;
    }

    private bool HasPassword(UserManager manager)
    {
        var user = manager.FindById(User.Identity.GetUserId());
        return (user != null && user.PasswordHash != null);
    }

    protected void Page_Load()
    {
        if (!IsPostBack)
        {
            if (dbBag.State == ConnectionState.Closed)
            {
                dbBag = dbConn.baglan();
            }

            // İşlenecek bölümleri belirle
            UserManager manager = new UserManager();
            if (HasPassword(manager))
            {
                changePasswordHolder.Visible = true;
            }
            else
            {
                setPassword.Visible = true;
                changePasswordHolder.Visible = false;
            }
            CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1;

            // Başarı iletisini işle
            var message = Request.QueryString["m"];
            if (message != null)
            {
                // Sorgu dizesini eylemden çıkar
                Form.Action = ResolveUrl("~/Account/Manage");

                SuccessMessage =
                    message == "ChangePwdSuccess" ? "Parolanız değiştirildi."
                    : message == "SetPwdSuccess" ? "Parolanız ayarlandı."
                    : message == "RemoveLoginSuccess" ? "Hesap kaldırıldı."
                    : String.Empty;
                successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
            }

            pnlGetir();
            siparisGetir();
        }
    }

    protected void siparisGetir() {

        dtrAdapt = new SqlDataAdapter("Select * From tbl_Siparisler Where Nick = '" + Request.Cookies["Uye"]["KullaniciAdi"] + "'", dbBag);
        DataTable dtTable = new DataTable();
        dtrAdapt.Fill(dtTable);

        rptSiparislerim.DataSource = dtTable;
        rptSiparislerim.DataBind();

    }

    protected void pnlGetir() {

        if (Request["p"] != null)
        {

            Panel pnl = (Panel)pnlAna.FindControl("pnl" + Request["p"]);

            if (pnl != null)
            {
                pnl.Visible = true;
            }

        }

    }

    protected void ChangePassword_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            UserManager manager = new UserManager();
            IdentityResult result = manager.ChangePassword(User.Identity.GetUserId(), CurrentPassword.Text, NewPassword.Text);
            if (result.Succeeded)
            {
                var user = manager.FindById(User.Identity.GetUserId());
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
            }
            else
            {
                AddErrors(result);
            }
        }
    }

    protected void SetPassword_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            // Yerel oturum açma bilgileri oluşturun ve yerel hesabı kullanıcıyla ilişkilendirin
            UserManager manager = new UserManager();
            IdentityResult result = manager.AddPassword(User.Identity.GetUserId(), password.Text);
            if (result.Succeeded)
            {
                Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
            }
            else
            {
                AddErrors(result);
            }
        }
    }

    public IEnumerable<UserLoginInfo> GetLogins()
    {
        UserManager manager = new UserManager();
        var accounts = manager.GetLogins(User.Identity.GetUserId());
        CanRemoveExternalLogins = accounts.Count() > 1 || HasPassword(manager);
        return accounts;
    }

    public void RemoveLogin(string loginProvider, string providerKey)
    {
        UserManager manager = new UserManager();
        var result = manager.RemoveLogin(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
        string msg = String.Empty;
        if (result.Succeeded)
        {
            var user = manager.FindById(User.Identity.GetUserId());
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            msg = "?m=RemoveLoginSuccess";
        }
        Response.Redirect("~/Account/Manage" + msg);
    }

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error);
        }
    }

    protected void rptDersler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "iframe")
        {
            ltrIframe.Text = e.CommandArgument.ToString();
        }
    }
}