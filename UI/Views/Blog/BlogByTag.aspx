<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Blog.Model.BlogentrieEntity>>" %>
<%@ Import Namespace="Blog.BLL" %>
<%@ Import Namespace="Blog.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

<div class="post">
    <h3>包括分类：<% =ViewData["TagName"] %> 的文章如下：</h3>
 </div>
<% foreach( var post in Model    ){ %>

 <div class="post">
      <div class="header">
        <h3><% =Html.ActionLink( post.Title, "BlogEntry", new{ page = post.Blog_id  } ) %></h3>
        <div class="date"><% =post.Datecreated %></div>
      </div>

  <div class="content">
        <%
            int authorid = (int)Session["visitor"];  
            AuthorEntity author= AuthorManager.SelectAuthorByID(authorid);
            var tags= Blog_TagManager.SelectBlog_TagByBlogID(post.Blog_id);
            
        %>
        <% =post.Body  %>
        <p><strong><%= author.Username%></strong></p>
        </div>
        <div class="footer">
        <ul>
        <li class="tags">&#20998;&#31867;: 
           <% foreach( var tag in tags){ %>
           <%TagEntity tagEntity = TagManager.SelectTagByID(tag.Tag_id); %>
           <% =Html.ActionLink(tagEntity.TagName, "BlogEntry", new { id = post.Blog_id })%>
           <% } %>        
        
        </li>

        <%var commentEntities = CommentManager.GetAllCommentByblog_id(post.Blog_id); %>
		<li class="comments">
            <% =commentEntities.Count > 0 ? "<a href=\"BlogEntry.aspx?page=" + post.Blog_id + "#comments\">&#35780;&#35770; (" + commentEntities.Count + ")</a>" : "- disabled -"%></li>
        </ul>
        </div>
        </div>


<% } %>
<% =Html.ActionLink("<< 前一页", "BlogByTag", new { id = (int)ViewData["TagId"], page = (int)ViewData["Page"] - 1 })%>
|
<% =Html.ActionLink("后一页>>", "BlogByTag", new { id = (int)ViewData["TagId"], page = (int)ViewData["Page"] + 1 })%>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
