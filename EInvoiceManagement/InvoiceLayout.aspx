<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InvoiceLayout.aspx.cs" Inherits="EInvoiceManagement.InvoiceLayout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/pageControl.js"></script>
    <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
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
                                                
                        <br />

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:label runat="server">ProductList</asp:label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:label runat="server">Unit Price</asp:label>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:label runat="server">Quanitiy</asp:label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="productList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="productList_SelectedIndexChanged">
                                        <asp:ListItem Text="Select Item" Value="selectItem"/>
                                        <asp:ListItem Text="Pear" Value="pear"/>
                                        <asp:ListItem Text="Peach" Value="peach"/>
                                        <asp:ListItem Text="Banana" Value="banana"/>
                                        <asp:ListItem Text="Apple" Value="apple"/>
                                        <asp:ListItem Text="Orange" Value="orange"/>
                                        <asp:ListItem Text="Pinaple" Value="pinaple"/>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPrice" runat="server" placeholder="Unit Price" Enabled="False"></asp:TextBox>
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
                            <div class="col">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-success w-100 d-block btn-md" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"  />
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
                                    <h5>Created by:</h5>
                                    <address>
                                        <asp:label id="lblUser" runat="server" Font-Bold="True"></asp:label> <br>
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
                                        <span id="spDate"><strong>Invoice Date: </strong><asp:label id="lblDate" runat="server"></asp:label></span><br>
                                    </p>
                                    
                                </div>
                            </div>

                            
                            <div class="col">
                               
                                <asp:GridView id="GridView1" class="table table-striped" BorderStyle="None" GridLines="None" runat="server">
                                    
                                </asp:GridView>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-7 text-right">
                                    
                                </div>
                                <div class="col-sm-3 text-right">
                                    <asp:Label runat="server" Text="TOTAL :" Font-Bold="True" style="text-align:right"></asp:Label>
                                </div>
                                <div class="col-sm-2 text-right">
                                    <asp:Label id="lblTotal" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-12 text-right">
                                    <asp:button id="btnSaveInvoice" class="btn btn-primary w-100 d-block btn-md" runat="server" OnClick="btnSaveInvoice_Click" Text="Save Invoice"></asp:button>
                                </div>
                            </div>
                                                                                    
                            <%--<div class="text-right">
                                <button class="btn btn-primary"><i class="fa fa-save"></i> Save Invoice</button>
                            </div>--%>

                        </div>
                            
                    </div>
                </div>
            </div>
        </div>

</asp:Content>
