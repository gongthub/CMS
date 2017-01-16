
$(function () {
    var pages = $(".div-cmspage");
    if (pages != null && pages != undefined && pages.length > 0) {
        $.each(pages, function (index, page) {
            initPageAttr(page);
        });
    }

});
////每页条数
//var PAGESIZE = 10;
////显示类型
//var PAGETYPE = "";
////所有信息条数
//var INFOSUM = 0;
////总页数
//var PAGENUM = 0;
function initPageAttr(e) {
    //传递对象
    var pageobj = {
        obj: e,
        pagesize: 10,
        pagetype: "",
        infosum: 0,
        pagenum: 0,
        selectindex: 1,
    };

    var infoType = $(e).attr("info-type");
    var infoPageSize = $(e).attr("info-pagesize");
    if (infoType != null && infoType != undefined && infoType.trim() != "") {
        pageobj.pagetype = infoType;
        if (infoPageSize != null && infoPageSize != undefined && infoPageSize.trim() != "") {
            if (!isNaN(infoPageSize)) {
                pageobj.pagesize = infoPageSize;
                initPage(pageobj);
            } else {
                alert("info-pagesize必须是数字！");
            }
        }
    }
}

function initPage(pageobj) {
    var pageInfos = $(pageobj.obj).find(pageobj.pagetype);
    if (pageInfos != null && pageInfos != undefined && pageInfos.length > 0) {
        pageobj.infosum = pageInfos.length;
        pageobj.pagenum = Math.ceil(pageobj.infosum / pageobj.pagesize);
        var startindex = (pageobj.selectindex - 1) * pageobj.pagesize;
        var endindex = pageobj.selectindex * pageobj.pagesize;
        $.each(pageInfos, function (index, pageInfo) {
            if (index >= startindex && index < endindex) {
                $(pageInfo).css("display", "");
            } else {
                $(pageInfo).css("display", "none");
            }
        });
        initPageTab(pageobj);
    }
}
function initPageTab(pageobj) {

    var pagectl = $(pageobj.obj).find(".div-cmspage-pagetab");
    if (pagectl[0] != null && pagectl[0] != undefined)
        pagectl[0].remove();

    var pageControl = document.createElement("div");
    pageControl.className = "div-cmspage-pagetab";
    if (pageobj.pagenum > 0) {
        for (var i = 1; i <= pageobj.pagenum; i++) {
            var pageNumber = document.createElement("span");
            pageNumber.innerText = i;
            pageNumber.onclick = function (e) {
                //alert(e.toElement.innerText);
                pageobj.selectindex = e.toElement.innerText;
                pageChange(pageobj)
            };
            pageControl.appendChild(pageNumber);
        }
    }
    pageobj.obj.appendChild(pageControl);

}

function pageChange(pageobj) { 
    initPage(pageobj);
}