<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageClient.master" AutoEventWireup="true"
    CodeFile="Inquiry.aspx.cs" Inherits="Client_Inquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Main -->
    <!-- Contact -->
    <div class="con-agile">
        <div class="container">
            <h2>
                Car Inquiry</h2>
            <div class="contact-form">
                <h4>
                    Register Your Car</h4>
                <form action="" method="post">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="ownername" runat="server" placeholder="Owner Name" required="true" /><asp:Label
                            ID="labelownername" runat="server" Text="labelownername"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-md-6 form-left">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="contact" runat="server" placeholder="Phone" required="true" />
                            <asp:Label ID="labelcontact" runat="server" Text="labelcontact"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-6 form-right">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="email" runat="server" placeholder="Email" /><asp:Label ID="labelemail"
                                runat="server" Text="labelemail"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="address" runat="server" placeholder="Address" TextMode="MultiLine" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-md-6 form-left">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="carno" runat="server" placeholder="Car No" required="true" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-6 form-right">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="engineno" runat="server" placeholder="Engine No" required="true" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                
                <div class="col-md-3 form-left">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="carcompany" runat="server" placeholder="Car Company" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-3 form-right">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="carmodel" runat="server" placeholder="Car Model" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-6 form-left">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox ID="carinsurance" runat="server" Text="Car has any Insurance?" Style="color: White;
                                font-size: 15px; padding-left: 5px; padding-top: 0.8em; padding-bottom: 0.8em;
                                padding-left: 1em; margin-bottom: 1em; display: inline-block; border-bottom: solid 1px #fff;" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="contact-map">
            <iframe src="" allowfullscreen></iframe>
        </div>
    </div>
    <br />
    <br />
    <br />
    <div class="con-agile">
        <form>
        <div class="container">
            <div class="contact-form">
                <h4>
                    Inquiry Form</h4>
                <div class="col-md-6 form-right">
                    
                            <asp:TextBox ID="orderno" runat="server" placeholder="Order No " Enabled="false" />
                        
                </div>
                <div class="col-md-6 form-right">
                    
                            <asp:TextBox ID="referenceno" runat="server" placeholder="Reference No" Enabled="false" />
                        
                </div>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label2" runat="server" Text="Select Service Categories For Your Car HERE:"
                            Style="color: White; font-size: 15px; padding-left: 5px; padding-top: 0.8em;
                            padding-right: 1em; padding-bottom: 0.8em; padding-left: 1em; margin-bottom: 1em;
                            display: inline-block;"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:Repeater ID="inqrepeater" runat="server">
                            <ItemTemplate>
                                <div class="col-md-4">
                                    <asp:CheckBox ID="servicecategory" CssClass="servicecategory" AutoPostBack="true"
                                        OnCheckedChanged="chkchange" runat="server" Text='<%#Eval("servicename")%>' Value='<%#Eval("servicename")%>'
                                        Style="color: White; font-size: 15px; padding-left: 5px; padding-top: 0.8em;
                                        padding-right: 1em; padding-bottom: 0.8em; padding-left: 1em; margin-bottom: 1em;
                                        display: inline-block; border-bottom: solid 1px #fff;" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
                Integer i=0;
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblservicecat" runat="server" Text="" Enabled="false"></asp:Label>
                        <asp:TextBox ID="remark" CssClass="remark" runat="server" placeholder="Remark" TextMode="MultiLine" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="submit" runat="server" Text="Button" OnClick="submit_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        </form>
        <div class="contact-map">
            <iframe src="" allowfullscreen></iframe>
        </div>
    </div>
    <!-- //Contact -->
    <!-- //Main -->
</asp:Content>
