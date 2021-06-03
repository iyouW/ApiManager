<template>
    <Card>
        <Row slot="title">
            <Col span="16">
                <Button type="success" icon="md-checkmark-circle" @click.stop="onSave">保存</Button>
            </Col>
            <Col span="8" class="t-a-r">
                <Button type="warning" icon="md-arrow-round-back" :to="modulePath">返回</Button>
            </Col>
        </Row>
        <Form :model="moduleBuilder" label-position="top">
            <FormItem title="名称">
                <Input v-model="moduleBuilder.name" placeholder="请输入模块名称" ></Input>
            </FormItem>
            <FormItem title="描述">
                <Input v-model="moduleBuilder.description" type="textarea" :rows="5" placeholder="请输入模块描述"></Input>
            </FormItem>
        </Form>
    </Card>
</template>
<script>
import { mapGetters } from 'vuex'
export default {
    computed:{
        ...mapGetters('module',['moduleBuilder']),
        projectId(){
            return this.$route.params.projectId
        },
        modulePath(){
            return `/${this.projectId}/module`
        }
    },
    methods:{
        async onSave(){
            this.moduleBuilder.projectId = this.projectId
            await this.moduleBuilder.saveAsync()
            this.$Notice.success({title:"创建成功"})
            this.$router.push(this.modulePath)
        }
    }
}
</script>