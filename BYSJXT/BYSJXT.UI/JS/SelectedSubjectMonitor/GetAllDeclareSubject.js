//申报课题一览表
function getAllDeclareSubject() {
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

    Ext.regModel('subjectModel', {
        fields: [
                { name: 'subjectId' },
                { name: 'subjectName' },
                { name: 'teacherName' },
                { name: 'departmentName' },
                { name: 'source' },
                { name: 'type' },
                { name: 'status' }
		        ]
    });

    var subjectStore = Ext.create('Ext.data.Store', {
        model: 'subjectModel',
        proxy: {
            type: 'ajax',
            url: '/SelectedSubject/GetAllSubjects',
            reader: {
                type: 'json',
                root: 'rows'
            }
        }
    });

    var subjectGrid = new Ext.grid.Panel({
        store: subjectStore,
        height: 390,
        selModel: Ext.create('Ext.selection.RowModel', { mode: "SINGLE" }),
//        tbar: [
//               {
//                   xtype: 'button',
//                   text: '刷新',
//                   action: 'refreshBtn'
//               }, '-', {
//                   xtype: 'exporterbutton',
//                   text: '导出'
//	                //store: subjectStore
//	            }
//            ],
        columns: [//配置表格列
                    { header: '课题编号', dataIndex: 'subjectId', width: 90, sortable: true },
                    { header: '课题名称', dataIndex: 'subjectName', width: 280, sortable: true,
                        renderer: function (val) {
                            return '<font color=blue>' + val + '</font>';
                        }
                    },
                    { header: '课题来源', dataIndex: 'source', width: 80, sortable: true },
                    { header: '课题类型', dataIndex: 'type', width: 80, sortable: true },
                    { header: '指导教师', dataIndex: 'teacherName', width: 65, sortable: true },
                    { header: '系所', dataIndex: 'departmentName', width: 65 },
                    { header: '状态', dataIndex: 'status', sortable: true }
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
        }, subjectGrid
                                            ],
        buttons: [{
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
        title: '申报课题一览表',
        height: 470,
        resizable: false,
        modal: true,
        width: 978,
        items: [mainPanel]
    });

    //获取树节点
    departmentTree.on("itemclick", function (view, record, item, index, e) {
        Ext.getCmp('nodeName').setValue(record.raw.text);
        subjectStore.load({
            params: {
                choseTreeId: record.raw.id
            }
        });
    });

    subjectGrid.on('cellclick', function (grid, rowIndex, colIndex, e) {
        if (colIndex == 1) {
            var rows = grid.getSelectionModel().getSelection();
            declareSubjectDetail(rows[0].get('subjectId'));
        }
    });

    mainWin.show();
}