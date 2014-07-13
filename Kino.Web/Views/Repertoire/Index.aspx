<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<FilmShowPresentModel>>" %>
<%@ Import Namespace="Kino.Web.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: Resources.View.Repertoire_MainLabel %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="<%: Url.Content("~/Scripts/repertoire.js") %>" type="text/javascript"></script>

    <h1><%: Resources.View.Repertoire_MainLabel %></h1>

    <%: Resources.View.Repertoire_ChooseDate %>
    <%: Html.TextBox(Resources.View.Repertoire_Date, DateTime.Today.ToString("yyyy-MM-dd"), new { @class = "date-picker", @id = "Date" }) %>
    <input type="button" value="Ok" id="acceptDate" />

    <% if(ViewBag.Show) {%>
    <table style="margin-top: 30px;">
    <% foreach(FilmShowPresentModel show in Model)
        {%>
            <tr style="height: 40px; font-size: 14px;">
                <td style="width: 100px;"><%: show.FilmName %></td>
                <%
            foreach (DateTime dt in show.timesShow)
            {
                if(HttpContext.Current.User.Identity.Name.Equals("") || HttpContext.Current.User.Identity.Name.Equals("99999999999")) {%>
                <td style="width: 100px;"><%: dt.Hour + ":" + dt.Minute %>0</td>
            <% }
               else {%>
                <td style="width: 100px;"><a style="text-decoration: none; color: lightgreen;" href="<%: Url.Action("GetTicket", "Repertoire", new { film = show.FilmName, date = dt, userId = HttpContext.Current.Session["userid"] }) %>"><%: dt.Hour + ":" + dt.Minute %>0</a></td>
                <%}
                }
                     %>
            </tr>
        <%}
          }%>
    </table>

    <img src="<%: Url.Content("~/Content/themes/images/kino1.JPG") %>" style="margin-top: 40px; margin-left: 50px;" />
</asp:Content>
