<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Blog.Model.TagEntity>>" %>
<%@ Import Namespace="GridViewHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

<h3>管理分类</h3>
    <p>
        <%= Html.ActionLink("新建", "AdminTagCreate")%>
    </p>

    <% =Html.TableDataGridView<Blog.Model.TagEntity>(Model, new string[] { "Tag_id", "TagName" },
        new TableDataOption()
         {

            EditAction = "AdminTagEdit",
            DeleteAction = "AdminTagDelete",
            
         Columns=new string []{ "编号","分类"  }     })%>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
