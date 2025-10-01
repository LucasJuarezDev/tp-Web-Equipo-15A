using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Manager;
using System.Net;
using System.Net.Mail;

namespace tpweb_equipo_15
{
    public partial class Registro : System.Web.UI.Page
    {
        Cliente clienteActual = new Cliente();
        Voucher voucherActual;
        int IdArticulo;
        string urlImagen;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["voucher"] != null)
            {
                voucherActual = (Voucher)Session["voucher"];
                IdArticulo = (int)Session["IdArticulo"];
                urlImagen = (string)Session["UrlImagen"];
            }
            else
            {
                Response.Write("<script>alert('Debe ingresar un voucher antes de registrarse!'); window.location='Default.aspx';</script>");
            }
        }

        protected void TextBoxDNI_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();

            if (clienteActual.Id != 0)
                MostrarDatosCliente(clienteActual);
        }

        protected void BotonParticipar_Click(object sender, EventArgs e)
        {

            if (CheckBoxTerminos.Checked == false)
            {
                LblMessageChkbox.Text = "Acepte los términos y condiciones";
                return;
            }

            BuscarCliente();

            if (clienteActual.Id == 0) GuardarCliente();

            ActualizarVoucher();
            EnvioMailCliente();

            Response.Redirect("~/GraciasPorParticipar.aspx");
        }

        private void MostrarDatosCliente(Cliente clienteActual)
        {
            TextBoxNombre.Text = clienteActual.Nombre;
            TextBoxApellido.Text = clienteActual.Apellido;
            TextBoxEmail.Text = clienteActual.Email;
            TextBoxDireccion.Text = clienteActual.Direccion;
            TextBoxCiudad.Text = clienteActual.Ciudad;
            TextBoxCP.Text = clienteActual.CP.ToString();
        }

        private Cliente ObtenerDatosCliente()
        {
            Cliente aux = new Cliente();
            int cp;

            aux.Documento = TextBoxDNI.Text;
            aux.Nombre = TextBoxNombre.Text;
            aux.Apellido = TextBoxApellido.Text;
            aux.Email = TextBoxEmail.Text;
            aux.Direccion = TextBoxDireccion.Text;
            aux.Ciudad = TextBoxCiudad.Text;
            int.TryParse(TextBoxCP.Text, out cp);
            aux.CP = cp;

            return aux;
        }

        private void BuscarCliente()
        {
            ClienteManager clienteManager = new ClienteManager();

            try
            {
                clienteActual = clienteManager.BuscarCliente(TextBoxDNI.Text);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error " + ex.Message + "');</script>");
            }
        }

        private void GuardarCliente()
        {
            ClienteManager clienteManager = new ClienteManager();
            clienteActual = ObtenerDatosCliente();

            clienteManager.Agregar(clienteActual);
        }

        private void ActualizarVoucher()
        {
            VoucherManager voucherManager = new VoucherManager();
            DateTime fecahActual = DateTime.Now;

            BuscarCliente();        //en caso de que el cliente no exista, luego de cargarlo lo vuelvo a buscar en la DB

            voucherActual.IdCliente = clienteActual.Id;     //para obtener su id
            voucherActual.FechaCanje = fecahActual;
            voucherActual.IdArticulo = IdArticulo;

            voucherManager.Modificar(voucherActual);
        }

        private void EnvioMailCliente()
        {
            ArticuloManager articuloManager = new ArticuloManager();

            try // Aca arranca el envío del mail
            {
                // Configuración del cliente SMTP
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("axelpereyra965@gmail.com", "dzdt bhmg ictr trtu"),
                    EnableSsl = true
                };

                string planillaHtml = Server.MapPath("CorreoNotificacionCanjeo.html");
                string body = File.ReadAllText(planillaHtml);

                Articulo articuloActual = articuloManager.BuscarArticulo(IdArticulo);

                body = body.Replace("{UrlImagen}", urlImagen);
                body = body.Replace("{Voucher}", voucherActual.CodigoVoucher);
                body = body.Replace("{Nombre}", articuloActual.Nombre);
                body = body.Replace("{Codigo}", articuloActual.Codigo);
                body = body.Replace("{Descripcion}", articuloActual.Descripcion);
                body = body.Replace("{Marca}", articuloActual.TipoMarca.Descripcion);
                body = body.Replace("{Categoria}", articuloActual.TipoCategoria.Descripcion);

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("axelpereyra965@gmail.com", "Promo Gana"),
                    Subject = "Confirmación de premio",
                    Body = body,
                    IsBodyHtml = true
                };

                // El destinatario
                mailMessage.To.Add(clienteActual.Email.ToString());

                // Enviar el correo
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al enviar el correo: " + ex.Message + "');</script>");
            }
        }


    }
}