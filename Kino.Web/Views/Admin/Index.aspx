<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Panel Administracyjny
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2><%: Resources.View.Admin_Panel %></h2>
    <nav>
        <ul>
            <li><%: Html.ActionLink(Resources.View.Admin_UsersList, "UsersList", "Admin", null, new { @class = "type-1-small" }) %></li>
            <li><%: Html.ActionLink(Resources.View.Admin_RoomsList, "RoomsList", "Admin", null, new { @class = "type-1-small" }) %></li>
            <li><%: Html.ActionLink(Resources.View.Admin_FilmsList, "FilmsList", "Admin", null, new { @class = "type-1-small" }) %></li>
        </ul>
    </nav>

</asp:Content>
