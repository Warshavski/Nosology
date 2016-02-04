<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modalTemplate.aspx.cs" Inherits="Escyug.Nosology.MVP.UI.WebApp.pages.templates.modalTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>


    <!-- general styles -->
    <link rel="stylesheet" href="../../Content/mdl-v1.0.5/material.min.css" />
    <link rel="stylesheet" href="../../Content/jDialog/jDialog.css" />
    <link rel="stylesheet" href="../../Content/Site.css" />
    <link rel="stylesheet" href="../../Content/modal/modal.css" />

    <!-- fonts -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:300,400,500,700" type="text/css" />

    

</head>
<body>
    <div class="demo-btns">
        <header>
            <h1>Material Design Modals</h1>
        </header>

        <div class="info">
            <div class="buttons">
                <p>
                    <a href="" data-modal="#modal" class="modal__trigger">Modal 1</a>
                </p>
            </div>
            <p>Click a button to activate a modal.<br>
                <a href="http://ettrics.com/code/material-design-modal/" target="_blank" class="link">Read the how-to on Ettrics.com</a></p>
        </div>
    </div>

    <!-- Modal -->
    <div id="modal" class="modal modal__bg" role="dialog" aria-hidden="true">
        <div class="modal__dialog">
            <div class="modal__content">
                <h1>Modal</h1>
                <p>Church-key American Apparel trust fund, cardigan mlkshk small batch Godard mustache pickled bespoke meh seitan. Wes Anderson farm-to-table vegan, kitsch Carles 8-bit gastropub paleo YOLO jean shorts health goth lo-fi. Normcore chambray locavore Banksy, YOLO meditation master cleanse readymade Bushwick.</p>

                <!-- modal close button -->
                <a href="" class="modal__close demo-close">
                    <svg class="" viewBox="0 0 24 24">
                        <path d="M19 6.41l-1.41-1.41-5.59 5.59-5.59-5.59-1.41 1.41 5.59 5.59-5.59 5.59 1.41 1.41 5.59-5.59 5.59 5.59 1.41-1.41-5.59-5.59z" />
                        <path d="M0 0h24v24h-24z" fill="none" />
                    </svg>
                </a>

            </div>
        </div>
    </div>

    <!-- jQuery library -->
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>

    <!-- mdl scripts -->
    <script type="text/javascript" src="../../Content/mdl-v1.0.5/material.min.js"></script>

    <script type="text/javascript" src="../../Content/modal/modal.js"></script>

</body>
</html>
