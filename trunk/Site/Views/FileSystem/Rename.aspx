<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Blank.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function ajaxOnComplete(result) {
            var object = result.get_response().get_object();
            if (!object.success) {
                alert(object.error);
            }
            else {
                location.href = '<%=Url.RouteUrl("ShowFolder")%>/' + object.id;
            }
        }
    </script>
    <div id="left">
        <div class="post_small">
            <div class="posttop">
            </div>
            <div class="postitem">
                <h2>Переименование</h2>

                <% using (Ajax.BeginForm(new AjaxOptions { OnComplete = "ajaxOnComplete" }))
                   { %>
                <div class="form">
                    <%=Html.Hidden("fileId", ViewData["fileId"])%>
                    <%=Html.Hidden("isDirectory", ViewData["isDirectory"])%>
                    
                    <label for="email">Новое название</label>
                    <%=Html.TextBox("name",ViewData["name"])%>
                    <div class="clear2">
                    </div>
                    <input class="button" name="Submit" type="submit" value="Создать" />
                </div>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
