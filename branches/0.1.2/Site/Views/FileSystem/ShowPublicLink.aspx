<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Blank.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script language="javascript">
    $(document).ready(function () {
        setTimeout(function () { $("#uasdasdasdrl").focus().select(); }, 100);
    });
</script>
 <div id="left">
        <div class="post_small">
            <div class="posttop">
            </div>
            <div class="postitem">
                <h2><%=LocaleRes.Localize.PublicLink%></h2>
                <div class="form">
                    <input type="text" size="55" id="uasdasdasdrl"  value="http://<%=Request.ServerVariables["HTTP_HOST"]%><%=Url.RouteUrl("DownloadPublicFile", new { name =ViewData["name"] , fileId = ViewData["fileId"], userId = ViewData["userId"] })%>" />
                    <div class="clear2">
                    </div>
                    <input class="button" name="Submit" type="submit" value="go" />
                </div>
            </div>
            
        </div>
    </div>

</asp:Content>
