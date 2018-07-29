<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="carcompany.aspx.cs" Inherits="carcompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Add Car Company</h3>
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
                                    car company name</label>
                                <asp:TextBox ID="carcompanyname" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="carcompanyname"
                                    ErrorMessage="carcompanyname is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-2">
                            <div class="box-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Insert" ID="btnsubmitcarcompany"
                                    OnClick="btnsubmit_Click1" />
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Update" ID="btnupdatecarcompany"
                                    OnClick="btnupdate_Click" />
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
              <h3 class="box-title">Data Table Of Car Company</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>Sr no.</th>
                  <th>carcompany Name</th>
                  
            
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="carcompanyRepeater" OnItemCommand="repeat_ItemCommand" runat="server">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btnupdatecarcompany" runat="server" CausesValidation="false" CommandArgument='<%#Eval("carcompanyid") %>' CommandName="edit"><span class="fa fa-edit"></span></asp:LinkButton>
                <asp:LinkButton ID="btndeletecarcompany" runat="server" CausesValidation="false" CommandArgument='<%#Eval("carcompanyid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton></td>
               
                  <td><%#Eval("carcompanyname") %></td>
                  
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

