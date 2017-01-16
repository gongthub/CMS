
$(function () {
    var pages = $(".div-cmspage");
    if (pages != null && pages != undefined && pages.length > 0) {
        $.each(pages, function (index, page) {
            initPageAttr(page);
        });
    }

});
//初始化属性
function initPageAttr(e) {
    //传递对象
    var pageobj = {
        obj: e,
        pagesize: 10,
        pagetype: "",
        pagestyle: "onlynum",
        infosum: 0,
        pagenum: 0,
        selectindex: 1,
    };

    var infoType = $(e).attr("info-type");
    var infoPageSize = $(e).attr("info-pagesize");
    var pageStyle = $(e).attr("page-style");

    if (infoType != null && infoType != undefined && infoType.trim() != "") {
        pageobj.pagetype = infoType;
        if (infoPageSize != null && infoPageSize != undefined && infoPageSize.trim() != "") {
            if (!isNaN(infoPageSize)) {
                pageobj.pagesize = infoPageSize;
            } else {
                alert("info-pagesize必须是数字！");
            }
        }
        if (pageStyle != null && pageStyle != undefined && pageStyle.trim() != "") {
            pageobj.pagestyle = pageStyle;
        }
        initPage(pageobj);
    }
}
//分页处理
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

//分页控件处理
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
            if (pageobj.selectindex == i) {
                pageNumber.className = "div-cmspage-pagetab-ctl-active";
            } else {
                pageNumber.className = "div-cmspage-pagetab-ctl";
            }
            pageNumber.onclick = function (e) {
                pageobj.selectindex = e.toElement.innerText;
                pageChange(pageobj)
            };
            pageControl.appendChild(pageNumber);
        }
    }
    pageobj.obj.appendChild(pageControl);
    initPageCtlStyle(pageobj);

}

/* 
onlynum:仅有数字 
haspn:包含上一页下一页

*/
//处理分页控件样式
function initPageCtlStyle(pageobj) {
    if (pageobj.pagestyle == "haspn") {
        var pagectl = $(pageobj.obj).find(".div-cmspage-pagetab");
        if (pagectl[0] != null && pagectl[0] != undefined) {
            var pageNumberNext = document.createElement("span");
            pageNumberNext.innerText = "下一页";
            pageNumberNext.onclick = function (e) { 
                if (pageobj.selectindex < pageobj.pagenum) {
                    pageobj.selectindex = Number(pageobj.selectindex)+1;
                    pageChange(pageobj)
                }
            };
            pagectl[0].appendChild(pageNumberNext);


            var pageNumberPre = document.createElement("span");
            pageNumberPre.innerText = "上一页";
            pageNumberPre.onclick = function (e) { 
                if (pageobj.selectindex > 1) {
                    pageobj.selectindex = Number(pageobj.selectindex) - 1;
                    pageChange(pageobj)
                }
            };
            pagectl[0].prepend(pageNumberPre);
        }
    }
}
 
//换页事件
function pageChange(pageobj) {
    initPage(pageobj);
}