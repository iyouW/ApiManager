<template>
    <Card>
        <div slot="title">
            <Button type="success" icon="md-add" to="/addProject">新增项目</Button>
        </div>
        <Table :columns="columns" :data="projectList.list"></Table>
    </Card>
</template>
<script>
import { mapGetters } from 'vuex'
export default {
    data(){
        return {
            columns:[
                {
                    type: 'index',
                    width: 60,
                    align: 'center'
                },
                {
                    title:'名称',
                    key:'name'
                },
                {
                    title:'描述',
                    key:'description'
                }
            ]
        }
    },
    computed:{
        ...mapGetters('project',['projectList'])
    },
    async created(){
        await this.projectList.initAsync()
    }
}
</script>