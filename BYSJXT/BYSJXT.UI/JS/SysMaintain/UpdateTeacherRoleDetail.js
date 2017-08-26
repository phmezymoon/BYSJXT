function updateTeacherRoleDetail(parm){
    Ext.QuickTips.init();

    Ext.Ajax.request({
        url:'/SysMaintain/GetTeacherInfo',
        type: 'json',
        params:{teacherId:parm.teacherId},
        success:function(response,option)
        {
                var json = Ext.JSON.decode(response.responseText) ;
                Ext.getCmp("teacherId").setValue(json.rows[0].teacherId);
                Ext.getCmp("teacherName").setValue(json.rows[0].teacherName);
                Ext.getCmp("role").setValue(json.rows[0].role);

        },
        failure:function()
        {
            Ext.Msg.alert("提示!","获取失败！");
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
                    readOnly:true,
                    fieldLabel: '登录工号'
                }, {
                    xtype:'textfield',
                    id:'teacherName',
                    readOnly:true,
                    fieldLabel: '姓名'
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
                    //value:'无'
                }],
            buttons: [{
            text: '修改',
            handler:function(){
                var teacherId = Ext.getCmp("teacherId").getValue();

                var role = Ext.getCmp("role").getValue();
                Ext.Ajax.request({
                        url:'/SysMaintain/UpdateTeacherRole',
                        params:{
                                teacherId:teacherId,
                                role:role
                                            
                        },
                        success: function(response, option){
                            var responseArray = Ext.JSON.decode(response.responseText);
                            if(responseArray.success)
                            {
                                Ext.Msg.alert("","修改成功");
                                teacherWin.close();
                            }else{
                                Ext.Msg.alert("","修改失败");
                            }
                        },
                        failure:function()
                        {
                            Ext.Msg.alert("","提交异常");
                        }
                    })
                            
                            
                
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
        title:"修改教师权限",
        items: teacherPanel,
        width:350,
		height:158,
		bodyStyle:'background-color:#F5F5F5',
	    resizable:false,
		draggable:false,
		modal: 'true'
    });
    teacherWin.show();
}