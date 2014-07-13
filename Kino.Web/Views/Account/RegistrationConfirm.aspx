<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    RegistrationConfirm
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center;">
        <h2 style="font-size: 2em;"><%: Resources.View.Register_ConfirmationLabel %></h2>
        <img src="<%: Url.Content("~/Content/themes/images/bn2.png") %>" />

        <p style="font-size: 18px;"><%: Resources.View.Register_ConfirmationPart1 %></p>
        <p style="font-size: 18px;"><%: Resources.View.Register_ConfirmationPart2 %></p>
        <%: Html.ActionLink(Resources.View.Master_MainSite, "Index", "Home", null, new { @class = "type-1-small" }) %>
    </div>
</asp:Content>
