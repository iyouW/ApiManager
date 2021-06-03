<template>
    <Card>
        <Row slot="title">
            <Col span="16">
                <Button type="success" icon="md-checkmark-circle" @click.stop="onSave">保存</Button>
            </Col>
            <Col span="8" class="t-a-r">
                <Button type="warning" icon="md-arrow-round-back" :to="apiPath">返回</Button>
            </Col>
        </Row>
        <Form :model="apiBuilder" label-position="top">
            <FormItem label="名称">
                <Input v-model="apiBuilder.name" placeholder="请输入接口名称" ></Input>
            </FormItem>
            <FormItem label="描述">
                <Input v-model="apiBuilder.description" type="textarea" :rows="5" placeholder="请输入接口描述"></Input>
            </FormItem>
            <FormItem label="杂项">
                <Checkbox v-model="apiBuilder.isSupported">是否支持</Checkbox>
                <Checkbox v-model="apiBuilder.isParameterStandard">参数是否标准格式</Checkbox>
            </FormItem>
            <FormItem label="映射名称">
                <Input v-model="apiBuilder.mapName" placeholder="请输入接口映射名称" ></Input>
            </FormItem>
            <FormItem label="请选择代理">
                <Select v-model="apiBuilder.proxyId" clearable placeholder="请输入接口映射名称" >
                    <Option v-for="(v,i) in proxyList.list" :key="i" :value="v.id">{{v.name}}</Option>
                </Select>
            </FormItem>
        </Form>
    </Card>
</template>
<script>
import { mapGetters } from 'vuex'
export default {
    computed:{
        ...mapGetters('api',['apiBuilder']),
        ...mapGetters('proxy',['proxyList']),
        projectId(){
            return this.$route.params.projectId
        },
        moduleId(){
            return this.$route.params.moduleId
        },
        apiPath(){
            return `/${this.projectId}/${this.moduleId}/api`
        }
    },
    async created(){
        this.proxyList.projectId = this.projectId
        await this.proxyList.initAsync()
    },
    methods:{
        async onSave(){
            this.apiBuilder.projectId = this.projectId
            this.apiBuilder.moduleId = this.moduleId
            await this.apiBuilder.saveAsync()
            this.$Notice.success({title:"创建成功"})
            this.$router.push(this.apiPath)
        }
    }
}
</script>