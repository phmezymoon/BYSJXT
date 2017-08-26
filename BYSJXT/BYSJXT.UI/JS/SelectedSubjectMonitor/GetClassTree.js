//获取学院-班级树
function getClassTree() {
    var myStore = new Ext.data.TreeStore({
        nodeParam: 'nodeId', //指定节点参数名
        proxy: {
            type: 'ajax',
            url: '/SelectedSubject/GetClassTree',
            reader: {
                type: 'json'
            },
            extraParams: {
                tid: ''
            }
        },
        autoLoad: true,
        root: {
            text: '合肥工业大学',
            id: '000',
            expanded: true
        },
        listeners: {
            'beforeexpand': function (node, eOpts) { //点击父亲节点的菜单会将节点的id通过ajax请求传到后台                          
                this.proxy.extraParams.tid = node.raw.id;
            }
        }
    });

    var tree = Ext.create('Ext.tree.Panel', {
        width: 230,
        height: 417,
        useArrows: true,
        store: myStore
    });

    return tree;
}
