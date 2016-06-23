<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Blog.Model" %>
<%
    AuthorEntity entity=(AuthorEntity)Session["userinfo"];
    if(entity!=null){
%>
        欢迎你 <b><%= Html.Encode(entity.Username) %></b>!角色:<%= Html.Encode(entity.Password) %>
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account") %> ]
<%}%>