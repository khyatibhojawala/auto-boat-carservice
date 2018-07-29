
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="parts.aspx.cs" Inherits="parts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        Add Parts</h3>
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
                                    Partname</label>
                                <asp:TextBox ID="partname" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="partname"
                                    ErrorMessage="PartName is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car company</label>
                                <asp:DropDownList ID="carcompany" CssClass="form-control" runat="server" 
                                     AutoPostBack="true" 
                                    onselectedindexchanged="carcompany_SelectedIndexChanged">
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="carcompany"
                                    ErrorMessage="CarCompanyName is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car type</label>
                                <asp:DropDownList ID="cartype" CssClass="form-control" runat="server" 
                                     AutoPostBack="true" onselectedindexchanged="cartype_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    car model</label>
                                <asp:DropDownList ID="carmodel" CssClass="form-control" runat="server" AutoPostBack="true"
                                    onselectedindexchanged="carmodel_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        </div>
                        <div class="row">
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
                                    Part price</label>
                                <asp:TextBox ID="partprice" runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="partprice"
                                    ErrorMessage="PartPrice is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
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
                                <asp:TextBox ID="cgst" runat="server" CssClass="form-control" 
                                    ontextchanged="cgst_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                        <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    IGST</label>
                                <asp:TextBox ID="igst" runat="server" CssClass="form-control" 
                                    ontextchanged="igst_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>
                                    remark</label>
                                <asp:TextBox ID="remark" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>
                                    part code</label>
                                <asp:TextBox ID="partcode" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                        </div>
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
              <h3 class="box-title">Data Table Of Car Parts</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>Sr no.</th>
                  <th>part name</th>
                  <th>carcompany Name</th>
                  <th>cartype</th>
                  <th>carmodel</th>
                  <th>carsubmodel</th>
                  <th>carPrice</th>
                   <th>SGST</th>
                  <th>CGST</th>
                  <th>IGST</th>
                  <th>remark</th>
                  <th>partcode</th>
                  <th>loginid</th>
                  <th>LastModifiedDate</th>
            
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="partRepeater" OnItemCommand="repeat_ItemCommand" runat="server" 
                        onitemdatabound="partRepeater_ItemDataBound">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btnupdate" runat="server" CausesValidation="false" CommandArgument='<%#Eval("partid") %>' CommandName="edit"><span class="fa fa-edit"></span></asp:LinkButton>
                <asp:LinkButton ID="btndelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("partid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton></td>
                  <td><%#Eval("partname") %></td>
                  <td><%#Eval("carcompanyname") %></td>
                  <td><%#Eval("cartype") %></td>
                  <td><%#Eval("carmodelname") %></td>
                  <td><%#Eval("carsubmodelname") %></td>
                  <td><%#Eval("partprice") %></td>
                  <td><%#Eval("sgst") %></td>
                  <td><%#Eval("cgst") %></td>
                  <td><%#Eval("igst") %></td>
                  <td><%#Eval("remark") %></td>
                  <td><%#Eval("partcode") %></td>
                  <td><%#Eval("loginid") %></td>
                  <td><%#Eval("tdate") %></td>
                  
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
