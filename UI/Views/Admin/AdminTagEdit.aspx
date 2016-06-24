<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Model.TagEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

<h3>修改分类</h3>
  
   <%= Html.ValidationSummary("修改分类失败！请修改错误后重试。") %>

    <% using (Html.BeginForm("AdminTagEdit")) { %>
        <div>
            <fieldset>
                   <%  =Html.Hidden ("id", Model.Tag_id .ToString ()) %>
                <p>
                    <label for="tagname">分类名称：</label>
                    <%= Html.TextBox("tagname",Model.TagName, new  { size=50 })%>
                    <%= Html.ValidationMessage("tagname") %>
                </p>
                <p>
                    <input type="submit" value="修改" class="button" />
                </p>
            </fieldset>
        </div>
    <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
