function getFile(fileLink, fileType) {
    var outPage = 'access/Downloads.ashx?fileName=' + fileLink + '&fileType=' + fileType;
    window.location.href = outPage;
}