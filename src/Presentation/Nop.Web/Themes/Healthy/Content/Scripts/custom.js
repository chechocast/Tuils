$(document).ready(function () {
    //$(".master-wrapper-page").before('<div class="top-header" id="fixed"><div class="top-header-links"></div></div>');
    //$(".header-links").appendTo(".top-header-links");

    //$(".top-menu").prependTo(".header-links-wrapper");
    //$(".top-menu").wrap("<div class='top-menu'></div>");
   
    //jQuery(function(jQuery)
    //{
    //    // Transforming the form's Select control using jqTransform Plugin.
    //    $(".currency-selector").jqTransform();
        
    //});
    //$(".header-selectors-wrapper").prependTo(".header");
    //$("#flyout-cart").appendTo(".header-links");

    //$(".mega-menu").appendTo(".header-menu");

    //$(".header-links ul li:eq(0)").remove();

    //$("ul.top-menu li:eq(0)").prependTo("#mega-menu");
    //$("ul.top-menu li").last().css("padding-right", "0");
    

    //product page
    //$(".email-a-friend").before('<div class="wishlist"></div>');
    //$(".add-to-wishlist-button").appendTo(".wishlist");

    //var offset = $("#fixed").offset();
    //$(window).scroll(function () {
    //    if ($(window).scrollTop() > offset.top) {
    //        $("#fixed").css({ 'top': '0px', 'position': 'fixed' });
    //    }
    //    else {
    //        $("#fixed").css({ 'top': offset.top, 'position': 'static' });
    //    };
    //});



    /**************************************************************** Footer Accordion *********************************************************************/
    $(document).ready(function () {

        //blocks
        jQuery('.block .title').append('<span class="fontawesome-plus"></span>');
        jQuery('.block .title').on("click", function () {
            if (jQuery(this).find('span').attr('class') == 'fontawesome-minus') {
                jQuery(this).find('span').addClass('fontawesome-plus').removeClass('fontawesome-minus').parents('.block').find('.listbox').slideToggle();
            }
            else {
                jQuery(this).find('span').addClass('fontawesome-minus').removeClass('fontawesome-plus').parents('.block').find('.listbox').slideToggle();
            }
        });

        //block bestsellers
        jQuery('.bestsellers .title').append('<span class="fontawesome-minus"></span>');
        jQuery('.bestsellers .title').on("click", function () {
            if (jQuery(this).find('span').attr('class') == 'fontawesome-plus') {
                jQuery(this).find('span').addClass('fontawesome-minus').removeClass('fontawesome-plus').parents('.bestsellers').find('.owl-carousel.owl-theme').slideToggle();
            }
            else {
                jQuery(this).find('span').addClass('fontawesome-plus').removeClass('fontawesome-minus').parents('.bestsellers').find('.owl-carousel.owl-theme').slideToggle();
            }
        });

        //footer
        //if ($(window).width() < 768) {
            jQuery('.footer div > h3').append('<span class="fontawesome-plus"></span>');
            jQuery('.footer h3').on("click", function () {
                if (jQuery(this).find('span').attr('class') == 'fontawesome-minus') {
                    jQuery(this).find('span').addClass('fontawesome-plus').removeClass('fontawesome-minus').parents('.footer-menu').find('ul.footer-list').slideToggle();
                }
                else {
                    jQuery(this).find('span').addClass('fontawesome-minus').removeClass('fontawesome-plus').parents('.footer-menu').find('ul.footer-list').slideToggle();
                }
            });
        //}
    });
	
	$('body').append('<div id="back-top"><a href="#top"><span></span></a></div>');
    // hide #back-top first
    $("#back-top").hide();

    // fade in #back-top
    $(function () {
        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('#back-top').fadeIn();
            } else {
                $('#back-top').fadeOut();
            }
        });

        // scroll body to 0px on click
        $('#back-top a').click(function () {
            $('body,html').animate({
                scrollTop: 0
            }, 800);
            return false;
        });
    });

});