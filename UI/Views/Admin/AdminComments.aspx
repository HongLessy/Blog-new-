<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Blog.Model.CommentEntity>>" %>
<%@ Import Namespace="GridViewHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

<% =Html.TableDataGridView<Blog.Model.CommentEntity>(Model, new string[] { "Author", "Body", "Datecreated", "Ip" },
                new TableDataOption()
                {

                    EditAction = "AdminCommentEdit",
                    DeleteAction = "AdminCommentDelete",
            
            Columns=new string []{ "作者","评论","发布日期","IP地址"}   })%>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
