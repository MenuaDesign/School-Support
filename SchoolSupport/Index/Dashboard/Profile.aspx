<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Index.Dashboard.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>SchoolSupport</title>
    <link rel="icon" type="image/png" href="img/logo.png">
    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <link href="css/dashboard.css" rel="stylesheet">
</head>
<body>
<form id="form1" runat="server">

    <div id="wrapper">

    <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
    <a class="sidebar-brand d-flex align-items-center justify-content-center" href="/index.aspx">
    <div class="sidebar-brand-icon">
    <img class="logonav" src="img/logo2.png" alt="">
    </div>
    <div class="sidebar-brand-text mx-3">SchoolSupport</div>
    </a>

    <hr class="sidebar-divider my-0">
    <li class="nav-item">
    <a class="nav-link" href="Index.aspx">
    <i class="fas fa-fw fa-tachometer-alt"></i>
    <span>Dashboard</span>
    </a>
    </li>

    <li class="nav-item">
    <a class="nav-link" href="Ticket.aspx">
    <i class="fas fa-fw fa-chart-area"></i>
    <span>Tickets</span>
    </a>
    </li>

    <li class="nav-item  active">
    <a class="nav-link" href="Profile.aspx">
    <i class="fas fa-fw fa-table"></i>
    <span>Profile</span>
    </a>
    </li>

    <hr class="sidebar-divider d-none d-md-block">

    </ul>
    <div id="content-wrapper" class="d-flex flex-column">

    <div id="content">
    <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">
    <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
    <i class="fa fa-bars"></i>
    </button>
    <ul class="navbar-nav ml-auto">
    <div class="topbar-divider d-none d-sm-block"></div>
    <li class="nav-item dropdown no-arrow">
    <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    <span class="mr-2 d-none d-lg-inline text-gray-600 small"><asp:Label ID="lblName" runat="server"></asp:Label></span></a>
    <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
    <a class="dropdown-item" href="Profile.aspx">
    <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>Profile</a>
    <div class="dropdown-divider"></div>
    <a class="dropdown-item" href="#" data-toggle="modal" data-target="#logoutModal">
    <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>Logout</a>
    </div>
    </li>
    </ul>
    </nav>

    <section class="contentsection">
    <div id="divlabelemail" runat="server" visible="false"><asp:Label ID="lblroomeamil" runat="server"></asp:Label></div>
    <div class="mytickets shadow">
    <div class="card-header" >Profile<asp:Label id="lblprofileRole" runat="server" Text="" Class="floatright"></asp:Label></div>
    <div class="profile">
    <a class="contentprofile">Name: </a><asp:TextBox runat="server" id="txtprofileName" Visible="false"></asp:TextBox><asp:Label id="lblprofileName" class="contentinprofile" runat="server"></asp:Label>
    <asp:LinkButton id="btnprofileName" runat="server" Class="floatright" OnClick="btnprofileName_Click"><i class="far fa-edit"></i></asp:LinkButton>
    <asp:LinkButton id="btnokName" runat="server" Class="floatright" OnClick="btnokName_Click" Visible="false"><i class="far fa-check-circle"></i></asp:LinkButton>
    <br />
    <a class="contentprofile">Email: </a><asp:TextBox runat="server" id="txtprofileEmail" Visible="false" TextMode="Email"></asp:TextBox><asp:Label id="lblprofileEmail" class="contentinprofile" runat="server"></asp:Label>
    <asp:LinkButton id="btnprofileEmail" runat="server" Class="floatright" OnClick="btnprofileEmail_Click"><i class="far fa-edit"></i></asp:LinkButton>
    <asp:LinkButton id="btnokEmail" runat="server" Class="floatright" OnClick="btnokEmail_Click" Visible="false"><i class="far fa-check-circle"></i></asp:LinkButton>
    <br />
    <asp:Label ID="lblerrorEmail" class="contentinprofile" runat="server" Visible="false"></asp:Label>
    </div>
    <div class="d-flex flex-row-reverse showtickets" style="margin-right: 0.5rem;">
    </div>
    </div>

    <div class="mytickets shadow">
    <div class="card-header" >Change Password<asp:Button id="btnReset" runat="server" onClick="btnReset_Click" Text="Reset" Class="btn-primary floatright btn-reset"></asp:Button></div>
    <div class="profile">
    <a class="contentprofile">Current Password: </a><asp:TextBox id="txtcPassword" runat="server" TextMode="Password" ></asp:TextBox><a ID="btnCurrent" class="floatright" runat="server"></a>
    <br />
    <a class="contentprofile">New Password: </a><asp:TextBox ID="txtnPassword" runat="server" TextMode="Password" ></asp:TextBox><a ID="btnNew" class="floatright" runat="server"></a>
    <br />
    <a class="contentprofile">Confirm New Password: </a><asp:TextBox id="txtconfPassword" runat="server" TextMode="Password" ></asp:TextBox><a ID="btnConfirm" class="floatright" runat="server"></a>
    <br />
    <asp:Label ID="lblerrorPassword" class="contentinprofile" runat="server" Visible="false"></asp:Label>
    </div>
    </div>
    </section>


    <footer class="sticky-footer bg-white">
    <div class="container my-auto">
    <div class="copyright text-center my-auto">
    <span>© 2019-2020 SchoolSupport | All Rights Reserved</span>
    </div>
    </div>
    </footer>

    </div>

    <a class="scroll-to-top rounded" href="#page-top">
    <i class="fas fa-angle-up"></i>
    </a>

    <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
    <div class="modal-content">
    <div class="modal-header">
    <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
    <span aria-hidden="true">×</span>
    </button>
    </div>
    <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
    <div class="modal-footer">
    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
    <a class="btn btn-primary" href="/Login/Login.aspx">Logout</a>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>

    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <script src="js/sb-admin-2.min.js"></script>

    <script src="vendor/chart.js/Chart.min.js"></script>

    <script src="js/demo/chart-area-demo.js"></script>
    <script src="js/demo/chart-pie-demo.js"></script>

    </div>
</form>
</body>
</html>
