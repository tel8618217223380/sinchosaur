<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Frontend.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    Ваши файлы
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function addContextMenu(fileId,isDirectory){
            $('#file_' + fileId).contextMenu('ContextMenu', {
                bindings: {
                    'move': function (t) {
                        tb_show('Переместить', '<%=Url.RouteUrl("Move")%>?fileId=' + fileId + '&isDirectory=' + isDirectory, "");
                    },

                    'copyto': function (t) {
                        tb_show('Копировать', '<%=Url.RouteUrl("Copy")%>?fileId=' + fileId + '&isDirectory=' + isDirectory, "");
                    },

                    'rename': function (t) {
                        tb_show('Переименовать', '<%=Url.RouteUrl("Rename")%>?fileId=' + fileId + '&isDirectory=' + isDirectory, "");
                    },

                    'delete': function (t) {
                        confirm_message = isDirectory == 1 ? 'эту директорию ?' : 'этот файл ?';
                        if (confirm('Вы уверены что хотите удалить ' + confirm_message))
                            location.href = '/file/delete?fileId=' + fileId + '&isDirectory=' + isDirectory;
                    }
                }
            });
        }
    </script>
    <div id="tab">
        <div id="tabhead">
            <ul>
                <li><%=Html.RouteLink("Добавить диреторию", "CreateDirectory", new { directoryId = ViewData["currenId"] }, new { @class = "thickbox" })%> </li>
                <li><%=Html.RouteLink("Загрузить файл", "Upload", null, new { @class = "thickbox" })%> </li>
            </ul>
        </div>
        <div id="tabcontent">
        <%=ViewData["currentPath"]%>
            <table cellspacing="0" cellpadding="0">
                <tbody>
                    <tr>
                        <th scope="col" >Название</th>
                        <th scope="col" style="width:80px">Размер</th>
                        <th scope="col" style="width:135px">Синхронизирован</th>
                    </tr>
                    <% 
                    if ( (int)ViewData["parentId"] > 1)
                    {%>
                        <tr align="left">
                            <td colspan="3"><%=Html.RouteLink("...", "ShowFolder", new { id = ViewData["parentId"] })%></td>
                        </tr>
                    <%}%>
                    <% foreach (MyFile file in (MyFile[])ViewData["files"]){ %>
                        <% if (file.IsDirectory){%>
                        <tr align="left">
                            <td colspan="3">
                                <div id="file_<%=file.FileId%>">
                                    <%=Html.RouteLink(MyHelpers.ShowFileName(file.Name, 70), "ShowFolder", new { id = file.FileId }, new { title = file.Name })%>
                                </div>
                                <script type="text/javascript">addContextMenu(<%=file.FileId%>,1) </script>
                            </td>
                        </tr>
                        <%}else{%>
                            <tr>
                                <td>
                                    <div id="file_<%=file.FileId%>">
                                        <%=Html.RouteLink(MyHelpers.ShowFileName(file.Name, 35), "DownloadFile", new { name = file.Name, id = file.FileId }, new { title = file.Name })%>
                                    </div>
                                     <script type="text/javascript">addContextMenu(<%=file.FileId%>,0) </script>
                                </td>
                                <td><%=MyHelpers.ShowSize(file.Size)%></td>
                                <td><%=file.LastWriteTime%></td>
                            </tr>
                        <%} %>
                    <%} %>
                </tbody>
            </table>
        </div>
    </div>
    <div class="contextMenu" id="ContextMenu">
      <ul>
        <li id="move"><img src="/content/images/move.png" alt=""/> Переместить</li>
        <li id="copyto"><img src="/content/images/copy.png" alt=""/> Скопировать</li>
        <li id="rename"><img src="/content/images/rename.png" alt=""/> Переименовать</li>
        <li id="delete"><img src="/content/images/delete.png" alt=""/> Удалить</li>
      </ul>
    </div>
    
</asp:Content>
