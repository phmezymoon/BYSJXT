//详细评阅意见
function commentDetail(param){
    Ext.Ajax.request({
        url:'/ProcessMonitor/GetComment',
        type: 'json',
        params:{studentId:param.studentId},
        success:function(response,option)
        {
            var json = Ext.JSON.decode(response.responseText) ;

            Ext.getCmp("teacherComment").setValue(json.rows[0].teacherComment);
            Ext.getCmp("mentorComment").setValue(json.rows[0].mentorComment);
            Ext.getCmp("studentFeedback").setValue(json.rows[0].studentFeedback);

        },
        failure:function()
        {
            Ext.Msg.alert("提示!","读取数据失败！");
        }
    });
                
                

    var teacherCommentPanel = new Ext.form.Panel({
        title:'督导组老师意见',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'teacherComment',
            anchor:'99%'
        }]
    });
    var mentorCommentPanel = new Ext.form.Panel({
        title:'指导老师意见',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'mentorComment',
            anchor:'99%'
        }]
    });

    var studentFeedbackPanel = new Ext.form.Panel({
        title:'学生反馈',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'studentFeedback',
            anchor:'99%'
        }]
    });
                

    var tabs = new Ext.tab.Panel({
        border: false,
        activeItem: 0,
        height:350,
        items:[ teacherCommentPanel,
                mentorCommentPanel,
                studentFeedbackPanel
                ]
    });

    var mainPanel = new Ext.Panel({
        border: false,
        height:360,
        layout:'form',
        width:700,
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
    }, tabs
                        ]
    });

    var mainWin = new Ext.Window({
        title: "详细论文译文",
        width: 710,
        height:400,
        resizable: false,
        modal: 'true',
        layout: 'column',
        items: [
            mainPanel
        ],
        buttons:[{
            text: '提出意见',
            handler: function () {
                updateTeacherComment(param);
                mainWin.close();
            }

        }, {
            text:'返回',
            handler:function(){
                mainWin.close();
            }
        }]
    });
    mainWin.show();  
    Ext.getCmp('NameForm_Detail').setValue(param.studentName + '  详细评阅意见');
}