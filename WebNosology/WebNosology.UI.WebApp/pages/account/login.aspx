<%@ Page Language="C#" MasterPageFile="~/pages/shared/default.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebNosology.UI.WebApp.pages.account.login" Title="Безымянная страница" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <form id="loginForm" runat="server" class="mdl-shadow--2dp">
        
        <i style="font-size: 60px;" class="fa fa-user-md user-logon-icon"></i>
        
        <br />
        
        <div align="center">
            
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input runat="server" class="mdl-textfield__input" type="text" id="loginField"
                    onfocus="$('#errorLabel').text('')" />
                <label class="mdl-textfield__label" for="loginField">Имя...</label>
            </div>
           
            <br />
           
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input runat="server" class="mdl-textfield__input" type="password" id="pwdField" 
                    onfocus="$('#errorLabel').text('')"/>
                <label class="mdl-textfield__label" for="pwdField">Пароль...</label>
            </div>
            
            <br />
            
            <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
            
        </div>
        
        <br />
        
        <label class="mdl-checkbox mdl-js-checkbox mdl-js-ripple-effect" for="checkBoxPersist">
            <input runat="server" type="checkbox" id="checkBoxPersist" class="mdl-checkbox__input"/>
            <span class="mdl-checkbox__label">Запомнить?</span>
        </label>
        
        <br />
        
        <button runat="server" id="checkButton"
            class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect
                   mdl-color--my2 mdl-color-text--white logon-button">
            Вход
        </button>
        
        <br />
        
    </form>
</asp:Content>
