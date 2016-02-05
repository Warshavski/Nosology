<%@ Page Title="" Language="C#" MasterPageFile="~/pages/shared/_Main.Master" AutoEventWireup="true" CodeBehind="documents.aspx.cs" Inherits="Escyug.Nosology.MVP.UI.WebApp.pages.documents" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        /*ul {
            border: solid 1px red;
        }

        li {
            border: solid 1px lime;
        }*/
    </style>
</asp:Content>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <span class="mdl-layout-title">Документы</span>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="mdl-grid nos-content nos-docs">

        <ul class="mdl-cell mdl-cell--6-col demo-list-three mdl-list">
            <asp:ListView ID="docsList" runat="server" EnableViewState="true">

                <ItemTemplate>

                    <li class="mdl-list__item mdl-list__item--three-line">
                        
                        
                        <span class="mdl-list__item-primary-content">
                            
                            <i class="material-icons mdl-list__item-avatar mdl-color--nos-main"></i>

                            <a href="'<%# Eval("Link") %>'">
                                <span><%# Eval("Title") %></span>
                            </a>

                            <span class="mdl-list__item-text-body"><%# Eval("Description") %></span>
                            <%--<a class="mdl-list__item-secondary-action" href="'<%# Eval("Link") %>'"></a>--%>
                        </span>
                        

                        <span class="mdl-list__item-secondary-content">
                            <i class="material-icons" id="<%# Eval("Id") %>">info_outline</i>
                            
                        </span>
                        
                        <div class="mdl-tooltip" for="<%# Eval("Id") %>">
                             <%# Eval("Id") %> | <%# Eval("Description") %> 
                        </div>

                    </li>

                    <%-- old template
                    <div class="mdl-cell mdl-cell--10-col demo-graphs">
                        <a href=>
                            <i class=" content-icon"></i>
                        </a>
                    </div>
                    --%>

                </ItemTemplate>

                <EmptyDataTemplate>
                    <div class="mdl-cell mdl-cell--12-col mdl-cell--middle mdl-cell-text--center">
                        <h2>NO DATA</h2>
                    </div>
                </EmptyDataTemplate>

                <LayoutTemplate>
                    <div id="itemPlaceholder" runat="server" />
                </LayoutTemplate>

            </asp:ListView>

        </ul>

    </div>
</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>
