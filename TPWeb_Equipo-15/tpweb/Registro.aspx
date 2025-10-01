<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="tpweb_equipo_15.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 16px;
        }
    </style>
        
    <script type="text/javascript">

        function validar() {
            const txtDNI = document.getElementById('TextBoxDNI.ClientID');
            const txtNombre = document.getElementById('TextBoxNombre.ClientID ');
            const txtApellido = document.getElementById(' TextBoxApellido');
            const txtEmail = document.getElementById('TextBoxEmail');
            const txtDireccion = document.getElementById('TextBoxDireccion');
            const txtCiudad = document.getElementById('TextBoxCiudad');
            const txtCD = document.getElementById('TextBoxCiudad');



            let valid = true;

            if (txtDNI.value.trim() === "") {
                txtDNI.classList.add("is-invalid");
                txtDNI.classList.remove("is-valid");
                valid = false;
            } else if (txtDNI.value.trim() <= 0) {
                txtDNI.classList.add("is-invalid");
                txtDNI.classList.remove("is-valid");
                valid = false;
            }
            else {
                txtDNI.classList.remove("is-invalid");
                txtDNI.classList.add("is-valid");
            }

            if (txtNombre.value.trim() === "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                valid = false;
            } else {
                txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");
            }

            if (txtApellido.value.trim() === "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                valid = false;
            } else {
                txtApellido.classList.remove("is-invalid");
                txtApellido.classList.add("is-valid");
            }

            const email = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!email.test(txtEmail.value.trim())) {
                txtEmail.classList.add("is-invalid");
                txtEmail.classList.remove("is-valid");
                valid = false;
            } else {
                txtEmail.classList.remove("is-invalid");
                txtEmail.classList.add("is-valid");
            }

            if (txtDireccion.value.trim() === "") {
                txtDireccion.classList.add("is-invalid");
                txtDireccion.classList.remove("is-valid");
                valid = false;
            } else {
                txtDireccion.classList.remove("is-invalid");
                txtDireccion.classList.add("is-valid");
            }

            if (txtCiudad.value.trim() === "") {
                txtCiudad.classList.add("is-invalid");
                txtCiudad.classList.remove("is-valid");
                valid = false;
            } else {
                txtCiudad.classList.remove("is-invalid");
                txtCiudad.classList.add("is-valid");
            }

            if (txtCD.value.trim() === "") {
                txtCD.classList.add("is-invalid");
                txtCD.classList.remove("is-valid");
                valid = false;
            } else {
                txtCD.classList.remove("is-invalid");
                txtCD.classList.add("is-valid");
            }

            return valid;
        }
    </script>

    <script type="text/javascript">
        function SoloNumeros(e) {
            var tecla = String.fromCharCode(e.which || e.keyCode);

            var rango = /[0-9]/;

            if (rango.test(tecla)) {
                return true;
            }

            if (e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 46 || (e.keyCode >= 37 && e.keyCode <= 40)) {
                return true;
            }

            return false;
        }
    </script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-3"></div>
    <div class="col">
        <hr />
        <div class="mb-3">
            <h1>Ingresa tus datos</h1>
            <div class="mb-3">
                <label for="TextBoxDNI" class="form-label">DNI</label>
                <asp:TextBox ID="TextBoxDNI" runat="server" CssClass="form-control" Placeholder="Ingrese su DNI" AutoPostBack="True" OnTextChanged="TextBoxDNI_TextChanged" onkeypress="return SoloNumeros(event)" required pattern="\d{7,8}"
                    title="El DNI debe unicamente 8 dígitos." MaxLength="8" Style="width: 235px;" ></asp:TextBox>
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="TextBoxNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" Placeholder="Ingrese su nombre" required pattern="[A-Za-z\s]+" 
   title="Solo ingrese letras." maxlength="30"></asp:TextBox>
                    
                </div>
                <div class="col">
                    <label for="TextBoxApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control" Placeholder="Ingrese su apellido" required pattern="[A-Za-z\s]+" 
   title="Solo ingrese letras." maxlength="30"></asp:TextBox>
                </div>  
                <div class="col">
                    <label for="TextBoxEmail" class="form-label">Email</label>
                    <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" Placeholder="Ingrese su email" TextMode="Email" required></asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col">
                    <label for="TextBoxDireccion" class="form-label">Dirección</label>
                    <asp:TextBox ID="TextBoxDireccion" runat="server" CssClass="form-control" Placeholder="Ingrese su dirección" 
   title="Solo ingrese letras." maxlength="30"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="TextBoxCiudad" class="form-label">Ciudad</label>
                    <asp:TextBox ID="TextBoxCiudad" runat="server" CssClass="form-control" Placeholder="Ingrese su ciudad" required></asp:TextBox>
                </div>
                <div class="col">
                    <label for="TextBoxCP" class="form-label">Código Postal (CP)</label>
                    <asp:TextBox ID="TextBoxCP" runat="server" CssClass="form-control" Placeholder="Ingrese su código postal" onkeypress="return SoloNumeros(event)" required pattern="\d{4,6}" 
                        title="El Codigo postal debe ser valido." maxlength="7" Style="width: 235px;"></asp:TextBox>
                </div>
            </div>

            <div class="form-check mb-3">
                <asp:CheckBox ID="CheckBoxTerminos" runat="server" CssClass="form-check-input" required />
                <label class="form-check-label" for="CheckBoxTerminos">Acepto todos los términos</label>
            </div>

            <div>
                <asp:Label ID="LblMessageChkbox" runat="server" Text="" style="color: red"></asp:Label>
            </div>
            <br/>
            <asp:Button ID="BotonParticipar" runat="server" Text="Participar" CssClass="btn btn-primary" OnClick="BotonParticipar_Click" />
        </div>
    </div>
    <div class="col-3"></div>
</div>
</asp:Content>