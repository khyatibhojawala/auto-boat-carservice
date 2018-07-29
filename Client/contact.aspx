<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="Client_contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Auto Car an Auto </title>

<!-- Meta tag Keywords -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Auto Car Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--// Meta tag Keywords -->

<!-- css files -->
<link href="resource/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" /> <!-- Bootstrap-Core-CSS -->
<link href="resource/css/style.css" rel="stylesheet" type="text/css" media="all" /> <!-- Style-CSS --> 
<link rel="stylesheet" href="resource/css/font-awesome.css"> <!-- Font-Awesome-Icons-CSS -->
<!-- //css files -->

<!-- online-fonts -->
<link href="//fonts.googleapis.com/css?family=Jockey+One&amp;subset=latin-ext" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i&amp;subset=cyrillic,cyrillic-ext,greek,greek-ext,latin-ext,vietnamese" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Niconne&amp;subset=latin-ext" rel="stylesheet">
</head>
<body>
    
    
    <form id="form1" runat="server" class="form-horizontal">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
  <div class="banner-2 wthree">
		<div class="container">
			<div class="banner_top">
				<div class="logo wow fadeInLeft animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInLeft;">
					<h1><a href="index.html"><span>A</span>uto Car</a></h1>
				</div>
				<div class="banner_top_right wow fadeInRight animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInRight;">
					<nav class="navbar navbar-default">
				<!-- Brand and toggle get grouped for better mobile display -->
				<div class="navbar-header">
				  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				  </button>
				</div>

				<!-- Collect the nav links, forms, and other content for toggling -->
				<div class="collapse navbar-collapse nav-wil" id="bs-example-navbar-collapse-1">
					<ul class="nav navbar-nav cl-effect-14">
						<li><a href="index.aspx" class="active">Home</a></li>
						<li><a href="about.aspx">About Us</a></li>
						<li><a href="services.aspx">Services</a></li>
						<li><a href="gallery.aspx">Gallery</a></li>
                        <li><a href="contact.aspx">Contact Us</a></li>
						<li><a href="../login.aspx">Login</a></li>
					</ul>
				</div><!-- /.navbar-collapse -->	
				
			</nav>
				</div>
				<div class="clearfix"> </div>
			</div>
			<!-- banner -->
		
		</div>
	</div>
<!-- //banner -->

<!-- Main -->
<!-- Codes -->
	<div class="container">
<div class="page agile-1">
	<div class="ser-top ser-top-c">
					<h2 class="tittle-agw3">Inquiry Form</h2>
					<div class="ser-t">
						<b></b>
						<span><i></i></span>
						<b class="line"></b>
					</div>
				 </div>

	<!--Forms-->
	<div class="page-header">
        <h3>Forms</h3>
      </div>
  <div class="bs-example " data-example-id="simple-horizontal-form">

      <div class="form-group">
        <label for="inputEmail3" class="col-sm-2 control-label">Name</label>
        <div class="col-sm-8">
          <%--<input type="email" class="form-control" id="inputEmail3" placeholder="Email">--%>
            <asp:TextBox ID="ownername" class="form-control" runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ownername"
                                    ErrorMessage="Name is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
      </div>
      <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">Email</label>
        <div class="col-sm-8">
          <asp:TextBox ID="email" class="form-control" runat="server"></asp:TextBox>
        </div>
      </div>
      <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">ContactNo</label>
        <div class="col-sm-8">
          <asp:TextBox ID="contact" MaxLength="10" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" class="form-control" AutoPostBack="true" runat="server" 
                ontextchanged="contactno_TextChanged"></asp:TextBox>
            <asp:Label ID="labelcontact" Visible="false" runat="server" Text="Label"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="contact"
                                    ErrorMessage="ContactNo is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
      </div>
       <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">Address</label>
        <div class="col-sm-8">
          <asp:TextBox ID="address" class="form-control" runat="server"></asp:TextBox>
        </div>
      </div>
        <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">CarNo</label>
        <div class="col-sm-1">
          <asp:TextBox ID="carno1" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-1">
          <asp:TextBox ID="carno2" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-1">
          <asp:TextBox ID="carno3" class="form-control" AutoPostBack="true" runat="server" 
                ontextchanged="carno3_TextChanged"></asp:TextBox>
        </div>
        <div class="col-sm-1">
          <asp:TextBox ID="carno4" class="form-control" AutoPostBack="true" runat="server" 
                ontextchanged="carno4_TextChanged"></asp:TextBox>
        </div>
      </div>
        
        <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">CarCompany</label>
        <div class="col-sm-8">
          <asp:DropDownList ID="carcompany" CssClass="form-control" runat="server" 
                AutoPostBack="true" onselectedindexchanged="carcompany_SelectedIndexChanged"  >
                            </asp:DropDownList>
        </div>
      </div>
        <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">CarType</label>
        <div class="col-sm-8">
         <asp:DropDownList ID="cartype" CssClass="form-control" runat="server" 
                AutoPostBack="true" onselectedindexchanged="cartype_SelectedIndexChanged">
                            </asp:DropDownList>
        </div>
      </div>
         <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">CarModel</label>
        <div class="col-sm-8">
          <asp:DropDownList ID="carmodel" CssClass="form-control" runat="server" 
                AutoPostBack="true" onselectedindexchanged="carmodel_SelectedIndexChanged">
                            </asp:DropDownList>
        </div>
      </div>
         <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">CarSubModel</label>
        <div class="col-sm-8">
          <asp:DropDownList ID="carsubmodel" CssClass="form-control" runat="server">
                            </asp:DropDownList>
        </div>
      </div>
           <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">EngineNo</label>
        <div class="col-sm-8">
          <asp:TextBox ID="engineno" class="form-control" runat="server"></asp:TextBox>
        </div>
      </div>
       <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Select Services which should apply on Car :
                                </label>
                                <div class="col-sm-8">
                                <asp:Repeater ID="inqrepeater" runat="server" >
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                        <asp:CheckBox ID="servicecategory" CssClass="servicecategory" AutoPostBack="true"
                                            OnCheckedChanged="chkchange" runat="server" Text='<%#Eval("servicename")%>' value='<%#Eval("servicename")%>' />
                                    </ItemTemplate>
                                </asp:Repeater>
                                </div>
                            </div>
                              <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">Remark</label>
        <div class="col-sm-8">
          <asp:TextBox ID="remark" class="form-control" runat="server"></asp:TextBox>
        </div>
      </div>
    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
          <div class="checkbox">
            <label>
              <asp:CheckBox ID="carinsurance" runat="server" AutoPostBack="true"/> Do you have Insurnace?
            </label>
          </div>
        </div>
      </div>
      <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
          <asp:Button ID="submit" CssClass="btn btn-default" runat="server" Text="Submit" 
                onclick="submit_Click" />
        </div>
      </div>
  </div>
  
	<!--//forms-->
	</div>
	</div>
<!-- //Codes -->
<!-- //Main -->

<!-- Footer -->
<div class="footer w3ls">
	<div class="container">
		<div class="footer-main">
			<div class="footer-top">
				<div class="col-md-4 ftr-grid fg1">
					<h4><a href="index.html">Auto Car</a></h4>
					<p>Lorem ipsum dolor sit amet, consectetur adip magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation</p>
					<a href="about.html">Learn More</a>
				</div>
				<div class="col-md-4 ftr-grid fg2">
					<h3>Our Address</h3>
					<div class="ftr-address">
						<div class="local">
							<i class="fa fa-map-marker" aria-hidden="true"></i>
						</div>
						<div class="ftr-text">
							<p>sargam shopping Center,City light</p>
						</div>
						<div class="clearfix"> </div>
					</div>
					<div class="ftr-address">
						<div class="local">
							<i class="fa fa-phone" aria-hidden="true"></i>
						</div>
						<div class="ftr-text">
							<p>+87965204896</p>
						</div>
						<div class="clearfix"> </div>
					</div>
					<div class="ftr-address">
						<div class="local">
							<i class="fa fa-envelope" aria-hidden="true"></i>
						</div>
						<div class="ftr-text">
							<p><a href="mailto:info@example.com">autoboat@gmail.com</a></p>
						</div>
						<div class="clearfix"> </div>
					</div>
				</div>
				<div class="col-md-4 ftr-grid fg2">
					<h3>Keep In Touch With Us</h3>
					<div class="right-w3l">
						<ul class="top-links">
							<li><a href="#"><i class="fa fa-facebook"></i></a></li>
							<li><a href="#"><i class="fa fa-twitter"></i></a></li>
							<li><a href="#"><i class="fa fa-google-plus"></i></a></li>
						</ul>
					</div>
					<div class="right-w3-2">
						<ul class="text-w3">
							<li><a href="#">Facebook</a></li>
							<li><a href="#">Twitter</a></li>
							<li><a href="#">Google</a></li>
						</ul>
					</div>
				</div>
			   <div class="clearfix"> </div>
			</div>
			<div class="copyrights">
				<p>&copy;Auto Car. <a href="http://w3layouts.com/" target="_blank"></a> </p>
			</div>
		</div>
	</div>
	<div class="newsletter-agile">
		<p>
            Send us Your Mail, we&#39;ll make sure You Never Miss a Thing!</p>
        <input name="email" placeholder="Enter Your E-mail Here.." required="" 
            type="email">
        <input type="submit" value="Subscribe"> </input></input></div>
</div>
 
<!-- Footer -->	

<!-- js-scripts -->						
		<!-- js -->
			<script type="text/javascript" src="resource/js/jquery-2.1.4.min.js"></script>
			<script type="text/javascript" src="resource/js/bootstrap.js"></script> <!-- Necessary-JavaScript-File-For-Bootstrap --> 
		<!-- //js -->
		<script src="js/jzBox.js"></script>
<!-- //js-scripts -->
    <div class="modal fade" id="modal-default">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">
                        Alert Box</h4>
                </div>
                <div class="modal-body">
                    <p>
                        Number should not More than 3 charachter</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>  
</ContentTemplate>
    </asp:UpdatePanel>
    </form>
    
</body>
</html>
