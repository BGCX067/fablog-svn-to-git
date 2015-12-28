<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Title="andersoncentral.org - Home" EnableEventValidation="false" %>

<%@ Register src="Controls/BlogView.ascx" tagname="BlogView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:BlogView ID="BlogView1" runat="server" />
    
</asp:Content>

