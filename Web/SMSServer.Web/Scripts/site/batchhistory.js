﻿var gird;
$(document).ready(function () {
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/batchhistory/getlist?parame=1',
            dataType: 'json',
            colModel: [
                { display: 'id', name: 'id', width: 100, align: 'center', hide: true },
                { display: '批次名称', name: 'batchname', width: 100, align: 'center' },
                { display: '短信内容', name: 'content', width: 250, align: 'center' },
                { display: '状态', name: 'state', width: 80, align: 'center' },
                { display: '提交数', name: 'sendamount', width: 80, align: 'center' },
                { display: '成功数', name: 'successamount', width: 80, align: 'center' },
                { display: '发送时间', name: 'posttime', width: 100, align: 'center' },
                { display: '创建时间', name: 'createtime', width: 100, align: 'center' },
                { display: '操作', name: 'identity', width: 100, align: 'center' }
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
            autoload: true,
            singleSelect: true,
            specify: true,
            striped: true,
            showcheckbox: true,
            mutliSelect: true,
            showToggleBtn: true
        });
    }
});