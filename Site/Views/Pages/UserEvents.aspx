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
                        <th scope="col">Действие</th>
                        <th scope="col">Файл</th>
                        <th scope="col">Каталог</th>
                        <th scope="col">Размер</th>
                        <th scope="col">Изменен</th>
                    </tr>
                    <% foreach (EventInfo userEvent in (EventInfo[])ViewData["userEvents"])
                       { %>
                    <tr>
                        <td>
                            <%=userEvent.Description%>
                        </td>
                        <td>
                            <%=Html.RouteLink(userEvent.FileName, "DownloadFile", new { id = userEvent.FileId, name = userEvent.FileName })%>
                        </td>
                         <td>
                            <%=userEvent.Path%>
                        </td>
                        <td>
                            <%=userEvent.FileSize / 1024%>
                            КБайт
                        </td>
                        <td>
                            <%=userEvent.Created%>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
