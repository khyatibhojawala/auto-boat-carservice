<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="regi.aspx.cs" Inherits="regi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Car Registration</h3>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Owner Name</label>
                                <asp:TextBox ID="ownername" runat="server" CssClass="form-control has-error" OnTextChanged="ownername_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                                <asp:Label ID="labelownername" Visible="false" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ownername"
                                    ErrorMessage="Owner name is a required field." ForeColor="Red">
                                </asp:RequiredFieldValidator>
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
                                <asp:TextBox ID="email" runat="server" AutoPostBack="true" CssClass="form-control"
                                    OnTextChanged="email_TextChanged"></asp:TextBox>
                                <asp:Label ID="labelemail" Visible="false" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="email"
                                    ErrorMessage="Email is a required field." ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Contact No.</label>
                                <asp:TextBox ID="contact" MaxLength="10" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"
                                    runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="contact_TextChanged"></asp:TextBox>
                                <asp:Label ID="labelcontact" Visible="false" runat="server" Text="Label"></asp:Label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="contact"
                                    ErrorMessage="Contact is a required field." ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>
                                Car No</label>
                            <div class="form-group">
                                <div class="col-xs-2">
                                    <asp:TextBox ID="carno1" runat="server" CssClass="form-control" Style="width: 600%;
                                        margin-left: -30px;"></asp:TextBox>
                                </div>
                                <div class="col-xs-2">
                                    <asp:TextBox ID="carno2" runat="server" CssClass="form-control" Style="width: 550%;
                                        margin-left: -15px;"></asp:TextBox>
                                </div>
                                <div class="col-xs-2">
                                    <asp:TextBox ID="carno3" runat="server" CssClass="form-control" Style="width: 600%;
                                        margin-left: -10px;" AutoPostBack="true" OnTextChanged="carno3_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-xs-2">
                                    <asp:TextBox ID="carno4" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" MaxLength="4" runat="server" Style="width: 670%;" CssClass="form-control"
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
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" value="Does car has Insurance?"
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
                <!-- /.box-body -->
            </div>
            <!-- Main content -->
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Car Inquiry</h3>
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
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>
                                    Select Services which should apply on Car :
                                </label>
                                <br />
                                <asp:Repeater ID="inqrepeater" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                        <asp:CheckBox ID="servicecategory" CssClass="servicecategory" AutoPostBack="true"
                                            OnCheckedChanged="chkchange" runat="server" Text='<%#Eval("servicename")%>' value='<%#Eval("servicename")%>' />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>
                                Remark</label>
                            <asp:TextBox ID="remark" Text='<%#Eval("remark") %>' TextMode="MultiLine" runat="server"
                                CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>
                                Is FollowUp</label>
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <asp:CheckBox ID="isfollowup" runat="server" />
                                </span>
                                <asp:TextBox ID="txtisfollowup" runat="server" CssClass="form-control" value="Is FollowUp?"
                                    ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>
                                RefrenceNo</label>
                            <asp:TextBox ID="refrenceno" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnsubmit"
                        OnClick="btnsubmit_Click" />
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnupdate"
                        OnClick="btnupdate_Click" />
                    <asp:Label ID="labelmsg" Visible="false" runat="server" Text="label"></asp:Label>
                </div>
            </div>
            <div class="box">
                <div class="box-header">
                    <h3 class="box-title">
                        Data Table Of Car Registration</h3>
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
                                    Owner Name
                                </th>
                                <th>
                                    Adrees
                                </th>
                                <th>
                                    Email
                                </th>
                                <th>
                                    Contact
                                </th>
                                <th>
                                    carno
                                </th>
                                <th>
                                    CarCompany
                                </th>
                                <th>
                                    CarType
                                </th>
                                <th>
                                    CarModel
                                </th>
                                <th>
                                    CarSubModel
                                </th>
                                <th>
                                    CarInsurance
                                </th>
                                <th>
                                    EngineNo
                                </th>
                                <th>
                                    TodayDate
                                </th>
                                
                                <th>
                                    LoginId
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="CarRegiRepeater" OnItemCommand="repeat_ItemCommand" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btnupdate1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("carid") %>'
                                                CommandName="edit"><span class="fa fa-edit"></span></asp:LinkButton>
                                            <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("carid") %>'
                                                CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton>
                                        </td>
                                        <td>
                                            <%#Eval("ownername") %>
                                        </td>
                                        <td>
                                            <%#Eval("address") %>
                                        </td>
                                        <td>
                                            <%#Eval("email") %>
                                        </td>
                                        <td>
                                            <%#Eval("contact") %>
                                        </td>
                                        <td>
                                            <%#Eval("carno") %>
                                        </td>
                                        <td>
                                            <%#Eval("carcompanyname") %>
                                        </td>
                                        <td>
                                            <%#Eval("cartype") %>
                                        </td>
                                        <td>
                                            <%#Eval("carmodelname") %>
                                        </td>
                                        <td>
                                            <%#Eval("carsubmodelname") %>
                                        </td>
                                        <td>
                                            <%#Eval("carinsurance") %>
                                        </td>
                                        <td>
                                            <%#Eval("engineno") %>
                                        </td>
                                        <td>
                                            <%#Eval("tdate") %>
                                        </td>
                                       
                                        <td>
                                            <%#Eval("loginid") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal fade" id="modal-default">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">
                        Alert Box</h4>
                </div>
                <div class="modal-body">
                    <p>
                        Number should not More than 3 charachter</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="recordinserted">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">
                        Alert Box</h4>
                </div>
                <div class="modal-body">
                    <p>
                        Your Record is sucessfully Inserted!</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.content -->
</asp:Content>
