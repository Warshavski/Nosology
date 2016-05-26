
function redirectToDocuments() {
    var url = '/Home/Documents';
    redirect(url);
}

function redirectToDownloads() {
    var url = '/Home/Downloads'
    redirect(url);
}

function redirect(url) {
    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',

        success: function (response) {
            window.location.href = response.Url;
        },
        error: function (response) {
            alert(response);
        }
    });
}

function renderPartial(url) {

    $('#p2').show();

    $.ajax({
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#p2').hide();
            $('main').html(data);
            componentHandler.upgradeAllRegistered();
        }
    });
    
};