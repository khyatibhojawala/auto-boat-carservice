<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ServiceOrderMaster.aspx.cs" Inherits="ServiceOrderMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Car Registration</h3>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
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
                                <asp:TextBox ID="ownername" runat="server" CssClass="form-control has-error"></asp:TextBox>
                                <asp:Label ID="labelownername" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Address</label>
                                <asp:TextBox ID="address" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Email</label>
                                <asp:TextBox ID="email" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelemail" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label style="margin-left: 2%;">
                                    Car No</label>
                                <div class="form-group">
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="carno1" runat="server" CssClass="form-control" Style="width: 550%;
                                            margin-left: -15px;"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="carno2" runat="server" CssClass="form-control" Style="width: 550%;
                                            margin-left: -10px;"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="carno3" runat="server" CssClass="form-control" Style="width: 550%;
                                            margin-left: -5px;" AutoPostBack="true" OnTextChanged="carno3_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox ID="carno4" MaxLength="4" runat="server" Style="width: 700%;" CssClass="form-control"
                                            AutoPostBack="true" OnTextChanged="carno4_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car company</label>
                                <asp:DropDownList ID="carcompany" CssClass="form-control" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="carcompany_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car type</label>
                                <asp:DropDownList ID="cartype" CssClass="form-control" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="cartype_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car model</label>
                                <asp:DropDownList ID="carmodel" CssClass="form-control" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="carmodel_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car submodel</label>
                                <asp:DropDownList ID="carsubmodel" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Car Insurance</label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <asp:CheckBox ID="carinsurance" runat="server" />
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
                                <asp:TextBox ID="engineno" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.box-body -->
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Service Order Master</h3>
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
                                    <asp:ListItem Value="cgst,sgst" Text="CGST/SGST"></asp:ListItem>
                                    <asp:ListItem Value="igst" Text="IGST"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>
                                    Select Services which should apply on Car :
                                </label>
                                <br />
                                <asp:Repeater ID="repeaterSOM" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                        <asp:CheckBox ID="servicecategory" CssClass="servicecategory" runat="server" Text='<%#Eval("servicename")%>'
                                            AutoPostBack="true" OnCheckedChanged="chkchange" value='<%#Eval("servicename")%>' />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Refrence No</label>
                                <asp:TextBox ID="refrenceno" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Car InquiryNumber</label>
                                <asp:TextBox ID="carinquiryid" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    TotalNumOFService</label>
                                <asp:TextBox ID="totalnumofservice" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="totalnumofservice"
                                    ErrorMessage="Select one Category"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Total Amount</label>
                                <asp:TextBox Enabled="false" ID="totalamount" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Remark</label>
                                <asp:TextBox ID="remark" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <asp:CheckBox ID="isservicestart" runat="server" Enabled="False" />
                                    </span>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" value="Is Service Start?"
                                        ReadOnly="true" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
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
                                    Start Service Date</label>
                                <div class="input-group date">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                    <asp:TextBox ID="startservicedate" Enabled="false" runat="server" CssClass="form-control pull-right datepicker"></asp:TextBox>
                                </div>
                                <!-- /.input group -->
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Choose Days or Months</label>
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Text="Select Duration" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="1 Day" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2 Day" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="5 Day" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="7 Day" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="10 Day" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="12 Day" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="15 Day" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="1 month" Value="1month"></asp:ListItem>
                                    <asp:ListItem Text="2 month" Value="2month"></asp:ListItem>
                                    <asp:ListItem Text="3 month" Value="3month"></asp:ListItem>
                                </asp:DropDownList>
                                <!-- /.input group -->
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    End Service Date</label>
                                <div class="input-group date">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                    <asp:TextBox ID="endservicedate" Enabled="false" runat="server" CssClass="form-control pull-right datepicker"></asp:TextBox>
                                </div>
                                <!-- /.input group -->
                            </div>
                        </div>
                    </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="box-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnsubmit"
                                    OnClick="btnsubmit_Click1" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.box-body -->
            </div>
            <div class="box">
                <div class="box-header">
                    <h3 class="box-title">
                        Data Table Of Service Order Master</h3>
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
                                    Order No.
                                </th>
                                <th>
                                    Car EngineNo.
                                </th>
                                <th>
                                    Master ID
                                </th>
                                <th>
                                    ServiceCategory Name
                                </th>
                                <th>
                                    Reference No.
                                </th>
                                <th>
                                    Price
                                </th>
                                <th>
                                    Sgst
                                </th>
                                <th>
                                    Cgst
                                </th>
                                <th>
                                    Igst
                                </th>
                                <th>
                                    Tax Amount
                                </th>
                                <th>
                                    Net/Total amt
                                </th>
                                <th>
                                    Discount
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="SOMRepeaterMaintain" OnItemCommand="repeat_ItemCommand" runat="server"
                                OnItemDataBound="SOMRepeaterMaintain_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("serviceordermaintainid") %>'
                                                CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton>
                                        </td>
                                        <td>
                                            <%#Eval("orderno")%>
                                        </td>
                                        <td>
                                            <%#Eval("engineno")%>
                                        </td>
                                        <td>
                                            <%#Eval("som")%>
                                        </td>
                                        <td>
                                            <%#Eval("servicename")%>
                                        </td>
                                        <td>
                                            <%#Eval("refno")%>
                                        </td>
                                        <td>
                                            <%#Eval("price")%>
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
                    Style="margin-left: 450px; height: 35px; width: 70px;" OnClick="printbtn_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
