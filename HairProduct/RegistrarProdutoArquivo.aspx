<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrarProdutoArquivo.aspx.cs" Inherits="HairProduct.RegistrarProdutoArquivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css"  media="screen" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Dropzone para receber arquivo-->
    <div class="container" 
         style= " border-color:#DCEBF5; 
                  border-style:solid; 
                  margin-top:30px;
                  align-content:center; 
                  background-color:#F5F5F5;
                  padding-top:30px">
    <div class="externo-left">
        <asp:FileUpload ID="FileUpload1"
            runat="server"
            BackColor="#97A8A6"
            CssClass="btn-outline-light"
            Font-Bold="True"
            onchange="getFileData(this);" />
    </div>
      <br />
    <div class="container" style="align-items: center">
        <asp:Button ID="btnUpload" runat="server" Text="Upload" class="btn btn-secondary  btn-lg"  />
        <asp:Label ID="IMsg" runat="server" role="alert" Enabled="False" Font-Bold="True" Font-Size="Medium" class="alert alert-danger" Text=""></asp:Label>


        <asp:Button ID="Button1" runat="server" Text="Modelo Planilha" class="btn btn-success  btn-lg"  OnClick="download_ModeloPlanilha"/>

    </div>
    <div class="list-group-item" style="width: 500px; margin: 30px;">
        <asp:Label ID="Label1" runat="server" Text="Contém cabeçalho ?" />
        <br />

        <asp:RadioButtonList ID="rbHDR" runat="server">
            <asp:ListItem Text="Yes" Value="Yes" Selected="True"> </asp:ListItem>
            <asp:ListItem Text="No" Value="No"></asp:ListItem>
        </asp:RadioButtonList>
        <br />

    </div>
    </div>
</asp:Content>
