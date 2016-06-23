/*$(document).ready(function () {   

    $('.lightmenu ul li').hover(
        function () {
            $('ul:first', this).slideDown(150);  
        },
        function () {
            $('ul:first', this).slideUp(150);
        }
    ); 
	
});*/
$(document).ready(function() {	
  $('.lightmenu ul li').hover(function() {
    //выполняется при наведении
    $(this).find('ul').fadeIn(300);
  },
  function() {
    //выполняется когда мы убираем мышку
    $(this).find('ul').hide();
  });	
});