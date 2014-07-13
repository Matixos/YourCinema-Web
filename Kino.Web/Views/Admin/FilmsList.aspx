<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PagedViewModel<FilmModel>>" %>
<%@ Import Namespace="MvcContrib.UI.Grid"%>
<%@ Import Namespace="MvcContrib.UI.Pager"%>
<%@ Import Namespace="MvcContrib.Pagination"%>
<%@ Import Namespace="System.Text.RegularExpressions"%>
<%@ Import Namespace="Kino.Web.Models"%>  

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    FilmsList
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>FilmsList</h2>

     <div class="grid">
    <%: Html.Grid(Model.PagedList).AutoGenerateColumns().Attributes(@class => "grid-table").Sort(Model.GridSortOptions) %>

        <div class="grid-pager">
        <%  
        Match pageMatch = Regex.Match(Request.Url.ToString(), "Page=([0-9]+)", RegexOptions.IgnoreCase);
        Model.CurrentPageNumber = pageMatch.Success ? System.Convert.ToInt32(pageMatch.Groups[1].Value) : 1;

        Match columnMatch = Regex.Match(Request.Url.ToString(), "Column=([A-Za-z0-9]+)", RegexOptions.IgnoreCase);
        string columnName = columnMatch.Success ? columnMatch.Groups[1].Value : null;

        Match directionMatch = Regex.Match(Request.Url.ToString(), "Direction=([A-Za-z0-9]+)", RegexOptions.IgnoreCase);
        string directionName = directionMatch.Success ? directionMatch.Groups[1].Value : null;

        string link = (columnName != null && directionName != null) ? "?Column=" + columnName + "&Direction=" + directionName + "&Page=" : "?Page=";

        Model.PreviousPageNumber = Model.CurrentPageNumber - 1;
        Model.NextPageNumber = Model.CurrentPageNumber + 1;

        if (Model.CurrentPageNumber == Model.FirstPageNumber)
        {%>
            <span class="pager-current-page"><%: Model.CurrentPageNumber %></span>
        <%}
        else
        {
            string lnk = link + 1;%>
            <a href="<%: lnk %>"><%: Model.FirstPageNumber %></a>
        <%}

        if (Model.PreviousPageNumber - Model.FirstPageNumber > 1)
        {%>
             <text>...</text>
        <%}

        if (Model.PreviousPageNumber > Model.FirstPageNumber && Model.PreviousPageNumber < Model.LastPageNumber)
        {
            string lnk = link + Model.PreviousPageNumber; %>
            <a href="<%: lnk %>"><%: Model.PreviousPageNumber %></a>
        <%}

        if (Model.CurrentPageNumber > Model.FirstPageNumber && Model.CurrentPageNumber < Model.LastPageNumber)
        {%>
            <span class="pager-current-page"><%: Model.CurrentPageNumber %></span>
        <%}
        if (Model.NextPageNumber > Model.FirstPageNumber && Model.NextPageNumber < Model.LastPageNumber)
        {
            string lnk = link + Model.NextPageNumber; %>
            <a href="<%: lnk %>"><%: Model.NextPageNumber %></a>
        <%}

        if (Model.LastPageNumber - Model.NextPageNumber > 1)
        {%>
            <text>...</text>
        <%}

        if (Model.LastPageNumber > Model.FirstPageNumber)
        {
            if (Model.CurrentPageNumber == Model.LastPageNumber)
            {%>
                <span class="pager-current-page"><%: Model.CurrentPageNumber %></span>
            <%}
            else
            {
                string lnk = link + Model.LastPageNumber; %>
                <a href="<%: lnk %>"><%: Model.LastPageNumber %></a>
            <%}
        }%>
        </div>
    </div>

</asp:Content>
