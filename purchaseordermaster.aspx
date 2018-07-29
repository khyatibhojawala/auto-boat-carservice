<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="purchaseordermaster.aspx.cs" Inherits="purchaseordermaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Customer Record Details</h3>
                    <asp:Label ID="Label1" Visible="false" runat="server" Text="Label"></asp:Label>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool">
                            <i class="fa fa-minus"></i>
                        </button>
                        <button type="button" class="btn btn-box-tool">
                            <i class="fa fa-remove"></i>
                        </button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Contact No.</label>
                                <asp:TextBox ID="contact" runat="server" CssClass="form-control contact" AutoPostBack="true"
                                    OnTextChanged="contact_TextChanged" MaxLength="10" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                                <asp:Label ID="labelcontact" Visible="false" runat="server" Text="Label"></asp:Label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="contact"
                                    ErrorMessage="Contact is a required field." ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Owner Name</label>
                                <asp:TextBox ID="ownername" runat="server" CssClass="form-control has-error" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="labelownername" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Address</label>
                                <asp:TextBox ID="address" ReadOnly="true" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Email</label>
                                <asp:TextBox ID="email" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelemail" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Car No</label>
                                    <asp:TextBox ReadOnly="true" ID="carno" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car company</label>
                                <asp:DropDownList ID="carcompany" CssClass="form-control" runat="server" Enabled="false"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car type</label>
                                <asp:DropDownList ID="cartype" CssClass="form-control" runat="server" Enabled="false"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car model</label>
                                <asp:DropDownList ID="carmodel" CssClass="form-control" runat="server" Enabled="false"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car submodel</label>
                                <asp:DropDownList ID="carsubmodel" CssClass="form-control" runat="server" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Car Insurance</label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <asp:CheckBox ReadOnly="true" ID="carinsurance" runat="server" />
                                    </span>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" value="Does car has Insurance?"
                                        ReadOnly="true" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Engine No</label>
                                <asp:TextBox ID="engineno" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.box-body -->
            </div>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Sales Order Master</h3>
                    <asp:Label ID="Label3" runat="server" Visible="false" Text="Label"></asp:Label>
                    <asp:Label ID="Label2" Visible="false" runat="server" Text="Label2"></asp:Label>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool">
                            <i class="fa fa-minus"></i>
                        </button>
                        <button type="button" class="btn btn-box-tool">
                            <i class="fa fa-remove"></i>
                        </button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>
                                    Select GST type which will apply on Service Amount :</label>
                                <asp:DropDownList ID="gsttype" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="cgst,sgst" Text="cgst,sgst">CGST/SGST</asp:ListItem>
                                    <asp:ListItem Value="igst" Text="igst">IGST</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>
                                    Select Parts want to buy :</label>
                                <asp:DropDownList ID="parts" CssClass="form-control" runat="server" 
                                    onselectedindexchanged="parts_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--<div class="col-md-12">
                            <div class="form-group">
                                <label>
                                    Select Services which should apply on Car :
                                </label>
                                <br />
                                <asp:Repeater ID="repeaterPOM" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                        <asp:CheckBox ID="partname" CssClass="servicecategory"
                                            AutoPostBack="true" runat="server" Text='<%#Eval("partname")%>' value='<%#Eval("partname")%>' />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>--%>
                    </div>
                    <div class="row">
                    <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Part Price</label>
                                <asp:TextBox ReadOnly="true" ID="partprice" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Quantity</label>
                                <asp:TextBox ID="quantity" runat="server" CssClass="form-control" 
                                    ontextchanged="quantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Total Amount</label>
                                <asp:TextBox ReadOnly="true" ID="totalamount" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>
                                    Worker Name</label>
                                <asp:DropDownList ID="salesmanname" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Remark</label>
                                <asp:TextBox ID="remark" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Refrence No</label>
                                <asp:TextBox ID="refrenceno" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                </div>
                <div class="box-footer">
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnsubmit"
                        OnClick="btnsubmit_Click" />
                </div>
            </div>
            <div class="box">
                <div class="box-header">
                    <h3 class="box-title">
                        Data Table Of Sales Master</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <table id="example" class="display nowrap table table-bordered table-striped ">
                        <thead>
                            <tr>
                                <th>
                                    Sr no.
                                </th>
                                <th>
                                    car owner contact
                                </th>
                                <th>
                                    orderno
                                </th>
                                <th>
                                    refno
                                </th>
                                <th>
                                    partname
                                </th>
                                <th>
                                    price
                                </th>
                                <th>
                                    Remark
                                </th>
                                <th>
                                    sgst
                                </th>
                                <th>
                                    cgst
                                </th>
                                <th>
                                    igst
                                </th>
                                <th>
                                    taxamt
                                </th>
                                <th>
                                    netamt
                                </th>
                                <th>
                                    discount
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="POMRepeaterMaintain" OnItemCommand="repeat_ItemCommand" runat="server"
                                OnItemDataBound="POMRepeaterMaintain_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("purchaseordermaintainid") %>'
                                                CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton>
                                        </td>
                                        <td>
                                            <%#Eval("contact")%>
                                        </td>
                                        <td>
                                            <%#Eval("orderno")%>
                                        </td>
                                        <td>
                                            <%#Eval("refno")%>
                                        </td>
                                        <td>
                                            <%#Eval("partname")%>
                                        </td>
                                        <td>
                                            <%#Eval("price")%>
                                        </td>
                                        <td>
                                            <%#Eval("remark")%>
                                        </td>
                                        <td>
                                            <%#Eval("sgst")%>
                                        </td>
                                        <td>
                                            <%#Eval("cgst")%>
                                        </td>
                                        <td>
                                            <%#Eval("igst")%>
                                        </td>
                                        <td>
                                            <%#Eval("taxamt")%>
                                        </td>
                                        <td>
                                            <%#Eval("netamt")%>
                                        </td>
                                        <td>
                                            <%#Eval("discount")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <!-- /.box-body -->
            </div>
                <div class="box-default">
        <asp:Button runat="server" CssClass="btn btn-primary" Text="Print" ID="printbtn" CausesValidation="false"
            Style="margin-left: 450px; height: 35px; width: 70px;" onclick="printbtn_Click"  />
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
