<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="carinquiryview.aspx.cs" Inherits="carinquiryview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="box">
            <div class="box-header">
              <h3 class="box-title">Data Table Of Car Registration</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table  id="example" class="display nowrap table table-bordered table-striped " >
              
                <thead> 
                <tr>
                <th>Sr no.</th>
                 <th>OrderNo</th>
                 <th>RefrenceNo</th>
                 <th>Remark</th>
                 <th>ServiceCategory</th>
                 <th>IsOnline</th>
                 <th>IsFollowUp</th>
                 <th>IsDone</th>
                </tr>
                </thead>
                <tbody>
                
                <asp:Repeater ID="CarRegiRepeater" OnItemCommand="repeat_ItemCommand" 
                        runat="server" onitemdatabound="CarRegiRepeater_ItemDataBound">
                <ItemTemplate>
                <tr>
                <td >
                <asp:LinkButton ID="btndelete" runat="server"  CommandArgument='<%#Eval("carinquiryid") %>' CommandName="delete"><span class="fa fa-trash"></span></asp:LinkButton></td>
                  <td><%#Eval("orderno")%></td>
                  <td><%#Eval("refrenceno")%></td>
                  <td><%#Eval("remark")%></td>
                  <td><%#Eval("servicecategory")%></td>
                  <td><%#Eval("isonline")%></td>
                  <td><%#Eval("isfollowup")%></td>
                  <td><%#Eval("isdone")%></td>
                 
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

