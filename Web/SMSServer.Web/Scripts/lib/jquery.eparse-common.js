
(function ($) {

    /*
    * xwAjaxPost form plugin
    * @requires jQuery v1.1 or later
    * post�ύʱͳһ�������ϴ���
    *pre-need:jquery.form.js && jquery.blockUI.js
    * Revision: wangjun
    * Version: 1.0.0
    */

    /*
    *  buton�����Ͳ�Ҫ����Ϊsubmit��
    *  demo: function updaterole() {
    *    $("#form1").xwAjaxPost(function () {
    * �ص���ajax����ɹ���ķ���  parent.callback_refresh_diagclose();
    *    });
    *}
    */
    $.fn.xwAjaxPost = function (options) {
        var isValid = $(this).valid();
        if (!isValid) {
            var validator = $(this).validate();
            for (var i = 0; i < validator.errorList.length; i++) {
                var obj = validator.errorList[i];
                $(obj.element).attr("title", obj.message);
            }
            $.unblockUI();
            return this;
        }
        if (typeof options == 'function')
            options = { EndPost: options };

        var defaults = {

        }
        var options = $.extend(defaults, options);
        this.each(function () {
            var suboptions = {
                dataType: 'json',
                beforeSubmit: postBefore,
                success: postSuccess
            };
            $(this).ajaxForm(suboptions);
            $(this).submit();
            return this;
        });
        /*���Ϊjson��ʽ*/
        function postSuccess(responseData, statusText) {
            var result = responseData.Code;
            var message = responseData.Result;
            if (result == undefined) {
                result = 1;
                message = "����ɹ���";
            }
            if (typeof options.EndPost == 'function') {
                if ($("body").find("#isok").length == 0) {
                    $("body").append("   <input type='hidden' id='isok' />");
                }
                $("#isok").val("isok");
            }
            $.unblockUI();
            if ($("body").find("#loadingpanel222").length != 0) {
                $("#loadingpanel222").remove();
            }
            if (result == 1) {
                Dialog.alert(message, options.EndPost);
            }
            else {
                Dialog.alert(message);
            }
        }

        function postBefore() {
            if ($("body").find("#loading").length != 0) {
                $.blockUI({ message: $('#loading') });
            }
            else {
                $("body").append(" <div id='loadingpanel222'> <img alt='loading' id='loading' src='/Content/Images/loading.gif')' style='display:none' /></div>");
                $.blockUI({ message: $('#loading') });
            }
        }
        function postError() {
            $.unblockUI();
            Dialog.alert("");
        }

    };
    /*
    * disable form plugin
    * @requires jQuery v1.1 or later
    *disable  ����ture,false
     
    * Revision: wangwei
    * Version: 1.0.0
    */
    /*
    *demo: $(".input_style_E").disable(false);
    *       $(".input_style_E").disable(true);
    */
    $.fn.disable = function (options) {
        if (options == null || options == false) {
            this.each(function () {
                return $(this).removeAttr("disabled");
            });
        }
        else {
            this.each(function () {
                return $(this).attr("disabled", "disabled");
            });
        }
    };
})(jQuery);

 