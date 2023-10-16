<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="aplicacionWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--    <div class="grid-container">--%>

    <div class="titulo">
        <h1 id="h1Title" runat="server">Bienvenido al Pokedex</h1>
    </div>

    <div class="row row-cols-1 row-cols-md-4 g-4 grid-container">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src='<%#Eval("UrlImagen")%>' class="card-img-top" alt="...">
                        <div class="card-body">
                            <h4 class="card-title"><%#Eval("Nombre")%></h4>
                            <h6 class="card-text"><%#Eval("Tipo")%></h6>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <%--</div>--%>















</asp:Content>
