//查看审查课题清单
function checkSubjectList(checker) {

    Ext.regModel('checkSubjectModel', {
        fields: [
                    { name: 'subjectId' },
                    { name: 'subjectName' },
                    { name: 'teacherId' },
                    { name: 'teacherName' },
                    { name: 'checkerId' },
                    { name: 'checkerName' },
                    { name: 'checkResult' },
		        ]
    });

    var checkSubjectStore = Ext.create('Ext.data.Store', {
        model: 'checkSubjectModel',
        proxy: {
            type: 'ajax',
            url: '/SelectedSubject/GetCheckSubjectList',
            reader: {
                type: 'json',
                root: 'rows'
            }
        }
    });

    var checkSubjectGrid = new Ext.grid.Panel({
        store: checkSubjectStore,
        height: 390,
        selModel: Ext.create('Ext.selection.RowModel', { mode: "SINGLE" }),
        columns: [//配置表格列
				    { header: '申请工号', width: 80, dataIndex: 'teacherId', sortable: true },
                    { header: '申请姓名', width: 80, dataIndex: 'teacherName', sortable: true, renderer: function (val) { return '<font color=blue>' + val + '</font>'; } },
                    { header: '课题编号',  dataIndex: 'subjectId', sortable: true },
                    {
                        header: '课题名称',
                        dataIndex: 'subjectName',
                        renderer: function (val) {
                            return '<font color=blue>' + val + '</font>';
                        },
                        sortable: true,
                        width: 380
                    },
                    { header: '审查工号', dataIndex: 'checkerId', width: 80, sortable: true },
                    { header: '审查姓名', dataIndex: 'checkerName', width: 80, sortable: true, renderer: function (val) { return '<font color=blue>' + val + '</font>'; } },
                    { header: '审查结论', dataIndex: 'checkResult', sortable: true, renderer: function (val) { return '<font color=blue>' + val + '</font>'; } }
			    ]
    });


    var checkSubjectPanel = new Ext.form.Panel({
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
                id: 'name',
                readOnly: true,
                fieldLabel: '名称'
            }]
        }, checkSubjectGrid
                                ],
        buttons: [ {
            text: '返回',
            handler: function () {
                checkSubjectWin.close();
            }
        }]
    });


    var checkSubjectWin = new Ext.Window({
        title: '审查课题清单',
        resizable: false,
        height: 500,
        modal: true,
        width: 980,
        items: [checkSubjectPanel]
    });

    var initial = function () {

        //  var title = queryInformation.departmentName + '    ' + queryInformation.teacherName; //更改名称显示信息

        Ext.getCmp('name').setValue(checker.checkerName + '  审查课题清单');
        //     Ext.getCmp('AmountForm_Detail').setValue(queryInformation.checkdAmount);


        checkSubjectStore.load({
            params: {
                checkerId: checker.checkerId,
                checkerName: checker.checkerName
            }
        });
    };

    //    
    //                Ext.getCmp('ImportButton_Detail').on('click',function (){
    //                    //try {
    //                        Ext.ux.Grid2Excel.Save2Excel(checkSubjectGrid);
    //                    //}
    //                    //catch (err){
    //                    //    Ext.Msg.alert('异常',err);
    //                    //}
    //                });
    //    
    checkSubjectGrid.on('cellclick', function (grid, rowIndex, colIndex, e) {
        if (colIndex == 3) {
            var rows = grid.getSelectionModel().getSelection();
            declareSubjectDetail(rows[0].get('subjectId'));
        }
    });

    checkSubjectWin.show();

    initial();
}