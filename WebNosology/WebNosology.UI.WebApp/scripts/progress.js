// move element to the center of the screen 
jQuery.fn.center = function() {
    this.css("position", "absolute");
    this.css("top", Math.max(0, (($(window).height() - $(this).outerHeight()) / 2) +
                                                $(window).scrollTop()) + "px");
    this.css("left", Math.max(0, (($(window).width() - $(this).outerWidth()) / 2) +
                                                $(window).scrollLeft()) + "px");
    return this;
}

//$('#progress').center();
//$('.main-content').hide();

$('.progress-button').click(function() {
    $('#overlay').show();
    $('#progress').show();
});


//letter-button
//document.getElementById("progress").style.display = "block";
//document.getElementById("main-content").style.display = "none";
//var id= $(this).text();//attr("id"); // Get the ID
//var searchKey = $(this).text()
//var outPage = "resultlist.aspx?searchType=search&searchKey=" + searchKey;
//document.location.href = outPage;
