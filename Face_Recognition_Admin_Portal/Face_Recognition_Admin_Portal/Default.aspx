<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Face_Recognition_Admin_Portal.Default" %>

<html lang="en" class="body-full-height">
    
<!-- Mirrored from aqvatarius.com/themes/atlant/html/pages-login.html by HTTrack Website Copier/3.x [XR&CO'2013], Wed, 27 May 2015 07:58:38 GMT -->
<!-- Added by HTTrack --><meta http-equiv="content-type" content="text/html;charset=utf-8" /><!-- /Added by HTTrack -->
<head>        
        <!-- META SECTION -->
        <title>Attendance Admin Portal</title>            
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        
        <link rel="icon" href="favicon.ico" type="image/x-icon" />
        <!-- END META SECTION -->
        
        <!-- CSS INCLUDE -->        
        <link rel="stylesheet" type="text/css" id="theme" href="css/theme-default.css"/>
        <!-- EOF CSS INCLUDE -->    
    </head>
    <body>
        <form id="form1" runat="server" class="form-horizontal">
        <div class="login-container">
       
            <div class="login-box animated fadeInDown">
                
                <div class="login-logo"><center><strong style="color: #FFFFFF; font-size: x-large">Attendance Admin Portal</strong></center></div>
                <div class="login-body">
                    <div class="login-title"><strong><center>Please Login</center></strong></div>
                   
                    <div class="form-group">
                        <div class="col-md-12">
                       
                            <asp:TextBox ID="txtusername" runat="server" class="form-control" placeholder="Username" required autofocus></asp:TextBox>
         
          
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                           
                             <asp:TextBox ID="txtpassword" runat="server" class="form-control" TextMode="Password" placeholder="Password" required autofocus></asp:TextBox>
          
          
                        </div>
                    </div>
                    <div class="form-group">

                     <div class="col-md-6">
                           
                        </div>
                       
                        <div class="col-md-6">
                         
                            <asp:Button ID="btn_save" runat="server" class="btn btn-primary btn-rounded pull-right" 
                           ValidationGroup="r" OnClick="Save_Click" Text="LOG IN" ForeColor="White" />
                           
                        </div>

                    </div>


                     <div class="form-group">

                     <div class="col-md-12">
                          <asp:Label ID="lbldisplay" runat="server" ForeColor="White"></asp:Label>
                        </div>
                       
                       

                    </div>


                </div>
                

               
            </div>
            
        </div>
    
   
        </form>
    </body>

<!-- Mirrored from aqvatarius.com/themes/atlant/html/pages-login.html by HTTrack Website Copier/3.x [XR&CO'2013], Wed, 27 May 2015 07:58:38 GMT -->
</html>
