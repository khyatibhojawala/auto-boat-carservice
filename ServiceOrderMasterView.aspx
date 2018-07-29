﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ServiceOrderMasterView.aspx.cs" Inherits="ServiceOrderMasterView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
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
                  <th>MaintainOrderNo</th>
                  <th>MasterOrderNO</th>
                  <th>Reference No.</th>
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
                
                <asp:Repeater ID="SOMRepeaterMaintain" runat="server">
                <ItemTemplate>
                <tr>
                <td >
                  <td><%#Eval("morderno")%></td>
                  <td><%#Eval("SOMOrderno")%></td>
                  <td><%#Eval("mrefno")%></td>
                  <td><%#Eval("price")%></td>
                  <td><%#Eval("sgst")%></td>
                  <td><%#Eval("cgst")%></td>
                  <td><%#Eval("igst")%></td>
                  <td><%#Eval("taxamt")%></td>
                  <td><%#Eval("netamt")%></td>
                  <td><%#Eval("discount")%></td>
                  
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

