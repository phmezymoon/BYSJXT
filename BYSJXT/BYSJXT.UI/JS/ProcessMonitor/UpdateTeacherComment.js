//督导老师提出意见
function updateTeacherComment(param) {
    Ext.Ajax.request({
        url: '/ProcessMonitor/GetComment',
        type: 'json',
        params: { studentId: param.studentId },
        success: function (response, option) {
            var json = Ext.JSON.decode(response.responseText);

            Ext.getCmp("teacherComment").setValue(json.rows[0].teacherComment);

        },
        failure: function () {
            Ext.Msg.alert("提示!", "读取数据失败！");
        }
    });

    var teacherCommentPanel = new Ext.form.Panel({
        frame: true,
        bodyPadding: 5,
        items: [{
            xtype: 'htmleditor',
            id: 'teacherComment',
            height: 250,
            width: 690,
            labelWidth: 70, //标签宽度
            labelSeparator: '：', //分隔符
            createLinkText: '创建超链接', //创建连接的提示信息
            defaultLinkValue: "http://www.", //连接的默认格式
            enableAlignments: true, //起用左、中、右对齐按钮
            enableColors: true, //起用前景色、背景色选择按钮
            enableFont: true, //起用字体选择按钮
            enableFontSize: true, //起用字体增大和缩写按钮
            enableFormat: true, //起用粗体、斜体、下划线按钮
            enableLinks: true, //起用创建连接按钮
            enableLists: true, //起用列表按钮
            enableSourceEdit: true, //起用源代码编辑按钮
            fontFamilies: ['宋体', '隶书', '黑体'], //字体列表
            buttonTips: {
                bold: {
                    title: 'Bold (Ctrl+B)',
                    text: '粗体'
                },
                italic: {
                    title: 'Italic (Ctrl+I)',
                    text: '斜体'
                },
                underline: {
                    title: 'Underline (Ctrl+U)',
                    text: '下划线'
                },
                increasefontsize: {
                    title: 'Grow Text',
                    text: '增大字体'
                },
                decreasefontsize: {
                    title: 'Shrink Text',
                    text: '缩小字体'
                },
                backcolor: {
                    title: 'Text Highlight Color',
                    text: '背景色'
                },
                forecolor: {
                    title: 'Font Color',
                    text: '前景色'
                },
                justifyleft: {
                    title: 'Align Text Left',
                    text: '左对齐'
                },
                justifycenter: {
                    title: 'Center Text',
                    text: '居中对齐'
                },
                justifyright: {
                    title: 'Align Text Right',
                    text: '右对齐'
                },
                insertunorderedlist: {
                    title: 'Bullet List',
                    text: '项目符号'
                },
                insertorderedlist: {
                    title: 'Numbered List',
                    text: '数字编号'
                },
                createlink: {
                    title: 'Hyperlink',
                    text: '超连接'
                },
                sourceedit: {
                    title: 'Source Edit',
                    text: '切换源代码编辑模式'
                }
            }
        }]


    });

    var mainPanel = new Ext.Panel({
        border: false,
        height: 360,
        layout: 'form',
        width: 700,
        items: [teacherCommentPanel]


    });

    var mainWin = new Ext.Window({
        title: "提出意见",
        width: 710,
        height: 330,
        resizable: false,
        modal: 'true',
        layout: 'column',
        items: [
                        mainPanel
                    ],
        buttons: [{
            text: '保存',
            handler: function () {
                Ext.MessageBox.confirm('提示', '是否提交？', callBack);
                function callBack(id) {
                    if (id == "yes") {
                        var teacherComment = Ext.getCmp("teacherComment").getValue();
                        Ext.Ajax.request({
                            url: '/ProcessMonitor/UpdateTeacherComment',
                            params: { teacherComment: teacherComment,
                                studentId: param.studentId
                            },
                            success: function (response, option) {
                                var responseArray = Ext.JSON.decode(response.responseText);
                                if (responseArray.success) {
                                    Ext.Msg.alert("提示!", "提交成功！", callBack);
                                    function callBack(id) {
                                        if (id == "ok") {
                                            mainWin.close();
                                            commentDetail(param);
                                        }
                                    }
                                } else {
                                    Ext.Msg.alert("", "提交失败");
                                }
                            },
                            failure: function () {
                                Ext.Msg.alert("", "提交异常");
                            }
                        })
                    }
                }
            }
        }, {
            text: '返回',
            handler: function () {
                mainWin.close();
                commentDetail(param);
            }
        }]
    });
    mainWin.show();
}