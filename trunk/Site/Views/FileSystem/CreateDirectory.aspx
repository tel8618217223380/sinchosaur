<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Blank.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function closeTB() {
            alert('Каталог добавлен');
            location.href = '<%=Url.RouteUrl("ShowFolder",new{id=ViewData["directoryId"]})%>';
        }
    </script>
    <div id="left">
        <div class="post_small">
            <div class="posttop">
            </div>
            <div class="postitem">
                <h2>Новая диретория</h2>

                <% using (Ajax.BeginForm(new AjaxOptions {OnSuccess = "closeTB"} ))
                   { %>
                <div class="form">
                    <%=Html.Hidden("directoryId", ViewData["directoryId"])%>
                    <label for="email">Название</label>
                    <%=Html.TextBox("name")%>
                    <div class="clear2">
                    </div>
                    <input class="button" name="Submit" type="submit" value="Создать" />
                </div>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
