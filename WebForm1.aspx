<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebPruebaAcceso.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/codigo.js"></script>
    <script src="js/sweetalert2.all.min.js"></script>
    <script src="js/sweetalert2.min.js"></script>
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Width="428px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnConsultaDataReader" runat="server" OnClick="btnConsultaDataReader_Click" Text="DATA READER" />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="btnConsultaDataSet" runat="server" OnClick="btnConsultaDataSet_Click" Text="DATA SET" />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="btnDatosDataSet" runat="server" OnClick="btnDatosDataSet_Click" Text="Obtener datos del DataSet" />
            <br />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Button" />
            <br />
            <br />
            <br />
        </div>
        <div>
            INSERTAR EMPLEADO
            <br />
            <asp:TextBox ID="txbID" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txbNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txbIdprod" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txbDescProd" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txbCategoProd" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txbPrecProd" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnProd" runat="server" OnClick="btnProd_Click" Text="Button" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
