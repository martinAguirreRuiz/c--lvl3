<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="aplicacionWeb.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .oculto{
            display:none;
        }
        .grid-container{
            margin-top: 2vh;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="grid-container">
        <asp:GridView ID="dgvPokemons" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto"/>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion"/>
                <asp:BoundField HeaderText="UrlImagen" DataField="UrlImagen" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto"/>
                <asp:BoundField HeaderText="Tipo" DataField="Tipo"/>
                <asp:BoundField HeaderText="Debilidad" DataField="Debilidad"/>
                <asp:CheckBoxField HeaderText="Activo" DataField="Activo" ReadOnly="true"/>
                <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Editar" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
    </div>





</asp:Content>
