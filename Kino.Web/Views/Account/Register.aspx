<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Kino.Web.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-left: 25px; color: white; font-size: 2em;"><%: Resources.View.Register_CreateNewAccount %></h2>
    <p style="margin-left: 25px;">
        <%: Resources.View.Register_FormHelpTip %> 
    </p>
    <p style="margin-left: 25px;">
        <%: Resources.View.Register_MinPasswordChar_Part1 + " " + Membership.MinRequiredPasswordLength + " " + Resources.View.Register_MinPasswordChar_Part2 %>
    </p>

    <% using (Html.BeginForm()) { %>
        <div style="margin-left: 25px;"><%: Html.ValidationSummary(true, Resources.View.Register_RegistrationError) %></div>
        <div class="center">
            <fieldset>
                <legend><%: Resources.View.Register_AccountInfo %></legend>

                <table style="border: solid 0px;">
                    <tr>
                        <td><%: Html.LabelFor(m => m.Name) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Name, new { @tabindex = 1 })%> *<br />
                            <%: Html.ValidationMessageFor(m => m.Name)%></td>
                        <td class="rightLabel"><%: Html.LabelFor(m => m.Password) %></td>
                        <td class="textbox"><%: Html.PasswordFor(m => m.Password, new { @tabindex = 7 }) %> *<br />
                            <%: Html.ValidationMessageFor(m => m.Password) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Surname) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Surname, new { @tabindex = 2 }) %> *<br />
                            <%: Html.ValidationMessageFor(m => m.Surname) %></td>
                        <td class="rightLabel"><%: Html.LabelFor(m => m.ConfirmPassword) %></td>
                        <td class="textbox"><%: Html.PasswordFor(m => m.ConfirmPassword, new { @tabindex = 8 }) %> *</td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.PESEL) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.PESEL, new { @tabindex = 3, @maxlength = "11" }) %> *<br />
                            <%: Html.ValidationMessageFor(m => m.PESEL) %></td>
                        <td></td>
                        <td style="padding-left: 20px;"><p style="width: 200px;"><%: Html.ValidationMessageFor(m => m.ConfirmPassword)%></p></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Address) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Address, new { @tabindex = 4 }) %> *<br />
                            <%: Html.ValidationMessageFor(m => m.Address) %></td>
                        <td class="rightLabel"><%: Html.LabelFor(m => m.Email) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Email, new { @tabindex = 9 }) %> *<br />
                            <%: Html.ValidationMessageFor(m => m.Email) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.Postcode) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Postcode, new { @tabindex = 5, @maxlength = "6" }) %> *<br />
                            <%: Html.ValidationMessageFor(m => m.Postcode) %></td>
                        <td class="rightLabel"><%: Html.LabelFor(m => m.Phone) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.Phone, new { @tabindex = 10, @maxlength = "12" }) %><br />
                            <%: Html.ValidationMessageFor(m => m.Phone) %></td>
                    </tr>
                    <tr>
                        <td><%: Html.LabelFor(m => m.City) %></td>
                        <td class="textbox"><%: Html.TextBoxFor(m => m.City, new { @tabindex = 6 }) %> *<br />
                            <%: Html.ValidationMessageFor(m => m.City) %></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3"></td>
                        <td style="text-align: right;"><%: Resources.View.Register_RequiredFields %></td>
                    </tr>
                </table>
                
                <hr />

                <table style="border: solid 0px;">
                    <tr>
                        <td><img src="<%: Url.Content("~/Content/themes/images/bn1.png") %>" /></td>
                        <td style="padding-left: 50px;"><input type="reset" value="<%: Resources.View.Register_ClearButton %>" /></td>
                        <td style="padding-left: 15px;"><input type="submit" value="<%: Resources.View.Register_RegButton %>" /></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
