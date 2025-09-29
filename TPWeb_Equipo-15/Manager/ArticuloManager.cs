using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Manager
{
    public class ArticuloManager
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS MarcaDescripcion, A.IdCategoria, C.Descripcion AS CategoriaDescripcion, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id and Precio > 0");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.TipoMarca = new Marca();
                    aux.TipoMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.TipoMarca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    aux.TipoCategoria = new Categoria();
                    aux.TipoCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.TipoCategoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Precio = Math.Round(aux.Precio, 2);

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


    }
}
