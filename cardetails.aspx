<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cardetails.aspx.cs" Inherits="cardetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="box">
                <div class="box-header">
                    <h3 class="box-title">
                        Data Table Of Car Registration</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <table id="example" class="display nowrap table table-bordered table-striped ">
                        <thead>
                            <tr>
                                <th>
                                    Sr no.
                                </th>
                                <th>
                                    Owner Name
                                </th>
                                <th>
                                    Adrees
                                </th>
                                <th>
                                    Email
                                </th>
                                <th>
                                    Contact
                                </th>
                                <th>
                                    carno
                                </th>
                                <th>
                                    CarCompany
                                </th>
                                <th>
                                    CarType
                                </th>
                                <th>
                                    CarModel
                                </th>
                                <th>
                                    CarSubModel
                                </th>
                                <th>
                                    CarInsurance
                                </th>
                                <th>
                                    EngineNo
                                </th>
                                <th>
                                    TodayDate
                                </th>
                                
                                <th>
                                    LoginId
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="CarRegiRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                           
                                        </td>
                                        <td>
                                            <%#Eval("ownername") %>
                                        </td>
                                        <td>
                                            <%#Eval("address") %>
                                        </td>
                                        <td>
                                            <%#Eval("email") %>
                                        </td>
                                        <td>
                                            <%#Eval("contact") %>
                                        </td>
                                        <td>
                                            <%#Eval("carno") %>
                                        </td>
                                        <td>
                                            <%#Eval("carcompanyname") %>
                                        </td>
                                        <td>
                                            <%#Eval("cartype") %>
                                        </td>
                                        <td>
                                            <%#Eval("carmodelname") %>
                                        </td>
                                        <td>
                                            <%#Eval("carsubmodelname") %>
                                        </td>
                                        <td>
                                            <%#Eval("carinsurance") %>
                                        </td>
                                        <td>
                                            <%#Eval("engineno") %>
                                        </td>
                                        <td>
                                            <%#Eval("tdate") %>
                                        </td>
                                       
                                        <td>
                                            <%#Eval("loginid") %>
                                        </td>
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

