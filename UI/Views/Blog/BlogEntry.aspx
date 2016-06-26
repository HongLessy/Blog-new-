<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Model.BlogentrieEntity>" %>
<%@ Import Namespace="Blog.Model" %>
<%@ Import Namespace ="Blog.BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

<div class="post">
      <div class="header">
        <h3><% =Html.ActionLink(Model.Title, "BlogEntry", new{ page = Model.Blog_id  } ) %></h3>
        <div class="date"><% =Model.Datecreated%></div>
      </div>

  <div class="content">
        
         <%
            int authorid = (int)Session["visitor"];  
            AuthorEntity author= AuthorManager.SelectAuthorByID(authorid);
            var tags= Blog_TagManager.SelectBlog_TagByBlogID(Model.Blog_id);
            
        %>
        <% =Model.Body  %>
        <p><strong><%= author.Username%></strong></p>
        </div>
        <div class="footer">
        <ul>
        <li class="tags">&#20998;&#31867;: 
           <% foreach( var tag in tags){ %>
           <%TagEntity tagEntity = TagManager.SelectTagByID(tag.Tag_id); %>
           <% =Html.ActionLink(tagEntity.TagName, "BlogEntry", new { id = Model.Blog_id })%>
           <% } %>        
        
        </li>

        <%var commentEntities = CommentManager.GetAllCommentByblog_id(Model.Blog_id); %>
		<li class="comments">
            <% =commentEntities.Count > 0 ? "<a href=\"BlogEntry.aspx?page=" + Model.Blog_id + "#comments\">&#35780;&#35770; (" + commentEntities.Count + ")</a>" : "- disabled -"%></li>
        </ul>
        </div>
        </div>
     
     <% var comments = Blog.BLL.CommentManager.GetAllCommentByblog_id(Model.Blog_id);%>
<% if( comments.Count > 0 ){ %>
<% foreach( var comment in comments ){ %>
    
    <a name="comments"><h4>&#35780;&#35770;</h4></a>
     
        <div class="post">
        <div class="content">
        <p>

 <%=comment.Body   %>
        </p>
        </div>
        <div class="footer">
        <ul>
        <li class="comment">Comment by <strong><%=comment.Author %></strong></li>
        </ul>
        <div class="date"><%=string.Format( "{0: yyyy年MM月dd日 HH:mm}",comment.Datecreated)%></div>
        </div>
        </div>


<% } %>

<% }else{ %>

  <div class="post">
        <div class="header">
        <a name="comments"><h3>还没有评论!</h3></a>
        </div>
        </div>

<% } %>


<% using( Html.BeginForm("AddComment","Blog") ){ %>

	<% =Html.ValidationSummary() %>

	
	

<fieldset>
    <legend>发表新评论</legend>
    <table style="width: 100%;">
        <tr valign="top">
            <td width="100">
                <strong>您的名字 *</strong></td>
                <input  type="hidden" name="id" value="<%= Model.Blog_id%>"/>
            <td>
                 <% =Html.ValidationMessage( "commentAuthor", "*" ) %>
	             <% =Html.TextBox( "commentAuthor" ) %>
              
            </td>
        </tr>
        <tr valign="top">
            <td width="100">
                <strong>评论 *</strong></td>
            <td>
                 <% =Html.ValidationMessage( "commentText", "*" ) %>
	             <% =Html.TextArea( "commentText","",10,60,1 ) %>

            </td>

        </tr>
        <tr valign="top">
            <td>
                &nbsp;
            </td>
            <td>HTML is <strong>not</strong> allowed.<br /> 
            <input type="submit" value="发表新评论" />

            </td>
           <td>&nbsp;</td>
        </tr>
    <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
    </table>
    </fieldset>

       <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
