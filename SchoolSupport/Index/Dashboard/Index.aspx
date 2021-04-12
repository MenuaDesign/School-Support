<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Index.Dashboard.Index" %>

<!DOCTYPE html>
<html lang="en">

<head>

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

<body id="page-top">
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
    <li class="nav-item active">
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

    <li class="nav-item">
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

    <div class="mytickets shadow">
    <div class="card-header" >My Tickets</div>
    <div class="font-weight-bold text-uppercase text-center" style="font-size:4rem;"><asp:Label ID="lblmytickets" runat="server"></asp:Label></div>
    <div class="d-flex flex-row-reverse showtickets" style="margin-right: 0.5rem;">
    <asp:Button ID="btntickets" runat="server" onClick="btntickets_Click" class="btn btn-secondary" Text="Show" style=""></asp:Button>
    </div>
    </div>

    <div class="mytickets shadow">
    <div class="card-header"><i class="far fa-newspaper"></i> New Tickets</div>
    <div class="font-weight-bold text-uppercase text-center" style="font-size:4rem;"><asp:Label ID="lblnewtickets" runat="server"></asp:Label></div>
    <div class="d-flex flex-row-reverse showtickets" style="margin-right: 0.5rem;">
    <asp:Button ID="btnnew" runat="server" onClick="btnnew_Click" class="btn btn-secondary" Text="Show" style=""></asp:Button>
    </div>
    </div>

    <div class="mytickets shadow">
    <div class="card-header" ><i class="far fa-folder-open"></i> Open Tickets</div>

    <div class="font-weight-bold text-uppercase text-center" style="font-size:4rem;"><asp:Label ID="lblopentickets" runat="server"></asp:Label></div>
    <div class="d-flex flex-row-reverse showtickets" style="margin-right: 0.5rem;">
    <asp:Button ID="btnopen" runat="server" onClick="btnopen_Click" class="btn btn-secondary" Text="Show" style=""></asp:Button>
    </div>
    </div>

    <div class="mytickets shadow">
    <div class="card-header" ><i class="fas fa-lock"></i> Solved Tickets</div>

    <div class="font-weight-bold text-uppercase text-center" style="font-size:4rem;"><asp:Label ID="lblsolvedTickets" runat="server"></asp:Label></div>
    <div class="d-flex flex-row-reverse showtickets" style="margin-right: 0.5rem;">
    <asp:Button ID="btnsolved" runat="server" onClick="btnsolved_Click" class="btn btn-secondary" Text="Show" style=""></asp:Button>
    </div>
    </div>

    </section>

   <section class="contentsection">

   <div class="tickets shadow">
   <div class="card-header"><i class="fas fa-ticket-alt"></i> Tickets<a  ID="btnAddmain" runat="server" data-toggle="modal" data-target="#insertModal" style="cursor: pointer;color:#68bd73; float: right;">Add <i class="fas fa-plus-square"></i></a></div>
    
    <asp:GridView onselectedindexchanged="gvTickets_SelectedIndexChanged" ID="gvTickets" runat="server" CssClass="table table-condensed table-hover" Width="100%" AutoGenerateColumns="False" DataKeyNames="ticket_id" AllowPaging="true" PageSize="5" onpageindexchanging="gvTickets_PageIndexChanging">
   <Columns>
   
   <asp:TemplateField HeaderText="Name">
   <EditItemTemplate>
   <asp:Label ID="lblName" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label1" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Ticket">
   <EditItemTemplate>
   <asp:TextBox ID="txtTicketNaam" runat="server" Text='<%# Bind("ticket_naam") %>'></asp:TextBox>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label2" runat="server" Text='<%# Bind("ticket_naam") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Subject">
   <EditItemTemplate>
   <asp:DropDownList ID="ddlSubject" runat="server">
   </asp:DropDownList>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label3" runat="server" Text='<%# Bind("subject_description") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Question">
   <EditItemTemplate>
   <asp:TextBox ID="txtQuestion" runat="server" Text='<%# Bind("ticket_question_description") %>'></asp:TextBox>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label4" runat="server" Text='<%# Bind("ticket_question_description") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Date">
   <EditItemTemplate>
   <asp:Label ID="lblDate" runat="server" Text='<%# Bind("ticket_date") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label5" runat="server" Text='<%# Bind("ticket_date") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Status">
   <EditItemTemplate>
   <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("status_description") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("status_description") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField AccessibleHeaderText="View"  ShowHeader="False">
   <ItemTemplate>
   <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"><i class="far fa-eye"></i></asp:LinkButton>
   </ItemTemplate>
   </asp:TemplateField>
   
   </Columns>
   </asp:GridView>
   
   <asp:GridView  ID="gvTicketsAnswer" runat="server" AutoGenerateColumns="False"  CssClass="table table-condensed table-hover" Width="100%" DataKeyNames="answer_id">
   <Columns>
   
   <asp:TemplateField HeaderText="Name">
   <EditItemTemplate>
   <asp:Label ID="TextBox1" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label2" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Answer">
   <EditItemTemplate>
   <asp:TextBox ID="txtAnswer" runat="server" Text='<%# Bind("answer_description") %>'></asp:TextBox>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label1" runat="server" Text='<%# Bind("answer_description") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Date">
   <EditItemTemplate>
   <asp:Label ID="TextBox2" runat="server" Text='<%# Bind("answer_date") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label3" runat="server" Text='<%# Bind("answer_date") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   </Columns>
   </asp:GridView>

   <asp:GridView onselectedindexchanged="gvVraag_selected" ID="gvVraag" runat="server" CssClass="table table-condensed table-hover" Width="100%" OnRowDeleting="OnRowDeleteVraag" OnRowUpdating="OnRowUpdatingVraag" OnRowEditing="OnRowEditingVraag" OnRowCancelingEdit="OnRowCancelingEditVraag" AutoGenerateColumns="False" DataKeyNames="ticket_id" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AllowPaging="true" PageSize="5" onpageindexchanging="gvVraag_PageIndexChanging">
   <Columns>
   
   <asp:TemplateField HeaderText="Name">
   <EditItemTemplate>
   <asp:Label ID="lblName" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label1" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Ticket">
   <EditItemTemplate>
   <asp:TextBox ID="txtTicketNaam" runat="server" Text='<%# Bind("ticket_naam") %>'></asp:TextBox>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label2" runat="server" Text='<%# Bind("ticket_naam") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Subject">
   <EditItemTemplate>
   <asp:DropDownList ID="ddlSubject" runat="server">
   </asp:DropDownList>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label3" runat="server" Text='<%# Bind("subject_description") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Question">
   <EditItemTemplate>
   <asp:TextBox ID="txtQuestion" runat="server" Text='<%# Bind("ticket_question_description") %>'></asp:TextBox>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label4" runat="server" Text='<%# Bind("ticket_question_description") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Date">
   <EditItemTemplate>
   <asp:Label ID="lblDate" runat="server" Text='<%# Bind("ticket_date") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label5" runat="server" Text='<%# Bind("ticket_date") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Status">
   <EditItemTemplate>
   <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("status_description") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("status_description") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField AccessibleHeaderText="View"  ShowHeader="False">
   <ItemTemplate>
   <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"><i class="far fa-eye"></i></asp:LinkButton>
   </ItemTemplate>
   </asp:TemplateField>
   
   </Columns>
   </asp:GridView>
   
   <asp:GridView  ID="gvAntwoord" runat="server" AutoGenerateColumns="False"  CssClass="table table-condensed table-hover" Width="100%" OnRowDeleting="OnRowDeleteAntwoord" DataKeyNames="answer_id" OnRowUpdating="OnRowUpdatingAntwoord" OnRowEditing="OnRowEditingAntwoord" OnRowCancelingEdit="OnRowCancelingEditAntwoord" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
   <Columns>
   
   <asp:TemplateField HeaderText="Name">
   <EditItemTemplate>
   <asp:Label ID="TextBox1" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label2" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Answer">
   <EditItemTemplate>
   <asp:TextBox ID="txtAnswer" runat="server" Text='<%# Bind("answer_description") %>'></asp:TextBox>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label1" runat="server" Text='<%# Bind("answer_description") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Date">
   <EditItemTemplate>
   <asp:Label ID="TextBox2" runat="server" Text='<%# Bind("answer_date") %>'></asp:Label>
   </EditItemTemplate>
   <ItemTemplate>
   <asp:Label ID="Label3" runat="server" Text='<%# Bind("answer_date") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   </Columns>
   </asp:GridView>
   
   <div runat="server" id="divaddanswer" visible="false" class="position-absolute mid-right">
   <a ID="btnAddAnswer" class="btn btn-primary" data-toggle="modal" data-target="#insertModalAnswer" style="cursor: pointer;color:#fff;"><strong>Reply </strong><i class="fas fa-reply"></i></a>
   </div>
   </div>
   </section>

   <asp:Label ID="lblrijnummer" runat="server" Text="" Style="display: none;"></asp:Label> 

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

    <div class="modal fade" id="insertModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
    <div class="modal-content">
    <div class="modal-header">
    <h5 class="modal-title" id="exampleModalLabel">Add a ticket</h5>
    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
    <span aria-hidden="true">×</span></button>
    </div>

    <div class="modal-body">
    <div class="d-flex flex-column">Ticket naam:<asp:TextBox ID="txtticketnaam" runat="server"></asp:TextBox>Ticket Subject:<asp:DropDownList ID="ddlSubjectAdd" runat="server"></asp:DropDownList>Question:<asp:TextBox ID="txtticketquestion" runat="server"></asp:TextBox>
    </div>
    </div>
    <div class="modal-footer">
    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
    <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" class="btn btn-primary" Text="Add"></asp:Button>
    </div>
    </div>
    </div>
    </div>

    <div class="modal fade" id="insertModalAnswer" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
    <div class="modal-content">
    <div class="modal-header">
    <h5 class="modal-title" id="exampleModalLabelAnswer">Reply</h5>
    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
    <span aria-hidden="true">×</span></button>
    </div>

    <div class="modal-body">
    <div class="d-flex flex-column">Answer:<asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox></div><asp:CheckBox ID="chkbSolved" runat="server" />Solved?</div>
                    
    <div class="modal-footer">
    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
    <asp:Button ID="Button1" runat="server" OnClick="btnAddMain_Click" class="btn btn-primary" Text="Reply"></asp:Button>
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