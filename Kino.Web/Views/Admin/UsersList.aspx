﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PagedViewModel<UserSmallModel>>" %>
<%@ Import Namespace="MvcContrib.UI.Grid"%>
<%@ Import Namespace="MvcContrib.UI.Pager"%>
<%@ Import Namespace="MvcContrib.Pagination"%>
<%@ Import Namespace="System.Text.RegularExpressions"%>
<%@ Import Namespace="Kino.Web.Models"%>  

<asp:Content ID="UserListTitle" ContentPlaceHolderID="TitleContent" runat="server">
    UsersList
</asp:Content>

<asp:Content ID="UserListContent" ContentPlaceHolderID="MainContent" runat="server">

<h2>UsersList</h2>

    <div class="grid">
    <%: Html.Grid(Model.PagedList).AutoGenerateColumns().Attributes(@class => "grid-table").Sort(Model.GridSortOptions).Columns(column => {
        column.For(item => "<input type='button' value='Show' onclick=\"location.href='" + Url.Action("ShowUser", "Admin", new { pesel = item.PESEL }) + "'\" />").Attributes(@style => "width: 80px").HeaderAttributes(@style => "width:80px").Encode(false).Sortable(false);
        column.For(item => "<input type='button' value='Remove' onclick=\"location.href='" + Url.Action("RemoveUser", "Admin", new { pesel = item.PESEL }) + "'\" />").Attributes(@style => "width: 80px").HeaderAttributes(@style => "width:80px").Encode(false).Sortable(false);
    })%>

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