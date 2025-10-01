using Dominio;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpweb_equipo_15
{
    public partial class Premios : System.Web.UI.Page
    {
        public List<Articulo> articuloList { get; set; }
        public List<Imagen> imageList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ArticuloManager managerArticulo = new ArticuloManager();
                ImagenManager managerImagen = new ImagenManager();

                articuloList = managerArticulo.listar();
                imageList = managerImagen.listar();

                List<Imagen> imagenPorId = new List<Imagen>();

                var articuloXimagenes = new List<ArticuloConImagenes>();


                for (int i = 0; i < articuloList.Count; i++)
                {
                    imagenPorId = imageList.FindAll(
                    x => x.IdArticulo == articuloList[i].Id);

                }
                foreach (var articulo in articuloList)
                {
                    // Obtener las imágenes para el artículo actual
                    var imagenesDelArticulo = imageList.FindAll(x => x.IdArticulo == articulo.Id);
                    articuloXimagenes.Add(new ArticuloConImagenes
                    {
                        articulo = articulo,
                        imagen = imagenesDelArticulo
                    });
                }


                repRepetidor.DataSource = articuloXimagenes;
                repRepetidor.DataBind();
            }
        }
        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var articuloConImagenes = (ArticuloConImagenes)e.Item.DataItem;
                var repImagenes = (Repeater)e.Item.FindControl("repImagenes");
                repImagenes.DataSource = articuloConImagenes.imagen;
                repImagenes.DataBind();
            }
        }

        protected void btnYoTeElijo_Command(object sender, CommandEventArgs e)
        {
            ImagenManager managerImagenes = new ImagenManager();

            // Obtener el ID del artículo
            int IdArticulo = Convert.ToInt32(e.CommandArgument);
            Imagen imagenArtSeleccionado = managerImagenes.BuscarImagen(IdArticulo);

            Session.Add("IdArticulo", IdArticulo);
            Session.Add("UrlImagen", imagenArtSeleccionado.ImagenUrl);

            Response.Redirect("~/Registro.aspx");
        }

        public class ArticuloConImagenes
        {
            public Articulo articulo { get; set; }
            public List<Imagen> imagen { get; set; }
        }
    }
}