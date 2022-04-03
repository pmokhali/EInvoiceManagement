<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InvoiceLayout.aspx.cs" Inherits="EInvoiceManagement.InvoiceLayout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/pageControl.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="wrapper wrapper-content animated fadeInRight">

            <div class="row">

                <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" height="100px" src="imgs/clipart.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Select Products</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server" placeholder="User Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtDate" runat="server" placeholder="Date" TextMode="DateTimeLocal"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="productList" runat="server">
                                        <asp:ListItem Text="Select Product" Value="selectProduct"/>
                                        <asp:ListItem Text="Bread" Value="bread"/>
                                        <asp:ListItem Text="Milk" Value="milk"/>
                                        <asp:ListItem Text="Banana" Value="banana"/>
                                        <asp:ListItem Text="Apple" Value="apple"/>
                                        <asp:ListItem Text="Cereal" Value="cereal"/>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPrice" runat="server" placeholder="Unit Price" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtQuantity" runat="server" placeholder="Quantity" TextMode="Number"></asp:TextBox>
                                </div>
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

                        <div class="row">
                            <div class="col-4">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-success w-100 d-block btn-md" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"  />
                                    </div>
                                </center>
                            </div>
                            <div class="col-4">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-warning w-100 d-block btn-md" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                    </div>
                                </center>
                            </div>
                            <div class="col-4">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-danger w-100 d-block btn-md" ID="btnReturn" runat="server" Text="Return" />
                                    </div>
                                </center>
                            </div>
                            
                        </div>

                            
                    </div>
                </div>
                <a href="HomePage.aspx"><< Back to Home</a>
                <br /><br />
            </div>

            <div class="col-md-7">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <h5>From:</h5>
                                    <address>
                                        <strong>Phethiso</strong><br>
                                        Sienna<br>
                                        Burgundy<br>
                                        <abbr title="Phone">P:</abbr> (123) 601-4590
                                    </address>
                                </div>

                                <div class="col-sm-6 text-right">
                                    <h4>Geniii</h4>
                                    <h4 class="text-navy">AI & Analytics</h4>
                                    <address>
                                        F1 Vesta, The Forum, N Bank Ln, <br>
                                        Century City, <br >
                                        Cape Town, 7441<br>
                                        <abbr title="Phone">Phone:</abbr> 021 551 5307
                                    </address>
                                    <p>
                                        <span><strong>Invoice Date:</strong> Marh 18, 2014</span><br>
                                    </p>
                                </div>
                            </div>

                            <%--<div class="table-responsive m-t">--%>
                                <%--<table class="table invoice-table" runat="server" id="tblInvoice" >
                                    <thead>
                                    <tr>
                                        <th>Item List</th>
                                        <th>Quantity</th>
                                        <th>Unit Price</th>
                                        <th>Total Price</th>
                                    </tr>
                                    </thead>
                                </table>--%>

                            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InvoiceProjectDBConnectionString %>" SelectCommand="SELECT Products.ProductName, Members.Username, Invoices.DateCreated, Invoices.Total, Invoices.ProductQty
FROM Invoices
INNER JOIN Products ON Products.Oid=Invoices.ProductID 
INNER JOIN Members on Members.Oid=Invoices.UserID Where "></asp:SqlDataSource>--%>
                            <div class="col">
                                <%--<asp:GridView class="table table-striped" BorderStyle="None" GridLines="None" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="OnRowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
                                        <asp:BoundField DataField="ProductQty" HeaderText="ProductQty" SortExpression="ProductQty" />
                                        <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                                        
                                    </Columns>
                                </asp:GridView>--%>

                                <asp:GridView id="GridView1" class="table table-striped" BorderStyle="None" GridLines="None" runat="server">
                                    
                                </asp:GridView>
                            </div>

                            
                            <%--</div><!-- /table-responsive -->--%>

                            <table class="table invoice-total">
                                <tbody>
                                <tr>
                                    <td><strong>Sub Total :</strong></td>
                                    <td>$1026.00</td>
                                </tr>
                                <tr>
                                    <td><strong>TAX :</strong></td>
                                    <td>$235.98</td>
                                </tr>
                                <tr>
                                    <td><strong>TOTAL :</strong></td>
                                    <td>$1261.98</td>
                                </tr>
                                </tbody>
                            </table>
                            <div class="text-right">
                                <button class="btn btn-primary"><i class="fa fa-dollar"></i> Make A Payment</button>
                            </div>

                            <div class="well m-t"><strong>Comments</strong>
                                It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less
                            </div>
                        </div>
                            
                    </div>
                </div>
            </div>
        </div>

</asp:Content>
