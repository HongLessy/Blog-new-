<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrimary" runat="server">

    <ul>
        <li>
            <a href="../Account/LogOn">��¼</a>
        </li>
        <li>
            <a href="../Account/Register">ע��</a>
        </li>
        <li>
            <a href="../Blog/Index?page=1&authorID=3">���Բ���</a>
        </li>
    </ul>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSecondary" runat="server">
</asp:Content>
