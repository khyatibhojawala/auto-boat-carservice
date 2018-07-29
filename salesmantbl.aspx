<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="salesmantbl.aspx.cs" Inherits="workerstbl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Salesman Name</h3>
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
                                    SalesMan Name</label>
                                <asp:TextBox ID="salesmanname" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    Workers DeptName</label>
                                <asp:DropDownList ID="dropdeptname" CssClass="form-control" runat="server">
                                <asp:ListItem>Select Workers Department</asp:ListItem>
                                <asp:ListItem Text="OILING" Value="OLILING"></asp:ListItem>
                                <asp:ListItem Text="ENGINE" Value="ENGINE"></asp:ListItem>
                                <asp:ListItem Text="BREAKS" Value="BREAKS"></asp:ListItem>
                                <asp:ListItem Text="WHEELS" Value="WHEELS"></asp:ListItem>
                                <asp:ListItem Text="WASHING" Value="WASHING"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="footer">
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnsubmit"
                            OnClick="btnsubmit_Click" />
                    </div>
                </div>
            </div>
            <!-- Main content -->

          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Data Table Of Salesman</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>Sr no.</th>
                  <th>SalesMan Name</th>
                  <th>Worker's DeptName</th>
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="CarRegiRepeater" runat="server" onitemcommand="CarRegiRepeater_ItemCommand">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("salesmanid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton></td>
                  <td><%#Eval("salesmanname")%></td>
                  <td><%#Eval("salesdeptname")%></td>
                   </tr>
                  </ItemTemplate>
                  </asp:Repeater>
               
                
                </tbody>
              </table>
            </div>
            <!-- /.box-body -->
          </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
