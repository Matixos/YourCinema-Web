<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        <%: Html.ActionLink(Resources.View.Log_Out, "LogOff", "Account", null, new { @class = "type-1-small" }) %>
        <%: Resources.View.Logged_User %>: <strong><%: HttpContext.Current.Session["userName"] %></strong>
        <%
        if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Administrator"))
        {
            %>
                <%: Html.ActionLink(Resources.View.Log_AdminPanel, "Index", "Admin", null, new { @class = "type-1-small", @style = "margin-left: 30px;" }) %>
            <%
        }
        else if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "User"))
        {
            %>
                <%: Html.ActionLink("User Panel", "ShowReserwations", "Account", null, new { @class = "type-1-small", @style = "margin-left: 30px;" }) %>
            <%
        }
    }
    else {
%> 
        <%: Html.ActionLink(Resources.View.Log_In, "LogOn", "Account", null, new { @class = "type-1-small" }) %>
<%
    }
%>