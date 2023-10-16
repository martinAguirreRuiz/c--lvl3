using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public int Registrar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("storedRegistrar");
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int Ingresar(string mail, string pass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("storedIngresar");
                datos.setearParametro("@Email", mail);
                datos.setearParametro("@Pass", pass);
                int xd = datos.ejecutarAccionScalar();
                return xd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Usuario Listar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("storedListarUsuario");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                Usuario aux = new Usuario();

                while (datos.Lector.Read())
                {
                    aux.Id = id;
                    aux.Email = datos.Lector["Email"].ToString();
                    aux.Pass = datos.Lector["Pass"].ToString();
                    if (datos.Lector["Nombre"] == null)
                    {
                        aux.Nombre = "";
                    }
                    else
                    {
                        aux.Nombre = datos.Lector["Nombre"].ToString();
                    }

                    if (datos.Lector["Apellido"] == null)
                    {
                        aux.Apellido = "";
                    }
                    else
                    {
                        aux.Apellido = datos.Lector["Apellido"].ToString();
                    }

                    if (datos.Lector["FechaNacimiento"] == null)
                    {
                        aux.FechaNacimiento = "";
                    }
                    else
                    {
                        aux.FechaNacimiento = datos.Lector["FechaNacimiento"].ToString();
                    }

                    if (datos.Lector["UrlImagen"] == null)
                    {
                        aux.UrlImagen = "";
                    }
                    else
                    {
                        aux.UrlImagen = datos.Lector["UrlImagen"].ToString();
                    }
                }

                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ModificarContra(string pass, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Usuarios set Pass = @pass where Id = @id");
                datos.setearParametro("@pass", pass);
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ActualizarDatos(Usuario aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("storedActualizarUsuario");
                datos.setearParametro("@pass", aux.Pass);
                datos.setearParametro("@nombre", aux.Nombre);
                datos.setearParametro("@apellido", aux.Apellido);
                datos.setearParametro("@fecha", aux.FechaNacimiento);
                datos.setearParametro("@img", aux.UrlImagen);
                datos.setearParametro("@id", aux.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
