<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Blog.Model.BlogentrieEntity>>" %>
<%@ Import Namespace="GridViewHelper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPage" runat="server">

    <h3>������ʡ�����</h3>
    <p>
        <%= Html.ActionLink("�½�", "AdminBlogCreate") %>
    </p>
  
 
    <% =Html.TableDataGridView<Blog.Model.BlogentrieEntity>(Model, new string[] { "Title", "Datepublished" },
                new TableDataOption()
                {

            EditAction = "AdminBlogEdit",
            DeleteAction = "AdminBlogDelete",
            
            Columns=new string []{ "����","��������"      }     })%>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
