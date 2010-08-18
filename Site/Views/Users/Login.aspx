<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Frontend.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Авторизация
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="left">
        <div class="post">
            <div class="posttop"></div>
            <div class="postitem">
                <h2><%=LocaleRes.Localize.Autorization%></h2>
                <% if (ViewData.ContainsKey("LoginFailed")){ %>
                      <h3><%=LocaleRes.Localize.UserNotExist%></h3>
                 <%}%>

                 <% using (Html.BeginForm()) { %>
                    <div class="form">

                        <label for="email">Email</label>
                        <%=Html.TextBox("email")%>
                        
                        <div class="clear2"></div>

                        <label for="website"><%=LocaleRes.Localize.Passwd%></label>
                        <%=Html.Password("password")%>

                        <div class="clear2"></div>

                        <input class="button" name="Submit" type="submit" value="<%=LocaleRes.Localize.Autorizate%>"/>
                    </div>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
