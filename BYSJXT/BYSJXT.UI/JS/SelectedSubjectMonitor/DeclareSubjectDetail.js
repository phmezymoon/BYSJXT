//查看课题详细信息
function declareSubjectDetail(subjectId){

    Ext.Ajax.request({
        url:'/SelectedSubject/GetSubjectDetails',
        type: 'json',
        params:{subjectId:subjectId},
        success:function(response,option)
        {
            var json = Ext.JSON.decode(response.responseText) ;

            Ext.getCmp("teacherName").setValue(json.rows[0].teacherName);
            Ext.getCmp("subjectName").setValue(json.rows[0].subjectName);
            Ext.getCmp("subjectId").setValue(json.rows[0].subjectId);
            Ext.getCmp("type").setValue(json.rows[0].type);
            Ext.getCmp("source").setValue(json.rows[0].source);
            Ext.getCmp("majorName1").setValue(json.rows[0].majorName1);
            Ext.getCmp("majorName2").setValue(json.rows[0].majorName2);
            Ext.getCmp("requirement").setValue(json.rows[0].requirement);
            Ext.getCmp("tools").setValue(json.rows[0].tools);
            Ext.getCmp("reference").setValue(json.rows[0].reference);
            Ext.getCmp("secondTeacher").setValue(json.rows[0].secondTeacher);
        },
        failure:function()
        {
            Ext.Msg.alert("提示!","读取数据失败！");
        }
    });
                
    var basicPanel = new Ext.form.Panel({
        height:150,
        labelAlign: 'right',
        title: '课题基本信息',
        labelWidth: 60,
        width:700,
        frame: true,
        items: [{
            width:680,
            layout:'column',
            border:false,
            frame:true,
            items:[{
                columnWidth:.3,
                frame:true,
                labelWidth: 60,
                xtype:'textfield',
                fieldLabel:'课题编号',
                readOnly:true,
                id: 'subjectId',
            },{
                columnWidth:.7,
                frame:true,
                margin:'0 0 0 20',
                labelWidth: 60,
                xtype:'textfield',
                fieldLabel:'课题名称',
                readOnly:true,
                id: 'subjectName',
            }]
        },{
            width: 680,
            frame:true,
            border:false,
            layout: 'column',
            items: [{
                columnWidth: .2,
                frame:true,
                labelWidth: 60,
                xtype: 'textfield',
                readOnly:true,
                fieldLabel: '指导教师',
                id: 'teacherName',
            },{
                columnWidth: .3,
                frame:true,
                margin:'0 0 0 20',
                labelWidth: 60,
                xtype: 'textfield',
                fieldLabel: '课题类型',
                readOnly:true,
                id: 'type',
            },{
                columnWidth: .3,
                frame:true,
                margin:'0 0 0 20',
                labelWidth: 60,
                xtype: 'textfield',
                fieldLabel: '课题来源',
                id: 'source',
                readOnly:true,
            },{
                columnWidth: .2,
                frame:true,
                margin:'0 0 0 10',
                labelWidth: 60,
                xtype: 'textfield',
                readOnly:true,
                fieldLabel: '第二导师',
                id: 'secondTeacher',
            }]
        },{
            width: 680,
            layout: 'column',
            border:false,
            frame:true,
            items: [{
                columnWidth: .5,
                frame:true,
                labelWidth: 70,
                xtype: 'textfield',
                readOnly:true,
                fieldLabel: '面向专业一',
                id: 'majorName1',
            },{
                columnWidth: .5,
                frame:true,
                margin:'0 0 0 20',
                labelWidth: 70,
                xtype: 'textfield',
                readOnly:true,
                fieldLabel: '面向专业二',
                id: 'majorName2',
            }]
        }]
    });

    var tasksPanel = new Ext.form.Panel({
        title:'任务要求',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 150,
            readOnly:true,
            id: 'requirement',
            anchor:'99%'
        }]
    });
    var toolsPanel = new Ext.form.Panel({
        title:'工具环境',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 150,
            readOnly:true,
            id: 'tools',
            anchor:'99%'
        }]
    });
    var referencePanel = new Ext.form.Panel({
        title:'参考资料',
        border: true,
        labelWidth:1,
        frame: true,
        items:[{
            xtype: 'textarea',
            height: 150,
            readOnly:true,
            id: 'reference',
            anchor:'99%'
        }]
    });

    Ext.regModel('Schedule', {
        fields: [
        {name:'scheduleRequirement'},
        {name:'beginDate'},
        {name:'endDate'}
	]
    });

    var ScheduleStore = Ext.create('Ext.data.Store', {
        model: 'Schedule',
        proxy: {
            type: 'ajax',
            url: '/SelectedSubject/GetSchedule',
            reader: {
                type: 'json',
                root  : 'rows'
            }
        }
    });

    ScheduleStore.load({
        params:{subjectId:subjectId}     
    });
               
    //json返回数据库的时间格式为通常为/Date(1332919782070)/，因此前台需要进行一定的转化
    function ChangeDateFormat(val) {  
        if (val != null) {  
            var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));  
            //月份为0-11，所以+1，月份小于10时补个0  
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;  
            var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();  
            return date.getFullYear() + "-" + month + "-" + currentDate;  
        }  
        return "";  
    }  

    var ScheduleGrid = new Ext.grid.Panel({
        store: ScheduleStore,
        height:150,
        simpleSelect : true,
        selType: 'rowmodel',
        columns: [//配置表格列
		{header:'进度要求',width:400,dataIndex:'scheduleRequirement'},
        {header:'起始日期',dataIndex:'beginDate',renderer:ChangeDateFormat},
        {header:'截止日期',dataIndex:'endDate',renderer:ChangeDateFormat}
	]
    });

    var SchedulePanel=new Ext.Panel({
        title:'计划进度',
        height:130,
        items:[
            ScheduleGrid
        ]
    });

    var tabs = new Ext.tab.Panel({
        border: false,
        activeItem: 0,
        height:250,
        items:[tasksPanel,toolsPanel,referencePanel,SchedulePanel]
    });

    var mainPanel = new Ext.Panel({
        border: false,
        height:360,
        layout:'form',
        width:700,
        items: [basicPanel,tabs]
    });

    var mainWin = new Ext.Window({
        title: "查看课题",
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
}