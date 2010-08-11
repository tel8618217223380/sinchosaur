<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Frontend.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    Загузить файлы
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/content/js/uploadify/swfobject.js" type="text/javascript"></script>
    <link href="/content/js/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="/content/js/uploadify/jquery.uploadify.v2.1.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
    var auth = "<% = Request.Cookies[FormsAuthentication.FormsCookieName]==null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value %>";
    var ASPSESSID = "<%= Session.SessionID %>";

    $(document).ready(function () {
        $("#uploadify").uploadify({
            'async': true,
            'uploader': '/content/js/uploadify/uploadify.swf',
            'script': '<%=Url.RouteUrl("Upload")%>',
            'scriptData': { 'outDirectoryId': 1, ASPSESSID: ASPSESSID, AUTHID: auth },
            'cancelImg': '/content/js/uploadify/cancel.png',
            'queueID': 'fileQueue',
            'displayData': 'speed',
            'auto': true,
            'multi': true,
            'sizeLimit': 100000000,
            'onSelectOnce': function () {
                $("#uploadify").uploadifySettings('scriptData', { outDirectoryId: $("#outdirectoryid").val() });
            },
            onComplete: function (event, queueID, fileObj, response, data) {
                eval("var object=" + response);
                if (!object.success) {
                    alert(object.error);
                }
                else {
                   // location.href = '<%=Url.RouteUrl("ShowFolder")%>/' + object.id;
                }

            }
        });
    });

    function close2() {
            location.href = '<%=Url.RouteUrl("ShowFolder")%>/' + $("#outdirectoryid").val();
        }
    </script>
    <div id="left">
        <div class="post">
            <div class="posttop"></div>
            <div class="postitem">
                <h2>Загрузить файлы</h2>
                <% Html.RenderPartial("SelectFolder");%>
                <div class="form">
                    <%=Html.Hidden("outDirectoryId",null, new { id = "outdirectoryid" })%>
                    <div id="fileQueue"></div>
                    <input type="file" id="uploadify"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
