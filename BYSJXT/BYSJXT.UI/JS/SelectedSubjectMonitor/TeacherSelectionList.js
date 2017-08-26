//教师选学生明细
function teacherSelectionList(teacher) {

    Ext.regModel('declareSubjectModel', {
        fields: [
                    { name: 'subjectId' },
                    { name: 'subjectName' },
                    { name: 'teacherId' },
                    { name: 'teacherName' },
                    { name: 'status' },
                    { name: 'studentId' },
                    { name: 'studentName' },
                    { name: 'selectedAmount' }
		        ]
    });

    var declareSubjectStore = Ext.create('Ext.data.Store', {
        model: 'declareSubjectModel',
        proxy: {
            type: 'ajax',
            url: '/SelectedSubject/GetTeacherSelectionList',
            reader: {
                type: 'json',
                root: 'rows'
            }
        }
    });

    var declareSubjectGrid = new Ext.grid.Panel({
        store: declareSubjectStore,
        height: 390,
        selModel: Ext.create('Ext.selection.RowModel', { mode: "SINGLE" }),
        columns: [//配置表格列
				    { header: '教师工号', width: 70, dataIndex: 'teacherId', sortable: true },
                    { header: '教师姓名', dataIndex: 'teacherName', sortable: true },
                    {
                        header: '课题名称',
                        dataIndex: 'subjectName',
                        renderer: function (val) {
                            return '<font color=blue>' + val + '</font>';
                        },
                        sortable: true,
                        width: 330
                    },
                    { header: '课题编号', dataIndex: 'subjectId', sortable: true, hidden: true },

                    { header: '状态', dataIndex: 'status', sortable: true },
                    { header: '选定学生', width: 70, renderer: function (val) {
                        if (val == null)
                            return '<font color=red>未选定</font>';
                        return '<font color=blue>' + val + '</font>';
                    }, dataIndex: 'studentName', sortable: true
                    },
                    { header: '学号', width: 100, dataIndex: 'studentId', sortable: true },
                    { header: '选题学生数', width: 75, dataIndex: 'selectedAmount', renderer: function (val) {
                        return '<font color=blue>' + val + '</font>';
                    }, sortable: true
                    }
			    ]
    });


    var declareSubjectPanel = new Ext.form.Panel({
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
            }, {
                xtype: 'textfield',
                columnWidth: .4,
                frame: true,
                margin: '0 0 0 50',
                labelWidth: 60,
                id: 'AmountForm_Detail',
                readOnly: true,
                fieldLabel: '合计数量'
            }]
        }, declareSubjectGrid
                                ],
        buttons: [{
            text: '返回',
            handler: function () {
                declareSubjectWin.close();
            }
        }]
    });


    var declareSubjectWin = new Ext.Window({
        title: '教师选学生明细',
        resizable: false,
        height: 500,
        modal: true,
        width: 980,
        items: [declareSubjectPanel]
    });

    var initial = function () {

        // var title = teacher.departmentName + '    ' + teacher.teacherName; //更改名称显示信息

        Ext.getCmp('NameForm_Detail').setValue(teacher.teacherName + ' 选学生明细');
        Ext.getCmp('AmountForm_Detail').setValue(teacher.declaredAmount);


        declareSubjectStore.load({
            params: {
                teacherId: teacher.teacherId
            }
        });
    };

    //    
    //                Ext.getCmp('ImportButton_Detail').on('click',function (){
    //                    //try {
    //                        Ext.ux.Grid2Excel.Save2Excel(declareSubjectGrid);
    //                    //}
    //                    //catch (err){
    //                    //    Ext.Msg.alert('异常',err);
    //                    //}
    //                });
    //    
    declareSubjectGrid.on('cellclick', function (grid, rowIndex, colIndex, e) {
        if (colIndex == 2) {
            var rows = grid.getSelectionModel().getSelection();
            declareSubjectDetail(rows[0].get('subjectId'));
        }
    });

    declareSubjectWin.show();

    initial();
}