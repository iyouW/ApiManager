<template>
    <Card>
        <div slot="title">
            <Button type="success" icon="md-add" class="m-r-5" to="/addProject">新增项目</Button>
            <Button type="primary" icon="ios-water" class="m-r-5" @click.stop="onGenerateCode">生成Bridge代码</Button>
            <Button type="primary" icon="md-sunny" @click.stop="onGenerateExample">生成示例代码</Button>
        </div>
        <Table max-height="600" :columns="columns" :data="projectList.list" @on-selection-change="onSelectionChanged">
            <template slot='action' slot-scope="{row}">
                <Button type="primary" size="small" :to="`/${row.id}/module`" class="m-r-5">管理模块</Button>
                <Button type="primary" size="small" :to="`/${row.id}/proxy`">管理代理</Button>
            </template>
        </Table>
    </Card>
</template>
<script>
import { mapGetters } from 'vuex'
export default {
    data(){
        return {
            columns:[
                {
                    type: 'selection',
                    width: 60,
                    align: 'center'
                },
                {
                    type: 'index',
                    width: 60,
                    align: 'center',
                    title:'序号'
                },
                {
                    title:'名称',
                    key:'name'
                },
                {
                    title:'描述',
                    key:'description'
                },
                {
                    title:'操作',
                    slot:'action',
                    fixed:'right',
                    width:180,
                    align:'center'
                }
            ]
        }
    },
    computed:{
        ...mapGetters('project',['projectList'])
    },
    async created(){
        await this.projectList.initAsync()
    },
    methods:{
        onSelectionChanged(e){
            this.projectList.selectedProject = e[0]
            console.log(e)
        },
        async onGenerateCode(){
            await this.projectList.generateCodeAsync()
        },
        async onGenerateExample(){
            await this.projectList.generateExampleAsync()
        }
    }
}
</script>