<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

<h3>添加分类</h3>
  
   <%= Html.ValidationSummary("添加分类失败！请修改错误后重试。") %>

    <% using (Html.BeginForm("AdminTagCreate")) { %>
        <div>
            <fieldset>
                <p>
                    <label for="tagname">分类名称：</label>
                    <%= Html.TextBox("tagname",null, new  { size=50 })%>
                    <%= Html.ValidationMessage("tagname") %>
                </p>
                <p>
                    <input type="submit" value="添加" class="button" />
                </p>
            </fieldset>
        </div>
    <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
