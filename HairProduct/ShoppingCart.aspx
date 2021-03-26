<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="HairProduct.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" media="screen" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <link rel="stylesheet" type="text/css" href="root/StyleSite2.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="formulario">

        <asp:GridView ID="GridView1"
            runat="server"
            AutoGenerateColumns="False"
            BackColor="White"
            BorderColor="#E7E7FF"
            BorderStyle="None"
            BorderWidth="1px"
            CellPadding="3"
            DataKeyNames="ID"
            OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating"
            OnRowDeleting="GridView1_RowDeleting"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnPageIndexChanging="GridView1_PageIndexChanging"
            GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:TemplateField HeaderText="Produto">
                    <ItemTemplate>
                        <asp:Label ID="Label1" Text='<%#Eval("Produto") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qtd">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_qtde" type="number" min="1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="txt_qtde" Text='<%#Eval("Quantidade") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vlr Und">
                    <ItemTemplate>
                        <asp:Label ID="Label3" Text='<%#Eval("Preco") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <asp:Label ID="Label4" Text='<%#Eval("total") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/root/imagens/botoes/edit.png" runat="server" Text="Editar" CommandName="Edit" Width="20px" Height="20px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/root/imagens/botoes/save.png" runat="server" Text="Salvar" CommandName="Update" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/root/imagens/botoes/cancel.png" runat="server" Text="Cancelar" CommandName="Cancel" Width="20px" Height="20px" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Excluir">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/root/imagens/botoes/delete.png" runat="server" Text="Editar" CommandName="Delete" Width="20px" Height="20px" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <div>
            <span>Subtotal: R$</span>
            <strong>
                <asp:Literal ID="lit_value_total" runat="server" />
            </strong>
        </div>
        <div style="background-color: #311990">
            <br />
            <asp:Button runat="server" Text="Continuar Comprando" class="btn btn-light"  OnClick="ContinuarComprando_Click"/>
            <asp:Button runat="server" Text="Finalizar Compra" class="btn btn-success" OnClick="FinalizarCompra_Click" />
        </div>
    </div>




</asp:Content>
