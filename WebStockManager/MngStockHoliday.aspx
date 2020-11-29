<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard01.Master" AutoEventWireup="true" CodeBehind="MngStockHoliday.aspx.cs" Inherits="WebStockManager.MngStockHoliday" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>休市設定</h3>
    &nbsp;<asp:DropDownList ID="ddlYears" runat="server"  CssClass=" input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged" >
    </asp:DropDownList>
    &nbsp;
    <asp:Button ID="btnGenHoiday" runat="server" Text="產生年度假日" CssClass=" input-sm" OnClick="btnGenHoiday_Click" />
&nbsp;
    <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass=" input-sm" OnClick="btnQuery_Click" />
    &nbsp;
    <asp:Button ID="btnAdd" runat="server" Text="新增"  CssClass=" input-sm" OnClick="btnAdd_Click"  />

       <asp:Panel ID="panelQ" runat="server">

           <br />

           <asp:GridView ID="GridView1" runat="server" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
              <Columns>

                  <asp:BoundField DataField="chYear"  HeaderText="年分" />
                   <asp:BoundField DataField="ReSetDate"  HeaderText="休市日期" />

                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Button ID="btnEdit" runat="server" Text="編輯" CommandName="cmdbtnEdit" />
                          <asp:Button ID="btnDel"  runat="server" Text="刪除"  CommandName="cmdbtnDel"  OnClientClick="if(confirm('刪除!!')==false) {return false;}" />


                      </ItemTemplate>


                  </asp:TemplateField>
              </Columns>

            </asp:GridView>

           <div class='pagin'> 
        <webdiyer:AspNetPager ID="anp" runat="server" AlwaysShow="true"
            CssClass="anpager" CurrentPageButtonClass="cpb"
            CustomInfoHTML="共%RecordCount%条，第%CurrentPageIndex%页/共%PageCount%页"
            FirstPageText='首页'
            LastPageText='尾页'
            NextPageText="下一页"
            OnPageChanged="anpList_PageChanged"
            PageIndexBoxType="DropDownList"
            PageSize="20"
            PagingButtonSpacing=""
            PrevPageText="上一页"
            ShowCustomInfoSection="Left" ShowMoreButtons="False" ShowPageIndex="true"
            ShowPageIndexBox="Always"
            SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到 ">
    </webdiyer:AspNetPager>
</div>
       </asp:Panel>
    <asp:Panel ID="panelEdit" runat="server">
        
        <label>
        <br />
        日期:</label> 
        <asp:TextBox ID="txtReSetDate" runat="server" onclick="GetDate()"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存" />
        &nbsp;
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="返回" />
        <br />
        <br />

    </asp:Panel>
     
    <asp:HiddenField ID="hidenId" runat="server" />

</asp:Content>
