<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="Modificacion.aspx.cs" Inherits="aplicacionWeb.Modificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .grid-container {
            margin-top: 2vh;
        }

        .img-fluid {
            height: 400px;
            width: 400px;
            display:block;
            margin: 0 auto;
        }
        .lblValid{
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="smImg" runat="server"></asp:ScriptManager>
    <div class="grid-container">
        <div class="row">

            <div class="col">
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtNumero" class="form-label">Número</label>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ddlTipo" class="form-label">Tipo</label>
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlDebilidad" class="form-label">Debilidad</label>
                    <asp:DropDownList ID="ddlDebilidad" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-check">
                    <asp:CheckBox ID="cbActivo" runat="server" Checked="true" />
                    <label for="cbActivo" class="form-check-label">Activo</label>
                </div>
                <br />
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                <label ID="lbl" class="lblValid" runat="server" visible="false">Completa todos los campos!</label>
            </div>

            <div class="col">
                <asp:UpdatePanel ID="upImg" runat="server">
                    <ContentTemplate>
                <div class="mb-3">
                    <label for="txtUrlImagen" class="form-label">Imagen</label>
                    <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                        <asp:Image ID="imgPokemon" runat="server" CssClass="img-fluid mb-3" ImageUrl="https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg" ImageAlign="Middle" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
    </div>
    </div>

</asp:Content>
