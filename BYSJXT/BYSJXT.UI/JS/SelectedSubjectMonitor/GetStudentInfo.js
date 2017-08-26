//获取学生联系方式
function getStudentInfo(student){
  
    Ext.Ajax.request({
        url:'/SelectedSubject/GetStudentInfo',
        type: 'json',
        params: {
                studentId: student.studentId
            },
        success:function(response,option)
        {
            var json = Ext.JSON.decode(response.responseText) ;
            Ext.getCmp("studentId").setValue(json.studentId);
            Ext.getCmp("studentName").setValue(json.studentName);
            Ext.getCmp("phone").setValue(json.phone);
            Ext.getCmp("email").setValue(json.email);

        },
        failure:function()
        {
            Ext.Msg.alert("提示!","获取学生信息失败！");
        }
    });

    var studentInfoPanel = new Ext.form.Panel({
        border:false,
        frame:true,
        labelAlign: 'left',
        buttonAlign: 'center',
        labelWidth: 70,
        bodyStyle:'padding:5px 5px 0',
        msgTarget :'qtip',
        items: [{
                    xtype:'textfield',
                    id:'studentId',
                    readOnly:true,
                    fieldLabel: '学号'
                }, {
                    xtype:'textfield',
                    id:'studentName',
                    readOnly:true,
                    fieldLabel: '姓名'
                },{
                    xtype:'numberfield',
                    fieldLabel: '移动电话',
                    hideTrigger : true,//隐藏微调按钮
                    readOnly:true,
				    allowDecimals : false,//不允许输入小数
                    id: 'phone',
                },{
                    xtype:'textfield',
                    id: 'email',
                    readOnly:true,
                    fieldLabel:'电子邮件',
                    vtype:'email'
                }],
            buttons: [{
            text: '返回',
            handler: function() {
                studentInfoWin.close();
            }
        }]
    });
    var studentInfoWin = new Ext.Window({
        title:"学生联系方式",
        items: studentInfoPanel,
        width:350,
		height:178,
		bodyStyle:'background-color:#F5F5F5',
	    resizable:false,
		draggable:false,
		modal: 'true'
    });

    studentInfoWin.show();

}
