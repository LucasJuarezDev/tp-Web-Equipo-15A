<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="tpweb.Premios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>

        .image-container {
              width: 100%;           
            height: 300px;        
            overflow: hidden;     
            display: flex;        
            justify-content: center; 
            align-items: center;  
        }
        .carousel-item img{
             max-width: none;     
            height: 300px;        
            width: 100%;          
        }
        .titulo-principal {
            display: flex;
            background-color: #eadae9;
            justify-content: center; 
            align-items: center;
        }
        .fw-bold{
            display: flex;
            background-color: #eadae9;
            justify-content: center; 
            align-items: center;   
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h3 class="titulo-principal">
            ¡¡Elegí el premio que más te guste!!
            <small class="text-body-secondary">Recordá que solo podes elegír uno</small>
          </h3>

    <br />

    <div class="container">
    <div class="row justify-content-center">
     <asp:Repeater runat="server" ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound">
        <ItemTemplate>
            <div class="col-md-5 mb-4"> 
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Articulo.Nombre") %></h5>
                    <div id="carousel<%# Eval("Articulo.Id") %>" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <asp:Repeater runat="server" ID="repImagenes">
                                <ItemTemplate>
                                    <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>"> <!-- con esto verifico la posicion de imagen actual-->
                                        <img src="<%# Eval("ImagenUrl") %>" class="d-block w-100" alt="Premio" >
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("Articulo.Id") %>" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("Articulo.Id") %>" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                    <p class="fw-bold"><%# Eval("Articulo.Descripcion") %></p>
                    <ul class="list-group list-group-flush">
                            <li class="list-group-item">PRECIO: $<%# Convert.ToDecimal(Eval("Articulo.Precio")).ToString("N2", System.Globalization.CultureInfo.CreateSpecificCulture("es-AR")) %> </li>           
                            <li class="list-group-item">MARCA: <%# ((Dominio.Marca)Eval("Articulo.TipoMarca")).Descripcion%></li>
                            <li class="list-group-item">CATEGORIA: <%# ((Dominio.Categoria)Eval("Articulo.TipoCategoria")).Descripcion%></li>
                        </ul>

                     <asp:LinkButton ID="btnYoTeElijo" runat="server" CssClass="btn btn-warning" CommandArgument='<%# Eval("Articulo.Id")%>' OnCommand="btnYoTeElijo_Command">
                        Yo te Elijo! </asp:LinkButton>
                </div>
            </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
    </div>
 
</asp:Content>
