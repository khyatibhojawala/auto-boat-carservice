<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ordermasterInvoice.aspx.cs" Inherits="ordermasterInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content">
        <!-- Content Header (Page header) -->
        <section class="content-header">
<%--<asp:Repeater ID="ordermasterrefno" runat="server">
<ItemTemplate>--%>
      <h1>
        Invoice
        <small>#007612</small>
      </h1>
      <%--</ItemTemplate></asp:Repeater>--%>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Examples</a></li>
        <li class="active">Invoice</li>
      </ol>
    </section>
        <div class="pad margin no-print">
            <div class="callout callout-info" style="margin-bottom: 0!important;">
                <h4>
                    <i class="fa fa-info"></i>Note:</h4>
                This page has been enhanced for printing. Click the print button at the bottom of
                the invoice to Print.
            </div>
        </div>
        <!-- Main content -->
        <section class="invoice pdf">
      <!-- title row -->
      <div class="row">
      <asp:Repeater ID="dateRepeater" runat="server">
            <ItemTemplate>
        <div class="col-xs-12">
          <h2 class="page-header">
            <i class="fa fa-globe"></i> AutoBoat, Inc.
            <small class="pull-right">Date: 2/10/2014</small>
          </h2>
        </div>
        <!-- /.col -->
        </ItemTemplate>
        </asp:Repeater>
      </div>
      <!-- info row -->
      <div class="row invoice-info">
        <div class="col-sm-4 invoice-col">
          From
          <address>
            <strong>Admin, Inc.</strong><br>
            795 Folsom Ave, Suite 600<br>
            San Francisco, CA 94107<br>
            Phone: (804) 123-5432<br>
            Email: info@almasaeedstudio.com
          </address>
        </div>
        <!-- /.col -->
        <div class="col-sm-4 invoice-col">
          To
           <asp:Repeater ID="CarOwnerDeatilsRepeater" runat="server">
            <ItemTemplate>
          <address>
            <strong><%#Eval("ownername")%></strong><br>
            <%#Eval("address")%><br>
            CarNo :<%#Eval("carno")%><br>
            Phone: <%#Eval("contact")%><br>
            Email: <%#Eval("email")%>
          </address>
          </ItemTemplate></asp:Repeater>
        </div>
        <!-- /.col -->
        <div class="col-sm-4 invoice-col">
         <asp:Repeater ID="ordernorepeterbind" runat="server">
            <ItemTemplate>
          <b>Invoice <%#Eval("refno") %></b><br>
          <br>
          <b>Order ID:</b> <%#Eval("orderno") %><br>
          <b>Payment Due:</b> <%#Eval("endservicedate") %><br>
          </ItemTemplate>
          </asp:Repeater>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

      <!-- Table row -->
      <div class="row">
        <div class="col-xs-12 table-responsive">
          <table class="table table-striped">
            <thead>
            <tr>
              <th>Orderno</th>
              <th>ServiceName</th>
              <th>OrderNOOfMaster</th>
              <th>RefrenceNO</th>
              <th>Price</th>
              <th>SGST</th>
              <th>CGST</th>
              <th>IGST</th>
            </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="OrdermasterDeatilsRepeater" runat="server">
            <ItemTemplate>
            <tr>
              <td><%#Eval("orderno")%></td>
              <td><%#Eval("servicename")%></td>
              <td><%#Eval("som")%></td>
              <td><%#Eval("refno")%></td>
             <td><%#Eval("price")%></td>
             <td><%#Eval("sgst")%></td>
             <td><%#Eval("cgst")%></td>
             <td><%#Eval("igst")%></td>
            </tr>
            </ItemTemplate></asp:Repeater>
            </tbody>
          </table>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

      <div class="row">
        <!-- accepted payments column -->
        <div class="col-xs-6">
         
        </div>
        <!-- /.col -->
        <div class="col-xs-6">
          

          <div class="table-responsive">
            <table class="table">
              
            </table>
          </div>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

      <!-- this row will not appear when printing -->
      <div class="row no-print">
        <div class="col-xs-12">
          <a href="invoice-print.html" target="_blank" class="btn btn-default" onclick="window.print();"><i class="fa fa-print"></i> Print</a>
          <button type="button" class="btn btn-success pull-right"><i class="fa fa-credit-card"></i> Submit Payment
          </button>
          <Button onclick="window.print();"  ID="pdf" class="btn btn-primary pull-right pdf" style="margin-right: 5px;" >
          Generate PDF
         </Button>
         
        </div>
      </div>
    </section>
        <!-- /.content -->
        <div class="clearfix">
        </div>
    </div>
    <!-- /.content-wrapper -->
    <div class="control-sidebar-bg">
    </div>
    <!-- ./wrapper -->
</asp:Content>
