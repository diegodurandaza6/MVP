$(document).ready(function() {
	
	// Body Scroll Top
	 $('.scroll-top').click(function(e){
        $('html, body').animate({scrollTop:0}, 'slow');
        return false;
    });
	
	// Counter
	$('.counter').each(function () {
		$(this).prop('Counter',0).animate({
			Counter: $(this).text()
			}, {
			duration: 4000,
			easing: 'swing',
			step: function (now) {
			$(this).text(Math.ceil(now));
			}
		});
	});
	if ($(window).width() > 992) {
	  $(window).scroll(function(){  
		 if ($(this).scrollTop() > 10) {
			$('.header:not(.inner-header)').addClass("fixed-top");
		  }else{
			$('.header:not(.inner-header)').removeClass("fixed-top");
		  }   
	  });
	} 
	
	var options = [];
	$( '.dropdown-menu a' ).on( 'click', function( event ) {
	   var $target = $( event.currentTarget ),
		   val = $target.attr( 'data-value' ),
		   $inp = $target.find( 'input' ),
		   idx;
	   if ( ( idx = options.indexOf( val ) ) > -1 ) {
		  options.splice( idx, 1 );
		  setTimeout( function() { $inp.prop( 'checked', false ) }, 0);
	   } else {
		  options.push( val );
		  setTimeout( function() { $inp.prop( 'checked', true ) }, 0);
	   }
	   $( event.target ).blur();		  
	   console.log( options );
	   return false;
	});
	AOS.init();

	$("#profile-list ul li a").click(function (event){		
		var targetEle = $(this).attr('href');
		$('html, body').animate({
			scrollTop: ($(targetEle).offset().top - 100)
		}, 1000);
	});
	
	
	$(function () {
	  $('[data-toggle="tooltip"]').tooltip()
	})
	
	$(function () {
		$("#slider-range").slider({
			range: true,
			min: 0,
			max: 10000,
			values: [100, 15000],
			slide: function (event, ui) {
				$("#slider-range .ui-slider-range").html('<div class="dataVal"></div>');
				$('#slider-range .dataVal').text("$" + $("#slider-range").slider("values", 0) +
					" - $" + $("#slider-range").slider("values", 1));
			}
		});
		$("#slider-range .ui-slider-range").html('<div class="dataVal"></div>');
		$('#slider-range .dataVal').text("$" + $("#slider-range").slider("values", 0) +
			" - $" + $("#slider-range").slider("values", 1));
	});
});
