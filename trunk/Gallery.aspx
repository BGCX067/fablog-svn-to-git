<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Default2" Title="Photo Gallery" %>

<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Photo Gallery</h1>
    <p>
        Currently working out the details of embedding all of the PicasaWeb RSS stream on
        this page.&nbsp; Hence the extra garbage data... You get the idea though :)</p>
    <p>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="RssDataSource1">
            <ItemTemplate>
                author:
                <asp:Label ID="authorLabel" runat="server" Text='<%# Eval("author") %>'></asp:Label><br />
                description:
                <asp:Label ID="descriptionLabel" runat="server" Text='<%# Eval("description") %>'>
                </asp:Label><br />
                link:
                <asp:Label ID="linkLabel" runat="server" Text='<%# Eval("link") %>'></asp:Label><br />
                pubDate:
                <asp:Label ID="pubDateLabel" runat="server" Text='<%# Eval("pubDate") %>'></asp:Label><br />
                pubDateParsed:
                <asp:Label ID="pubDateParsedLabel" runat="server" Text='<%# Eval("pubDateParsed") %>'>
                </asp:Label><br />
                title:
                <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>'></asp:Label><br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <cc1:RssDataSource ID="RssDataSource1" runat="server" MaxItems="0" Url="http://picasaweb.google.com/data/feed/base/user/jenrenanderson?kind=album&alt=rss&hl=en_US&access=public">
        </cc1:RssDataSource>
    </p>
    
</asp:Content>

