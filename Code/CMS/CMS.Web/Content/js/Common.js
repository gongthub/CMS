
function htmlEncode(str) {
    var ele = document.createElement('span');
    ele.appendChild(document.createTextNode(str));
    return ele.innerHTML;
}
function htmlDecode(str) {
    var ele = document.createElement('span');
    ele.innerHTML = str;
    return ele.textContent;
}

//上传图片
function uploadImg(fileId) { 
    var dataret = {};
    var formData = new FormData();
    formData.append("fileicon", $("#" + fileId + "")[0].files[0]);
    $.ajax({
        type: "POST",
        url: "/SystemManage/UpFile/UploadImg",
        dataType: "json",
        data: formData,
        async: false,
        // 告诉jQuery不要去处理发送的数据
        processData: false,
        // 告诉jQuery不要去设置Content-Type请求头
        contentType: false,
        success: function (data) {
            var jsonData = eval(data);
            if (jsonData.message == "true") {
                if (jsonData.data != null && jsonData.data != undefined) {
                    //filePath = jsonData.data; 
                    dataret = jsonData.data;
                }
            } else {
                alert(jsonData.data);
                return;
            }
        }
    });
    return dataret;
}