<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Staff.aspx.cs" Inherits="Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Baza.mdb" SelectCommand="SELECT * FROM [staff]">
        </asp:AccessDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataSourceID="AccessDataSource1" PageSize="10">
            <Columns>
                <asp:BoundField DataField="Ime" HeaderText="Ime" SortExpression="Ime" />
                <asp:BoundField DataField="Pozicija" HeaderText="Pozicija" SortExpression="Pozicija" />
            </Columns>
        </asp:GridView>
    <asp:TextBox ID="Ime" runat="server" Placeholder="Ime"></asp:TextBox>
    <asp:TextBox ID="Pass" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>
    <asp:Button ID="Dodaj" runat="server" Text="Novi" OnClick="Novi_Click" />
    <asp:Button ID="Salji" runat="server" Text="Otkaz" OnClick="Otkaz_Click" /><br />
    <asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label>
</asp:Content>

