<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Blog.Model" %>
<%@ Import Namespace="Blog.BLL" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

    <h3> 新建随笔、文章</h3>

    <%= Html.ValidationSummary("新建随笔、文章失败！请修改错误后重试。") %>

    <% using (Html.BeginForm("AdminBlogCreate","Admin",FormMethod.Post  )) {%>
    <div>
        <fieldset>
                     
            <p>
                <label for="username">作者：</label>
                <%= Html.DropDownList ("username")%>
                <%= Html.ValidationMessage("username", "*")%>
            </p>
            <p>
                <label for="title">标题：</label>
                <%= Html.TextBox("title",null,  new { size=75})%>
                <%= Html.ValidationMessage("title", "*") %>
            </p>
            <p>
                <label for="description">描述：</label>
                <%= Html.TextArea("description","",5,85,null)%>
                <%= Html.ValidationMessage("description", "*")%>
            </p>
            <p>
                <label for="title">分类：</label>
               
                <% foreach (var tag in (List<TagEntity>)ViewData["tag"] )  { %>
                  
                     <input  type="checkbox" name="TagCheckBox" value="<%= tag.Tag_id%>"/><%= tag.TagName%>          
                      
                  <br/><span style="style1"><label for="title">分类：</label></span>
                   <% } %>
           </p>
            <p>
                <label for="title">类型：</label>
                
                <%= Html.RadioButton("type", "文章", true, new  { id="type1" })%>
                  <label for="type1" >文章</label>               
                  <%= Html.RadioButton("type", "随笔", false, new { id = "type2" })%>
                     <label for="type2" >随笔</label>  

            </p>
            <p>         
                <label for="title">允许评论：</label>
                
                  <%  =Html.CheckBox("CommentCheckBox") %>                                   
               </p>
            <p>
                <label for="title">私有：</label>
                  <%  =Html.CheckBox("PrivateCheckBox") %>                                   
            </p>
             <p>           
                 <label for="title">内容：</label>
                   
                   <% =Html.TextArea ("body",null,20,85,null) %>
               
            </p>
            <p>
                <input type="submit" value="新建" class="button"  />
            </p>        
        </fieldset>
    </div>
    <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

