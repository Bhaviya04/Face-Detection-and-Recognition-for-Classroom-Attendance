<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="showreport.aspx.cs" Inherits="Face_Recognition_Admin_Portal.showreport" %>
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
                            <asp:Label ID="lblcoursename" runat="server"></asp:Label></h3>
                        <ul class="panel-controls">
                            <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span></a>
                            </li>
                        </ul>
                    </div>
                                <div class="panel-body">                                    
                                    <div class="row">
                            <div class="col-md-6">              
                                                                
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Total Lectures:</label>
                                            <div class="col-md-9">
                                              
                                                <asp:Label ID="lbltotallectures" runat="server"></asp:Label>

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
                                     <asp:Button ID="Button1" OnClick="ExportToExcel" runat="server" Text="Get Excel Report" class="btn btn-primary" AutoPostBack="true" />
                                <br /><br />
                                 </div>
                                </div>
               
                              <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <asp:Label ID="lblcoursename1" runat="server"></asp:Label> Details</h3>
                                <ul class="panel-controls">
                                    <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span></a>
                                    </li>
                                </ul>
                            </div>
                            <div class="panel-body panel-body-table">
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <table class="table table-bordered table-striped table-actions">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="GridView1" EmptyDataText="No data based on your search" runat="server" AutoGenerateColumns="False"
                                                                Width="100%" CellPadding="5" BorderStyle="None" BorderColor="White" CellSpacing="5"
                                                                GridLines="None" Font-Size="Small">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Student Username" ItemStyle-Width="200px">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("uname")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Course" ItemStyle-Width="200px">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcourse" runat="server" Text='<%#Eval("course_number")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Present" ItemStyle-Width="200px">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblpresent" runat="server" Text='<%#Eval("present")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Lectures" ItemStyle-Width="200px">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbllectures" runat="server" Text='<%#Eval("lectures")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
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
