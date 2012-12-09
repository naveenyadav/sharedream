<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Helpchild.aspx.cs" Inherits="Zero.ShareDream.Helpchild" %>

<%@ Import Namespace="Zero.ShareDream" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:PlaceHolder id="MetaPlaceHolder" runat="server" />
    <asp:PlaceHolder id="MetaPlaceHolder1" runat="server" />
    <asp:PlaceHolder id="MetaPlaceHolder2" runat="server" />
    <asp:PlaceHolder id="MetaPlaceHolder3" runat="server" />
    <asp:PlaceHolder id="MetaPlaceHolder4" runat="server" />
    <asp:PlaceHolder id="MetaPlaceHolder5" runat="server" />
     <asp:PlaceHolder id="Metatitle" runat="server" />
    
    
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHLogin" runat="server">
   
</asp:Content>
<asp:Content ID="Content3"  ContentPlaceHolderID="CPHDonation" runat="server">

    <table>
        <tr>
            <td valign="top">
                <asp:Label ID="LID" runat="server" Visible="false"></asp:Label>
                <asp:Image ID="IChildPic1" runat="server" Width="150" Height="150" />
                  <div>
                 
                <asp:LinkButton ID="LBTwitter" runat="server" ></asp:LinkButton> <br /><br />
                      <asp:Label ID="LBFacebook" style="position: relative;" runat="server" ></asp:Label>
                    </div>
            </td>
            <td valign="top"  style="padding-left: 10px;">
                <div id="title" onmouseover="mouseOver('title');" onmouseout="mouseOut('title');" class="ui-titlebar titleme" >
                    <div style="float: left;padding-left: 10px; width: 50%;">
                        <asp:LinkButton ID="LChildName" runat="server" CssClass="ui-child-name" Font-Bold="True" Font-Size="Medium"></asp:LinkButton>
                        &nbsp;,
                        <asp:Label ID="LChildAge" runat="server"></asp:Label>
                    </div>
                    
                    <br style="clear: both;" />
                </div>
                <div style="width: 425px">
                <table>
                <tr>
                <td valign="top"><img src="Photos/comma.png" /></td>
                    
                <td>
                <h1><asp:Label ID="Label1" style="font-size: 12px;color: Black;font-family: Lucida Sans Unicode;"  runat="server"></asp:Label></h1>
                </td></tr>
                </table>
                <br />
                <asp:Label ID="LCare" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="LCity" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="LCountry" runat="server" Visible="false"></asp:Label>
                </div>
            </td>
            </tr>
            <tr>
            <td colspan="2">
          
            </td>
            </tr>
            </table>
    <asp:Label ID="LKind" runat="server" ></asp:Label>
    
    <table>
        <asp:Repeater ID="RepHelp" runat="server" OnItemDataBound="repAlert_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td valign="top" width="580" >
                        <div style="width: 100%; border: 1px solid aqua; padding: 20px;">
                            <asp:LinkButton ID="LChildName"  CssClass="ui-header-name" runat="server" Font-Bold="True" Font-Size="Medium"><%# ((Help)Container.DataItem).HelperName  %></asp:LinkButton>
                            &nbsp;,
                            <asp:Label ID="LChildAge" runat="server" Text='<%# ((Help)Container.DataItem).HelperEmail  %>'></asp:Label>
                            <asp:Label ID="LMobile" runat="server" Text='<%# ((Help)Container.DataItem).HelperMobileNo  %>'></asp:Label><br />
                            <table><tr>
                            <td valign="top" >
                                <img src="Photos/comma.png" />
                            </td>
                            <td><h1><asp:Label ID="LStory" style="font-size: 14px;" runat="server" Text='<%# ((Help)Container.DataItem).HelperHelp  %>'></h1></asp:Label>
                            </td></tr>
                            
                            </table>
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <br style="clear: both;" />

    <h1>
        Please Fill the detail to help:</h1>
    <table>
        <tr>
            <td  valign="top">
                Full Name :
            </td>
            <td>
                <asp:TextBox ID="TBName" runat="server" Width="500" Height="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                Email :
            </td>
            <td>
                <asp:TextBox ID="TBEmail" runat="server" Width="500" Height="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Write How to Help :
            </td>
            <td>
                <asp:TextBox ID="TBHelp" runat="server" TextMode="MultiLine" Width="500" Height="70"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                Mobile No :
            </td>
            <td>
                <asp:TextBox ID="TBMobileNo" runat="server" Width="500" Height="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="BSubmit" runat="server" Text="Submit" OnClick="BSubmit_Click" />
            </td>
        </tr>
    </table>
   <br style=" clear: both;" />

</asp:Content>
