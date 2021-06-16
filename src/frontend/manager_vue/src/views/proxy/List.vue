<template>
    <Card>
        <Row slot="title">
            <Col span="16">
                <Button type="success" icon="md-add" :to="`/${projectId}/addProxy`">新增代理</Button>
            </Col>
            <Col span="8" class="t-a-r">
                <Button type="warning" icon="md-arrow-round-back" :to="`/project`">返回</Button>
            </Col>
        </Row>
        <Table max-height="600" :columns="columns" :data="proxyList.list">
            <template slot="action" slot-scope="{ row }">
                <Button class="m-r-5" type="primary" size="small" :to="`/${projectId}/addProxy?proxyId=${row.id}`">编辑</Button>
                <Button type="error" size="small" @click.stop="()=>onDelete(row)" >删除</Button>
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
                    title:'代理描述',
                    key:'description'
                },
                {
                    title:'操作',
                    slot:'action',
                    fixed:'right',
                    width:260,
                    align:'center'
                }
            ]
        }
    },
    computed:{
        ...mapGetters('proxy',['proxyList']),
        projectId(){
            return this.$route.params.projectId
        }
    },
    async created(){
        this.proxyList.projectId = this.projectId
        await this.proxyList.initAsync()
    },
    methods:{
        async onDelete(row){
            await this.proxyList.deleteAsync(row)
        }
    }
}
</script>