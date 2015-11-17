<%@ Page Language="C#" MasterPageFile="~/pages/shared/default.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebNosology.UI.WebApp.pages.account.login" Title="Безымянная страница" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <meta name="description" content="Высокозатратные нозологии - Аутентификация">
    <meta name="apple-mobile-web-app-title" content="Высокозатратные нозологии - Вход">
    <title>Высокозатратные нозологии - Вход</title>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    
    <!-- #LOGIN_FORM -->
    <form id="loginForm" runat="server" class="mdl-shadow--2dp default-form">
        
        <asp:HiddenField ID="HiddenChecked" runat="server"  Value="false"/>
        
        <i style="font-size: 60px;" class="fa fa-user-md user-logon-icon mdl-color-text--nos-main"></i>
        
        <br />
        
        <!-- #INPUT_CONTAINER -->
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
            
        </div><!-- / #INPUT_CONTAINER -->
        
        <br />
        
        <label class="mdl-checkbox mdl-js-checkbox mdl-js-ripple-effect" for="checkBoxPersist" onclick="checkPersist();">
            <input type="checkbox" id="checkBoxPersist" class="mdl-checkbox__input" />
            <span class="mdl-checkbox__label">Запомнить?</span>
        </label>
        
        <br />
        
        <button runat="server" id="checkButton"
            class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect
                   mdl-color--nos-help mdl-color-text--white logon-button">Вход
        </button>
        
        <br />
        
    </form><!-- / #LOGIN_FORM -->
    
  
</asp:Content>
