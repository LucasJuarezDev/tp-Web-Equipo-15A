using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class MarcaManager
    {
        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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

        public void Agregar(string descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO MARCAS(Descripcion) VALUES ( @Descripcion )");
                datos.SetearParametro("@Descripcion", descripcion);
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
