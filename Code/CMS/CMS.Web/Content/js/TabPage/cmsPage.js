
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
        obj: e, //对象
        pagesize: 10,//每页条数
        pagetype: "",//标签类型
        pagestyle: "onlynum",//样式
        infosum: 0,//总条数
        pagenum: 0,//总页数
        selectindex: 1,//当前页数
        pagectllen: 0,//页码长度
    };

    var infoType = $(e).attr("info-type");
    var infoPageSize = $(e).attr("info-pagesize");
    var pageStyle = $(e).attr("page-style");
    var pageCtlLen = $(e).attr("page-ctllen");

    if (infoType != null && infoType != undefined && infoType != "") {
        pageobj.pagetype = infoType;
        if (infoPageSize != null && infoPageSize != undefined && infoPageSize != "") {
            if (!isNaN(infoPageSize)) {
                pageobj.pagesize = infoPageSize;
            } else {
                alert("info-pagesize必须是数字！");
            }
        }
        if (pageStyle != null && pageStyle != undefined && pageStyle != "") {
            pageobj.pagestyle = pageStyle;
        }
        if (pageCtlLen != null && pageCtlLen != undefined && pageCtlLen != "") {
            pageobj.pagectllen = pageCtlLen;
        }
        initPage(pageobj);
    }
}
//分页处理
function initPage(pageobj) {
    //var pagecontents = $(pageobj.obj).find("div-cmspage-content");
    //if (pagecontents!=null)
    clearPageCtl(pageobj);

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
                //pageobj.selectindex = this.target.innerText;
                pageobj.selectindex = this.innerText;
                pageChange(pageobj)
            };
            pageControl.appendChild(pageNumber);
        }
    }
    pageobj.obj.appendChild(pageControl);
    initPageCtlStyle(pageobj);

}

//清除分页控件
function clearPageCtl(pageobj) {
    var pagectl = $(pageobj.obj).find(".div-cmspage-pagetab");
    if (pagectl[0] != null && pagectl[0] != undefined) {
        var _parentElement = pagectl[0].parentNode;
        if (_parentElement) {
            _parentElement.removeChild(pagectl[0]);
        }
    }
}

/* 
onlynum:仅有数字 
haspn:包含上一页、下一页
haspntd:包含上一页、下一页、首页、末页
*/
//处理分页控件样式
function initPageCtlStyle(pageobj) {
    switch (pageobj.pagestyle) {
        case "haspn":
            initinitPageCtlStylehaspn(pageobj);
            break;
        case "haspntd":
            initinitPageCtlStylehaspntd(pageobj);
            break;
    }
    initPageCtlLength(pageobj);
}

//处理haspn类型样式
function initinitPageCtlStylehaspn(pageobj) {
    var pagectl = $(pageobj.obj).find(".div-cmspage-pagetab");
    if (pagectl[0] != null && pagectl[0] != undefined) {
        var pageNumberNext = document.createElement("span");
        pageNumberNext.innerText = "下一页";
        pageNumberNext.className = "div-cmspage-pagetab-next";
        pageNumberNext.onclick = function (e) {
            if (pageobj.selectindex < pageobj.pagenum) {
                pageobj.selectindex = Number(pageobj.selectindex) + 1;
                pageChange(pageobj)
            }
        };
        pagectl[0].appendChild(pageNumberNext);



        var pageNumberPre = document.createElement("span");
        pageNumberPre.innerText = "上一页";
        pageNumberPre.className = "div-cmspage-pagetab-pre";
        pageNumberPre.onclick = function (e) {
            if (pageobj.selectindex > 1) {
                pageobj.selectindex = Number(pageobj.selectindex) - 1;
                pageChange(pageobj)
            }
        };
        $(pagectl[0]).prepend(pageNumberPre);
        //pagectl[0].insertBefore(pageNumberPre);
    }
}

//处理haspntd类型样式
function initinitPageCtlStylehaspntd(pageobj) {

    initinitPageCtlStylehaspn(pageobj);

    var pagectl = $(pageobj.obj).find(".div-cmspage-pagetab");
    if (pagectl[0] != null && pagectl[0] != undefined) {
        var pageNumberT = document.createElement("span");
        pageNumberT.innerText = "末页";
        pageNumberT.className = "div-cmspage-pagetab-top";
        pageNumberT.onclick = function (e) {
            pageobj.selectindex = Number(pageobj.pagenum);
            pageChange(pageobj)
        };
        pagectl[0].appendChild(pageNumberT);

        var pageNumberD = document.createElement("span");
        pageNumberD.innerText = "首页";
        pageNumberD.className = "div-cmspage-pagetab-down";
        pageNumberD.onclick = function (e) {
            pageobj.selectindex = Number(1);
            pageChange(pageobj)
        };
        $(pagectl[0]).prepend(pageNumberD);
        //pagectl[0].prepend(pageNumberD);
    }
}

//处理页码显示长度
function initPageCtlLength(pageobj) {
    var pagectls = $(pageobj.obj).find(".div-cmspage-pagetab span");
    if (pagectls != null && pagectls != undefined && pagectls.length > 0) {
        if (pageobj.pagectllen > 0 && pageobj.pagectllen < pageobj.pagenum) {
            var mediaIndex = Math.round(pageobj.pagectllen / 2) - 1;
            var startIndex = pageobj.selectindex + mediaIndex;
            if (pageobj.selectindex <= mediaIndex) {
                startIndex = 1 + Number(mediaIndex);
            } else {
                startIndex = 1 + Number(pageobj.selectindex);
            }
            var endIndex = pageobj.pagenum - mediaIndex;
            var svIndex = pageobj.selectindex - mediaIndex;
            if (svIndex <= 0) {
                svIndex = 0;
            }
            var evIndex = endIndex - mediaIndex - 1;
            //alert(startIndex);
            //alert(evIndex);
            $.each(pagectls, function (index, pagectl) {
                var ntext = pagectl.innerText;
                if (!isNaN(ntext)) {
                    if (((ntext <= startIndex && ntext > svIndex) || ((evIndex <= ntext && ntext <= startIndex) && startIndex > evIndex)) || ntext >= endIndex) {
                        $(pagectl).css("display", "");
                    } else {
                        $(pagectl).css("display", "none");
                    }
                }
                if (ntext == endIndex) {
                    var pagectld = document.createElement("span");
                    pagectld.innerText = "…";
                    $(pagectl).before(pagectld);
                }
            });
        }
    }
}

//换页事件
function pageChange(pageobj) {
    initPage(pageobj);
}