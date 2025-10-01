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
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LblMessageStatus.Text = "";

        }

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            VoucherManager voucher_manager = new VoucherManager();
            Voucher voucherActual = new Voucher();

            try
            {
                voucherActual = voucher_manager.BuscarVoucher(txbIngresoVaucher.Text);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error " + ex.Message + "');</script>");
            }


            if (voucherActual.CodigoVoucher == null)
            {
                LblMessageStatus.Text = "El voucher ingresado no es valido";
                return;
            }

            if (voucherActual.IdCliente != null)
            {
                LblMessageStatus.Text = "Voucher ya utilizado";
                return;
            }

            //Guardo datos del voucher
            Session.Add("voucher", voucherActual);
            Response.Redirect("~/Premios.aspx");
        }


    }
}