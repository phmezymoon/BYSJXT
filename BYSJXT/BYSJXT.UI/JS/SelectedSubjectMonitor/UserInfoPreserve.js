//个人信息维护
function userInfoPreserve(){

    Ext.QuickTips.init();
    
    Ext.Ajax.request({
        url:'/Login/GetTeacherInfo',
        type: 'json',
        success:function(response,option)
        {
                var json = Ext.JSON.decode(response.responseText) ;
                Ext.getCmp("teacherId").setValue(json.teacherId);
                Ext.getCmp("teacherName").setValue(json.teacherName);
                Ext.getCmp("phone").setValue(json.phone);
                Ext.getCmp("email").setValue(json.email);

        },
        failure:function()
        {
            Ext.Msg.alert("提示!","您还没有登陆或登陆已失效！");
        }
    });

    var userInfoPanel = new Ext.form.Panel({
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
                    //disabled:true
                }, {
                    xtype:'textfield',
                    id:'teacherName',
                    readOnly:true,
                    fieldLabel: '姓名'
                    //disabled:true
                },{
                    xtype:'numberfield',
                    fieldLabel: '移动电话',
                    hideTrigger : true,//隐藏微调按钮
				    allowDecimals : false,//不允许输入小数
				    // nanText :'请输入有效的电话',
                    id: 'phone',
                },{
                    xtype:'textfield',
                    id: 'email',
                    fieldLabel:'电子邮件',
                    //  nanText :'请输入有效的电子邮件',
                    vtype:'email'
                },{
                    xtype:'textfield',
                    fieldLabel: '新口令',
                    id: 'password',
                    vtype: 'alphanum',
                    vtypeText:'密码必须为字母或数字',
                    inputType: 'password'
                },{
                    xtype:'textfield',
                    fieldLabel: '确认口令',
                    id: 'confirmPassword',
                    vtype:'alphanum',
                    vtypeText:'密码必须为字母或数字',
                    inputType: 'password'
            }],
            buttons: [{
            text: '保存',
            handler:function(){
                var password = Ext.getCmp("password").getValue();
                var confirmPassword = Ext.getCmp("confirmPassword").getValue();
                var phone = Ext.getCmp("phone").getValue();
                var email = Ext.getCmp("email").getValue();
                if(password || confirmPassword){
                   if (!Ext.getCmp("password").isValid() || !Ext.getCmp("confirmPassword").isValid()) 
                    {
                        Ext.Msg.alert("错误","密码必须为字母或数字");
                    }else if(password != confirmPassword){
                        Ext.Msg.alert("","密码输入不一致");
                    }else{
                        Ext.Ajax.request({
                            url:'/Login/UpdateTeacherInfo',
                            params:{password:password,
                                    phone:phone,
                                    email:email
                            },
                            success: function(response, option){
                                var responseArray = Ext.JSON.decode(response.responseText);
                                if(responseArray.success)
                                {
                                    Ext.Msg.alert("","信息已提交");
                                    Ext.getCmp("password").setValue("");
                                    Ext.getCmp("confirmPassword").setValue("");
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
                userInfoWin.close();
            }
        }]
    });
    var userInfoWin = new Ext.Window({
        title:"个人信息维护",
        items: userInfoPanel,
        width:350,
		height:240,
		bodyStyle:'background-color:#F5F5F5',
	    resizable:false,
		draggable:false,
		modal: 'true'
    });
    userInfoWin.show();

}