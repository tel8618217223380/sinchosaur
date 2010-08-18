<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Frontend.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Main Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="post">
        <div class="postitem">
            <h2>Welcome at Sinchosaur!</h2>
            <p>
                Sinchosaur its system for synchronize directories at different 
                computers through a proxy server with the ability to access files 
                through the site and preservation of all changes in the files.
            </p>
        </div>
    </div>
</asp:Content>
