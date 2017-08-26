//详细论文译文
function translationDetail(param){
    Ext.Ajax.request({
        url:'/ProcessMonitor/GetTranslation',
        type: 'json',
        params:{studentId:param.studentId},
        success:function(response,option)
        {
            var json = Ext.JSON.decode(response.responseText) ;

            Ext.getCmp("sourceText").setValue(json.rows[0].sourceText);
            Ext.getCmp("translationContent").setValue(json.rows[0].translationContent);

        },
        failure:function()
        {
            Ext.Msg.alert("提示!","读取数据失败！");
        }
    });
                
                

    var sourceTextPanel = new Ext.form.Panel({
        title:'原文',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'sourceText',
            anchor:'99%'
        }]
    });
    var translationContentPanel = new Ext.form.Panel({
        title:'译文',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'translationContent',
            anchor:'99%'
        }]
    });
                

    var tabs = new Ext.tab.Panel({
        border: false,
        activeItem: 0,
        height:350,
        items:[ sourceTextPanel,
                translationContentPanel
                ]
    });

    var mainPanel = new Ext.Panel({
        border: false,
        height:360,
        layout:'form',
        width:700,
        //items: [tabs]
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
                        ],
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
            text:'返回',
            handler:function(){
                mainWin.close();
            }
        }]
    });
    mainWin.show();  
    Ext.getCmp('NameForm_Detail').setValue(param.studentName + '  详细论文译文');
}