<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kino.Web.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Logowanie
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Resources.View.LogOn_MainLabel %></h1>
    <div style="margin-left: 200px;">
    <p>
        <%: Resources.View.LogOn_TooltipPart1 %> 
        <%: Html.ActionLink(Resources.View.LogOn_RegisterLabel, "Register", null, new { @class = "type-1-small", @style = "margin-left: 15px;" }) %> 
        <%: Resources.View.LogOn_TooltipPart2 %>
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, Resources.View.LogOn_Error) %>
        <div>
            <fieldset style="width: 450px;">
                <legend><%: Resources.View.LogOn_AccountInfo %></legend>
                
                <table style="border: solid 0px;">
                    <tr>
                        <td><%: Html.LabelFor(m => m.PESEL) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.PESEL, new { @tabindex = 1, @maxlength = "11" }) %><br />
                             <%: Html.ValidationMessageFor(m => m.PESEL) %></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Password) %></td>
                        <td class="textbox"><%: Html.PasswordFor(m => m.Password, new { @tabindex = 2 }) %><br />
                            <%: Html.ValidationMessageFor(m => m.Password) %></td>
                        <td><%: Html.ActionLink(Resources.View.LogOn_ForgottenPassLabel, "ChangePassword", null, new { @class = "type-1-small", @style = "margin-left: 20px;" }) %></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="textbox"><%: Html.CheckBoxFor(m => m.RememberMe) %>
                            <%: Html.LabelFor(m => m.RememberMe) %></td>
                        <td></td>
                    </tr>
                </table>
                
                <p>
                    <input type="submit" style="margin-left: 130px;" value="<%: Resources.View.Log_In %>" />
                </p>
            </fieldset>
        </div>
    <% } %>
    </div>
</asp:Content>