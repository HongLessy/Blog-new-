<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerHead" ContentPlaceHolderID="head" runat="server">
    <title>Register</title>
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="ContentPlaceHolderPrimary" runat="server">
   <div class="post">
    <h3>填写以下表单创建新的注册用户。</h3>
    </div>

    <div class="content">
    <p>
       密码至少必须的字符长度为：<%=Html.Encode(ViewData["PasswordLength"])%>  
    </p>
    </div>
    
    <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm()) { %>


<fieldset>
    <table style="width: 100%;">
        <tr valign="top">
            <td width="100">
                <strong>用户名</strong></td>
                
            <td>
                <%= Html.TextBox("userName") %>
                    <%= Html.ValidationMessage("userName") %>
              
            </td>
        </tr>
        <tr valign="top">
            <td width="100">
                <strong>Email</strong></td>
            <td>
                <%= Html.TextBox("email") %>
                    <%= Html.ValidationMessage("email") %>

            </td>

        </tr>
        <tr valign="top">
            <td width="100">
                <strong>密码</strong></td>
            <td>
                <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>

            </td>

        </tr>
        <tr valign="top">
            <td width="100">
                <strong>确认密码</strong></td>
            <td>
  <%= Html.Password("confirmPassword") %>
                    <%= Html.ValidationMessage("confirmPassword") %>
            </td>

        </tr>
        <tr valign="top">
            <td>
                &nbsp;
            </td>
            <td>
            <input type="submit" value="注册" class="button"  />

            </td>
           <td>&nbsp;</td>
        </tr>
    <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
    </table>
    </fieldset>     
    <% } %>
</asp:Content>
