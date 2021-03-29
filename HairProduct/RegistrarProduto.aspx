<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrarProduto.aspx.cs" Inherits="HairProduct.RegistrarProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>FORMULARIO</h2>
   
        <table>
            <tr>
                <td>
                    <div class="form-group col-3">
                        <img src="root/imagens/Capa/capa2.jpg" />
                    </div>
                </td>
                <td>
                    <div class="form-group ">
                        <asp:Label ID="Produto" runat="server" Text="Produto"></asp:Label>
                        <asp:TextBox ID="txt_Produto" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Categoriaa" runat="server" Text="Categoria"></asp:Label>
                        <asp:DropDownList ID="Categoria" runat="server" class="form-control">
                            <asp:ListItem Value="">Selecione </asp:ListItem>
                            <asp:ListItem Value="Hidratação"></asp:ListItem>
                            <asp:ListItem Value="Nutrição"></asp:ListItem>
                            <asp:ListItem Value="Reconstrução"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Marca" runat="server" Text="Marca"></asp:Label>
                        <asp:TextBox ID="txt_Marca" runat="server" class="form-control"></asp:TextBox>
                        
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Preco" runat="server" Text="Preço"></asp:Label>
                        <asp:TextBox ID="txt_Preco" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div >
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem Text="Lançamento" Value="Lançamento"></asp:ListItem>
                            <asp:ListItem Text="Ofertas" Value="Ofertas"> </asp:ListItem>
                            <asp:ListItem Text="Destaques" Value="Destaques"> </asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Imagem_Produto" runat="server" Text="Foto Produto"></asp:Label>
                        <asp:FileUpload ID="img_Produto" runat="server" class="form-control" />
                        
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="Salvar" class="btn btn-success" OnClick="Button1_Click"/>
                    <asp:Button ID="Button2" runat="server" Text="Cancelar" class="btn btn-light"/>
                </td>
            </tr>
        </table>
</asp:Content>
