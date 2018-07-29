<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="carmodel.aspx.cs" Inherits="carmodel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Add Car Model</h3>
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
                                <asp:DropDownList ID="carcompany" CssClass="form-control" runat="server" 
                                 AppendDataBoundItems="true" AutoPostBack="true" 
                                    onselectedindexchanged="carcompany_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car type</label>
                                <asp:DropDownList ID="cartype" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car model</label>
                                <asp:TextBox ID="carmodel1" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="carmodel1"
                                    ErrorMessage="Car Model is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
                                
                            </div>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-2">
                            <div class="box-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Insert" ID="btnsubmitcarmodel"
                                   OnClick="btnsubmit_Click1" />
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Update" ID="btnupdatecarmodel"
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
              <h3 class="box-title">Data Table Of Car Model</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>Sr no.</th>
                  <th>carcompany Name</th>
                  <th>car Type</th>
                  <th>car Model</th>
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="carmodelRepeater" OnItemCommand="repeat_ItemCommand" runat="server">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btnupdatecarmodel" runat="server" CausesValidation="false"  CommandArgument='<%#Eval("carmodelid") %>' CommandName="edit"><span class="fa fa-edit"></span></asp:LinkButton>
                <asp:LinkButton ID="btndeletecarmodel" runat="server" CausesValidation="false"  CommandArgument='<%#Eval("carmodelid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton></td>
                  <td><%#Eval("carcompanyname") %></td>
                  <td><%#Eval("cartype") %></td>
                  <td><%#Eval("carmodelname") %></td>
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

