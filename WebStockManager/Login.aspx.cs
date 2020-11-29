using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStockManager
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "股票管理系統";

            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["WebStockManagerCookie"];

                if (cookie != null)
                {
                    // 載入預設帳號

                

                }

                HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                if (cookie1 != null)
                {
                    cookie1.Expires = DateTime.Now.AddYears(-1);
                    Response.Cookies.Add(cookie1);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtPWD.Text.Trim().ToUpper() == "ZXC0986493031")
            {

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                "alonso",
                  DateTime.Now,
                  DateTime.Now.AddMinutes(120),
                 false,
                  "alonso",
                  FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                Response.Redirect("~/MngStockHoliday.aspx");
            }
        }
    }
}