//详细工作记录
function scheduleDetail(param) {
    Ext.regModel('scheduleModel', {
        fields: [
                    { name: 'scheduleRequirement' },
                    { name: 'beginDate' },
                    { name: 'endDate' },
                    { name: 'status' }
		        ]
    });

    var scheduleStore = Ext.create('Ext.data.Store', {
        model: 'scheduleModel',
        proxy: {
            type: 'ajax',
            url: '/ProcessMonitor/GetSchedule',
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

    var scheduleGrid = new Ext.grid.Panel({
        store: scheduleStore,
        height: 190,
        selModel: Ext.create('Ext.selection.RowModel', { mode: "SINGLE" }),
        columns: [//配置表格列
				    { header: '进度要求', width: 400, dataIndex: 'scheduleRequirement' },
                    { header: '起始日期', dataIndex: 'beginDate', renderer: ChangeDateFormat },
                    { header: '截止日期', dataIndex: 'endDate', renderer: ChangeDateFormat },
                    { header: '状态', dataIndex: 'status', renderer: function (val) {
                        if (val == "未完成")
                            return '<font color=red>' + val + '</font>';
                        else if (val == "完成")
                            return '<font color=bule>' + val + '</font>';
                    } 
                    }
			    ]
    });


    var schedulePanel = new Ext.form.Panel({
        frame: true,
        items: [{
            layout: 'column',
            frame: true,
            items: [{
                xtype: 'textfield',
                border: false,
                columnWidth: .6,
                frame: true,
                labelWidth: 40,
                id: 'NameForm_Detail',
                readOnly: true,
                fieldLabel: '名称'
            }]
        }, scheduleGrid
                            ],
        buttons: [{
            text: '返回',
            handler: function () {
                scheduleWin.close();
            }
        }]
    });


    var scheduleWin = new Ext.Window({
        title: '详细工作记录',
        resizable: false,
        height: 300,
        modal: true,
        width: 780,
        items: [schedulePanel]
    });

    var initial = function () {
        Ext.getCmp('NameForm_Detail').setValue(param.studentName + '  详细工作记录');

        scheduleStore.load({
            params: {
                subjectId: param.subjectId
            }
        });
    };


    scheduleWin.show();

    initial();
}