<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="GraciasPorParticipar.aspx.cs" Inherits="tpweb.GraciasPorParticipar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .serpentinas {
        position: absolute;
        top: 10%;
        left: 50%;
        transform: translateX(-50%);
        width: 100%;
        height: 100%;
        overflow: hidden;
        pointer-events: none;
    }

    .serpentina {
        position: absolute;
        width: 10px;
        height: 200px;
        background: linear-gradient(to bottom, #ff69b4, #ff1493);
        animation: caer 2s infinite;
        opacity: 0.7;
    }

    @keyframes caer {
        0% {
            transform: translateY(-100%) rotate(0deg);
        }
        100% {
            transform: translateY(100vh) rotate(720deg);
        }
    }

    .container {
        position: relative;
        text-align: center;
        padding: 50px;
        background-color: #f8f9fa;
        border-radius: 10px;
        margin-top: 50px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }

    .thank-you-title {
        font-size: 2.5rem;
        color: #007bff;
    }

    .return-button {
        margin-top: 20px;
        font-size: 1.2rem;
        padding: 10px 20px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
    <div class="col-3"></div>
    <div class="col">
        <div class="container">
            <h1 class="thank-you-title">¡Gracias por participar!</h1>
           <asp:Button ID="BotonParticipar" runat="server" Text="Volver al inicio" CssClass="btn btn-primary return-button" OnClick="BotonParticipar_Click" />

        </div>
    </div>
    <div class="col-3"></div>
</div>

<div class="serpentinas">
    <div class="serpentina" style="left: 10%; animation-delay: 0s;"></div>
    <div class="serpentina" style="left: 30%; animation-delay: 0.5s;"></div>
    <div class="serpentina" style="left: 50%; animation-delay: 1s;"></div>
    <div class="serpentina" style="left: 70%; animation-delay: 1.5s;"></div>
    <div class="serpentina" style="left: 90%; animation-delay: 2s;"></div>
</div>

</asp:Content>
