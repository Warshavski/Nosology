// shows up contact info dialog window (side menu in #HEADER) 
function showContactDialog() {
    jDialog.alert({
        title: '<h2><i class="fa fa-cube"></i> ООО "Эскейп-ЮГ"</h2>',
        content: '<strong>Тел. : </strong>(861) 257-04-14<br /><strong>Факс : </strong>(861) 257-37-97<br /> <strong>E-mail : </strong><a href="mailto:support@escyug.ru">support@escyug.ru</a>'
    });
}

// shows up page info dialog window (side menu in #HEADER)
function showNoticeDialog() {
    jDialog.alert({
        title: '<h2>Справка</h2>',
        content: '#FILL_WITH_INFORMATION'
    });
}

