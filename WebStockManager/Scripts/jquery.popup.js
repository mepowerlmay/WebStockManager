/**
* popup.js
* @category   javascript
* @package    jquery
* @author     jiang <ljjiang2008@gmail.com>
* @version    
*/
(function($) {
    var popup = function() {
        var self = this;
        var popupStatus = 0;
        this.open = function(content) {

            var windowWidth = document.documentElement.clientWidth;
            var windowHeight = document.documentElement.clientHeight;

            //创建popupBackground
            if ($("#popupBackground1024").length == 0) {
                var divback = "<div id='popupBackground1024'></div>"
                $(divback).appendTo('body').hide().css({
                    position: 'absolute',
                    overflow: 'hidden',
                    height: '100%',
                    width: '100%',
                    top: 0,
                    left: 0,
                    background: '#000000',
                    zIndex: 1
                });
            };

            $("#popupBackground1024").css({
                "height": windowHeight
            });

            //如果传入的是选择器,则弹出窗口
            if (content.substr(0, 1) == '#') {

                var popupHeight = $(content).height();
                var popupWidth = $(content).width();

                $(content).css({
                    "position": "absolute",
                    "top": windowHeight / 2 - popupHeight / 2,
                    "left": windowWidth / 2 - popupWidth / 2
                });

                //if (popupStatus == 0) {
                $("#popupBackground1024").css({
                    "opacity": "0.5"
                });
                $("#popupBackground1024").fadeIn("fast");
                // }
                $(content).fadeIn("fast");
                popupStatus++;
            }
            else {
                //如果传入的不是选择器,则以消息形式弹出
                //创建消息小窗口
                if ($("#popupMessageContent1024").length == 0) {
                    //                    var divpopupmsgcontent = "<div id='popupMessageContent1024' style='z-index: 2; position: absolute;  width: 200px; zoom: 1; display: block; background: #ffffff; height: 100px; top: 211px; left: 315px'>" +
                    //                                            "<div id='popupclosebtn' style='margin-left: 148px'><input id='btnpopupclose' type='button' value='关闭'/></div>" +
                    //                                            "<div id='popupmsg' style='padding: 5px; background-color: Yellow'/>" +
                    //                                            "</div>";
                    var divpopupmsgcontent = "    <div style='z-index: 2; position: absolute;  width: 200px; zoom: 1; display: block;" +
"        background: #ffffff; height: 100px; top: 211px; left: 315px' id='popupMessageContent1024'>" +
"        <div style='margin: 2px; width: 194px; height: 94px; border: 1px solid #A9A9A9;'>" +
"            <div style='height: 27px; background: #CFF3DF; border-bottom: 1px solid #A9A9A9;" +
"                padding-top: 3px;'>" +
"                <div style='width: 140px; float: left; font-size: 12px; line-height: 24px; padding-left: 5px;'>" +
"                    系统提示</div>" +
"                <div style='float: left;' id='popupclosebtn'>" +
"                    <input id='btnpopupclose' value='关闭' type='button' /></div>" +
"            </div>" +
"            <div style='padding-bottom: 5px; height: 66px; line-height: 66px; color: #ff0000;" +
"                text-align: center;' id='popupmsg'>" +
"            </div>" +
"        </div>" +
"    </div>";
                    //设置消息框的风格
                    $(divpopupmsgcontent).appendTo('body').hide().css({
                        position: 'absolute',
                        height: '100px',
                        width: '200px',
                        background: '#FFFFFF',
                        zIndex: 2
                    });

                    //为消息小窗口加关闭按钮事件
                    $("#btnpopupclose").click(function() { $.popup.close("#popupMessageContent1024"); });
                };
                //设置消息小窗口的内容
                $("#popupmsg").html(content);
                //以普通弹出窗口形式打开消息窗口
                this.open("#popupMessageContent1024");
            }
        }
        this.close = function(content) {
            //   if (popupStatus == 1) {
            $("#popupBackground1024").fadeOut("fast");

            //  }
            $(content).fadeOut("fast");
            popupStatus--;
        }
    }
    $.extend({ popup: new popup() });
})(jQuery);