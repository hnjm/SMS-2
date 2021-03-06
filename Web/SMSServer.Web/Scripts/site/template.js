﻿var gird;
$(document).ready(function () {
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/template/getlist',
            dataType: 'json',
            colModel: [
                 { display: 'id', name: 'id', width: 30, align: 'center', hide: false },
                        { display: '常用短语', name: 'content', width: 400, align: 'center' },
                        { display: ' 创建时间', name: 'createtime', width: 100, align: 'center' }
            ],
            minColToggle: 1,
            onrowclick: false,
            sortname: "id",
            sortorder: "asc",
            usepager: true,
            useRp: true,
            rp: 15,
            resizable: false,
            width: 'auto',
            height: 'auto',
            autoload: false,
            singleSelect: true,
            specify: true,
            striped: true,
            showcheckbox: true,
            mutliSelect: true,
            showToggleBtn: true
        });
        doQuery();
    }
    function doQuery() {
        var contactQuery = {

        };
        var params = {
            extParam: contactQuery
        };
        if ($('#grid')[0] != undefined) {
            $('#grid')[0].p.newp = 1;
            $('#grid').flexOptions(params).flexReload();
        }
    }

    $("#add").click(function () {
        $.AddAction(450, 160, '添加常用短语', "info/addtemplate.aspx", doQuery);;
    });
    $("#edit").click(function () {
        $.EditAction(450, 160, '修改常用短语', "info/EditTemplate.aspx?id={0}", doQuery);;
    });
    $("#delete").click(function () {
        $.DeleteAction("template", doQuery, "是否确认删除所选的数据？");
    });
    $("#clear").click(function () {
        art.dialog.confirm("是否确认清空所有？", function () {
            $.post("../ajax/template/clear", {}, function (data) {
                if (data.Result == 1) {
                    doQuery();
                } else {
                    $.showError(data.Message);
                }
            }, "json");
        }
         , function () {
         });
    });
});


function add() {
    if ($.trim($("#template").val()) == "") {
        $.showError("短语不能为空");
        return;
    }

    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}
function edit() {
    if ($.trim($("#template").val()) == "") {
        $.showError("短语不能为空");
        return;
    }
     /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });

    $("#select").click(function () {
        var checkedRows = $("#grid").getCheckedRows();
        if (!checkedRows || checkedRows.length <= 0) {
            $.showError("请选择需要的数据！");
            return false;
        }
        art.dialog.data("content", checkedRows[i][1]);
        var api = art.dialog.open.api;
        api && api.close();
    });
}