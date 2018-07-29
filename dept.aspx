<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="dept.aspx.cs" Inherits="dept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Department Registration</h3>
                    <asp:Label ID="Label1" Visible="false" runat="server" Text="Label1"></asp:Label>
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
                                    Dept Name</label>
                                <asp:TextBox ID="deptname" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="footer">
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnsubmit"
                            OnClick="btnsubmit_Click" />
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnupdate"
                            OnClick="btnupdate_Click" />
                    </div>
                </div>
            </div>
            <!-- Main content -->

          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Data Table Of Car Registration</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>Sr no.</th>
                  <th>DeptName</th>
                 
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="CarRegiRepeater" OnItemCommand="repeat_ItemCommand" runat="server">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btnupdate" runat="server" CausesValidation="false" CommandArgument='<%#Eval("deptid") %>' CommandName="edit"><span class="fa fa-edit"></span></asp:LinkButton>
                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("deptid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton></td>
                  <td><%#Eval("deptname") %></td>
                 
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
</asp:Content>
