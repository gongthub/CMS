
//初始化新页面分页加载控件
function initNewPageEle(eleId) {
    var hdPageEle = $("#hd" + eleId);
    var totalPages = hdPageEle.attr("totalPage");
    var currPages = hdPageEle.attr("currPage");
    if (currPages == null || currPages == undefined) {
        currPages = 1;
    }
    var pageInt = Number(currPages);

    var totalPageint = Number(totalPages);

    if (totalPageint >= pageInt) {
        $("#pageEle" + eleId).pagination({
            currentPage: pageInt,
            totalPage: totalPageint,
            isShow: true,
            count: 7,
            homePageText: "首页",
            endPageText: "尾页",
            prevPageText: "上一页",
            nextPageText: "下一页",
            callback: function (current) {
                var origin = window.location.origin;
                var pathnames = window.location.pathname;
                var strs = pathnames.split('/');
                if (strs.length >= 2) {
                    var colNames = "";
                    if (strs[0] != "" && strs[0] != null) {
                        colNames = strs[0];
                    } else
                        if (strs[1] != "" && strs[1] != null) {
                            colNames = strs[1];
                        }
                    var hrefs = origin + "/" + colNames + "/" + current;
                    window.location.href = hrefs;
                }
            }
        });
    }
}

//初始化Ajax分页加载控件 重新填充当前区域
function initAjaxPageEle(eleId) {
    var hdPageEle = $("#hd" + eleId);
    var totalPages = hdPageEle.attr("totalPage");
    var currPages = hdPageEle.attr("currPage");
    var totalPage = Number(totalPages);
    var currPage = Number(currPages);
    if (totalPage >= currPage) {
        initPage(eleId, currPage, totalPage);
    }
}

//初始化Ajax分页加载控件 叠加内容在内容区域
function initAjaxPageEleOver(eleId) {
    var hdPageEle = $("#hd" + eleId);
    var totalPages = hdPageEle.attr("totalPage");
    var currPages = hdPageEle.attr("currPage");
    var totalPage = Number(totalPages);
    var currPage = Number(currPages);
    var nextdiv = "";
    if (totalPage >= currPage) {
        nextdiv = '<div class="syspageEleNext" id="syspageEleNext' + eleId + '" onclick="initPageOver(' + "'" + eleId + "'" + ')" style="cursor:pointer">加载更多...</div>';
    } else {
        nextdiv = '<div class="syspageEleNextNull">没有更多了</div>';
    }
    $("#pageEle" + eleId).append(nextdiv);
}

function initPage(eleId, currpage, totalpage) {

    $("#pageEle" + eleId).pagination({
        currentPage: currpage,
        totalPage: totalpage,
        isShow: true,
        count: 7,
        homePageText: "首页",
        endPageText: "尾页",
        prevPageText: "上一页",
        nextPageText: "下一页",
        callback: function (current) {
            GetDatas(eleId, current, 1);
        }
    });
}

function initPageOver(eleId) {
    var hdPageEle = $("#hd" + eleId);
    var totalPages = hdPageEle.attr("totalPage");
    var currPages = hdPageEle.attr("currPage");
    var totalPage = Number(totalPages);
    var currPage = Number(currPages);
    currPage++;
    if (totalPage >= currPage) {
        GetDatas(eleId, currPage, 2);
    }
    if (totalPage <= currPage) {
        $("#syspageEleNext" + eleId).remove();
        var nextdiv = '<div class="syspageEleNext">没有更多了</div>';
        $("#pageEle" + eleId).append(nextdiv);
    }
    //$("#pageEle" + eleId).pagination({
    //    currentPage: currpage,
    //    totalPage: totalpage,
    //    isShow: true,
    //    count: 7,
    //    homePageText: "首页",
    //    endPageText: "尾页",
    //    prevPageText: "上一页",
    //    nextPageText: "下一页",
    //    callback: function (current) {
    //        GetDatas(eleId, current, 2);
    //    }
    //});
}

function GetDatas(Ids, curr, contentType) {
    var hdPageEle = $("#hd" + Ids);
    var currCounts = hdPageEle.attr("currCount");
    var sourcename = hdPageEle.attr("sourcename");
    var sort = hdPageEle.attr("sort");
    var sortdesc = hdPageEle.attr("sortdesc");
    var sortdesc = hdPageEle.attr("sortdesc");

    var mcodes = hdPageEle.html();
    var ishtmls = hdPageEle.attr("ishtml");
    if (ishtmls != "false") {
        ishtmls = "true";
    }
    if (sort == null || typeof (sort) == "undefined") {
        sort = "";
    }
    if (sortdesc == null || typeof (sortdesc) == "undefined") {
        sortdesc = "";
    }

    var currCount = Number(currCounts);
    var currPage = Number(curr);

    var attrDatas = {};
    var sysajaxpageattrs = hdPageEle.find(".sysajaxpageattr");
    if (sysajaxpageattrs != null && sysajaxpageattrs != undefined && sysajaxpageattrs.length > 0) {
        for (var i = 0; i < sysajaxpageattrs.length; i++) {
            var fname = $(sysajaxpageattrs[i]).attr("fname");
            var fvalue = $(sysajaxpageattrs[i]).attr("fvalue");
            attrDatas[fname] = fvalue;
        }
    }
    var jsondata = {
        SourceName: sourcename,
        Sort: sort,
        SortDesc: sortdesc,
        CurrCount: currCount,
        CurrPage: currPage,
        IsHtml: ishtmls,
        MCodes: htmlEncode(mcodes)
    }
    var formData = new FormData();
    formData.append("pageDatas", JSON.stringify(jsondata));
    formData.append("attrDatas", JSON.stringify(attrDatas));

    $.ajax({
        url: '/WebSiteCommon/GetContentModels',
        // 告诉jQuery不要去处理发送的数据
        processData: false,
        // 告诉jQuery不要去设置Content-Type请求头
        contentType: false,
        data: formData,
        dataType: 'JSON',
        type: 'POST',
        success: function (datas) {
            var data = eval(datas);
            if (data.IsHtml == "false") {
                return data.ContentModels;
            } else {
                if (contentType == 1) {
                    var ohtmls = hdPageEle[0].outerHTML;
                    var PageEle = $("#" + Ids);
                    PageEle.html(data.Htmlstr + ohtmls);
                } else
                    if (contentType == 2) {
                        var PageEle = $("#" + Ids);
                        var oldHtmls = PageEle.html();
                        PageEle.html(oldHtmls + data.Htmlstr);
                    }

            }
            hdPageEle = $("#hd" + Ids);
            hdPageEle.attr("totalCount", data.TotalCount);
            hdPageEle.attr("totalPage", data.TotalPage);
            hdPageEle.attr("currCount", data.CurrCount);
            hdPageEle.attr("currPage", data.CurrPage);
            initPage(data.CurrPage, data.TotalPage);
        }
    });
}

function htmlEncode(str) {
    var ele = document.createElement('span');
    ele.appendChild(document.createTextNode(str));
    return ele.innerHTML;
}