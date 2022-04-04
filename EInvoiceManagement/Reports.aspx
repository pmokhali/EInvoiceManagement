<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="EInvoiceManagement.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/pageControl.js"></script>
    <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="wrapper wrapper-content animated fadeInRight">
         <center><h3>Reports</h3></center>
         <br /><br />
            <div class="row">

                <div class="col-md-8 mx-auto">
                <div class="card" style="background-color:#E3F5DF">
                    <div class="card-body">

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:label runat="server" Font-Bold="True" Font-Size="Large">Total Number of Products: </asp:label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:label ID="lblTotalProducts" runat="server"></asp:label>
                                </div>
                            </div>
                        </div>                  
                    </div>
                </div>
                
                <br /><br />
            </div>

            
            </div>
         <div class="row">
             <div class="col-md-8 mx-auto">
                    <div class="card" style="background-color:#E3F5DF">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <center><h5>Total items sold per product</h5></center>
                                    <address>
                                        <asp:label id="lblUser" runat="server" Font-Bold="True"></asp:label> <br>
                                    </address>
                                </div>
                            </div>
                            <div class="row">
                                <asp:GridView ID="GridView1" class="table table-striped" BorderStyle="None" GridLines="None" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                                        <asp:BoundField DataField="Sold" HeaderText="Sold" SortExpression="Sold" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InvoiceProjectDBConnectionString %>" SelectCommand="SELECT [Sold], [ProductName] FROM [Products]"></asp:SqlDataSource>
                            </div>
                            
                        </div>
                            
                    </div>
                </div>

         </div>
         <br /><br />
         <div class="row">

            <div class="col-md-8 mx-auto">
                <div class="card" style="background-color:#E3F5DF">
                    <div class="card-body">
                                      
                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:label runat="server" Font-Bold="True" Font-Size="Large">Number of Products sold: </asp:label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:label ID="lblproductssold" runat="server"></asp:label>
                                </div>
                            </div>
                        </div>                  
                    </div>
                </div>
                
            </div>

            
        </div>
         <br /><br />
         <div class="row">

            <div class="col-md-8 mx-auto">
                <div class="card" style="background-color:#E3F5DF">
                    <div class="card-body">
                                      
                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:label runat="server" Font-Bold="True" Font-Size="Large">Number of Products in stock: </asp:label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:label ID="lblproductsinstock" runat="server"></asp:label>
                                </div>
                            </div>
                        </div>                  
                    </div>
                </div>
            </div>
        </div>
         <br /><br />

         <div class="row">

            <div class="col-md-8 mx-auto">
                <div class="card" style="background-color:#E3F5DF">
                    <div class="card-body">
                                      
                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <center><asp:label runat="server" Font-Bold="True" Font-Size="Large">In stock vs Sold </asp:label></center>
                                </div>
                            </div>
                        </div>   
                        <div class="row">

                            <div class="col-md-4">
                                <div class="form-group">
                                    <center><asp:label ID="lblinstock" runat="server"></asp:label></center>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <center><asp:label  runat="server">-</asp:label></center>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:label ID="lblsold" runat="server"></asp:label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
         <br /><br />
         <a href="HomePage.aspx"><< Back to Home</a>
         <br /><br />

        </div>

</asp:Content>
