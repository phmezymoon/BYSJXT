//获取公告的内容
function noticeDetail(noticeId) {
    Ext.Ajax.request({
        url: '/InfoRelease/GetNoticeContent',
        type: 'json',
        params: { noticeId: noticeId },
        success: function (response, option) {
            var json = Ext.JSON.decode(response.responseText);

            Ext.getCmp("noticeContent").setValue(json.rows[0].noticeContent);
        },
        failure: function () {
            Ext.Msg.alert("提示!", "读取数据失败！");
        }
    });

    var noticePanel = new Ext.form.Panel({
        border: true,
        labelWidth: 1,
        frame: true,
        items: [{
            xtype: 'textarea',
            height: 250,
            readOnly: true,
            id: 'noticeContent',
            anchor: '99%'
        }]
    });

    var mainPanel = new Ext.Panel({
        border: false,
        height: 360,
        layout: 'form',
        width: 700,
        items: [noticePanel]

    });

    var mainWin = new Ext.Window({
        title: "公告内容",
        width: 710,
        height: 300,
        resizable: false,
        modal: 'true',
        layout: 'column',
        items: [
                    mainPanel
                ],
        buttons: [{
            text: '修改',
            handler: function () {
                updateNotice(noticeId);
                mainWin.close();
            }

        }, {
            text: '返回',
            handler: function () {
                mainWin.close();
                notice();
            }
        }]
    });
    mainWin.show();
}