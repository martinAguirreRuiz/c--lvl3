using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aplicacionWeb
{
    public partial class Pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.Parse(Session["idUsuario"].ToString()) == -1)
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtPass1.Text == txtPass2.Text && txtPass1.Text != "")
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.ModificarContra(txtPass1.Text, (int)Session["idUsuario"]);
                Response.Redirect("Perfil.aspx", false);
            }
            else if(txtPass1.Text == "" || txtPass2.Text == "")
            {
                lblValid.Visible = true;
            }
            else
            {
                lblValid.InnerText = "Ambos campos deben coincidir";
                lblValid.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }
    }
}