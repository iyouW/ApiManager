<template>
    <Card>
        <Row slot="title">
            <Col span="16">
                <Button type="success" icon="md-add" :to="`/${projectId}/addModule`">新增模块</Button>
            </Col>
            <Col span="8" class="t-a-r">
                <Button type="warning" icon="md-arrow-round-back" :to="`/project`">返回</Button>
            </Col>
        </Row>
        <Table max-height="600" :columns="columns" :data="moduleList.list">
            <template slot="action" slot-scope="{row}">
                <Button class="m-r-5" type="primary" size="small" :to="`/${projectId}/addModule?moduleId=${row.id}`">编辑</Button>
                <Button class="m-r-5" type="error" size="small" @click.stop="()=>onDelete(row)"  >删除</Button>
                <Button type="primary" size="small" :to="`/${projectId}/${row.id}/api`">管理接口</Button>
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
                    type:'index',
                    width:60,
                    align:'center',
                    title:'序号'
                },
                {
                    title:'名称',
                    key:'name'
                },
                {
                    title:'模块描述',
                    key:'description'
                },
                {
                    title:'操作',
                    fixed:'right',
                    width:260,
                    align:'center',
                    slot:'action'
                }
            ]
        }
    },
    computed:{
        ...mapGetters('module',['moduleList']),
        projectId(){
            return this.$route.params.projectId
        }
    },
    async created(){
        this.moduleList.projectId = this.projectId
        await this.moduleList.initAsync()
    },
    methods:{
        async onDelete(row){
            await this.moduleList.deleteAsync(row)
        }
    }
}
</script>