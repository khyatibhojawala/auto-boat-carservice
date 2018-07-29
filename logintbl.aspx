<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="logintbl.aspx.cs" Inherits="logintbl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Emp Registration</h3>
                    <asp:Label ID="Label2" Visible="false" runat="server" Text="Label2"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="no"></asp:Label>
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
                                <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelusername" Visible="false" runat="server" Text="Label"></asp:Label>
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
                                <label>
                                    Contact</label>
                                <asp:TextBox ID="contact" runat="server" CssClass="form-control" MaxLength="10" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
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
                                    <asp:TextBox ID="DOB" runat="server" 
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
                                <asp:DropDownList ID="dropdeptname" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Password</label>
                                <asp:TextBox ID="password" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="labelpassword" Visible="false" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Password Hint</label>
                                <asp:TextBox ID="passhint" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-md-2">
                            <div class="box-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnsubmit"
                                    OnClick="btnsubmit_Click"  OnClientClick=" Validate();" />
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnupdate"
                                    OnClick="btnupdate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- Main content -->
 
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Data Table Of Login table</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
                <thead> 
                <tr>
                <th>Sr no.</th>
                  <th>Name</th>
                  <th>Surname</th>
                  <th>Username</th>
                  <th>Email</th>
                   <th>Contact</th>
                  <th>DeptName</th>
                  <th>Password</th>
                  <th>PasswordHint</th>
                  <th>DOB</th>
                  <th>EntryDate</th>
                  <th>ModifyDate</th>
                  <th>EmpLoginID</th>
                </tr>
                </thead>
                <tbody>
                <asp:Repeater ID="LogintblRepeater" OnItemCommand="repeat_ItemCommand"  
                        runat="server" onitemdatabound="LogintblRepeater_ItemDataBound">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btnupdate1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("loginid") %>' CommandName="edit"><span class="fa fa-edit"></span></asp:LinkButton>
                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false"  CommandArgument='<%#Eval("loginid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton></td>
                  <td><%#Eval("name") %></td>
                  <td><%#Eval("surname") %></td>
                  <td><%#Eval("username") %></td>
                  <td><%#Eval("email") %></td>
                  <td><%#Eval("contact") %></td>
                  <td><%#Eval("deptname") %></td>
                  <td><%#Eval("password") %></td>
                  <td><%#Eval("passhint") %></td>
                  <td><%#Eval("DOB") %></td>
                  <td><%#Eval("entrydate") %></td>
                  <td><%#Eval("modifydate") %></td>
                  <td><%#Eval("emploginid") %></td>
                   </tr>
                  </ItemTemplate>
                  </asp:Repeater>
                </tbody>
              </table>
            </div>
            <!-- /.box-body -->
          </div>

            <!-- /.content -->
        </ContentTemplate>
    </asp:UpdatePanel>
        <%--Birthday Count --%>
     <script type="text/javascript">
         function Validate() {
             var enteredValue = document.getElementById('<%=DOB.ClientID %>');
             var enteredAge = getAge(enteredValue.value);
             if (enteredAge < 18) {
                 $('#<%= Label1.ClientID %>').text("yes")
                 alert("DOB less than 18");
                 enteredValue.focus();
                 return false;
             }
         }
         function getAge(DOB) {
             var today = new Date();
             var birthDate = new Date(DOB);
             var age = today.getFullYear() - birthDate.getFullYear();
             var m = today.getMonth() - birthDate.getMonth();
             if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                 age--;
             }
             return age;
         }
    </script>
        <%--End Birthday Count --%>
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
                        update </p>
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
