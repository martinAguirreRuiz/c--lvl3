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
                if (int.Parse(Session["idUsuario"].ToString()) == -1)
                {
                    Response.Redirect("Default.aspx", false);
                }
                else
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
                    }
                    catch (Exception ex)
                    {
                        Session["error"] = ex;
                        Response.Redirect("Error.aspx", false);
                    }
                }
                }

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
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
                if (Session["ruta"] != null)
                {
                    aux.UrlImagen = Session["ruta"].ToString();
                }
                else
                {
                    aux.UrlImagen = "";
                }

                negocio.ActualizarDatos(aux);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session["error"] = ex;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            if (fileImagen.HasFile)
            {
                string extension = System.IO.Path.GetExtension(fileImagen.FileName);
                if (extension == ".jpg")
                {
                    lblImg.Visible = false; 
                    string ruta = Server.MapPath("./Images/");
                    fileImagen.PostedFile.SaveAs(ruta + "perfil-" + Session["idUsuario"].ToString() + ".jpg");
                    Session.Add("ruta", "perfil-" + Session["idUsuario"].ToString() + ".jpg");
                    imgPerfil.ImageUrl = "~/Images/perfil-" + Session["idUsuario"].ToString() + ".jpg";
                }
                else
                {
                    lblImg.Visible = true;
                }
            }
        }
    }
}