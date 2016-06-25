<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Blog.Model.TagEntity>>" %>
<%@ Import Namespace ="Blog.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

<div class="post">
    <h3>全部分类</h3>
    </div>
    <% foreach(TagEntity tag in Model){ %>
        <a href="#"><%= tag.TagName%></a> 
    <%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
