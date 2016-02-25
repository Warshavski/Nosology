<%@ Page Title="" Language="C#" MasterPageFile="~/pages/shared/_Default.Master" AutoEventWireup="true" CodeBehind="loginTemplate.aspx.cs" Inherits="Escyug.Nosology.MVP.UI.WebApp.pages.templates.loginTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
     <form id="loginForm" runat="server">

        <asp:HiddenField ID="HiddenChecked" runat="server" />
        
        <asp:HiddenField ID="HiddenLogin" runat="server" />
        <asp:HiddenField ID="HiddenPwd" runat="server" />

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    </form>

    <div class="mdl-grid">

        <!-- #SPACER -->
        <div class="mdl-cell mdl-cell--1-col mdl-cell--hide-phone mdl-cell--hide-tablet"></div>

        <!-- #MAIN CELL -->
        <div class="mdl-cell mdl-cell--10-col mdl-cell--middle">
            <div class="login-block mdl-shadow--2dp">

                <i class="fa fa-user-md mdl-color-text--nos-main login-block__icon"></i>

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                    <input class="mdl-textfield__input" type="text" id="loginInput" onfocus="clearError();" />
                    <label class="mdl-textfield__label" for="loginInput">Логин...</label>
                </div>

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                    <input class="mdl-textfield__input" type="password" id="pwdInput" onfocus="clearError();" />
                    <label class="mdl-textfield__label" for="pwdInput">Пароль...</label>
                </div>

                <label class="mdl-checkbox mdl-js-checkbox mdl-js-ripple-effect" for="persistCheckBox">
                    <input type="checkbox" id="persistCheckBox" class="mdl-checkbox__input" />
                    <span class="mdl-checkbox__label">Запомнить?</span>
                </label>

                <asp:Label ID="errorLabel" CssClass="login-block__label--error" runat="server" Text=""></asp:Label>

                <button id="checkButton" onclick="testLogin()"
                    class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect 
                        mdl-button--colored mdl-color-text--white mdl-color--nos-main login-block__button">
                    ВХОД
                </button>

            </div>
        </div>

        <!-- #SPACER -->
        <div class="mdl-cell mdl-cell--1-col mdl-cell--hide-phone mdl-cell--hide-tablet"></div>

    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
    <script type="text/javascript">

        // server elements (bad practice?)
        var serverLogin     = $selectElement('#<%= HiddenLogin.ClientID %>');
        var serverPwd       = $selectElement('#<%= HiddenPwd.ClientID %>');
        var serverPersist   = $selectElement('#<%= HiddenChecked.ClientID %>');

        // client elements
        var errorLabel      = $selectElement('.login-block__label--error');
        var loginField      = $selectElement('#loginInput');
        var pwdField        = $selectElement('#pwdInput');
        var persistCheck    = $selectElement('#persistCheckBox');

        // selector function
        function $selectElement(selector) {
            return document.querySelector(selector);
        }

        // error label cleanup
        function clearError() {
            if (errorLabel.innerText != '') {
                errorLabel.innerText = '';
            }
        }

        // works fine
        function checkPersist() {
            if (persistCheck['checked']) {    
                return true;
            }
            return false;
        }

        // works fine
        function checkInput() {
            if (loginField.value.trim() == '' || pwdField.value.trim() == '') {
                return false;
            }
            return true;
        }

        // main login function, checks inputs and call server side event (can't call server side event)
        function testLogin() {

            var isValidInput = checkInput();

            if (isValidInput) {
                // set value for server side events
                serverLogin.value = loginField.value;
                serverPwd.value = pwdField.value;
                
                var isPersist = checkPersist();
                serverPersist.value = isPersist;
                
                // call server side event
                <%= Page.ClientScript.GetPostBackEventReference(HiddenPwd, String.Empty) %>; 
            }
            else {
                errorLabel.innerText = 'Ошибка! Поля не должны быть пустыми';
            }
            
            <%--
            $('#<%= HiddenLogin.ClientID %>').val(isValidInput);
            <%= Page.ClientScript.GetPostBackEventReference(HiddenLogin, String.Empty) %>; 
            --%>
        }
    </script>
</asp:Content>
