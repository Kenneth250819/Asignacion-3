<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaReporteForm.aspx.cs" Inherits="Asignacion_3.Paginas.VistaReporteForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Generar Reporte en PDF</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Edad" HeaderText="Edad" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnGeneratePDF" runat="server" Text="Generar PDF" OnClick="btnGeneratePDF_Click" />
</form>
</body>
</html>
