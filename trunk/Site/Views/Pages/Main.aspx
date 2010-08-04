<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layouts/Frontend.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Главная страница
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="post">
        <div class="postitem">
            <h2>Добро пожаловать!</h2>
            <p>
                Sinchosaur - это средство для автоматической синхронизации папок на 
                разных компьютерах, нужно лишь, зарегистрироваться, установить клиент.
            </p>
        </div>
    </div>
</asp:Content>
