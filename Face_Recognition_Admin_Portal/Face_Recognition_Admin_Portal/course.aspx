<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="Face_Recognition_Admin_Portal.course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                            Add Course</h3>
                        <ul class="panel-controls">
                            <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span></a>
                            </li>
                        </ul>
                    </div>
                                <div class="panel-body">                                    
                                    <div class="row">
                            <div class="col-md-6">              
                                                                
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Professor Name:</label>
                                            <div class="col-md-9">
                                              
                                                <asp:DropDownList ID="ddlprofessor" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlprofessor" 
                            InitialValue="0" ErrorMessage="* Professor Required" Display="Dynamic" ForeColor="Red" ValidationGroup="r"></asp:RequiredFieldValidator>
                                                <span class="help-block">&nbsp;</span>
                                            </div>
                                        </div>

                                <div class="form-group">
                                            <label class="col-md-3 control-label">Course Name:</label>
                                            <div class="col-md-9">
                                              
                                                <asp:TextBox ID="txtcoursename" runat="server" class="form-control" required></asp:TextBox>

                                                <span class="help-block">&nbsp;</span>
                                            </div>
                                        </div>

                                <div class="form-group">
                                            <label class="col-md-3 control-label">Course Number:</label>
                                            <div class="col-md-9">
                                              
                                                <asp:TextBox ID="txtcoursenumber" runat="server" class="form-control" required></asp:TextBox>

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
                                          
                                 <div class="col-md-3">
                                     <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="r" OnClick="Button1_Click" AutoPostBack="true" />
                                     <br /><br />
                                </div>
                                
                               
                                </div>


                              <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    Course Details</h3>
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
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                                                                Width="100%" CellPadding="5" BorderStyle="None" BorderColor="White" CellSpacing="5"
                                                                GridLines="None" Font-Size="Small">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Professor Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblpname" runat="server" Text='<%#Eval("prof_name")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Course Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcname" runat="server" Text='<%#Eval("course_name")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Course Number">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbllcnumber" runat="server" Text='<%#Eval("course_number")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                  
                                                                     <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btn_edit" class="btn btn-default btn-rounded btn-condensed btn-sm"
                                                                                CommandName="edit" CommandArgument='<%#Eval("course_id") %>' ToolTip='<%#Eval("course_id") %>'
                                                                                runat="server"><span class="fa fa-pencil"></span></asp:LinkButton>
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

