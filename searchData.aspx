<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="searchData.aspx.cs" Inherits="searchData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content">

      <div class="box box-default">
        <div class="box-header with-border">
          <h3 class="box-title">Find Form MobileNumber</h3>

          <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
          </div>
        </div>
        <div class="box-body">
          <div class="row">
            <div class="col-md-3">
              <div class="form-group">
                <label>Contact No</label>
                <asp:DropDownList ID="contactnodrop" CssClass="form-control select2" 
                      style="width: 100%;" runat="server" AutoPostBack="true"
                      onselectedindexchanged="contactnodrop_SelectedIndexChanged"></asp:DropDownList>
              </div>
            </div>
            <div class="col-md-3">
              <div class="form-group">
                <label>OrderMaster</label>
                <asp:TextBox ID="ordermasterrefno" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            </div>
            <div class="col-md-3">
              <div class="form-group">
                <label>Sales</label>
                <asp:TextBox ID="salesrefno" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            </div>
             <div class="col-md-3">
             </div>
          </div>
          <div class="row">
             <div class="col-md-3">
             </div>
             <div class="col-md-3">
             <div class="form-group">
               <asp:Button ID="btnaddOrderMaster" CssClass="btn btn-default" runat="server" 
                     Text="AddOrderMaster" onclick="btnaddOrderMaster_Click"></asp:Button>
              </div>
             </div>
             <div class="col-md-3">
               <div class="form-group">
               <asp:Button ID="btnaddPurchaseMaster" CssClass="btn btn-default" runat="server" 
                       Text="AddSalesMaster" onclick="btnaddPurchaseMaster_Click"></asp:Button>
              </div>
             </div>
             <div class="col-md-3">
             </div>
         
          </div>
          <!-- /.row -->
        </div>
        </div>
        <asp:Panel ID="panelDisplayData" runat="server" >
            <div class="box">
            <div class="box-header">
              <h3 class="box-title">Data Table Of Service Order Master</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example1" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                  <tr>
                <th>Sr no.</th>
                  <th>Order No.</th>
                  <th>ServiceCategory Name</th>
                  <th>Price</th>
                  <th>Sgst</th>
                  <th>Cgst</th>
                   <th>Igst</th>
                  <th>Tax Amount</th>
                  <th>Net/Total amt</th>
                   <th>Discount</th>
            
                </tr>
                
                </thead>
                <tbody>
                
                <asp:Repeater ID="displaydataRepeater" runat="server" 
                        onitemcommand="displaydataRepeater_ItemCommand" 
                        onitemdatabound="displaydataRepeater_ItemDataBound">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btndelete" runat="server"  CommandArgument='<%#Eval("serviceordermaintainid") %>'  CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton>
               </td>
                  <td><%#Eval("orderno")%></td>
                  <td><%#Eval("servicename")%></td>
                  <td><%#Eval("price")%></td>
                  <td><%#Eval("sgst")%></td>
                  <td><%#Eval("cgst")%></td>
                  <td><%#Eval("igst")%></td>
                  <td><%#Eval("taxamt")%></td>
                  <td><%#Eval("netamt")%></td>
                  <td><%#Eval("discount")%></td>
                 </td>
                   </tr>
                  </ItemTemplate>
                  </asp:Repeater>
               
                
                </tbody>
              </table>
            </div>
            <!-- /.box-body -->
          </div>
            </asp:Panel>
              <asp:Panel ID="partspanel" runat="server">
            <div class="box">
            <div class="box-header">
              <h3 class="box-title">Data Table Of Service Order Master</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>Sr no.</th>
                  <th>PartName</th>
                  <th>Price</th>
                  <th>SGST</th>
                  <th>CGST</th>
                  <th>IGSt</th>
                  <th>Tax Amount</th>
                  <th>Qty</th>
                  <th>Net/Total amt</th>
                   <th>TotalQtyAmout</th>
                 
            
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="partsdisplayRepeater" runat="server" 
                        onitemcommand="partsdisplayRepeater_ItemCommand" 
                        onitemdatabound="partsdisplayRepeater_ItemDataBound">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("purchaseordermaintainid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton>
               </td>
                     <td><%#Eval("partname")%></td>
                  <td><%#Eval("price")%></td>
                  <td><%#Eval("sgst")%></td>
                  <td><%#Eval("cgst")%></td>
                  <td><%#Eval("igst")%></td>
                  <td><%#Eval("taxamt")%></td>
                  <td><%#Eval("netamt")%></td>
                   <td><%#Eval("qty")%></td>
                   <td><%#Eval("totalqtyamt")%></td>
                 </td>
                   </tr>
                  </ItemTemplate>
                  </asp:Repeater>
               
                
                </tbody>
              </table>
            </div>
            <!-- /.box-body -->
          </div>
            </asp:Panel>
        </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
