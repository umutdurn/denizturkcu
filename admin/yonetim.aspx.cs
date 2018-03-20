using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_yonetim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            panelGetir();
        }
    }

    protected void panelGetir() {

        if (Request["v"] != null)
        {
            Panel pnl = (Panel)AnaPanel.FindControl("pnl" + Request["v"].ToString());

            if (pnl != null)
            {
                pnl.Visible = true;
            }
            else
            {
                pnlkategori.Visible = true;
            }
        }
        else
        {
            pnlkategori.Visible = true;
        }
    }
}