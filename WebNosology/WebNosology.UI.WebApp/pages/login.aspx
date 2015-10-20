<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebNosology.UI.WebApp.pages.login" EnableViewState="false"  ErrorPage="~/pages/error.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="Высокозатратные нозологии">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <title>Высокозатратные нозологии</title>

    <!-- Add to homescreen for Chrome on Android -->
    <meta name="mobile-web-app-capable" content="yes">
    <%--<link rel="icon" sizes="192x192" href="images/android-desktop.png">--%>

    <!-- Add to homescreen for Safari on iOS -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="apple-mobile-web-app-title" content="Форма входа">
    <%--<link rel="apple-touch-icon-precomposed" href="images/ios-desktop.png">--%>

    <!-- Tile icon for Win8 (144x144 + tile color) -->
    <%--<meta name="msapplication-TileImage" content="images/touch/ms-touch-icon-144x144-precomposed.png">--%>
    <meta name="msapplication-TileColor" content="#3372DF">

    <%--<link rel="shortcut icon" href="images/favicon.png">--%>
    
    <link rel="stylesheet" href="../plugins/mdl/material.css"/>
    <link rel="stylesheet" href="../styles/login.css"/>  
    <link rel="stylesheet" href="../plugins/font-awesome/css/font-awesome.min.css" />
    
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:regular,bold,italic,thin,light,bolditalic,black,medium&amp;lang=en" />
    
</head>

<body>
    
    <div class="logon-layout mdl-layout mdl-layout--fixed-header mdl-js-layout mdl-color--grey-100">
        
        <header class="mdl-layout__header mdl-layout__header--scroll mdl-color--my mdl-color-text--white">
            <span class="mdl-layout-title mdl-layout__header-row">Высокозатратные нозологии</span>
        </header>
      
        <main class="mdl-layout__content">
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
        </main>
          
        <footer class="mdl-mini-footer">
            
            <div class="mdl-mini-footer--left-section" >
                <ul class="mdl-mini-footer--link-list">
                    <li><a href="http://www.escyug.ru/">ООО "Эскейп-Юг"</a></li>
                    <li><a href="http://www.minzdravkk.ru/">Министерство здравоохранения Краснодарского края</a></li>
                </ul>
            </div>
        </footer>
          
    </div>
    
    <script type="text/javascript" src="../scripts/jQuery/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="../plugins/mdl/material.min.js"></script>   
    
</body>

</html>