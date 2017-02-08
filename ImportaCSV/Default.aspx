<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImportaCSV._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <h2 style="height: 18px">&nbsp;</h2>
    <asp:FileUpload ID="FileUpload1" runat="server" Height="47px" Width="222px" />        
    <asp:Button ID="Button1" runat="server" Height="41px" Text="Importar Arquivo CSV" Width="224px" OnClick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Font-Size="Medium" style="z-index: 1; left: 138px; top: 419px; position: absolute; width: 320px; height: 20px;" Text="Total das Vendas :"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataKeyNames="IdVenda" DataSourceID="SqlDataSource" ForeColor="#333333" GridLines="None" Width="517px" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="IdVenda" HeaderText="Venda" ReadOnly="True" SortExpression="IdVenda" />
            <asp:BoundField DataField="DtaVenda" HeaderText="Data" SortExpression="DtaVenda" DataFormatString=" {0:dd/MM/yyyy}" />
            <asp:BoundField DataField="IdCliente" HeaderText="Cliente" SortExpression="IdCliente" />
            <asp:BoundField DataField="NomeCliente" HeaderText="Nome" SortExpression="NomeCliente" />
            <asp:BoundField DataField="VlrVenda" HeaderText="Valor" SortExpression="VlrVenda" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <h2 style="height: 26px">&nbsp;</h2>
    <h2 style="height: 49px; margin-bottom: 0px;">
        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:WPRD_VENDASConnectionString %>" SelectCommand="SELECT * FROM [VENDAS]"></asp:SqlDataSource>
    </h2>
    <br />
    
</asp:Content>
