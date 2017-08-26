//查询开题报告
function getOpeningReport() {
    var classTree = getClassTree();

    var leftPanel = new Ext.Panel({
        autoScroll: true,
        items: [{
            title: '院系组织',
            height: 435,
            items: [classTree]
        }],
        height: 437,
        width: 230
    });

    Ext.regModel('studentModel', {
        fields: [
                { name: 'studentId' },
                { name: 'studentName' },
                { name: 'className' },
                { name: 'departmentName' },
                { name: 'subjectId' },
                { name: 'subjectName' }
		        ]
    });

    var studentStore = Ext.create('Ext.data.Store', {
        model: 'studentModel',
        proxy: {
            type: 'ajax',
            url: '/ProcessMonitor/GetAllStudent',
            reader: {
                type: 'json',
                root: 'rows'
            }
        }
    });

    var studentGrid = new Ext.grid.Panel({
        store: studentStore,
        height: 360,
        selModel: Ext.create('Ext.selection.RowModel', { mode: "SINGLE" }),
        columns: [//配置表格列
                { header: '学号', dataIndex: 'studentId', width: 90, sortable: true },
                { header: '姓名', dataIndex: 'studentName', width: 65, sortable: true, renderer: function (val) { return '<font color=blue>' + val + '</font>'; } },
                { header: '系', dataIndex: 'departmentName', width: 80, sortable: true },
                { header: '班级', dataIndex: 'className', width: 100, sortable: true },
                { header: '课题编号', dataIndex: 'subjectId', width: 90, sortable: true, hidden: true },
                {
                    header: '课题名称',
                    dataIndex: 'subjectName',
                    width: 290,
                    renderer: function (val) { return '<font color=blue>' + val + '</font>'; },
                    sortable: true
                },
                { header: '详细信息', width: 90, renderer: function () { return '<font color=blue>查询</font>'; } }
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
        }, studentGrid
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
        title: '查阅开题报告',
        height: 470,
        resizable: false,
        modal: true,
        width: 978,
        items: [mainPanel]
    });

    //获取树节点
    classTree.on("itemclick", function (view, record, item, index, e) {
        Ext.getCmp('nodeName').setValue(record.raw.text);
        studentStore.load({
            params: {
                choseTreeId: record.raw.id
            }
        });
    });

    studentGrid.on('cellclick', function (grid, rowIndex, colIndex, e) {
        var rows = grid.getSelectionModel().getSelection();
        if (colIndex == 4) {
            declareSubjectDetail(rows[0].get('subjectId'));
        } else if (colIndex == 1) {
            getStudentInfo({
                studentId: rows[0].get('studentId')
            });
        } else if (colIndex == 5) {
            openingReportDetail({
                studentId: rows[0].get('studentId'),
                studentName: rows[0].get('studentName')
            });
        }
    });

    mainWin.show();
}