<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Model.BlogentrieEntity>" %>
<%@ Import Namespace="Blog.Model" %>
<%@ Import Namespace="Blog.BLL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

      <h3>修改随笔、文章</h3>

    <%= Html.ValidationSummary("修改随笔、文章失败！请修改错误后重试。") %>

    <% using (Html.BeginForm("AdminBlogEdit","Admin",FormMethod.Post  )) {%>
    <div>
        <fieldset>
                     
            <p>
                <input type="hidden" name="id" id="id" value ="<% =Model.Blog_id.ToString()  %>"  />
            </p>
            <p>
                <label for="username">作者：</label>
                <%= Html.DropDownList ("username")%>
                <%= Html.ValidationMessage("username", "*")%>
            </p>
            <p>
                <label for="title">标题：</label>
                <%= Html.TextBox("title", Model.Title, new { size=75})%>
                <%= Html.ValidationMessage("title", "*") %>
            </p>
            <p>
                <label for="description">描述：</label>
                <%= Html.TextArea("description",Model.Description,5,85,null)%>
                <%= Html.ValidationMessage("description", "*")%>
            </p>
            <p>
                <label for="title">分类：</label>
               <% 
                    Blog_TagEntity blogtagentity = Blog_TagManager.SelectBlog_TagByBlogID(Model.Blog_id);
           
                %>
                <% foreach (var tag in (List<TagEntity>)ViewData["tag"] ) { %>
                  
                  <% if (blogtagentity.Tag_id==tag.Tag_id)
                     {      %>  
                   <%  =Html.CheckBox("TagCheckBox",true, new {  id=tag.TagName }) %>                  
                  <label for="<% =tag.TagName %>" ><% =tag.TagName %></label>
                  <br/><span class="style1"><label for="title">分类：</label></span>
                   <% } 
                      else                     
                     {   
                         %>
                                
                     <%  =Html.CheckBox("TagCheckBox", false, new { id = tag.TagName })%>
                     <label for="<% =tag.TagName %>" ><% =tag.TagName%></label>                  
                     <br/><span class="style1"><label for="title">分类：</label></span>
                   <% } 
                   } %>
            </p>
            <p>
                <label for="title">类型：</label>
                <% if (Model.Type.ToString ()=="article")
                   { %>
                
                <%= Html.RadioButton("type", "文章", true, new { id = "type1" })%>
                  <label for="type1" >文章</label>               
                  <%= Html.RadioButton("type", "随笔", false, new { id = "type2" })%>
                     <label for="type2" >随笔</label>  
          
                <%  } 
                  else                  
                  {                  
                  %>
                
                <%= Html.RadioButton("type", "文章", false, new { id = "type3" })%>
                  <label for="type3" >文章</label>               

                    <%= Html.RadioButton("type", "随笔", true, new { id = "type1" })%>
                     <label for="type4" >随笔</label>               
               
                  
                  <%  } %>

            </p>
            <p>         
                <label for="title">允许评论：</label>
                
                  <%  =Html.CheckBox("CommentCheckBox",Model.Allowcomment ) %>                                   
               </p>
            <p>
                <label for="title">私有：</label>
                  <%  =Html.CheckBox("PrivateCheckBox",Model.Markprivate ) %>                                   
            </p>
                        
                 <label for="title">内容：</label>
             <p>       
                   <% =Html.TextArea ("body",Model.Body ,20,90,null) %>
               
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
