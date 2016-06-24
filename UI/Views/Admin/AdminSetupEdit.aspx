<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Model.PersonsettingEntity>" %>

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
                    <input type="submit" value="修改" class="button"  />
                </p>
            </fieldset>
        </div>
    <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
