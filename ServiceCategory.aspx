<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ServiceCategory.aspx.cs" Inherits="ServiceCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Service Entry</h3>
                    <asp:Label ID="Label1" Visible="false" runat="server" Text="Label2"></asp:Label>
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
                                    ServiceName</label>
                                <asp:TextBox ID="servicename" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="servicename"
                                    ErrorMessage="Servicename is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    price</label>
                                <asp:TextBox ID="price" runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="price"
                                    ErrorMessage="Price is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    SGST</label>
                                <asp:TextBox ID="sgst" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    CGST</label>
                                <asp:TextBox ID="cgst" runat="server" CssClass="form-control" AutoPostBack="true"
                                    ontextchanged="cgst_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    IGST</label>
                                <asp:TextBox ID="igst" runat="server" AutoPostBack="true" CssClass="form-control" 
                                    ontextchanged="igst_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="box-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnsubmit"
                                    OnClick="btnsubmit_Click1" />
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnupdate"
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
              <h3 class="box-title">Data Table Of Car Services</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>Sr no.</th>
                  <th>Service Name</th>
                  <th>Date</th>
                  <th>LoginId</th>
                  <th>Price</th>
                   <th>SGST</th>
                  <th>CGST</th>
                  <th>IGST</th>
            
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="servicecategoryRepeater" OnItemCommand="repeat_ItemCommand" 
                        runat="server" onitemdatabound="servicecategoryRepeater_ItemDataBound">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btnupdate" runat="server" CausesValidation="false" CommandArgument='<%#Eval("servicecategoryid") %>' CommandName="edit"><span class="fa fa-edit"></span></asp:LinkButton>
                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false"  CommandArgument='<%#Eval("servicecategoryid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton></td>
                  <td><%#Eval("servicename") %></td>
                  <td><%#Eval("tdate") %></td>
                  <td><%#Eval("loginid") %></td>
                  <td><%#Eval("price") %></td>
                  <td><%#Eval("sgst") %></td>
                  <td><%#Eval("cgst") %></td>
                  <td><%#Eval("igst") %></td>
                  
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
