(function () {
    
    /*Hiển thị, ẩn menu trong chế độ tự động---*/
    function mo_menu(){
        $('body').addClass('open-menu');
    }
    
    $('.mobile-menu-toggle-btn').on('click', mo_menu);
 
    $('.mobile-menu-bg').on('click', function(){
        /*Dùng cách add  thuộc tính transition trong css vào lớp .mobile-menu-wrap thay cho việc gán trực tiếp vào lớp này
         *  khi ẩn  menu để tránh hiện tượng lộ menu khi load trang lần đầu*/
        $('.mobile-menu-wrap').css('transition', 'all  0.3s ease');
        $('body').removeClass('open-menu');
    });
	
	
	
	
	
    /*
    $('body').addClass('animate1');
    */
    /*-----------------------------------------*/
    
    /*Hiển thị danh mục------------------------*/
    function show_danhmuc(){
        
        $('body').addClass('show_dm');
    }
    $('#showdm').on('click', show_danhmuc);
    $('.danhmuc-bg').on('click', function(){
        $('body').removeClass('show_dm');
    });
    
    /*------------------------------------------*/
    
    
    /*Hiển thị món ăn -----------------------*/
    function show_monan(){
        
        $('body').addClass('show_ma');
         $('.monan').css({
             "transition": "all .2s ease"
         });
    }
    $('#themmonan').on('click', show_monan);
    $('.monan-bg').on('click', function(){
        $('body').removeClass('show_ma');
    });
    
    
   
    

    
   /*Định vị một đối tượng giữa màn hình--------*/ 
    $.fn.center = function(parent) {
       
        this.css({
            "position": "fixed",
            "top": ((($(window).height() - $(this).outerHeight()) / 2)  + "px"),
            "left": ((($(window).width() - $(this).outerWidth()) / 2)  + "px")
        });
        return this;
    };
    $.fn.center_k = function(parent) {

        this.css({
            "position": "fixed",
            "left": ((($(window).height() - $(this).outerHeight()) / 2)  + "px"),
            "top": ((($(window).width() - $(this).outerWidth()) / 2)  + "px")
        });
        return this;
    };
     $.fn.center_kk = function(parent) {

        this.css({
            "position": "fixed",
            "left": ((($(window).height() - $(this).outerHeight()) / 2)  + "px"),
            "top": ((($(window).width() - $(this).outerWidth()) / 2)  + "px")
        });
        return this;
    };
    
    $.fn.center1 = function(parent) {

        this.css({
            "position": "fixed",
            "top": ((150)  + "px"),
            "left": ((($(window).width() - $(this).outerWidth()) / 2)  + "px")
        });
        return this;
    };
    $.fn.center2 = function(parent) {

        this.css({
            "position": "fixed",
            "top": ((50)  + "px"),
            "left": ((($(window).width() - $(this).outerWidth()) / 2)  + "px")
        });
        return this;
    };
    
    /*-------------------------------*/
    $('.danhmuc').center();
    $('.monan').center();
   
    
    
    $('.indonhang').center();
    /*-------------------------------------------*/

    
/*JS Tạo hiệu ứng menusite. Thiết kế bởi Võ Văn Tùng*/
    function Plugin(element) {
        var $this = $(element);
         $this.children('li').hover(function () {
            $(this).addClass('openmbt');
       },function () {
            $(this).removeClass('openmbt');
        } );
    }
 
    $.fn[ "bootstrapMenu" ] = function(){
        new Plugin(this);
    };
    
    
    /*Ajax*/
    $('#test_t').on("click", function () {
      $('.print_t').printThis({
        base: ""
      });
    });
	
	
    
  
        

    /*---------------------------------------------*/
	
	function op_b(){
        $('body').addClass('open-bt');
        $('.d1').css('width', '100%');
        $('.st').css('width', 'calc(100% - 57px)')
    }
    $('.st').on('click', op_b);

	$('.bt3').on('click', function(){
        $('body').removeClass('open-bt');
        $('.d1').css('width', '250px');
        $('.st').css('width', '190px');
    });




   
  
	
	
 
    
	
	
	
	
	
    
})(jQuery);
