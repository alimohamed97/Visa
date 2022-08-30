$(function(){
    
    /** Home Section Services */
    // $('.small-category-2').hover(function(){
        
    //     $(this).css('height', '250px').find('p').slideDown();
    //     $(this).css('border', '3px solid #AB4B52');
    
    // });

    // $('.small-category-2').mouseleave(function(){
        
    //     $(this).css('height', '150px').find('p').hide();
    //     $(this).css('border', 'none');
    
    // });

    $('.show-flags').click(function(){
        $('.flags').slideToggle();
    });

    $('.ui').change(function(){
        $value =  $(this).find(":selected").attr('data-href'); 
        if($value != 'select'){
            window.location.href = $value+".html";
        }
       
    });


    //===== CHINA OR SAME SECTIONS 
    if($(window).width() <=  991){

        $('.buttons-services .col-buttons').removeClass('col').addClass('col-12');

        $('.buttons-services .arrow-box').click(function(){

            if($(this).next().hasClass('show-data')){
                $(this).next().removeClass('show-data');
                $(this).next().hide();
            }else{
                $('.arrow-data').removeClass('show-data');
                $(this).next().addClass('show-data');
                $(this).next().show();
            }
            
        });
    }


    //======= Change Background Filter 
    // [ header-home | header-china | header-uae | header-use | header-brazil - header-egypt - header-maldives | header-country ]
    /** Home */
    $('.tab-home').click(function(){
        $('#hero-area').addClass('header-home').removeClass('header-tab2 header-tab3 header-tab4 header-tab5');
    });

    /** China */
    $('.tab-china').click(function(){
        $('#hero-area').addClass('header-china').removeClass('header-tab2 header-tab3 header-tab4 header-tab5');
    });

    /** Brazil */
    $('.tab-brazil').click(function(){
        $('#hero-area').addClass('header-brazil').removeClass('header-tab2 header-tab3 header-tab4 header-tab5');
    });

    /** Country */
    $('.tab-country').click(function(){
        $('#hero-area').addClass('header-country').removeClass('header-tab2 header-tab3 header-tab4 header-tab5');
    });

    /** UAE */
    $('.tab-uae').click(function(){
        $('#hero-area').addClass('header-country').removeClass('header-tab2 header-tab3 header-tab4 header-tab5');
    });

    /** UAE */
    $('.tab-usa').click(function(){
        $('#hero-area').addClass('header-usa').removeClass('header-tab2 header-tab3 header-tab4 header-tab5');
    });

     /** Egypt */
     $('.tab-egypt').click(function(){
        $('#hero-area').addClass('header-egypt').removeClass('header-tab2 header-tab3 header-tab4 header-tab5');
    });

     /** Maldives */
     $('.tab-maldives').click(function(){
        $('#hero-area').addClass('header-maldives').removeClass('header-tab2 header-tab3 header-tab4 header-tab5');
    });
    
    $('.tab-header2').click(function(){
        $('#hero-area').addClass('header-tab2').removeClass('header-home header-tab3 header-tab4 header-tab5');
    });

    $('.tab-header3').click(function(){
        $('#hero-area').addClass('header-tab3').removeClass('header-home header-tab2 header-tab4 header-tab5');
    })

    $('.tab-header4').click(function(){
        $('#hero-area').addClass('header-tab4').removeClass('header-home header-tab2 header-tab3 header-tab5');
    })

    $('.tab-header5').click(function(){
        $('#hero-area').addClass('header-tab5').removeClass('header-home header-tab2 header-tab3 header-tab4');
    })
    
}); 