//查找所有公告
function notice() {
    Ext.regModel('noticeModel', {
        fields: [
                    { name: 'noticeId' },
                    { name: 'noticeTitle' },
                    { name: 'createDate' },
                    { name: 'status' }
		        ]
    });

    var noticeStore = Ext.create('Ext.data.Store', {
        model: 'noticeModel',
        autoLoad: true,
        proxy: {
            type: 'ajax',
            url: '/InfoRelease/GetAllNotice',
            reader: {
                type: 'json',
                root: 'rows'
            }
        }
    });

    //json返回数据库的时间格式为通常为/Date(1332919782070)/，因此前台需要进行一定的转化
    function ChangeDateFormat(val) {
        if (val != null) {
            var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
            //月份为0-11，所以+1，月份小于10时补个0  
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            return date.getFullYear() + "-" + month + "-" + currentDate;
        }
        return "";
    }

    var noticeGrid = new Ext.grid.Panel({
        store: noticeStore,
        height: 190,
        selModel: Ext.create('Ext.selection.RowModel', { mode: "SINGLE" }),
        columns: [//配置表格列
                    { header: '公告编号', dataIndex: 'noticeId', sortable: true, hidden: true },
				    { header: '公告标题', width: 150, dataIndex: 'noticeTitle', renderer: function (val) { return '<font color=blue>' + val + '</font>'; } },
                    { header: '创建日期', width: 150, dataIndex: 'createDate', renderer: ChangeDateFormat },
                    { header: '状态', width: 150, dataIndex: 'status', renderer: function (val) {
                        if (val == "已发布")
                            return '<font color=red>' + val + '</font>';
                        else
                            return val;

                    }
                    },
                    { header: '删除', width: 90, renderer: function () { return '<font color=blue>删除</font>'; } }
			    ]
    });


    var noticePanel = new Ext.form.Panel({
        frame: true,
        items: [noticeGrid],
        buttons: [{
            text: '发布',
            handler: function () {
                var rows = noticeGrid.getSelectionModel().getSelection();

                Ext.Ajax.request({
                    url: '/InfoRelease/ReleaseNotice',
                    type: 'json',
                    params: { noticeId: rows[0].get('noticeId') },
                    success: function (response, option) {
                        Ext.Msg.alert("提示!", "发布成功！", callBack);
                        function callBack(id) {
                            if (id == "ok") {
                                noticeWin.close();
                                notice();
                            }
                        }
                    },
                    failure: function () {
                        Ext.Msg.alert("提示!", "发布失败！");
                    }
                });

            }

        }, {
            text: '添加',
            handler: function () {
                addNotice();
                noticeWin.close();
            }

        }, {
            text: '修改',
            handler: function () {
                noticeWin.close();
                var rows = noticeGrid.getSelectionModel().getSelection();
                updateNotice(rows[0].get('noticeId'));
            }

        }, {
            text: '返回',
            handler: function () {
                noticeWin.close();
            }
        }]
    });


    var noticeWin = new Ext.Window({
        title: '公告',
        resizable: false,
        height: 260,
        modal: true,
        width: 580,
        items: [noticePanel]
    });

    noticeGrid.on('cellclick', function (grid, rowIndex, colIndex, e) {
        var rows = grid.getSelectionModel().getSelection();
        if (colIndex == 0) {
            noticeDetail(rows[0].get('noticeId'));
            noticeWin.close();
        } else if (colIndex == 3) {
            Ext.MessageBox.confirm('提示', '是否删除？', callBack);
            function callBack(id) {
                if (id == "yes") {
                    Ext.Ajax.request({
                        url: '/InfoRelease/DeleteNotice',
                        type: 'json',
                        params: { noticeId: rows[0].get('noticeId') },
                        success: function (response, option) {
                            Ext.Msg.alert("提示!", "删除成功！", callBack);
                            function callBack(id) {
                                if (id == "ok") {
                                    noticeWin.close();
                                    notice();
                                }
                            }
                        },
                        failure: function () {
                            Ext.Msg.alert("提示!", "删除失败！");
                        }
                    });
                }
            }

        }
    });


    noticeWin.show();


}