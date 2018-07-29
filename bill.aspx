<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="content">
        <!-- Content Header (Page header) -->
        <section class="content-header">
      <h1>
         <asp:Label ID="Label2" runat="server" Text="Enter Owner's Contact No"></asp:Label>
        <small><asp:TextBox ID="carownercontactno" AutoPostBack="true" CssClass="form-control" runat="server" 
              ontextchanged="carownercontactno_TextChanged"></asp:TextBox></small>
      </h1>
      <ol class="breadcrumb">
       </ol>
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
            <strong>Auto-Boat, Car Service.</strong><br>
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
            CarNo : <%#Eval("carno")%><br>
            Phone : <%#Eval("contact")%><br>
            Email : <%#Eval("email")%>
          </address>
          </ItemTemplate></asp:Repeater>
        </div>
        <!-- /.col -->
        <div class="col-sm-4 invoice-col">
         <asp:Repeater ID="ordernorepeterbind" runat="server">
            <ItemTemplate>
          <b>Invoice No: <%#Eval("prno") %></b><br>
          <br>
          </ItemTemplate>
          </asp:Repeater>
          <b>Date :</b><asp:Label ID="Label4" runat="server" Text=""></asp:Label> <br>
          
        </div>
        <!-- /.col -->
      </div>
      <div class="row">
        <div class="col-sm-4 invoice-col">
        <asp:Repeater ID="serviceorderno" runat="server">
            <ItemTemplate>
            <b>Service No : </b><%#Eval("srno")%><br>
            </ItemTemplate>
          </asp:Repeater>
        </div>
      </div >
      <!-- /.row -->

      <!-- Table row -->
      <div class="row">
        <div class="col-xs-12 table-responsive">
          <table class="table table-striped">
            <thead>
            <tr>
              <th>Orderno</th>
              <th>ServiceName</th>
              <th>RefrenceNO</th>
              <th>Price</th>
              <th>SGST</th>
              <th>CGST</th>
              <th>IGST</th>
              <th>Final Price</th>
            </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="billdetails" runat="server">
            <ItemTemplate>
            <tr>
              <td><%#Eval("orderno")%></td>
              <td><%#Eval("servicename")%></td>
              <td><%#Eval("refno")%></td>
             <td><%#Eval("price")%></td>
             <td><%#Eval("sgst")%></td>
             <td><%#Eval("cgst")%></td>
             <td><%#Eval("igst")%></td>
             <td><%#Eval("netamt")%></td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            </tbody>
          </table>
        </div>
        <!-- /.col -->
      </div>
      <div class="row">
        <div class="col-xs-12 table-responsive">
          <table class="table table-striped">
            <thead>
            <tr>
            <th>Orderno</th>
              <th>PartName</th>
              <th>Refno</th>
              <th>Price</th>
              <th>SGST</th>
              <th>CGST</th>
              <th>IGST</th>
              <th>Final Price</th>
              <th>Quantity</th>
              <th>Quantity Price</th>
            </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="partsrepeater" runat="server">
            <ItemTemplate>
            <tr>
             <td><%#Eval("orderno")%></td>
              <td><%#Eval("partname")%></td>
              <td><%#Eval("refno")%></td>
              <td><%#Eval("price")%></td>
             <td><%#Eval("sgst")%></td>
             <td><%#Eval("cgst")%></td>
             <td><%#Eval("igst")%></td>
             <td><%#Eval("netamt")%></td>
             <td><%#Eval("qty")%></td>
             <td><%#Eval("totalqtyamt")%></td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
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
          <p class="lead"></p>

          <div class="table-responsive">
            <table class="table">
              <tr>
                <th style="width:50%">Subtotal:</th>
                <td><asp:Label ID="stotal" runat="server"></asp:Label></td>
              </tr>
              <tr>
                <th>ADD Discount (%):</th>
                <td>
                <small><asp:TextBox ID="discount" AutoPostBack="true" CssClass="form-control" 
                        runat="server" ontextchanged="TextBox1_TextChanged" 
              ></asp:TextBox></small>
              </td>
              </tr>
              <tr>
                <th>Total:</th>
                <td><asp:Label ID="disamt" runat="server"></asp:Label></td>
              </tr>
            </table>
          </div>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

      <!-- this row will not appear when printing -->
      <div class="row no-print">
        <div class="col-xs-12">
          <%--<a href="invoice-print.html" target="_blank" onclick="hey();" class="btn btn-default"><i class="fa fa-print"></i> Print</a>--%>
        
          <asp:Button ID="Button1" CssClass="btn btn-success pull-right" runat="server" Text="Pay Online" onclick="Button1_Click" style="margin-left:10px;"></asp:Button>
          
          <asp:Button ID="editbill" runat="server" CssClass="btn btn-success pull-right"
                Text=" Edit Bill" onclick="editbill_Click"></asp:Button>
          
         <asp:Button ID="Button2" runat="server" Text="Generate PDF" onclick="Button2_Click" CssClass="btn btn-primary pull-right pdf" style="margin-right:10px;"></asp:Button>
         
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
    </ContentTemplate>
    </asp:UpdatePanel>
 <script>
     function hey() {
         window.print();
     }
</script>
</asp:Content>

