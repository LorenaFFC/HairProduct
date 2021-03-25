<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="HairProduct.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" media="screen" href="root/Style.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="collapse navbar-collapse" id="navbarTogglerDemo02" style="border-top: solid; border-color: white">
            <ul class="navbar-nav mr-auto mt-3 mt-lg-2">
                <li >
                    <img src="https://i.pinimg.com/originals/c0/3c/4d/c03c4d0870e741308eef7da942691498.png" style="height:60px; width:80px"  />
                </li>
                <li class="nav-item active" style="margin-left:50px">
                    <div class="form-group">
                       
                        <asp:DropDownList ID="filtro" runat="server" class="form-control">
                            <asp:ListItem Value="">Categoria </asp:ListItem>
                            <asp:ListItem Value="Hidratação"></asp:ListItem>
                            <asp:ListItem Value="Nutrição"></asp:ListItem>
                            <asp:ListItem Value="Reconstrução"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
                <li class="nav-item active" style="margin-left:30px">
                    <div class="form-group">
                       
                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                            <asp:ListItem Value="">Marca </asp:ListItem>
                            <asp:ListItem Value="Hidratação"></asp:ListItem>
                            <asp:ListItem Value="Nutrição"></asp:ListItem>
                            <asp:ListItem Value="Reconstrução"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
                <li class="nav-item active" style="margin-left:50px;margin-right:50px">
                    <div class="form-group">
                       
                        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                            <asp:ListItem Value="">Produto </asp:ListItem>
                            <asp:ListItem Value="Hidratação"></asp:ListItem>
                            <asp:ListItem Value="Nutrição"></asp:ListItem>
                            <asp:ListItem Value="Reconstrução"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
                <li>
                    <div class="input-group">
                        <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
                        <div class="input-group-append" id="button-addon4">
                            <button class="btn btn-outline-success  mr-sm-4" type="submit">Search</button>
                        </div>
                    </div>

                </li>
            </ul>
        </div>
    </nav>

    <h1 class="titulo">PRODUCTS    </h1>

    <div class="container">
        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <img src="<%#Eval("Url") %>" alt="Primeiro Slide" class="img-produto-carrossel">
                                    </td>
                                </tr>
                                <tr style="align-items: center">
                                    <td class="produto-nome"><%#Eval("Nome") %>
                                        <h4><strong>R$ <%#Eval("Preco") %></strong></h4>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>

                    <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                        <img src="root/imagens/Anterior.png" style="width: 50px; height: 50px">
                        <span class="sr-only">Anterior</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                        <img src="root/imagens/Proximo.png" style="width: 50px; height: 50px">
                        <span class="sr-only">Próximo</span>
                    </a>
                </div>

                <div class="carousel-item">
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="lnkTest1" runat="server">
                                             <img id='wa' src="<%#Eval("Url") %>" alt="Primeiro Slide" class="img-produto-carrossel">
                                        </asp:HyperLink>
                                    </td>
                                    <asp:Literal ID="tablebreak" runat="server"></asp:Literal>
                                </tr>
                                <tr>
                                    <td class="produto-nome"><%#Eval("Nome") %>
                                        <h4><strong>R$ <%#Eval("Preco") %></strong></h4>
                                    </td>
                                </tr>
                        </ItemTemplate>
                        <SeparatorTemplate></SeparatorTemplate>
                    </asp:Repeater>


                </div>


            </div>


            <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                <img src="root/imagens/Anterior.png" style="width: 50px; height: 50px">
                <span class="sr-only">Anterior</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                <img src="root/imagens/Proximo.png" style="width: 50px; height: 50px">
                <span class="sr-only">Próximo</span>
            </a>
        </div>
    </div>



    <script type="text/javascript">

        console.log("asasas" + teste);
        jQuery(document).ready(function () {
            $('#carouselExampleControls').jcarousel({
                wrap: 'first',
                visible: 3,
            });
        });
    </script>





</asp:Content>
