<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InvoiceIssuing.aspx.cs" Inherits="EInvoiceManagement.InvoiceIssuing" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/pageControl.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">
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
                                        <asp:Button class="btn btn-success w-100 d-block btn-md" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
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
                            <div class="col">
                                <center>
                                    <img width="100px" height="100px" src="imgs/invoice.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Created Invoices</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InvoiceProjectDBConnectionString %>" SelectCommand="SELECT Products.ProductName, Members.Username, Invoices.DateCreated, Invoices.Total, Invoices.ProductQty
FROM Invoices
INNER JOIN Products ON Products.Oid=Invoices.ProductID 
INNER JOIN Members on Members.Oid=Invoices.UserID"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="OnRowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                                        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
                                        <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                                        <asp:BoundField DataField="ProductQty" HeaderText="ProductQty" SortExpression="ProductQty" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
