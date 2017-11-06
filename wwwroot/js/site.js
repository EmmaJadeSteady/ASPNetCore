
(function(){
  /*  var ele = $("#username");      
    ele.text("Steady");

    var main = $("main1");
    if(main == null){
        console.log("null");
    }else{
        main.on("mouseenter", function(){
            main.style.backgroundColor = "#888";
        });

        main.on("mouseleave",function(){
            main.style.backgroundColor = "";
        });
    }
    var menuitems = $("nav ul a");
    menuitems.on("click", function(){
        var mi = $(this);
        alert(mi.text());
    });

   

} */


    var $sidebarAndSection = $("sidebar, #wrapper");
    var $icon = $("#sidebarToggle i.fa");
    if($sidebarAndSection == null){
        alert("sidebar section not found")
    }
    $("#sidebarToggle").on("click", function(){
        //alert("sidebar clicked");
        $sidebarAndSection.toggleClass("hide-sidebar");
        if($sidebarAndSection.hasClass("hide-sidebar")){
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        }else{
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left");
        }

    });

})(); 
