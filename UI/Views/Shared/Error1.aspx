﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="head" runat="server">
    Error
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="ContentPlaceHolderPrimary" runat="server">
    <h2>
        Sorry, an error occurred while processing your request.
    </h2>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderSecondary" runat="server">
   
</asp:Content>
