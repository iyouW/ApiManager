<template>
    <Card>
        <Row slot="title">
            <Col span="16">
                <Button type="success" icon="md-add" :to="`/${projectId}/${moduleId}/addApi`">新增接口</Button>
            </Col>
            <Col span="8" class="t-a-r">
                <Button type="warning" icon="md-arrow-round-back" :to="`/${projectId}/module`">返回</Button>
            </Col>
        </Row>
        <Table max-height="600" :columns="columns" :data="apiList.list">
            <template slot-scope="{ column }" slot="isSupported" >
                {{ column? '是' : '否' }}
            </template>
            <template slot-scope="{ column }" slot="isParameterStandard" >
                {{ column? '是' : '否' }}
            </template>
            <template slot-scope="{ row }" slot="action">
                <Button type="primary" size="small" :to="`/${projectId}/${moduelId}/${row.id}/parameter`">管理接口参数</Button>
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
                    title:'接口描述',
                    key:'description'
                },
                {
                    title:'是否支持',
                    slot:'isSupported',
                },
                {
                    title:'是否标准格式参数',
                    slot:'isParameterStandard'
                },
                {
                    title:'别名',
                    key:'mapName'
                },
                {
                    title:'操作',
                    fixed:'right',
                    width:160,
                    align:'center',
                    slot:'action'
                }
            ]
        }
    },
    computed:{
        ...mapGetters('api',['apiList']),
        projectId(){
            return this.$route.params.projectId
        },
        moduleId(){
            return this.$route.params.moduleId
        }
    },
    async created(){
        this.apiList.projectId = this.projectId
        this.apiList.moduleId = this.moduleId
        await this.apiList.initAsync()
    }
}
</script>