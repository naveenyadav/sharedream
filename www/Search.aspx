<%@ Page Title="Search a Child" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Zero.ShareDream.WebForm3" %>
<%@ Import Namespace="Zero.ShareDream" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <meta name="keywords" content="Sharedream, Share Dream, www.sharedream.in, sharedream.in, sharedream, share dream" />
    <meta name="description" content="Sharedream is an online comprehensive system for betterment of life of street children and their future. If you find any children working near by your house, working in hotels, motels, dhabbas or residing near by your slum. you can create profile for those children on Sharedream, and share their background story to social media like facebook twitter. We provides an interaction medium where you accept any kind of help from your friends, family, society or the visitors of Sharedream. It is kind of online adoption of the street children where you bring awareness to people around you for those children. You talk to people to spent some time with them, educate them, invite them for dinner or launch, or anything that they can do for your adopted children." />
    <link rel="image_src" href="http://www.sharedream.in/Images/sharedreamlogo.png" />
    <meta property="og:title" content="Welcome to Sharedream" />
    <meta property="og:description" content="Sharedream is an online comprehensive system for betterment of life of street children and their future. If you find any children working near by your house, working in hotels, motels, dhabbas or residing near by your slum. you can create profile for those children on Sharedream, and share their background story to social media like facebook twitter. We provides an interaction medium where you accept any kind of help from your friends, family, society or the visitors of Sharedream. It is kind of online adoption of the street children where you bring awareness to people around you for those children. You talk to people to spent some time with them, educate them, invite them for dinner or launch, or anything that they can do for your adopted children." />
    <meta property="og:url" content="http://www.sharedream.in/" />
    <meta property="og:image" content="http://www.sharedream.in/Images/sharedreamlogo.png" />
    <meta property="og:image:type" content="image/png" />
    <meta property="og:image:width" content="66" />
    <meta property="og:image:height" content="91" />
    <meta name="Author" content="Zerobuddy" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHLogin" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHDonation" runat="server">
   <center><p>
   <h1>Search a Child:</h1><br />
       <asp:DropDownList ID="DDLSearch" runat="server" Height="37px" 
           style="margin-top: 0px" Width="133px">
       <asp:ListItem Value="2">Search By City</asp:ListItem>
       <asp:ListItem Value="1">Search By Name</asp:ListItem>
       <asp:ListItem Value="3">Search By Country</asp:ListItem>
       </asp:DropDownList>
    <asp:TextBox ID="TBSearch" runat="server" Width="400" Height="30"></asp:TextBox>
    <asp:Button ID="BSearch" runat="server" Text="Search" Height="35" 
           onclick="BSearch_Click"/></p></center>

 <table>
        <asp:Repeater ID="RepChild" runat="server" OnItemDataBound="repAlert_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td>
                        <div>
                            <table>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="LID" runat="server" Visible="false" Text='<%# ((Child)Container.DataItem).ChildID  %>'></asp:Label>
                                        <asp:Image ID="IChildPic1" runat="server" Width="100" Height="100" />
                                    </td>
                                    <td valign="top" width="580" style="padding-left: 10px;">
                                        <div onmouseover="mouseOver('title');" onmouseout="mouseOut('title');" class="ui-titlebar titleme">
                                            <div style="float: left; padding-left: 10px; width: 50%;">
                                                <asp:LinkButton ID="LChildName" runat="server" Font-Bold="True" style="color: white;" Font-Size="Medium"><%# ((Child)Container.DataItem).ChildName  %></asp:LinkButton>
                                                &nbsp;,
                                                <asp:Label ID="LChildAge" runat="server" Text='<%# ((Child)Container.DataItem).ChildAge  %>'></asp:Label>
                                            </div>
                                            <br style="clear: both;" />
                                        </div>
                                        <div style="width: 425px">
                                            <table>
                                                <tr>
                                                    <td valign="top">
                                                        <img src="Photos/comma.png" />
                                                    </td>
                                                    <td>
                                                        <h1>
                                                            <asp:Label ID="Label1" Style=" color: Black; font-family: Lucida Sans Unicode; font-size: 12px;"
                                                                runat="server" Text='<%# ((Child)Container.DataItem).ChildStory  %>'></asp:Label>
                                                        </h1>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <asp:Label ID="LStory" runat="server" Visible="false" Text='<%# ((Child)Container.DataItem).ChildAddress  %>'></asp:Label><br />
                                            <asp:Label ID="LCare" runat="server" Visible="false" Text='<%# ((Child)Container.DataItem).CareNumber  %>'></asp:Label>
                                            <asp:Label ID="LCity" runat="server" Visible="false" Text='<%# ((Child)Container.DataItem).ChildCity  %>'></asp:Label>
                                            <asp:Label ID="LCountry" runat="server" Visible="false" Text='<%# ((Child)Container.DataItem).ChildCountry  %>'></asp:Label>
                                            <div class="button-left-side">
                                            </div>
                                            <div class="button-mid-side floatLeft">
                                                <span>
                                                <asp:LinkButton ID="LBHelp" runat="server" Style="top: -10px; font-weight: bold; position: relative;">Help</asp:LinkButton>
                                                    <asp:LinkButton ID="LBEdit"  runat="server" Visible="false">Edit</asp:LinkButton></span>
                                                <span>
                                            </div>
                                        <div class="button-right-side floatLeft">
                                        </div>
                                   </div>
                        </td> </tr> </table> </div>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
