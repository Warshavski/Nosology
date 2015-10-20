<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downloads.aspx.cs" Inherits="WebNosology.UI.WebApp.pages.downloads" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="Высокозатратные нозологии - Загрузки">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <title>Высокозатратные нозологии - Загрузки</title>

    <!-- Add to homescreen for Chrome on Android -->
    <meta name="mobile-web-app-capable" content="yes">
    <%--<link rel="icon" sizes="192x192" href="images/android-desktop.png">--%>

    <!-- Add to homescreen for Safari on iOS -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="apple-mobile-web-app-title" content="Высокозатратные нозологии - Загрузки">
    <%--<link rel="apple-touch-icon-precomposed" href="images/ios-desktop.png">--%>

    <!-- Tile icon for Win8 (144x144 + tile color) -->
    <%--<meta name="msapplication-TileImage" content="images/touch/ms-touch-icon-144x144-precomposed.png">--%>
    <meta name="msapplication-TileColor" content="#3372DF">

    <%--<link rel="shortcut icon" href="images/favicon.png">--%>
    
    <link rel="stylesheet" href="../plugins/mdl/material.css"/>
    <link rel="stylesheet" href="../styles/main.css"/>  
    <link rel="stylesheet" href="../plugins/font-awesome/css/font-awesome.min.css" />
    <link rel="Stylesheet" href="../plugins/jDialog/jDialog.css" />
  
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:regular,bold,italic,thin,light,bolditalic,black,medium&amp;lang=en" />
    <%--<link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />--%>
  
</head>

<body>

    <div class="nos-layout mdl-layout mdl-js-layout mdl-layout--fixed-drawer mdl-layout--fixed-header">
        
        <!-- #HEADER (TITLE, MENU) -->
        <header class="nos-header mdl-layout__header mdl-color--grey-100 mdl-color-text--grey-600">
            
            <!-- #TITLE -->
            <div class="mdl-layout__header-row">
                
                <span class="mdl-layout-title">Загрузки</span>
                <div class="mdl-layout-spacer"></div>
              
                <button class="mdl-button mdl-js-button mdl-js-ripple-effect mdl-button--icon" id="hdrbtn">
                    <i class="fa fa-ellipsis-v"></i>
                </button>
              
                <!-- #TITLE #CONTEXT_MENU -->
                <ul class="mdl-menu mdl-js-menu mdl-js-ripple-effect mdl-menu--bottom-right" for="hdrbtn">
                    <li class="mdl-menu__item" onclick="showNoticeDialog()">
                        Справка
                    </li>
                    <li class="mdl-menu__item" onclick="showContactDialog()">
                        Контакты
                    </li>
                </ul>
                
            </div>
            
            <!-- #SUBTITLE -->
            <div class="mdl-layout__header-row" style="height: 35px;">
                <i class="fa fa-star"></i>
                <asp:Label ID="userLevel" runat="server" Text="[user level placeholder]"></asp:Label>
            </div>
            
        </header>
        
        <!-- #SIDE_PANEL (USER INFO, NAVIGATION MENU) -->
        <div class="nos-drawer mdl-layout__drawer mdl-color-text--white">  
            
            <header class="nos-drawer-header">
                
                <i class="fa fa-user-md" style="font-size: 54px"></i>
                
                <div class="nos-avatar-dropdown">
                    
                    <asp:Label ID="userName" runat="server" Text="[user name placeholder]"></asp:Label>
                    <div class="mdl-layout-spacer"></div>
                    
                </div>
                
            </header>
            
            <!-- #NAVIGATION_MENU -->
            <nav class="nos-navigation mdl-navigation">
                <form id="mainForm" runat="server">
                    
                    <a class="mdl-navigation__link" href="main.aspx">
                        <i class="fa fa-home nav-icon" role="presentation"></i>
                        Главная
                    </a>
                    
                    <a class="mdl-navigation__link" href="documents.aspx">
                        <i class="fa fa-file-text nav-icon" role="presentation"></i>
                        Документы
                    </a>
                    
                    <a class="mdl-navigation__link" href="downloads.aspx">
                        <i class="fa fa-download nav-icon" role="presentation"></i>
                        Загрузки
                    </a>
                    
                    <!-- closes user session and redirects to the login page -->
                    <a runat="server" id="signOutLink" class="mdl-navigation__link">
                        <i class="fa fa-sign-out nav-icon" role="presentation"></i>
                        Выход
                    </a>
                     
                    <div class="mdl-layout-spacer"></div>
                    
                </form>
            </nav>
            
        </div>
      
        <!-- #MAIN_CONTENT (LIST OF FILES) -->
        <main class="mdl-layout__content mdl-color--grey-100">
            <div class="mdl-grid nos-content">
                
                <br />
                
                <div download class="nos-graphs mdl-shadow--2dp mdl-color--white mdl-cell mdl-cell--8-col">
                    <a href="../files/dist/Высокозатратные нозологии.msi">
                        <i class="fa fa-file-o content-icon"></i>
                        Установочный файл "Высокозатратные нозологии"
                    </a>
                </div>
                
                <br />
                
                <div download class="nos-graphs mdl-shadow--2dp mdl-color--white mdl-cell mdl-cell--8-col">
                    <a href="../files/dist/dotnetfx.exe">
                        <i class="fa fa-file-o content-icon"></i>
                        Библиотека .NET Framework
                    </a>
                </div>
                
                <br />
                
                <div download class="nos-graphs mdl-shadow--2dp mdl-color--white mdl-cell mdl-cell--8-col">
                    <a href="../files/dist/Высокозатратные нозологии(Руководство)Вер.2_1.doc">
                        <i class="fa fa-file-text-o content-icon"></i>
                        Руководство пользователя
                    </a>
                </div>
                
            </div>
        </main>
        
    </div>
    
    <script type="text/javascript" src="../scripts/jQuery/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="../plugins/mdl/material.js"></script>   
    <script type="text/javascript" src="../plugins/jDialog/jDialog.js"></script>
    
    <!-- shows up contact info dialog window (side menu in #HEADER) -->
    <script type="text/javascript">
        function showContactDialog() {
            jDialog.alert('Контактные данные : #FILL_WITH_INFORMATION');
        }
    </script>
    
    <!-- shows up page info dialog window (side menu in #HEADER) -->
     <script type="text/javascript">
         function showNoticeDialog() {
             jDialog.alert('Справка о странице : #FILL_WITH_INFORMATION');
         }
    </script>

</body>
</html>
