using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStockManager.App_Code
{
    public class BasePage : System.Web.UI.Page
    {

        protected override void OnPreLoad(EventArgs e)
        {
            this.Title = "股票管理系統";
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            base.OnPreLoad(e);
        }


    }
}