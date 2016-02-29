<%@ Page Title="" Language="C#" MasterPageFile="~/pages/shared/_Default.Master" AutoEventWireup="true" CodeBehind="common.aspx.cs" Inherits="Escyug.Nosology.MVP.UI.WebApp.Degrade.pages.error" EnableViewState="false" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="mdl-grid">

        <!-- #SPACER -->
        <div class="mdl-cell mdl-cell--1-col mdl-cell--hide-phone mdl-cell--hide-tablet"></div>

        <!-- #MAIN CELL -->
        <div class="mdl-cell mdl-cell--10-col mdl-cell--middle">
            <div class="login-block mdl-shadow--2dp" align="center">

                <i class="material-icons mdl-color-text--nos-main login-block__icon">warning</i>
                
                <br />
                
                <span class="mdl-layout__title">Что-то пошло не так</span>

                <br />
                 
            </div>
        </div>

        <!-- #SPACER -->
        <div class="mdl-cell mdl-cell--1-col mdl-cell--hide-phone mdl-cell--hide-tablet"></div>

    </div>
</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">

</asp:Content>
