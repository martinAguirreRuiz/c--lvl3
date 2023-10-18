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
    public partial class Modificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (int.Parse(Session["idUsuario"].ToString()) == -1)
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        ElementoNegocio elementoNegocio = new ElementoNegocio();

                        ddlTipo.DataSource = elementoNegocio.listar();
                        ddlTipo.DataTextField = "Descripcion";
                        ddlTipo.DataValueField = "Id";
                        ddlTipo.DataBind();

                        ddlDebilidad.DataSource = elementoNegocio.listar();
                        ddlDebilidad.DataTextField = "Descripcion";
                        ddlDebilidad.DataValueField = "Id";
                        ddlDebilidad.DataBind();

                        if (Session["idSeleccionado"] == null) //Agregar (llega todo vacío)
                        {
                        }
                        else
                        {
                            //Modifico (vienen las cosas precargadas)
                            PokemonNegocio negocio = new PokemonNegocio();

                            Pokemon seleccionado = negocio.listarUnico(int.Parse(Session["idSeleccionado"].ToString()));

                            txtNombre.Text = seleccionado.Nombre;
                            txtNumero.Text = seleccionado.Numero.ToString();
                            txtDescripcion.Text = seleccionado.Descripcion;
                            ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                            ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                            cbActivo.Checked = seleccionado.Activo ? true : false;
                            txtUrlImagen.Text = seleccionado.UrlImagen;
                            txtUrlImagen_TextChanged(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //En cualquiera de los dos casos tengo que cargar todo, pero en uno tengo que modificar y en otro agregar
            if (txtNombre.Text == "" || txtNumero.Text == "" || txtDescripcion.Text == "")
            {
                lbl.Visible = true;
            }
            else if (ddlTipo.SelectedValue == ddlDebilidad.SelectedValue)
            {
                lbl.Visible = true;
                lbl.InnerText = "No puedes tener mismo tipo y debilidad";
            }
            else
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon nuevo = new Pokemon();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);
                nuevo.Activo = cbActivo.Checked ? true : false;
                nuevo.UrlImagen = txtUrlImagen.Text;

                if (Session["idSeleccionado"] == null) //Agregar
                {
                    negocio.agregar(nuevo);
                }
                else
                {
                    //Modifico
                    nuevo.Id = (int)Session["idSeleccionado"];
                    negocio.modificar(nuevo);
                }
                Response.Redirect("Lista.aspx", false);
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lista.aspx", false);
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUrlImagen.Text == "")
                {
                    imgPokemon.ImageUrl = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
                }
                else
                {
                    imgPokemon.ImageUrl = txtUrlImagen.Text;
                }

            }
            catch (Exception)
            {
                imgPokemon.ImageUrl = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
            }
        }
    }
}