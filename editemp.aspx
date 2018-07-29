<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editemp.aspx.cs" Inherits="editemp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Edit Employee</h3>
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
                                    Name</label>
                                <asp:TextBox ID="name" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelname" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Surname</label>
                                <asp:TextBox ID="surname" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelsurname" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    username</label>
                                <asp:TextBox ID="username" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelusername" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Email</label>
                                <asp:TextBox ID="email" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelemail" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Contact</label>
                                <asp:TextBox ID="contact" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelcontact" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    DOB:</label>
                                <div class="input-group date">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                    <asp:TextBox ID="DOB" Enabled="false" runat="server" 
                                        CssClass="form-control pull-right datepicker"></asp:TextBox>
                                    <asp:Label ID="labelDOB" Visible="false" runat="server" Text="Label"></asp:Label>
                                </div>
                                <!-- /.input group -->
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    DeptName</label>
                                <asp:TextBox ID="dropdeptname" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Password</label>
                                <asp:TextBox ID="password" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelpassword" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Password Hint</label>
                                <asp:TextBox ID="passhint" AutoPostBack="true" runat="server" CssClass="form-control" 
                                    ontextchanged="passhint_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-md-2">
                            <div class="box-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" 
                                    ID="btnsubmit" onclick="btnsubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.box-body -->
            </div>
                <%--alert dailogbox for carno should not more than 3 character--%>
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
                       password and passwordHint only first four character can be same!</p>
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
     <%--end alert dailogbox for carno should not more than 3 character--%>
      <div class="modal fade" id="updatedisplay">
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
                       Your data is updated!</p>
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

    <div class="modal fade" id="passlength">
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
                      password should be of minimum length of 5 characters!</p>
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
</asp:Content>

