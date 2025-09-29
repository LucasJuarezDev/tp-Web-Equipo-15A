using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ImagenManager
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }

        public List<Imagen> ListarPorArticuloId(int idArticulo) //pide el id y lista todas img de ese articulo
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                datos.SetearParametro("@IdArticulo", idArticulo);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }


        public Imagen BuscarImagen(int IdArt)
        {
            Imagen imagenBuscada = new Imagen();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArt");
                datos.SetearParametro("@IdArt", IdArt);
                datos.EjecutarLectura();

                datos.Lector.Read();

                imagenBuscada.Id = (int)datos.Lector["Id"];
                imagenBuscada.IdArticulo = (int)datos.Lector["IdArticulo"];

                if (!(datos.Lector["ImagenUrl"] is DBNull))
                    imagenBuscada.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                datos.Lector.Close();

                return imagenBuscada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }

        public void Agregar(string url)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO IMAGENES (idArticulo, ImagenUrl) VALUES ( (SELECT TOP 1 id FROM ARTICULOS ORDER BY id DESC), @ImagenUrl)");
                datos.SetearParametro("@ImagenUrl", url);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }


        public void Agregar(string url, int IdArt)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO IMAGENES (idArticulo, ImagenUrl) VALUES ( @IdArt, @ImagenUrl)");
                datos.SetearParametro("@IdArt", IdArt);
                datos.SetearParametro("@ImagenUrl", url);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }


        public void modificar(Imagen ImgModificada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update IMAGENES set idArticulo = @idArticulo, ImagenUrl = @ImagenUrl Where Id = @id");
                datos.SetearParametro("@idArticulo", ImgModificada.IdArticulo);
                datos.SetearParametro("@ImagenUrl", ImgModificada.ImagenUrl);
                datos.SetearParametro("@id", ImgModificada.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }
    }
}
