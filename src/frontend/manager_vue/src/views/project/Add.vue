<template>
    <Card>
        <Row slot="title">
            <Col span="16">
                <Button type="primary" icon="md-checkmark-circle" @click.stop="onSave">保存</Button>
            </Col>
            <Col span="8" class="t-a-r">
                <Button type="warning" icon="md-arrow-round-back" to="/project">返回</Button>
            </Col>
        </Row>
        <Form :model="projectBuilder" label-position="top">
            <FormItem label="名称">
                <Input v-model="projectBuilder.name" placeholder="请输入项目名称"></Input>
            </FormItem>
            <FormItem label="描述">
                <Input type="textarea" :rows="5" v-model="projectBuilder.description" placeholder="请输入项目描述"></Input>
            </FormItem>
        </Form>
    </Card>
</template>
<script>
import { mapGetters } from 'vuex' 
export default {
    computed:{
        ...mapGetters('project',['projectBuilder']),
        projectId(){
            return this.$route.query.projectId
        }
    },
    async created(){
        if(this.projectId){
            this.projectBuilder.clear()
            this.projectBuilder.id = this.projectId
            await this.projectBuilder.getAsync()
        }
    },
    methods:{
        async onSave(){
            await this.projectBuilder.saveAsync()
            this.$Notice.success({title:"创建成功"})
            this.$router.push("/project")
        }
    }
}
</script>