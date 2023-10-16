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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text)))//Valido que los campos estén llenos
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario nuevo = new Usuario();
                    nuevo.Email = txtEmail.Text;
                    nuevo.Pass = txtPass.Text;
                    int Id = negocio.Registrar(nuevo);
                    Session["idUsuario"] = Id;
                    if (Id == -1)
                    {
                        Session.Add("Error", "Ya existe un usuario registrado con este mail, por favor elegí otro");
                        Response.Redirect("Error.aspx", false);
                    }
                    else
                    {
                        Session["mailUsuario"] = nuevo.Email;
                        Response.Redirect("Default.aspx", false);
                       
                    }
                }
                else
                {
                    Session.Add("Error", "Complete ambos campos para registrarse");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception)
            {
                Session.Add("Error", "Hubo un error en el registro. Por favor intentar nuevamente");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}