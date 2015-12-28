<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreatePost.aspx.cs" Inherits="CreatePost" Title="andersoncentral.org homepage" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Create/Edit a Blog Entry</h1>
    <p><b>Title:</b></p>
    <p><asp:TextBox ID="TextBox1" runat="server" Width="344px"></asp:TextBox></p>
    <br />
    <p><FTB:FreeTextBox ID="FreeTextBox1" runat="server" FormatHtmlTagsToXhtml="False" RenderMode="Rich" BackColor="Gray" ButtonSet="Office2000" GutterBackColor="Silver" Width="515px">
    </FTB:FreeTextBox></p>
    <p><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" /></p>
</asp:Content>

