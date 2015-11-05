<%@ Page Language="C#" MasterPageFile="~/pages/shared/main.Master" AutoEventWireup="true" CodeBehind="downloads.aspx.cs" Inherits="WebNosology.UI.WebApp.pages.main.downloads" Title="Безымянная страница" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <span class="mdl-layout-title">Загрузки</span>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <br />
                
    <div download class="nos-graphs mdl-shadow--2dp mdl-color--white mdl-cell mdl-cell--8-col">
        <a href="../../files/dist/Высокозатратные нозологии.msi">
            <i class="fa fa-file-o content-icon"></i>
            Установочный файл "Высокозатратные нозологии"
        </a>
    </div>
    
    <br />
    
    <div download class="nos-graphs mdl-shadow--2dp mdl-color--white mdl-cell mdl-cell--8-col">
        <a href="../../files/dist/dotnetfx.exe">
            <i class="fa fa-file-o content-icon"></i>
            Библиотека .NET Framework
        </a>
    </div>
    
    <br />
    
    <div download class="nos-graphs mdl-shadow--2dp mdl-color--white mdl-cell mdl-cell--8-col">
        <a href="../../files/dist/Высокозатратные нозологии(Руководство)Вер.2_1.doc">
            <i class="fa fa-file-text-o content-icon"></i>
            Руководство пользователя
        </a>
    </div>
    
</asp:Content>
