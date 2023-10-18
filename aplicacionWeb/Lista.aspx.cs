using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace aplicacionWeb
{
    public partial class Lista : System.Web.UI.Page
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
                    PokemonNegocio negocio = new PokemonNegocio();
                    dgvPokemons.DataSource = negocio.listar();
                    dgvPokemons.DataBind();
                    Session.Add("idSeleccionado", null);
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session["idSeleccionado"] = null;
            Response.Redirect("Modificacion.aspx", false);
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvPokemons.SelectedDataKey.Value;
            Session["idSeleccionado"] = dgvPokemons.SelectedDataKey.Value;
            Response.Redirect("Modificacion.aspx", false);
        }
    }
}