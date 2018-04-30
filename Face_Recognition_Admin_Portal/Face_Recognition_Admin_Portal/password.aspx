<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="Face_Recognition_Admin_Portal.password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content-wrap">    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>          
                 <div class="row">
            <div class="col-md-12">

                             <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>

                             <!-- START VALIDATIONENGINE PLUGIN -->
                            <div class="panel panel-default">
                             <div class="panel-heading">
                        <h3 class="panel-title">
                            Change Password</h3>
                        <ul class="panel-controls">
                            <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span></a>
                            </li>
                        </ul>
                    </div>
                                <div class="panel-body">                                    
                                    <div class="row">
                            <div class="col-md-6">              
                                                                
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">New Password:</label>
                                            <div class="col-md-9">
                                              
                                                <asp:TextBox ID="txtpassword" runat="server" class="form-control" TextMode="Password" required></asp:TextBox>

                                                <span class="help-block">&nbsp;</span>
                                            </div>
                                        </div>

                                <div class="form-group">
                                            <label class="col-md-3 control-label">Confirm Password:</label>
                                            <div class="col-md-9">
                                              
                                                <asp:TextBox ID="txtconfimpassword" runat="server" class="form-control" TextMode="Password" required></asp:TextBox>

                                                <span class="help-block">&nbsp;</span>
                                            </div>
                                        </div>

                                    </div>
                                    </div>

                                </div>
                            </div>                
                            <!-- END VALIDATIONENGINE PLUGIN -->


                             </ContentTemplate>
                            </asp:UpdatePanel>
                         
                                          <div class="col-md-12">
                                          
                                 <div class="col-md-2">
                                     <asp:Button ID="Button1" runat="server" Text="Update Password" OnClick="Button1_Click" class="btn btn-primary" ValidationGroup="r" AutoPostBack="true" />
                                </div>
                                </div>
                <div class="col-md-12">
                <br />
                    <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ValidationGroup="r" runat="server" ErrorMessage="Both the passwords must match" ControlToCompare="txtpassword" ControlToValidate="txtconfimpassword" Display="Dynamic"></asp:CompareValidator>
                                     <br /><br />
                    </div>
                        </div>
                    
                        </div>
                    </div>

    <script type='text/javascript' src='js/plugins/bootstrap/bootstrap-datepicker.js'></script>        
        <script type='text/javascript' src='js/plugins/bootstrap/bootstrap-select.js'></script>        

        <script type='text/javascript' src='js/plugins/validationengine/languages/jquery.validationEngine-en.js'></script>
        <script type='text/javascript' src='js/plugins/validationengine/jquery.validationEngine.js'></script>        

        <script type='text/javascript' src='js/plugins/jquery-validation/jquery.validate.js'></script>                

        <script type='text/javascript' src='js/plugins/maskedinput/jquery.maskedinput.min.js'></script>        
    <!-- END SCRIPTS -->
</asp:Content>
