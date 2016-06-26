<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Model.PersonsettingEntity>" %>
<%@ Import Namespace="Blog.Model" %>
<%@ Import Namespace="Blog.BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

       <h3>设置基本信息</h3>
  
   <%= Html.ValidationSummary("修改基本信息失败！请修改错误后重试。") %>

    <% using (Html.BeginForm("AdminSetupEdit")) { %>
        <div>
            <fieldset>
                  <p>
                    <label for="blog_title">博客标题：</label>
                    <%= Html.TextBox("blog_title", Model.Blog_title, new { size = 50 })%>
                    <%= Html.ValidationMessage("blog_title")%>
                </p>
                
                <p>
                    <label for="description">描述（HTML）：</label>
                    <%= Html.TextArea("description",Model.Description, new { rows = 5, cols =43 })%>
                    <%= Html.ValidationMessage("description")%>
                </p>
                
                
                 <p>
                    <label for="blog_path">网站路径：</label>
                    <%= Html.TextBox("blog_path",Model.Blog_path, new { size = 50 })%>
                    <%= Html.ValidationMessage("blog_path")%>
                </p>
                 <p>
                    <label for="rss_size">RSS页面大小：</label>
                    <%= Html.TextBox("rss_size", Model.Rss_size, new { size = 47 })%>
                    <%= Html.ValidationMessage("rss_size")%>
                </p>
                 <p>
                    <label for="max_uploadfile">文件最大上载字节数：</label>
                    <%= Html.TextBox("max_uploadfile", Model.Max_uploadfile, new { size = 37 })%>
                    <%= Html.ValidationMessage("max_uploadfile")%>
                </p>
                <p>
                    <%
                        AuthorEntity entity = (AuthorEntity)Session["userinfo"];
                        var models=ModelManager.GetAllModel();
                        ModelEntity me = models.Select(p => p).Where(p => p.Name == entity.Username).First();
                        
                     %>
                    <label for="changSkin">修改皮肤：</label>
                    <input  type="hidden" name="model_id" value="<%= me.Model_id%>"/>
                    <select name="changSkin">
                    <% if (me.Path == "Page")
                       {%>
                        <option value="Admin" selected="selected">右列表风格</option>
                        <option value="LeftRightAdmin">左列表风格</option>
                    <%}else{ %>
                        <option value="Admin">右列表风格</option>
                        <option value="LeftRightAdmin" selected="selected">左列表风格</option>
                    <%} %>
                    </select>
                </p>
                
                <p>
                    <input type="submit" value="修改" class="button"  />
                </p>
            </fieldset>
        </div>
    <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
