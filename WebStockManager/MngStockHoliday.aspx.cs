﻿using Alonso.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebStockManager.Model;

namespace WebStockManager
{
    public partial class MngStockHoliday : System.Web.UI.Page
    {
        DAL.StockCalendarDAL dal = new DAL.StockCalendarDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //產生初始化年分
                ddlYears.Items.Clear();
                for (int i = 0; i < 5; i++)
                {
                    ddlYears.Items.Add(DateTime.Now.AddYears(i).ToString("yyyy"));
                }


                ShowCRUD(emCRUD.View);



                anp.RecordCount = dal.CalcCount(GetCond());
                BindRep();


            }
        }
        private void BindRep()
        {


            GridView1.DataSource = dal.GetListArray("*", "Id desc", anp.PageSize, anp.CurrentPageIndex, GetCond());
            GridView1.DataBind();
        }
        private string GetCond()
        {
           

            string cond = string.Format( " chYear ='{0}'", ddlYears.SelectedValue ) ;
            return cond;
        }
        protected void anpList_PageChanged(object sender, EventArgs e)
        {
            anp.RecordCount = dal.CalcCount(GetCond());
            BindRep();
        }
        protected void search(object sender, EventArgs e)
        {
            anp.RecordCount = dal.CalcCount(GetCond());
            BindRep();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = null;
            string Id = "";
            string cond = " 1=1 ";
            string msg = "";
            var whereClausesBuilder = new WhereClausesBuilder();
            List<SqlParameter> GroupSqlParameter = new List<SqlParameter>();

            StockCalendar m = null;
            if (e.CommandName != "cmdbtnAdd")
            {
                row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
              Id = this.GridView1.DataKeys[row.RowIndex]["Id"].ToString();          
            }

            switch (e.CommandName)
            {
                case "cmdbtnAdd":

                    break;
                case "cmdbtnEdit":
                    ClearDataToForm(); //清除資料                                       
                    hidenId.Value = Id;
                    m = dal.GetModel(TypeChange.StringToInt(Id));
                    SetDataToForm(m);
                    ShowCRUD(emCRUD.Edit);    //設定顯示方式                          
                    break;
                case "cmdbtnDel":
                    whereClausesBuilder.appendCriteria("AA001", Id, "  AA001= {0} ", ref cond, ref GroupSqlParameter);
                 //  pARAADAL.DeleteByCond(cond, GroupSqlParameter);
                    msg = "刪除成功!!";
                    Tool.Alert(msg, this);
                    anp.RecordCount = dal.CalcCount(GetCond());
                    BindRep();
                    break;
            }
        }

      

        /// <summary>                              
        /// 設定資料到From                         
        /// </summary>                             
        /// <param name="m"></param>               
        private void SetDataToForm(StockCalendar m)
        {

        }
        /// <summary>                    
        /// 清除From資訊                 
        /// </summary>                   
        private void ClearDataToForm()
        {

        }
        /// <summary>                                                  
        /// 查詢/新增面板切換                                          
        /// </summary>                                                 
        /// <param name="v">傳入型別  emCRUD </param>                
        /// <remarks>  新增/修改  & 查詢頁面切換使用  </remarks>       
        private void ShowCRUD(emCRUD v)
        {
            if (v == emCRUD.View)
            {
                panelEdit.Visible = false;
                panelQ.Visible = true;
            }

            if (v == emCRUD.Edit)
            {
                panelEdit.Visible = true;
                panelQ.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenHoiday_Click(object sender, EventArgs e)
        {
            int iYear = TypeChange.StringToInt(ddlYears.SelectedValue);

            DateTime dtS = new DateTime(iYear, 1, 1);


            DateTime dtE = new DateTime(iYear, 12, 31);
            
            for (int i = 0; i < (dtE- dtS).Days; i++)
            {
           
                DateTime temp = dtS.AddDays(i);
                if (temp.DayOfWeek != DayOfWeek.Sunday && temp.DayOfWeek != DayOfWeek.Saturday)
                    continue;  //不處理


                string cond = " chYear = '{0}' and ReSetDate = '{1}' ";
                StockCalendar m = new StockCalendar();
                    m.chYear = iYear.ToString();

                    m.ReSetDate = temp.ToString("yyyyMMdd");
                    int count = dal.CalcCount(string.Format(cond, m.chYear, m.ReSetDate));
                if (count > 0) continue;   //不處理

                //新增

                dal.Add(m);





            }


            anp.RecordCount = dal.CalcCount(GetCond());
            BindRep();

            Tool.Alert( "新增完成", this);

        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            anp.RecordCount = dal.CalcCount(GetCond());
            BindRep();
        }
    }
}