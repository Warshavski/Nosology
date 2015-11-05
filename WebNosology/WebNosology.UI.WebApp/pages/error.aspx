<%@ Page Language="C#" MasterPageFile="~/pages/shared/default.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="WebNosology.UI.WebApp.pages.error" Title="Безымянная страница" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>Высокозатратные нозологии - Ошибка</title>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <form id="loginForm" runat="server" class="mdl-shadow--2dp">
        
        <i style="font-size: 60px;" class="fa fa-exclamation-triangle user-logon-icon"></i>
        
        <br />
        
        <div align="center">
            <span>Что-то пошло не так</span>                    
        </div>
       
        <button runat="server" id="backButton"
            class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect
                   mdl-color--my mdl-color-text--white logon-button">
            Вернуться назад
        </button>
        
    </form>
</asp:Content>
