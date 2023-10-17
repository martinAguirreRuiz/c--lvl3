using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace aplicacionWeb
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> ListaPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            ListaPokemon = negocio.listarActivos();
            repRepetidor.DataSource = ListaPokemon;
            repRepetidor.DataBind();
            Session.Add("listaPokemon", ListaPokemon);

            if (Session["idUsuario"] == null)
            {
            }
            else
            {
                if (int.Parse(Session["idUsuario"].ToString()) != -1)
                {
                    UsuarioNegocio uNegocio = new UsuarioNegocio();
                    Usuario aux = uNegocio.Listar((int)Session["idUsuario"]);
                    if (String.IsNullOrEmpty(aux.Nombre))
                    {
                        h1Title.InnerText = h1Title.InnerText + " " + Session["mailUsuario"].ToString();
                    }
                    else
                    {
                        h1Title.InnerText = h1Title.InnerText + " " + aux.Nombre;
                    }
                }
            }
        }
    }
}