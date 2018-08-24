// JavaScript source code

var lowimgs = $("img[lowsrc]");
if (lowimgs != null && lowimgs != undefined && lowimgs.length > 0) {
    $(lowimgs).each(function (index,item) {
        var lowsrcs = $(item).attr("lowsrc");
        if (lowsrcs != null) {
            var srcs = $(item).attr("src"); //获取
            $(item).attr("src", lowsrcs); // 设置

            var img = new Image();
            img.src = srcs;
            img.onload = function () {
                $(item).attr("src", srcs); // 设置
            }
        }
    });
}
