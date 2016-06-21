<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginHead" ContentPlaceHolderID="head" runat="server">
    <title>Log On</title>
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="ContentPlaceHolderPrimary" runat="server">
    
    <div class="post">
    <h3>请登录到用户管理面板</h3>
    </div>
    
    <div class="content">
    <p>
       请输入用户名、密码登录。<br />
       如果没有户名、密码，请单击链接<%= Html.ActionLink("免费注册", "Register") %>： 
    </p>
    </div>
    <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm()) { %>
                   
   <fieldset>
    <table style="width: 100%;">
        <tr valign="top">
            <td width="100">
                <strong>&#29992;&#25143;&#21517;</strong></td>
                
            <td>
                <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username") %>
              
            </td>
        </tr>
        <tr valign="top">
            <td width="100">
                <strong>&#23494;&#30721;</strong></td>
            <td>
                <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>

            </td>

        </tr>
        <tr valign="top">
            <td>
                &nbsp;
            </td>
            <td><%= Html.CheckBox("rememberMe") %> 记住我？
         <br /> 
            <input type="submit" value="&#30331;&#24405;" class="button"  />

            </td>
           <td>&nbsp;</td>
        </tr>
    <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
    </table>
    </fieldset>
    <% } %>
  


</asp:Content>
