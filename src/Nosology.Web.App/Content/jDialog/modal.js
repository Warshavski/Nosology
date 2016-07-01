// shows up contact info dialog window (side menu in #HEADER) 
function showContactDialog() {
    jDialog.alert({
        title: '<h3><i class="fa fa-cube"></i> ООО "Эскейп-ЮГ"</h3>',
        content: '<strong>Тел. : </strong>(861) 257-04-14<br /><strong>Факс : </strong>(861) 257-37-97<br /> <strong>E-mail : </strong><a href="mailto:support@escyug.ru">support@escyug.ru</a>'
    });
}

// shows up page info dialog window (side menu in #HEADER)
function showNoticeDialog() {
    jDialog.alert({
        title: '<h3>Справка</h3>',
        content: '#FILL_WITH_INFORMATION'
    });
}

