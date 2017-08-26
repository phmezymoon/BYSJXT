//添加教师账号
function addTeacher(){
    Ext.QuickTips.init();

	Ext.regModel('teacherProModel', {
		fields: [{name: 'teacherPro'}]
	});

	var teacherProStore = Ext.create('Ext.data.Store',{
		model : 'teacherProModel',
		data : [
            {teacherPro:'无'},
			{teacherPro:'教授'},
            {teacherPro:'副教授'},
            {teacherPro:'讲师'}
		]
	});

    Ext.regModel('departmentModel', {
		fields: [{name: 'departmentName'},{name: 'departmentId'}]
	});

	var departmentStore = Ext.create('Ext.data.Store',{
		model : 'departmentModel',
        proxy: {
            type: 'ajax',
            url: '/SysMaintain/GetDepartmentName',
            reader: {
                type: 'json',
                root: 'rows'
            }

        }
	});

    Ext.regModel('roleModel', {
		fields: [{name: 'role'}]
	});

	var roleStore = Ext.create('Ext.data.Store',{
		model : 'roleModel',
		data : [
            {role:'无'},
			{role:'校督导员'},
            {role:'校管理员'}
		]
	});


    var teacherPanel = new Ext.form.Panel({
        border:false,
        frame:true,
        labelAlign: 'left',
        buttonAlign: 'center',
        labelWidth: 70,
        bodyStyle:'padding:5px 5px 0',
        msgTarget :'qtip',
        items: [{
                    xtype:'textfield',
                    id:'teacherId',
                    fieldLabel: '登录工号'
                },{
                    xtype:'textfield',
                    fieldLabel: '密码',
                    id: 'password',
                    vtype: 'alphanum',
                    vtypeText:'密码必须为字母或数字',
                    inputType: 'password'
                }, {
                    xtype:'textfield',
                    id:'teacherName',
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
                    fieldLabel: '职称',
                    id: 'teacherPro',
                    listConfig : {
					    emptyText : '未找到匹配值',//当值不在列表是的提示信息
					    maxHeight : 90//设置下拉列表的最大高度为60像素
				    },
				    autoSelect : true,
				    triggerAction: 'all',//单击触发按钮显示全部数据
                    store: teacherProStore,
                    displayField:'teacherPro',//定义要显示的字段
				    valueField:'teacherPro',//定义值字段
				    queryMode: 'local',//本地模式
				    forceSelection : true,//要求输入值必须在列表中存在
				    typeAhead : true,//允许自动选择匹配的剩余部分文本
                    value:'无'
                },{
                    xtype:'combo',
                    fieldLabel: '所在系',
                    id: 'departmentName',
                    listConfig : {
					    emptyText : '未找到匹配值',//当值不在列表是的提示信息
					    maxHeight : 90//设置下拉列表的最大高度为60像素
				    },
				    //autoSelect : true,
				    triggerAction: 'all',//单击触发按钮显示全部数据
                    store: departmentStore,
                    displayField:'departmentName',//定义要显示的字段
				    valueField:'departmentId',//定义值字段
				    queryMode: 'remote',
				    forceSelection : true,//要求输入值必须在列表中存在
				    typeAhead : true,//允许自动选择匹配的剩余部分文本
            },{
                    xtype:'combo',
                    fieldLabel: '权限',
                    id: 'role',
                    listConfig : {
					    emptyText : '未找到匹配值',//当值不在列表是的提示信息
					    maxHeight : 90//设置下拉列表的最大高度为60像素
				    },
				    autoSelect : true,
				    triggerAction: 'all',//单击触发按钮显示全部数据
                    store: roleStore,
                    displayField:'role',//定义要显示的字段
				    valueField:'role',//定义值字段
				    queryMode: 'local',//本地模式
				    forceSelection : true,//要求输入值必须在列表中存在
				    typeAhead : true,//允许自动选择匹配的剩余部分文本
                    value:'无'
                }],
            buttons: [{
            text: '添加',
            handler:function(){
                var password = Ext.getCmp("password").getValue();
                var teacherId = Ext.getCmp("teacherId").getValue();
                var phone = Ext.getCmp("phone").getValue();
                var email = Ext.getCmp("email").getValue();

                var teacherName = Ext.getCmp("teacherName").getValue();
                var teacherPro = Ext.getCmp("teacherPro").getValue();
                var departmentId = Ext.getCmp("departmentName").getValue();
                var role = Ext.getCmp("role").getValue();
                if(password || teacherId || teacherName || departmentId){
                    if (!Ext.getCmp("password").isValid() ) 
                    {
                        Ext.Msg.alert("错误","密码必须为字母或数字");
                    }
                    else{
                        Ext.Ajax.request({
                            url:'/SysMaintain/AddTeacher',
                            params:{password:password,
                                    phone:phone,
                                    email:email,
                                    teacherId:teacherId,
                                    teacherName:teacherName,
                                    teacherPro:teacherPro,
                                    departmentId:departmentId,
                                    role:role
                                            
                            },
                            success: function(response, option){
                                var responseArray = Ext.JSON.decode(response.responseText);
                                if(responseArray.success)
                                {
                                    Ext.Msg.alert("","信息已提交");
                                    Ext.getCmp("password").setValue("");
                                    Ext.getCmp("phone").setValue("");
                                    Ext.getCmp("email").setValue("");
                                    Ext.getCmp("teacherId").setValue("");
                                    Ext.getCmp("teacherName").setValue("");
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
                teacherWin.close();
            }
        }]
    });
    var teacherWin = new Ext.Window({
        title:"添加教师账号",
        items: teacherPanel,
        width:350,
		height:290,
		bodyStyle:'background-color:#F5F5F5',
	    resizable:false,
		draggable:false,
		modal: 'true'
    });
    teacherWin.show();
}