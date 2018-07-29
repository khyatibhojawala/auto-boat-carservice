<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua">
            <div class="inner">
              <h3><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h3>
              <p>Car Details</p>
            </div>
            <div class="icon">
              <i class="ion ion-bag"></i>
            </div>
            <a href="cardetails.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-green">
            <div class="inner">
              <h3><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><sup style="font-size: 20px"></sup></h3>

              <p>ServiceRecord</p>
            </div>
            <div class="icon">
              <i class="ion ion-stats-bars"></i>
            </div>
            <a href="ServiceOrderMasterView.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>

          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-yellow">
            <div class="inner">
              <h3><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><sup style="font-size: 20px"></h3>

              <p>SalesRecord</p>
            </div>
            <div class="icon">
              <i class="ion ion-person-add"></i>
            </div>
            <a href="salesmaintainView.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-red">
            <div class="inner">
              <h3>65</h3>

              <p>Search</p>
            </div>
            <div class="icon">
              <i class="ion ion-pie-graph"></i>
            </div>
            <a href="searchData.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
      </div>
           <div class="row">
        <div class="col-md-3">
          <div class="box box-solid">
            <div class="box-header with-border">
              <h3 class="box-title">Labels</h3>

              <div class="box-tools">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="box-body no-padding">
              <ul class="nav nav-pills nav-stacked">
                <li><asp:LinkButton ID="btnunseen" runat="server" onclick="btnunseen_Click" ><i class="fa fa-circle-o text-red"></i>Unseen inquiries</asp:LinkButton></li>
                <li><asp:LinkButton ID="btnseen" runat="server" onclick="btnseen_Click" ><i class="fa fa-circle-o text-red"></i>Seen inquiries</asp:LinkButton></li>
                <li><asp:LinkButton ID="btnduedateinquiry" runat="server" 
                        onclick="btnduedateinquiry_Click" ><i class="fa fa-circle-o text-red"></i>DueDate Services</asp:LinkButton></li>
              </ul>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <div class="col-md-9">

        <asp:Panel ID="unseenpanel" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="box">
            <div class="box-header">
              <h3 class="box-title">Unseen Inquiry Details</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>IsSeen</th>
                <th>Contact</th>
                 <th>ServiceCategory</th>
                  <th>Remark</th>
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="inquiryUnseenRepeater" runat="server">
                <ItemTemplate>
                <tr>
                <td >
                  <asp:CheckBox ID="isseencheckedbox" runat="server" OnCheckedChanged="chkchange" AutoPostBack="true" Text='<%#Eval("orderno")%>'/></td>
                  <td><%#Eval("contact")%></td>
                 <td><%#Eval("servicecategory")%></td>
                  <td><%#Eval("remark")%></td>
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
        </asp:Panel>
        </div>
        <div class="col-md-9">

        <asp:Panel ID="seenpanel" runat="server">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <div class="box">
            <div class="box-header">
              <h3 class="box-title">Seen Inquiry Details</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>IsSeen</th>
                <th>Contact</th>
                 <th>ServiceCategory</th>
                  <th>Remark</th>
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="seenRepeater" runat="server">
                <ItemTemplate>
                <tr>
                  <td><asp:CheckBox ID="isseencheckedbox1" runat="server" OnCheckedChanged="chkchange" AutoPostBack="true" Text='<%#Eval("orderno")%>' /></td>
                  <td><%#Eval("contact")%></td>
                 <td><%#Eval("servicecategory")%></td>
                  <td><%#Eval("remark")%></td>
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
        </asp:Panel>
        </div>
        <div class="col-md-9">

        <asp:Panel ID="duedateinquirypanel" runat="server">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
        <div class="box">
            <div class="box-header">
              <h3 class="box-title">Details Of Duedate Services</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                  <th>contact</th>
                  <th>Car No</th>
                  <th>Remark</th>
                  <th>Sart service date</th>
                  <th>End service date</th>
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="dueInquiry" runat="server">
                <ItemTemplate>
                <tr>
                  <td><%#Eval("contact")%></td>
                  <td><%#Eval("carno")%></td>
                 <td><%#Eval("remark")%></td>
                  <td><%#Eval("startservicedate")%></td>
                  <td><%#Eval("endservicedate")%></td>
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
        </asp:Panel>
        </div>
        </div>
</asp:Content>

