//添加学生账号
function addStudent(){
    Ext.QuickTips.init();

    Ext.regModel('classModel', {
		fields: [{name: 'className'},{name: 'classId'}]
	});

	var classStore = Ext.create('Ext.data.Store',{
		model : 'classModel',
        proxy: {
            type: 'ajax',
            url: '/SysMaintain/GetClassName',
            reader: {
                type: 'json',
                root: 'rows'
            }

        }
	});

    var studentPanel = new Ext.form.Panel({
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
                    fieldLabel: '学号'
                },{
                    xtype:'textfield',
                    fieldLabel: '密码',
                    id: 'password',
                    vtype: 'alphanum',
                    vtypeText:'密码必须为字母或数字',
                    inputType: 'password'
                }, {
                    xtype:'textfield',
                    id:'studentName',
                    fieldLabel: '姓名'
                },{
                    xtype:'numberfield',
                    fieldLabel: '移动电话',
                    hideTrigger : true,//隐藏微调按钮
				    allowDecimals : false,//不允许输入小数
                    id: 'phone',
                },{
                    xtype:'textfield',
                    id: 'email',
                    fieldLabel:'电子邮件',
                    vtype:'email'
                },{
                    xtype:'combo',
                    fieldLabel: '班级',
                    id: 'className',
                    listConfig : {
					    emptyText : '未找到匹配值',//当值不在列表是的提示信息
					    maxHeight : 90//设置下拉列表的最大高度为60像素
				    },
				    //autoSelect : true,
				    triggerAction: 'all',//单击触发按钮显示全部数据
                    store: classStore,
                    displayField:'className',//定义要显示的字段
				    valueField:'classId',//定义值字段
				    queryMode: 'remote',
				    forceSelection : true,//要求输入值必须在列表中存在
				    typeAhead : true,//允许自动选择匹配的剩余部分文本
            }],
            buttons: [{
            text: '添加',
            handler:function(){
                var password = Ext.getCmp("password").getValue();
                var studentId = Ext.getCmp("studentId").getValue();
                var phone = Ext.getCmp("phone").getValue();
                var email = Ext.getCmp("email").getValue();

                var studentName = Ext.getCmp("studentName").getValue();
                var classId = Ext.getCmp("className").getValue();
                if(password || studentId || studentName || classId){
                    if (!Ext.getCmp("password").isValid() ) 
                    {
                        Ext.Msg.alert("错误","密码必须为字母或数字");
                    }
                    else{
                        Ext.Ajax.request({
                            url:'/SysMaintain/AddStudent',
                            params:{password:password,
                                    phone:phone,
                                    email:email,
                                    studentId:studentId,
                                    studentName:studentName,
                                    classId:classId
                                            
                            },
                            success: function(response, option){
                                var responseArray = Ext.JSON.decode(response.responseText);
                                if(responseArray.success)
                                {
                                    Ext.Msg.alert("","信息已提交");
                                    Ext.getCmp("password").setValue("");
                                    Ext.getCmp("phone").setValue("");
                                    Ext.getCmp("email").setValue("");
                                    Ext.getCmp("studentId").setValue("");
                                    Ext.getCmp("studentName").setValue("");
                                }else{
                                    Ext.Msg.alert("","提交失败");
                                }
                            },
                            failure:function()
                            {
                                Ext.Msg.alert("","提交异常");
                            }
                        })
                    }
                }
                            
                            
                
            }
        },{
            text: '返回',
            margin:'0 0 0 50',
            handler: function() {
                studentWin.close();
            }
        }]
    });
    var studentWin = new Ext.Window({
        title:"添加学生账号",
        items: studentPanel,
        width:350,
		height:237,
		bodyStyle:'background-color:#F5F5F5',
	    resizable:false,
		draggable:false,
		modal: 'true'
    });
    studentWin.show();
}