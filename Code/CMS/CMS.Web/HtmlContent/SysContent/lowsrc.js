// JavaScript source code

var lowimgs = $("img[lowsrc]");
if (lowimgs != null && lowimgs != undefined && lowimgs.length > 0) {
    $(lowimgs).each(function (index,item) {
        var lowsrcs = $(item).attr("lowsrc");
        if (lowsrcs != null) {
            var srcs = $(item).attr("src"); //��ȡ
            $(item).attr("src", lowsrcs); // ����

            var img = new Image();
            img.src = srcs;
            img.onload = function () {
                $(item).attr("src", srcs); // ����
            }
        }
    });
}
