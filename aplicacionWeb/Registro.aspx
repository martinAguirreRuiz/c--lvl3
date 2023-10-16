<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="aplicacionWeb.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="registro-container">
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox CssClass="form-control" TextMode="Email" ID="txtEmail" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtPass" class="form-label">Contraseña</label>
            <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtPass" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistro_Click"/>
    </div>







</asp:Content>
