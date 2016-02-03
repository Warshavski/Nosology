<%@ Page Title="" Language="C#" MasterPageFile="~/pages/shared/_Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Escyug.Nosology.MVP.UI.WebApp.Default" EnableViewState="false" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="mdl-grid">

        <!-- #SPACER -->
        <div class="mdl-cell mdl-cell--1-col mdl-cell--hide-phone mdl-cell--hide-tablet"></div>

        <!-- #MAIN CELL -->
        <div class="mdl-cell mdl-cell--10-col mdl-cell--middle">
            <div class="login-block mdl-shadow--2dp">

                <i class="fa fa-user-md mdl-color-text--nos-main login-block__icon"></i>

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                    <input class="mdl-textfield__input" type="text" id="loginInput" />
                    <label class="mdl-textfield__label" for="loginInput">Логин...</label>
                </div>

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                    <input class="mdl-textfield__input" type="text" id="pwdInput" />
                    <label class="mdl-textfield__label" for="pwdInput">Пароль...</label>
                </div>

                <label class="mdl-checkbox mdl-js-checkbox mdl-js-ripple-effect" for="persistCheckBox" >
                    <input type="checkbox" id="persistCheckBox" class="mdl-checkbox__input" />
                    <span class="mdl-checkbox__label">Запомнить?</span>
                </label>

                <button class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect 
                    mdl-button--colored mdl-color--nos-main login-block__button">
                    ВХОД
                </button>

            </div>
        </div>

        <!-- #SPACER -->
        <div class="mdl-cell mdl-cell--1-col mdl-cell--hide-phone mdl-cell--hide-tablet"></div>

    </div>
</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>




<%-- Old version
    <!-- #LOGIN_FORM -->
    <form id="loginForm" runat="server" class="mdl-shadow--2dp default-form">
        
        <asp:HiddenField ID="HiddenChecked" runat="server"  Value="false"/>
        
        <i style="font-size: 60px;" class="fa fa-user-md user-logon-icon mdl-color-text--nos-main"></i>
        
        <br />
        
        <!-- #INPUT_CONTAINER -->
        <div>
            
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input runat="server" class="mdl-textfield__input" type="text" id="loginField"
                    onfocus="$('#errorLabel').text('');" />
                <label class="mdl-textfield__label" for="loginField">Имя...</label>
            </div>
           
            <br />
           
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <input runat="server" class="mdl-textfield__input" type="password" id="pwdField" 
                    onfocus="$('#errorLabel').text('');"/>
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
        
        <button runat="server" id="checkButton" onclick="checkInput();"
            class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect
                   mdl-color--nos-help mdl-color-text--white logon-button">Вход
        </button>
        
        <br />
        
    </form><!-- / #LOGIN_FORM -->--%>