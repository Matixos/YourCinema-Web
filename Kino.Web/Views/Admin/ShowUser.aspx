<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kino.Business.Entity.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ShowUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>ShowUser</h2>

    <div class="center">
            <fieldset style="width: 450px;">
                <legend><%: Resources.View.Register_AccountInfo %></legend>

                <table style="border: solid 0px;">
                    <tr>
                        <td><%: Html.LabelFor(m => m.Name) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Name, new { @disabled = "disabled" })%></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Surname) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Surname, new { @disabled = "disabled" }) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.PESEL) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.PESEL, new { @disabled = "disabled" }) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Address) %></td>
                        <td class="textbox"><%: Html.TextAreaFor(m => m.Address, new { @disabled = "disabled", @style = "width: 200px; resize: none;" }) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Email) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Email, new { @disabled = "disabled" }) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Phone) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Phone, new { @disabled = "disabled" }) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Culture) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Culture, new { @disabled = "disabled" }) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Points) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Points, new { @disabled = "disabled" }) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.ReservationCnt) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.ReservationCnt, new { @disabled = "disabled" }) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.CreateDate) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.CreateDate, new { @disabled = "disabled" }) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.LastActivity) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.LastActivity, new { @disabled = "disabled" }) %></td>
                    </tr>
                </table>
            </fieldset>
    </div>
    <%: Html.ActionLink("Back", "UsersList", "Admin", null, new { @class = "type-1-small", @style = "margin-left: 30px;" }) %>

</asp:Content>