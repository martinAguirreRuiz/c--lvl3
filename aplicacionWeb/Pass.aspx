<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pass.aspx.cs" Inherits="aplicacionWeb.Pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #lblValid{
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="registro-container">

        <%--<p class="pregunta">Escribe tu nueva contraseña y confírmala</p>--%>
        <div class="btn-container">
            <div class="mb-3">
                    <label for="txtPass1" class="form-label">Escribe tu nueva contraseña</label>
                    <asp:TextBox ID="txtPass1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            <div class="mb-3">
                    <label for="txtPass2" class="form-label">Confirma tu nueva contraseña</label>
                    <asp:TextBox ID="txtPass2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
        </div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click"/>
            <label ID="lblValid" visible="false" runat="server">La nueva contraseña no puede estar vacía</label>
    </div>

</asp:Content>
