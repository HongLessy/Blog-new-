<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Model.CommentEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

<h3>修改评论</h3>
  
   <%= Html.ValidationSummary("修改评论失败！请修改错误后重试。") %>

    <% using (Html.BeginForm("AdminCommentEdit")) { %>
        <div>
            <fieldset>
                   <%  =Html.Hidden("Comment_id", Model.Comment_id.ToString())%>
                <p>
                    <label for="author">您的名字：</label>
                    <%= Html.TextBox("author", Model.Author, new  { size=33})%>
                    <%= Html.ValidationMessage("author")%>
                </p>
                <p>
                    <label for="body">评论：</label>
                    <%= Html.TextArea("body",Model.Body,new {rows=5,cols=36  })  %>
                    <%= Html.ValidationMessage("body") %>
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
