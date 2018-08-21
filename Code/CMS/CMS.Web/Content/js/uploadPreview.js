/*
*名称:图片上传本地预览插件 v1.1
*作者:周祥
*时间:2013年11月26日
*介绍:基于JQUERY扩展,图片上传预览插件 目前兼容浏览器(IE 谷歌 火狐) 不支持safari
*插件网站:http://keleyi.com/keleyi/phtml/image/16.htm
*参数说明: Img:图片ID;Width:预览宽度;Height:预览高度;ImgType:支持文件类型;Callback:选择文件显示图片后回调方法;
*使用方法: 
<div>
<img id="ImgPr" width="120" height="120" /></div>
<input type="file" id="up" />
把需要进行预览的IMG标签外 套一个DIV 然后给上传控件ID给予uploadPreview事件
$("#up").uploadPreview({ Img: "ImgPr", Width: 120, Height: 120, ImgType: ["gif", "jpeg", "jpg", "bmp", "png"], Callback: function () { }});
*/
jQuery.fn.extend({
    uploadPreview: function (opts) {
        var _self = this,
            _this = $(this);
        opts = jQuery.extend({
            Img: "ImgPr",
            Width: 100,
            Height: 100,
            ImgType: ["gif", "jpeg", "jpg", "bmp", "png", "ico"],
            Callback: function () { }
        }, opts || {});
        _self.getObjectURL = function (file) {
            var url = null;
            if (window.createObjectURL != undefined) {
                url = window.createObjectURL(file)
            } else if (window.URL != undefined) {
                url = window.URL.createObjectURL(file)
            } else if (window.webkitURL != undefined) {
                url = window.webkitURL.createObjectURL(file)
            }
            return url
        };
        _this.change(function () {
            if (this.value) {
                if (!RegExp("\.(" + opts.ImgType.join("|") + ")$", "i").test(this.value.toLowerCase())) {
                    alert("选择文件错误,图片类型必须是" + opts.ImgType.join("，") + "中的一种");
                    this.value = "";
                    return false
                }
                if ($.browser.msie) {
                    try {
                        $("#" + opts.Img).attr('src', _self.getObjectURL(this.files[0]))
                    } catch (e) {
                        var src = "";
                        var obj = $("#" + opts.Img);
                        var div = obj.parent("div")[0];
                        _self.select();
                        if (top != self) {
                            window.parent.document.body.focus()
                        } else {
                            _self.blur()
                        }
                        src = document.selection.createRange().text;
                        document.selection.empty();
                        obj.hide();
                        obj.parent("div").css({
                            'filter': 'progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)',
                            'width': opts.Width + 'px',
                            'height': opts.Height + 'px'
                        });
                        div.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = src
                    }
                } else {
                    $("#" + opts.Img).attr('src', _self.getObjectURL(this.files[0]))
                }
                opts.Callback()
            }
        })
    },

    uploadPreviews: function (opts) {
        var _self = this,
           _this = $(this);
        opts = jQuery.extend({
            div: "divShowImg",
            Width: 100,
            Height: 100,
            ImgType: ["gif", "jpeg", "jpg", "bmp", "png"],
            Callback: function () { }
        }, opts || {});
        _self.getObjectURL = function (file) {
            var url = null;
            if (window.createObjectURL != undefined) {
                url = window.createObjectURL(file)
            } else if (window.URL != undefined) {
                url = window.URL.createObjectURL(file)
            } else if (window.webkitURL != undefined) {
                url = window.webkitURL.createObjectURL(file)
            }
            return url
        };
        _this.change(function () {
            changeRemoveImgs(opts.div);
            for (var i = 0; i < this.files.length; i++) {
                if (this.value) {
                    if (!RegExp("\.(" + opts.ImgType.join("|") + ")$", "i").test(this.value.toLowerCase())) {
                        alert("选择文件错误,图片类型必须是" + opts.ImgType.join("，") + "中的一种");
                        this.value = "";
                        return false
                    }
                    if ($.browser.msie) {
                        try {
                            var img_html = "<div class='isImg' data-name='" + this.files[i].name + "' data-id='0'><img src='" + _self.getObjectURL(this.files[i]) + "' style='height:" + opts.Height
                                + "px; width:" + opts.Width + "px;'><button class='removeBtn' onclick='javascript:uploadPreviewsremoveImg(this)'>x</button></div>";
                            $("#" + opts.div).append(img_html);
                            //$("#" + opts.div).attr('src', _self.getObjectURL(this.files[i]))
                        } catch (e) {
                            var src = "";
                            var obj = $("#" + opts.div);
                            var div = obj.parent("div")[0];
                            _self.select();
                            if (top != self) {
                                window.parent.document.body.focus()
                            } else {
                                _self.blur()
                            }
                            src = document.selection.createRange().text;
                            document.selection.empty();
                            obj.hide();
                            obj.parent("div").css({
                                'filter': 'progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)',
                                'width': opts.Width + 'px',
                                'height': opts.Height + 'px'
                            });
                            div.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = src
                        }
                    } else {
                        var img_html = "<div class='isImg' data-name='" + this.files[i].name + "' data-id='0'><img src='" + _self.getObjectURL(this.files[i]) + "' style='height:" + opts.Height
                            + "px; width:" + opts.Width + "px;'><button class='removeBtn' onclick='javascript:uploadPreviewsremoveImg(this)'>x</button></div>";
                        $("#" + opts.div).append(img_html);
                        //$("#" + opts.Img).attr('src', _self.getObjectURL(this.files[i]))
                    }
                }
                opts.Callback()
            }
        })
    }
});
//移除图片
function uploadPreviewsremoveImg(r) {
    $(r).parent().remove();
}

function changeRemoveImgs(divShowId)
{
    var divImgs = $("#" + divShowId).find(".isImg");
    for (var i = 0; i < divImgs.length; i++) {
        var ids=$(divImgs[i]).data("id");
        if (ids == 0)
            $(divImgs[i]).remove();
    }
}

//获取图片
function uploadPreviewsgetImgs(inputFileId, divShowId) {
    var fileList =new Array();
    var files = $("#" + inputFileId)[0].files;
    var divImgs = $("#" + divShowId).find(".isImg");
    for (var i = 0; i < divImgs.length; i++) {
        for (var j = 0; j < files.length; j++) {
            if (files[j].name == $(divImgs[i]).data("name"))
                fileList.push(files[j].name);
        }
    }
    return fileList;
}