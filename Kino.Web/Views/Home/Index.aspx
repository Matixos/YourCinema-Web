<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: Resources.View.Master_MainSite %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Resources.View.Main_Hello %></h1>
    <p style="text-align: center;">
        <%: Resources.View.Main_Invitation %>
        <img src="<%: Url.Content("~/Content/themes/images/kino.jpg") %>" />
    </p>
</asp:Content>