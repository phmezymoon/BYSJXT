//学生选题清单
function studentSelectionList(student) {

    Ext.regModel('studentModel', {
        fields: [
                    { name: 'studentId' },
                    { name: 'studentName' },
                    { name: 'subjectId' },
                    { name: 'subjectName' },
                    { name: 'teacherId' },
                    { name: 'teacherName' },
                    { name: 'selectionOrder' }
		        ]
    });

    var studentStore = Ext.create('Ext.data.Store', {
        model: 'studentModel',
        proxy: {
            type: 'ajax',
            url: '/SelectedSubject/GetStudentSelectionList',
            reader: {
                type: 'json',
                root: 'rows'
            }
        }
    });

    var studentGrid = new Ext.grid.Panel({
        store: studentStore,
        height: 390,
        selModel: Ext.create('Ext.selection.RowModel', { mode: "SINGLE" }),
        columns: [//配置表格列
				    {header: '学号', dataIndex: 'studentId', width: 120, sortable: true },
                    { header: '姓名', dataIndex: 'studentName', width: 80, sortable: true, renderer: function (val) { return '<font color=blue>' + val + '</font>'; } },
                    { header: '课题编号', dataIndex: 'subjectId', sortable: true },
                    {
                        header: '课题名称',
                        dataIndex: 'subjectName',
                        renderer: function (val) {
                            return '<font color=blue>' + val + '</font>';
                        },
                        sortable: true,
                        width: 330
                    },
                    { header: '教师工号', dataIndex: 'teacherId', width: 80, sortable: true },
                    { header: '教师姓名', dataIndex: 'teacherName', width: 80, sortable: true, renderer: function (val) { return '<font color=blue>' + val + '</font>'; } },
                    { header: '选题序号', dataIndex: 'selectionOrder', width: 60, sortable: true }
			    ]
    });


    var studentPanel = new Ext.form.Panel({
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
        }, studentGrid
                                ],
        buttons: [{
            text: '返回',
            handler: function () {
                studentWin.close();
            }
        }]
    });


    var studentWin = new Ext.Window({
        title: '学生选题清单',
        resizable: false,
        height: 500,
        modal: true,
        width: 980,
        items: [studentPanel]
    });

    var initial = function () {

        // var title = teacher.departmentName + '    ' + teacher.teacherName; //更改名称显示信息

        Ext.getCmp('NameForm_Detail').setValue(student.studentName + ' 选题清单');
        Ext.getCmp('AmountForm_Detail').setValue(student.selectedAmount);


        studentStore.load({
            params: {
                studentId: student.studentId
            }
        });
    };

    //    
    //                Ext.getCmp('ImportButton_Detail').on('click',function (){
    //                    //try {
    //                        Ext.ux.Grid2Excel.Save2Excel(studentGrid);
    //                    //}
    //                    //catch (err){
    //                    //    Ext.Msg.alert('异常',err);
    //                    //}
    //                });
    //    
    studentGrid.on('cellclick', function (grid, rowIndex, colIndex, e) {
        var rows = grid.getSelectionModel().getSelection();
        if (colIndex == 3) {
            declareSubjectDetail(rows[0].get('subjectId'));
        } else if (colIndex == 1) {
            getStudentInfo({
                studentId: rows[0].get('studentId')
            });
        }
    });

    studentWin.show();

    initial();
}
