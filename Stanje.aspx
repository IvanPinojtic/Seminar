<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Stanje.aspx.cs" Inherits="Stanje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Baza.mdb" SelectCommand="SELECT * FROM [proizvod]"></asp:AccessDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataSourceID="AccessDataSource1">
        <Columns>
            <asp:BoundField DataField="Naziv" HeaderText="Naziv" SortExpression="Naziv" />
            <asp:BoundField DataField="Kategorija" HeaderText="Kategorija" SortExpression="Kategorija" />
            <asp:BoundField DataField="Lokacija" HeaderText="Lokacija" SortExpression="Lokacija" />
            <asp:BoundField DataField="Kolicina" HeaderText="Kolicina" SortExpression="Kolicina" />
        </Columns>
    </asp:GridView>
    <asp:TextBox ID="Naziv" runat="server" Placeholder="Naziv"></asp:TextBox>
    <asp:DropDownList ID="Kategorija" runat="server">
        <asp:ListItem>hrana</asp:ListItem>
        <asp:ListItem>pice</asp:ListItem>
        <asp:ListItem>obuca</asp:ListItem>
        <asp:ListItem>odjeca</asp:ListItem>
        <asp:ListItem>zivotinja</asp:ListItem>
        <asp:ListItem>biljka</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="Lokacija" runat="server">
        <asp:ListItem>vrbik 8</asp:ListItem>
        <asp:ListItem>konavoska 2</asp:ListItem>
        <asp:ListItem>negdje 77</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="Kolicina" runat="server" Placeholder="Kolicina"></asp:TextBox>
    <asp:Button ID="Dodaj" runat="server" Text="Dodaj" OnClick="Dodaj_Click" />
    <asp:Button ID="Salji" runat="server" Text="Salji" OnClick="Salji_Click" /><br />
    <asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label>
   <!--     <asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
            <asp:ListItem Text="hrana" Value="hrana"></asp:ListItem>
            <asp:ListItem>pice</asp:ListItem>
            <asp:ListItem>obuca</asp:ListItem>
            <asp:ListItem>odjeca</asp:ListItem>
            <asp:ListItem>zivotinja</asp:ListItem>
            <asp:ListItem>biljka</asp:ListItem>
        </asp:CheckBoxList>-->
</asp:Content>

