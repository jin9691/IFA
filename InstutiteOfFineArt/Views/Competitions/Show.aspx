<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Home.Master"
    AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="InstutiteOfFineArt.Views.Competitions.Show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyClass" runat="server">
    page
</asp:Content>
<%@ Import Namespace="InstutiteOfFineArt.Codes" %>
<asp:Content ID="Content5" ContentPlaceHolderID="CssJs" runat="server">
    <link rel="Stylesheet" type="text/css" href="../../Assets/Css/parallax.css" />
    <script src="../../Assets/Js/cufon-yui.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Assets/Js/jquery.easing.1.3.js"></script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentSite" runat="server">
    <% if (Flash.dictFlash != null) %>
    <% foreach (var key in Flash.dictFlash.Keys)
       { %>
    <center>
        <div class="alert alert-<%= key %> alert-small">
            <%= Flash.dictFlash[key] %>
        </div>
    </center>
    <% } %>
    <% Flash.dictFlash.Clear(); %>
    <nav class="cbp-spmenu-upload cbp-spmenu-vertical-upload cbp-spmenu-right" id="cbp-spmenu-s1">
        <h3><i class="glyphicon glyphicon-upload" style="margin-right: 10px"></i><b>Upload Painting</b></h3>
        <div class="menu-upload">      
            <form id="Form1" runat="server" action="Show.aspx" method="post" enctype="multipart/form-data">
                <center class="hiddenFileInputContainter">
                    <img src="../../Assets/Images/Pages/add.png" id="addImageUpload" />
                
                    <asp:FileUpload ID="fileUploadField" runat="server"></asp:FileUpload>
                
                    <br />
                    <asp:TextBox Visible="false" ID="fileUploadName" runat="server" Enabled="False"></asp:TextBox>
                    <asp:Label ID="lbfileUploadErr" runat="server" Text="" ForeColor="#88B4DA" CssClass="lbUploadErr"></asp:Label>
                </center>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <b>Description:</b>
                        <asp:TextBox ID="txtDesc" Height="150px" TextMode="MultiLine" CssClass="desc form-control" runat="server"></asp:TextBox>
                        <br>
                        <asp:Label ID="lbDescErr" runat="server" Text="" ForeColor="#88B4DA" CssClass="lbUploadErr"></asp:Label>
                        <center style="margin-top:20px">                        
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" 
                                CssClass="btn btn-success btn-lg" onclick="btnUpload_Click"></asp:Button>                           
                            <input type="reset" value="Cancel" id="hideRightPush" class="btn btn-danger btn-lg">                            
                        </center> 
                    </div>
                </div>
            </form>
        </div>
    </nav>
    <script type="text/javascript">

        $(document).ready(function () {
            if ($('#<%=fileUploadField.ClientID %>').val().length > 0) {
                readURL(this);
            }
            function readURL(input) {
                if (input.files && input.files[0]) {
                    console.log(input.files[0].type);
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        if (!input.files[0].type.match('image.*')) {
                            alert('no image');
                        } else {
                            console.log(e.target.result);
                            $("#preview_image").attr('src', e.target.result);
                            $("#addImageUpload").attr('src', e.target.result);
                        }
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            }

            $('#<%=fileUploadField.ClientID %>').change(function () {
                $('#<%=fileUploadName.ClientID %>').val(this.files[0].name);
                readURL(this);
            });

        });
    </script>
    <div id="pxs_container" class="pxs_container">
        <div class="pxs_loading">
            Loading images...</div>
        <div class="pxs_slider_wrapper">
            <asp:ListView ID="lvPxsSliderWrapper" runat="server">
                <LayoutTemplate>
                    <ul class="pxs_slider ul">
                        <li id="itemPlaceholder" runat="server" class="li"></li>
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li class="li">
                        <div class="row" style="margin-top: 1%">
                            <div class="col-md-5 image-src" style="margin-left: 2%">
                                <center>
                                <img src='../../Assets/Images/Paintings/<%# Eval("PaintingURL")%>' alt='<%# Eval("Id")%> Image' />
                                <center>
                                    <h2>
                                        Mark: <strong><small>
                                            <%# Eval("Mark")%></small></strong>
                                    </h2>
                                </center>
                                </center>
                            </div>
                            <div class="col-md-6">
                                <div class="image-desc">
                                    <h2>
                                        Student: <strong><small><%# Student_Name(Eval("StudentId"))%></small></strong> 
                                        <a href="#" class="btn btn-danger btn-sm pull-right"style="margin-left: 5px">More</a>
                                    </h2>
                                    <hr>
                                    <div class="row">
                                        <div class="col-md-2">
                                            <b>Description:</b>
                                        </div>
                                        <div class="col-md-10">
                                            <%# Eval("PaintingDescription")%>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-md-2">
                                            <b>Remark:</b>
                                        </div>
                                        <div class="col-md-10">
                                            <%# Eval("Comment")%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:ListView>
            <div class="pxs_navigation">
                <span class="pxs_prev"></span><span class="pxs_next"></span>
            </div>
            <div class="row">
                <ul class="pxs_thumbnails">
                        <asp:ListView ID="lvPxsSliderSmall" runat="server">
                            <LayoutTemplate>                  
                                <li class="image-thumbs" id="itemPlaceholder" runat="server"></li>
                                <li style="margin-left: 50%" class="img-upload"><a href="#" class="pull-right btn btn-primary btn-lg"
                                id="showRightPush"><span class="glyphicon glyphicon-upload" style="margin-right: 5px;
                                    opacity: 0.8"></span>Upload </a></li>                        
                            </LayoutTemplate>
                            <ItemTemplate>
                                 <li class="image-thumbs">
                                    <img style="height: 100px" src='../../Assets/Images/Paintings/<%# Eval("PaintingURL")%>' alt='<%# Eval("Id")%> Image' />
                                  </li>
                            </ItemTemplate>
                        </asp:ListView>
                    </ul>
                
            </div>
        </div>
    </div>
    <script type="text/javascript">
        (function ($) {
            $.fn.parallaxSlider = function (options) {
                var opts = $.extend({}, $.fn.parallaxSlider.defaults, options);
                return this.each(function () {
                    var $pxs_container = $(this),
                    o = $.meta ? $.extend({}, opts, $pxs_container.data()) : opts;

                    //the main slider
                    var $pxs_slider = $('.pxs_slider', $pxs_container),
                    //the elements in the slider
                    $elems = $pxs_slider.children(),
                    //total number of elements
                    total_elems = $elems.length,
                    //the navigation buttons
                    $pxs_next = $('.pxs_next', $pxs_container),
                    $pxs_prev = $('.pxs_prev', $pxs_container),
                    //the bg images
                    $pxs_bg1 = $('.pxs_bg1', $pxs_container),
                    $pxs_bg2 = $('.pxs_bg2', $pxs_container),
                    $pxs_bg3 = $('.pxs_bg3', $pxs_container),
                    //current image
                    current = 0,
                    //the thumbs container
                    $pxs_thumbnails = $('.pxs_thumbnails', $pxs_container),
                    //the thumbs
                    $thumbs = $pxs_thumbnails.children(".image-thumbs"),
                    //the interval for the autoplay mode
                    slideshow,
                    //the loading image
                    $pxs_loading = $('.pxs_loading', $pxs_container),
                    $pxs_slider_wrapper = $('.pxs_slider_wrapper', $pxs_container);

                    //first preload all the images
                    var loaded = 0,
                    $images = $pxs_slider_wrapper.find('img');

                    $images.each(function () {
                        var $img = $(this);
                        $('<img/>').load(function () {
                            ++loaded;
                            if (loaded == total_elems * 2) {
                                $pxs_loading.hide();
                                $pxs_slider_wrapper.show();

                                //one images width (assuming all images have the same sizes)
                                var one_image_w = $pxs_slider.find('img:first').width();

                                /*
                                need to set width of the slider,
                                of each one of its elements, and of the
                                navigation buttons
                                */
                                setWidths($pxs_slider,
                                $elems,
                                total_elems,
                                $pxs_bg1,
                                $pxs_bg2,
                                $pxs_bg3,
                                one_image_w,
                                $pxs_next,
                                $pxs_prev);

                                /*
                                set the width of the thumbs
                                and spread them evenly
                                */
                                $pxs_thumbnails.css({
                                    'width': one_image_w + 'px',
                                    'margin-left': -one_image_w / 2 + 'px'
                                });
                                var spaces = (one_image_w / (total_elems + 1)) + 20;

                                $thumbs.each(function (i) {
                                    var $this = $(this);
                                    var left = spaces * (i + 1) - $this.width() / 2;
                                    $this.css('left', left + 'px');
                                    $(".img-upload").css('left', left + 'px');
                                    $(".img-upload").css('top', '30px');
                                    if (o.thumbRotation) {
                                        var angle = Math.floor(Math.random() * 41) - 20;
                                        $this.css({
                                            '-moz-transform': 'rotate(' + angle + 'deg)',
                                            '-webkit-transform': 'rotate(' + angle + 'deg)',
                                            'transform': 'rotate(' + angle + 'deg)'
                                        });
                                    }
                                    //hovering the thumbs animates them up and down
                                    $this.bind('mouseenter', function () {
                                        $(this).stop().animate({ top: '-30px' }, 300);
                                    }).bind('mouseleave', function () {
                                        $(this).stop().animate({ top: '0px' }, 300);
                                    });
                                });

                                //make the first thumb be selected
                                highlight($thumbs.eq(0));

                                //slide when clicking the navigation buttons
                                $pxs_next.bind('click', function () {
                                    ++current;
                                    if (current >= total_elems)
                                        if (o.circular)
                                            current = 0;
                                        else {
                                            --current;
                                            return false;
                                        }
                                    highlight($thumbs.eq(current));
                                    slide(current,
                                    $pxs_slider,
                                    $pxs_bg3,
                                    $pxs_bg2,
                                    $pxs_bg1,
                                    o.speed,
                                    o.easing,
                                    o.easingBg);
                                });
                                $pxs_prev.bind('click', function () {
                                    --current;
                                    if (current < 0)
                                        if (o.circular)
                                            current = total_elems - 1;
                                        else {
                                            ++current;
                                            return false;
                                        }
                                    highlight($thumbs.eq(current));
                                    slide(current,
                                    $pxs_slider,
                                    $pxs_bg3,
                                    $pxs_bg2,
                                    $pxs_bg1,
                                    o.speed,
                                    o.easing,
                                    o.easingBg);
                                });

                                /*
                                clicking a thumb will slide to the respective image
                                */
                                $thumbs.bind('click', function () {
                                    var $thumb = $(this);
                                    highlight($thumb);
                                    //if autoplay interrupt when user clicks
                                    if (o.auto)
                                        clearInterval(slideshow);
                                    current = $thumb.index();
                                    slide(current,
                                    $pxs_slider,
                                    $pxs_bg3,
                                    $pxs_bg2,
                                    $pxs_bg1,
                                    o.speed,
                                    o.easing,
                                    o.easingBg);
                                });



                                /*
                                activate the autoplay mode if
                                that option was specified
                                */
                                if (o.auto != 0) {
                                    o.circular = true;
                                    slideshow = setInterval(function () {
                                        $pxs_next.trigger('click');
                                    }, o.auto);
                                }

                                /*
                                when resizing the window,
                                we need to recalculate the widths of the
                                slider elements, based on the new windows width.
                                we need to slide again to the current one,
                                since the left of the slider is no longer correct
                                */
                                $(window).resize(function () {
                                    w_w = $(window).width();
                                    setWidths($pxs_slider, $elems, total_elems, $pxs_bg1, $pxs_bg2, $pxs_bg3, one_image_w, $pxs_next, $pxs_prev);
                                    slide(current,
                                    $pxs_slider,
                                    $pxs_bg3,
                                    $pxs_bg2,
                                    $pxs_bg1,
                                    1,
                                    o.easing,
                                    o.easingBg);
                                });

                            }
                        }).error(function () {
                            alert('here')
                        }).attr('src', $img.attr('src'));
                    });



                });
            };

            //the current windows width
            var w_w = $(window).width();

            var slide = function (current,
            $pxs_slider,
            $pxs_bg3,
            $pxs_bg2,
            $pxs_bg1,
            speed,
            easing,
            easingBg) {
                var slide_to = parseInt(-w_w * current);
                $pxs_slider.stop().animate({
                    left: slide_to + 'px'
                }, speed, easing);
                $pxs_bg3.stop().animate({
                    left: slide_to / 2 + 'px'
                }, speed, easingBg);
                $pxs_bg2.stop().animate({
                    left: slide_to / 4 + 'px'
                }, speed, easingBg);
                $pxs_bg1.stop().animate({
                    left: slide_to / 8 + 'px'
                }, speed, easingBg);
            }

            var highlight = function ($elem) {
                $elem.siblings().removeClass('selected');
                $elem.addClass('selected');
            }

            var setWidths = function ($pxs_slider,
            $elems,
            total_elems,
            $pxs_bg1,
            $pxs_bg2,
            $pxs_bg3,
            one_image_w,
            $pxs_next,
            $pxs_prev) {
                /*
                the width of the slider is the windows width
                times the total number of elements in the slider
                */
                var pxs_slider_w = w_w * total_elems;
                $pxs_slider.width(pxs_slider_w + 'px');
                //each element will have a width = windows width
                $elems.width(w_w + 'px');
                /*
                we also set the width of each bg image div.
                The value is the same calculated for the pxs_slider
                */
                $pxs_bg1.width(pxs_slider_w + 'px');
                $pxs_bg2.width(pxs_slider_w + 'px');
                $pxs_bg3.width(pxs_slider_w + 'px');

                /*
                both the right and left of the
                navigation next and previous buttons will be:
                windowWidth/2 - imgWidth/2 + some margin (not to touch the image borders)
                */
                var position_nav = w_w / -one_image_w;
                $pxs_next.css('right', position_nav + 'px');
                $pxs_prev.css('right', position_nav + 'px');
                $pxs_prev.css('top', '15px');
            }

            $.fn.parallaxSlider.defaults = {
                auto: 0, //how many seconds to periodically slide the content.
                //If set to 0 then autoplay is turned off.
                speed: 1000, //speed of each slide animation
                easing: 'jswing', //easing effect for the slide animation
                easingBg: 'jswing', //easing effect for the background animation
                circular: true, //circular slider
                thumbRotation: true//the thumbs will be randomly rotated
            };
            //easeInOutExpo,easeInBack
        })(jQuery);


        $(".menu-upload>center>img").hover(function () {
            $(this).animate({ opacity: "1" }, 50);
        }, function () {
            $(this).animate({ opacity: "0.9" }, 50);
        })

        $(".img-upload").hover(function () {
            $(this).animate({ opacity: "1" }, 50);
        }, function () {
            $(this).animate({ opacity: "0.9" }, 50);
        })
        $(function () {
            var $pxs_container = $('#pxs_container');
            $pxs_container.parallaxSlider();
        });
        var menuRight = document.getElementById('cbp-spmenu-s1'),
           showRightPush = document.getElementById('showRightPush'),
           body_upload = document.body,
           menu_upload = document.getElementById('menu-upload');

        showRightPush.onclick = function () {
            classie.toggle(this, 'active');
            classie.toggle(body_upload, 'cbp-spmenu-push-toleft');
            classie.toggle(menuRight, 'cbp-spmenu-open');
            classie.toggle(menu_upload, 'cbp-spmenu-push-toleft');
        };
        hideRightPush.onclick = function () {
            classie.toggle(this, 'active');
            classie.toggle(body_upload, 'cbp-spmenu-push-toleft');
            classie.toggle(menuRight, 'cbp-spmenu-open');
            classie.toggle(menu_upload, 'cbp-spmenu-push-toleft');
        };
        var err = $(".lbUploadErr").text();
        if (err.length > 0) {
            $("#showRightPush").click();
        }
        $('.dropdown-toggle').dropdown();
    </script>
</asp:Content>
