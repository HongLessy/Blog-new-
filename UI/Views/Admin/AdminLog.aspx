<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Blog.Model.LogEntity>>" %>
<%@ Import Namespace="GridViewHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

<h3>日志</h3>


   <% =Html.TableDataGridView<Blog.Model.LogEntity>(Model, new string[] { "Id", "Date" },
                new TableDataOption()
                {

                    EditButtonText = "浏览",
                    EditAction = "AdminLogShow",
                    DeleteAction = "AdminLogDelete",

                    Columns = new string[] { "编号", "日期" }
                })%>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
