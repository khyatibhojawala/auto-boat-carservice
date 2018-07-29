<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cartype.aspx.cs" Inherits="cartype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Add Car Type</h3>
                    <asp:Label ID="Label1" runat="server" Visible="false" Text="Label1"></asp:Label>
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
                                    car company</label>
                                <asp:DropDownList ID="carcompany" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                
                            </div>
                        </div>
                        
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car Type</label>
                                <asp:TextBox ID="cartype1" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cartype1"
                                    ErrorMessage="Car Type is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
                                
                            </div>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-2">
                            <div class="box-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Insert" ID="btnsubmitcartype"
                                   OnClick="btnsubmit_Click1" />
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Update" ID="btnupdatecartype"
                                   OnClick="btnupdate_Click"  />
                            </div>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                </div>
                <!-- /.box-body -->
            </div>
            
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Data Table Of Car Type</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>Sr no.</th>
                  <th>carcompany Name</th>
                  <th>car Type</th>
            
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="cartypeRepeater" OnItemCommand="repeat_ItemCommand" runat="server">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btnupdatecartype" runat="server" CausesValidation="false" CommandArgument='<%#Eval("cartypeid") %>' CommandName="edit"><span class="fa fa-edit"></span></asp:LinkButton>
                <asp:LinkButton ID="btndeletecartype" runat="server" CausesValidation="false"  CommandArgument='<%#Eval("cartypeid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton></td>
                  <td><%#Eval("carcompanyname") %></td>
                  <td><%#Eval("cartype") %></td>
                   </tr>
                  </ItemTemplate>
                  </asp:Repeater>
               
                
                </tbody>
              </table>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        
            <!-- /.content -->
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

