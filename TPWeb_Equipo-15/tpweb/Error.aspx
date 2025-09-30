<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tpweb_equipo_15.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="error"> Error de autenticación </h1>
    <asp:Label Text="" ID="lblMensaje" runat="server" />
    <a href="Registro.aspx">Vuelve al registro</a>
</asp:Content>
