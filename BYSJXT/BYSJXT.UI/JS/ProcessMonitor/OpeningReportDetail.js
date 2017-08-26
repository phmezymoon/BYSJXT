//详细开题报告
function openingReportDetail(param){
    Ext.Ajax.request({
        url:'/ProcessMonitor/GetOpeningReport',
        type: 'json',
        params:{studentId:param.studentId},
        success:function(response,option)
        {
            var json = Ext.JSON.decode(response.responseText) ;

            Ext.getCmp("subjectMeaning").setValue(json.rows[0].subjectMeaning);
            Ext.getCmp("subjectOverview").setValue(json.rows[0].subjectOverview);
            Ext.getCmp("keyIssues").setValue(json.rows[0].keyIssues);
            Ext.getCmp("subjectSolution").setValue(json.rows[0].subjectSolution);
            Ext.getCmp("condition").setValue(json.rows[0].condition);

        },
        failure:function()
        {
            Ext.Msg.alert("提示!","读取数据失败！");
        }
    });
                
                

    var subjectMeaningPanel = new Ext.form.Panel({
        title:'课题意义',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'subjectMeaning',
            anchor:'99%'
        }]
    });
    var subjectOverviewPanel = new Ext.form.Panel({
        title:'课题综述',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'subjectOverview',
            anchor:'99%'
        }]
    });
    var keyIssuesPanel = new Ext.form.Panel({
        title:'关键问题',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'keyIssues',
            anchor:'99%'
        }]
    });

    var subjectSolutionPanel = new Ext.form.Panel({
        title:'课题方案',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'subjectSolution',
            anchor:'99%'
        }]
    });

    var conditionPanel = new Ext.form.Panel({
        title:'需要条件',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 250,
            readOnly:true,
            id: 'condition',
            anchor:'99%'
        }]
    });

    var tabs = new Ext.tab.Panel({
        border: false,
        activeItem: 0,
        height:350,
        items:[ subjectMeaningPanel,
                subjectOverviewPanel,
                keyIssuesPanel,
                subjectSolutionPanel,
                conditionPanel]
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
        title: "详细开题报告",
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
    Ext.getCmp('NameForm_Detail').setValue(param.studentName + '  详细开题报告');
}