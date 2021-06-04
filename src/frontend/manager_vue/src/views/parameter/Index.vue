<template>
    <div>
        <Card class="m-b-50">
            <Row>
                <Col span="16">
                    <Button type="success" icon="md-checkmark-circle" @click.stop="onSave">保存</Button>
                </Col>
                <Col span="8" class="t-a-r">
                    <Button type="warning" icon="md-arrow-round-back" :to="apiPath">返回</Button>
                </Col>
            </Row>
        </Card>
        <Card class="m-b-50">
            <div slot="title">输入参数</div>
            <parameter-editor :parameter="parameterList.input"></parameter-editor>
        </Card>
        <Card class="m-b-50">
            <div slot="title">输出参数</div>
            <parameter-editor :parameter="parameterList.output"></parameter-editor>
        </Card>
        <Card class="m-b-50">
            <div slot="title">异常参数</div>
            <parameter-editor :parameter="parameterList.exception"></parameter-editor>
        </Card>
    </div>
</template>
<script>
import { mapGetters } from 'vuex'
import ParameterEditor from '../../components/ParameterEditor'
export default {
    components:{
        ParameterEditor
    },
    computed:{
        ...mapGetters('parameter',['parameterList']),
        projectId(){
            return this.$route.params.projectId
        },
        moduleId(){
            return this.$route.params.moduleId
        },
        apiId(){
            return this.$route.params.apiId
        },
        apiPath(){
            return `/${this.projectId}/${this.moduleId}/api`
        }
    },
    async created(){
        this.parameterList.projectId = this.projectId
        this.parameterList.moduleId = this.moduleId
        this.parameterList.apiId = this.apiId
        await this.parameterList.initAsync()
    },
    methods:{
        async onSave(){
            await this.parameterList.saveAsync()
            this.$Notice.success({title:'保存成功'})
        }
    }
}
</script>