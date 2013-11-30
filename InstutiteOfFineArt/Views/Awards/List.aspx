<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="InstutiteOfFineArt.Views.Awards.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Award List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyClass" runat="server">
    page
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="container">	

			
			<section class="main">
				
				<div class="wrapper">

					
					<div class="topbar" style="margin-left:90px">
						<span id="close" class="back">&larr;</span>
						<h2>Award List</h2><h3 id="name" ></h3>
					</div>

					<ul id="tp-grid" class="tp-grid">

						<!-- Bryan Moats -->
						<li data-pile="Bryan Moats">
							<a href="#">
								<span class="tp-info"><span>Flu &amp; You</span></span>
								<img src="../../Assets/Images/Paintings/1.jpg" />
							</a>
						</li>
						<li data-pile="Bryan Moats">
							<a href="#">
								<span class="tp-info"><span>Test Your Flu IQ</span></span>
								<img src="../../Assets/Images/Paintings/2.jpg" />
							</a>
						</li>
						<li data-pile="Bryan Moats">
							<a href="#">
								<span class="tp-info"><span>Unexpected Fatherly Faces and Feelings</span></span>
								<img src="../../Assets/Images/Paintings/3.jpg" />
							</a>
						</li>
                        	<li data-pile="Bryan Moats">
							<a href="#">
								<span class="tp-info"><span>Flu &amp; You</span></span>
								<img src="../../Assets/Images/Paintings/1.jpg" />
							</a>
						</li>
						<li data-pile="Bryan Moats">
							<a href="#">
								<span class="tp-info"><span>Test Your Flu IQ</span></span>
								<img src="../../Assets/Images/Paintings/2.jpg" />
							</a>
						</li>
						<li data-pile="Bryan Moats">
							<a href="#">
								<span class="tp-info"><span>Unexpected Fatherly Faces and Feelings</span></span>
								<img src="../../Assets/Images/Paintings/3.jpg" />
							</a>
						</li>
						<!-- Mike Dornseif -->
						<li data-pile="Mike Dornseif">
							<a href="#">
								<span class="tp-info"><span>On to Easter</span></span>
								<img src="../../Assets/Images/Paintings/4.jpg" />
							</a>
						</li>
						<li data-pile="Mike Dornseif">
							<a href="#">
								<span class="tp-info"><span>Love Birds</span></span>
								<img src="../../Assets/Images/Paintings/5.jpg" />
							</a>
						</li>
						<li data-pile="Mike Dornseif">
							<a href="#">
								<span class="tp-info"><span>Here Fishy fishy</span></span>
								<img src="../../Assets/Images/Paintings/6.jpg" />
							</a>
						</li>

						<!-- Griffin Moore -->
						<li data-pile="Griffin Moore">
							<a href="#">
								<span class="tp-info"><span>Briefcase</span></span>
								<img src="../../Assets/Images/Paintings/7.jpg" />
							</a>
						</li>
						<li data-pile="Griffin Moore">
							<a href="#">
								<span class="tp-info"><span>Clipboard</span></span>
								<img src="../../Assets/Images/Paintings/8.jpg" />
							</a>
						</li>
						<li data-pile="Griffin Moore">
							<a href="#">
								<span class="tp-info"><span>Sweet pack</span></span>
							<img src="../../Assets/Images/Paintings/9.jpg" />
								</a>
						</li>

						<!-- Andrea Austoni -->
						<li data-pile="Andrea Austoni">
							<a href="#">
								<span class="tp-info"><span>Growth in 2012 (Holiday Card)</span></span>
								<img src="../../Assets/Images/Paintings/10.jpg" />
							</a>
						</li>
						<li data-pile="Andrea Austoni">
							<a href="#">
								<span class="tp-info"><span>Grady Wilson</span></span>
								<img src="../../Assets/Images/Paintings/11.jpg" />
							</a>
						</li>
						<li data-pile="Andrea Austoni">
							<a href="#">
								<span class="tp-info"><span>More Cowbell</span></span>
							<img src="../../Assets/Images/Paintings/12.jpg" />
								</a>
						</li>
					</ul>
				</div>
			</section>

		</div><!-- /container -->
		<script type="text/javascript" src="../../Assets/Js/jquery.min.js"></script>
		<script type="text/javascript" src="../../Assets/Js/jquery.stapel.js"></script>
		<script type="text/javascript">
		    $(function () {

		        var $grid = $('#tp-grid'),
					$name = $('#name'),
					$close = $('#close'),
					$loader = $('<div class="loader"><i></i><i></i><i></i><i></i><i></i><i></i><span>Loading...</span></div>').insertBefore($grid),
					stapel = $grid.stapel({
					    delay: 50,
					    onLoad: function () {
					        $loader.remove();
					    },
					    onBeforeOpen: function (pileName) {
					        $name.html(pileName);
					    },
					    onAfterOpen: function (pileName) {
					        $close.show();
					    }
					});

		        $close.on('click', function () {
		            $close.hide();
		            $name.empty();
		            stapel.closePile();
		        });

		    });
		</script>
	
</asp:Content>

