using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace aplicacionWeb
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((int)Session["idUsuario"] != -1)
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    try
                    {
                        Usuario aux = negocio.Listar((int)Session["idUsuario"]);

                        txtEmail.Text = aux.Email;
                        txtPass.Text = aux.Pass;
                        txtNombre.Text = aux.Nombre;
                        txtApellido.Text = aux.Apellido;
                        txtFecha.Text = aux.FechaNacimiento;
                        txtUrlImagen.Text = aux.UrlImagen;
                        txtUrlImagen_TextChanged(sender, e);
                    }
                    catch (Exception ex)
                    {
                        Session["error"] = ex;
                        Response.Redirect("Error.aspx", false);
                    }
                }

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUrlImagen.Text == "")
                {
                    imgPerfil.ImageUrl = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
                }
                else
                {
                    imgPerfil.ImageUrl = txtUrlImagen.Text;
                }
            }
            catch (Exception)
            {
                imgPerfil.ImageUrl = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario aux = new Usuario();
            try
            {
                aux.Id = (int)Session["idUsuario"];
                aux.Pass = txtPass.Text;
                aux.Nombre = txtNombre.Text;
                aux.Apellido = txtApellido.Text;
                aux.FechaNacimiento = txtFecha.Text;
                aux.UrlImagen = txtUrlImagen.Text;

                negocio.ActualizarDatos(aux);

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session["error"] = ex;
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}