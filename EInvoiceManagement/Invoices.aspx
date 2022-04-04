<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="~/Invoices.aspx.cs" EnableEventValidation="false" Inherits="EInvoiceManagement.Invoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/pageControl.js"></script>
    <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper wrapper-content animated fadeInRight">

            <div class="row">

                <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" height="100px" src="imgs/invoice.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Select Items on table below to view Invoice</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                                                
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-striped" BorderStyle="None" GridLines="None" runat="server" 
                                    AutoGenerateColumns="False" DataSourceID="SqlDataSource1"  AllowPaging="true" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                    
                                    <Columns>
                                        <asp:BoundField DataField="InvoiceID" HeaderText="Invoice ID" SortExpression="InvoiceID" />
                                        <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice" />
                                        <asp:BoundField DataField="ItemQuantity" HeaderText="Item Quantity" SortExpression="ItemQuantity" />
                                        <asp:BoundField DataField="ItemTotalPrice" HeaderText="Item Total Price" SortExpression="ItemTotalPrice" />
                                        <asp:BoundField DataField="InvoiceTotalPrice" HeaderText="Invoice Total Price" SortExpression="InvoiceTotalPrice" />
                                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InvoiceProjectDBConnectionString %>" SelectCommand="SELECT [InvoiceID], [UnitPrice], [ItemQuantity], [ItemTotalPrice], [InvoiceTotalPrice], [DateCreated], [ProductName] FROM [Invoice_Table]"></asp:SqlDataSource>

                            </div>
                            
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtoid" runat="server" TextMode="Number" Visible="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                            
                    </div>
                </div>
                <a href="HomePage.aspx"><< Back to Home</a>
                <br /><br />
            </div>

            <div class="col-md-6">
                    <div class="card border-0">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-8">
                                    
                                </div>

                                <div class="col-sm-4 text-right">
                                    <h4>Geniii</h4>
                                    <h4 class="text-navy">AI & Analytics</h4>
                                    <address>
                                        F1 Vesta, The Forum, N Bank Ln, <br>
                                        Century City, <br >
                                        Cape Town, 7441<br>
                                        <abbr title="Phone">Phone:</abbr> 021 551 5307
                                    </address>
                                    
                                </div>
                            </div>

                            
                            <div class="col">
                                <asp:GridView id="GridView2" class="table table-striped" BorderStyle="None" GridLines="None" runat="server">
                                </asp:GridView>
                            </div>
                            <br />
                            
                            
                        </div>
                            
                    </div>
                </div>

            </div>

</asp:Content>
