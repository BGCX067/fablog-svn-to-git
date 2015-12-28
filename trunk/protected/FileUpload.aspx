<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="FileUpload" Title="File Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>

<h1>File Upload</h1>
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />&nbsp;</p>
    <p>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>&nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>

</asp:Content>

