<template>
    <Card>
        <Row slot="title">
            <Col span="16">
                <Button type="success" icon="md-checkmark-circle" @click.stop="onSave">保存</Button>
            </Col>
            <Col span="8" class="t-a-r">
                <Button type="warning" icon="md-arrow-round-back" :to="proxyPath">返回</Button>
            </Col>
        </Row>
        <Form :model="proxyBuilder" label-position="top">
            <FormItem title="名称">
                <Input v-model="proxyBuilder.name" placeholder="请输入代理名称" ></Input>
            </FormItem>
            <FormItem title="描述">
                <Input v-model="proxyBuilder.description" type="textarea" :rows="5" placeholder="请输入代理描述"></Input>
            </FormItem>
        </Form>
    </Card>
</template>
<script>
import { mapGetters } from 'vuex'
export default {
    computed:{
        ...mapGetters('proxy',['proxyBuilder']),
        projectId(){
            return this.$route.params.projectId
        },
        proxyPath(){
            return `/${this.projectId}/proxy`
        }
    },
    methods:{
        async onSave(){
            this.proxyBuilder.projectId = this.projectId
            await this.proxyBuilder.saveAsync()
            this.$Notice.success({title:"创建成功"})
            this.$router.push(this.proxyPath)
        }
    }
}
</script>