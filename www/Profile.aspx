<%@ Page Title="Create Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Zero.ShareDream.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHLogin" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHDonation" runat="server">
    <asp:Panel ID="PCreateProfile" runat="server">
  
<center><h1>Create a Child's Profile</h1><hr />
<table>
<tr><td><asp:Label ID="LName" runat="server" Text="Name Of Child:"></asp:Label></td><td><asp:TextBox ID="TBName" width="300" Height="30" runat="server"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="LAge" runat="server" Text="Age(Appprox):"></asp:Label></td><td><asp:TextBox ID="TBAge" width="300" Height="30" runat="server"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="LCity" runat="server" Text="City:"></asp:Label></td><td><asp:TextBox ID="TBCity" width="300" Height="30" runat="server"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="LCountry" runat="server" Text="Country:"></asp:Label></td><td><asp:TextBox ID="TBCountry" width="300" Height="30" runat="server"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="LAddress" runat="server" Text="Address:"></asp:Label></td><td><asp:TextBox ID="TBAddress" width="300" Height="30" runat="server"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="LCareNumber" runat="server" Text="CareTakerNumber:"></asp:Label></td><td><asp:TextBox ID="TBCareNumber" width="300" Height="30" runat="server"></asp:TextBox></td></tr>

<tr><td><asp:Label ID="LUpload" runat="server" Text="Upload a Photo:"></asp:Label></td><td><asp:FileUpload ID="FUpload" Width="300" runat="server" /></td></tr>

<tr  valign="top"><td><asp:Label ID="LBackground" runat="server" Text="Background Story:"></asp:Label></td><td><asp:TextBox ID="TBStory" width="300" Height="250" TextMode="MultiLine" runat="server"></asp:TextBox></td></tr>
</table>

    <asp:Button ID="BSubmit" runat="server" Text="Submit" onclick="BSubmit_Click" />
      </asp:Panel>

</center>
</asp:Content>
