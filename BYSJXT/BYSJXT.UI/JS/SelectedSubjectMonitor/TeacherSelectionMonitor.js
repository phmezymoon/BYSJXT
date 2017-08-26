﻿//教师选学生监控
function teacherSelectionMonitor() {
    var departmentTree = getDepartmentTree();

    var leftPanel = new Ext.Panel({
        autoScroll: true,
        items: [{
            title: '院系组织',
            height: 435,
            items: [departmentTree]
        }],
        height: 437,
        width: 230
    });

    Ext.regModel('teacherModel', {
        fields: [
                { name: 'teacherName' },
                { name: 'teacherId' },
                { name: 'collegeName' },
                { name: 'departmentName' },
                { name: 'declaredAmount' },
                { name: 'selectedAmount' }
		        ]
    });

    var teacherStore = Ext.create('Ext.data.Store', {
        model: 'teacherModel',
        proxy: {
            type: 'ajax',
            url: '/SelectedSubject/GetAllTeachers',
            reader: {
                type: 'json',
                root: 'rows'
            }
        }
    });

    var teacherGrid = new Ext.grid.Panel({
        store: teacherStore,
        height: 390,
        selModel: Ext.create('Ext.selection.RowModel', { mode: "SINGLE" }),
        columns: [//配置表格列
				    {header: '工号', dataIndex: 'teacherId', width: 90, sortable: true },
                    { header: '姓名', dataIndex: 'teacherName', width: 65, sortable: true, renderer: function (val) { return '<font color=blue>' + val + '</font>'; } },
                    { header: '学院', dataIndex: 'collegeName', width: 150, sortable: true },
                    { header: '系所', dataIndex: 'departmentName', width: 150, sortable: true },
                    { header: '申报课题', dataIndex: 'declaredAmount', width: 80, sortable: true },
                    { header: '已选课题', dataIndex: 'selectedAmount', width: 80, sortable: true },
                    { header: '详细信息', width: 90, renderer: function () { return '<font color=blue>查询</font>'; } }//渲染
			    ]
    });

    var rightPanel = new Ext.form.Panel({
        width: 732,
        height: 437,
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
                id: 'nodeName',
                readOnly: true,
                fieldLabel: '名称'
            }//, {
//                xtype: 'textfield',
//                columnWidth: .4,
//                frame: true,
//                margin: '0 0 0 50',
//                labelWidth: 60,
//                id: 'AmountForm',
//                readOnly: true,
//                fieldLabel: '合计数量'
//            }
            ]
        }, teacherGrid
                                            ],
        buttons: [ {
            text: '返回',
            handler: function () {
                mainWin.close();
            }
        }]
    });


    var mainPanel = new Ext.Panel({
        layout: 'column',
        items: [leftPanel, rightPanel]
    });

    var mainWin = new Ext.Window({
        title: '教师选学生监控',
        height: 470,
        resizable: false,
        modal: true,
        width: 978,
        items: [mainPanel]
    });

    //获取树节点
    departmentTree.on("itemclick", function (view, record, item, index, e) {
        Ext.getCmp('nodeName').setValue(record.raw.text);
        teacherStore.load({
            params: {
                choseTreeId: record.raw.id
            }
        });
    });

    teacherGrid.on('cellclick', function (grid, rowIndex, colIndex, e) {
        if (colIndex == 6) {
            var rows = grid.getSelectionModel().getSelection();
            teacherSelectionList({
                teacherId: rows[0].get('teacherId'),
                teacherName: rows[0].get('teacherName'),
                departmentName: rows[0].get('departmentName'),
                declaredAmount: rows[0].get('declaredAmount')
            });
        }
    });

    mainWin.show();
}