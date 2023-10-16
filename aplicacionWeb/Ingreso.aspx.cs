using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aplicacionWeb
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text)))//Valido que los campos estén llenos
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    int Id = negocio.Ingresar(txtEmail.Text, txtPass.Text);
                    Session["idUsuario"] = Id;
                    if (Id == -1)
                    {
                        Session.Add("Error", "El mail o contraseña ingresados son incorrectos");
                        Response.Redirect("Error.aspx", false);
                    }
                    else
                    {
                        Session["mailUsuario"] = txtEmail.Text;
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                    Session.Add("Error", "Complete ambos campos para iniciar sesión");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception)
            {
                Session.Add("Error", "Hubo un error en el inicio de sesión. Por favor intentar nuevamente");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}