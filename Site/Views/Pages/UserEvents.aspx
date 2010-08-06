<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Frontend.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    События
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="tab">
        <div id="tabcontent">
            <h2>События </h2>
            <table cellspacing="0" cellpadding="0">
                <tbody>
                    <tr>
                        <th scope="col" style="width:70px">Действие</th>
                        <th scope="col">Файл</th>
                        <th scope="col" style="width:80px">Размер</th>
                        <th scope="col" style="width:135px">Синхронизирован</th>
                    </tr>
                    <% foreach (EventInfo userEvent in (EventInfo[])ViewData["userEvents"])
                       { %>
                    <tr>
                        <td><%=userEvent.Description%></td>
                        <td><%=Html.RouteLink(MyHelpers.ShowFileName(userEvent.FileName, 25), "DownloadFile", new { id = userEvent.FileId, name = userEvent.FileName }, new { title =userEvent.Path + "\\" + userEvent.FileName })%></td>
                        <td><%=MyHelpers.ShowSize(userEvent.FileSize)%></td>
                        <td><%=userEvent.Created%></td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
