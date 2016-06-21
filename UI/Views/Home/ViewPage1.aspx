<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="GridViewHelper" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

    <h2>≤‚ ‘Admin.master<br />ViewPage1</h2>
    <% 
        string[] arr={"asd","234","ad","∞°…Ω∂´","qwe"};
        var result = arr.AsQueryable().ToPagedList(1,5);  
        TableDataOption options = new TableDataOption(); 
        
    %>
    <%= Html.TableDataGridView<string>(result, new string[] { "lie1", "lie2" }, options)%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
