<template>
    <div>
        <Card class="m-b-50">
            <div slot="title">输入参数</div>
            <parameter-editor :root="root"></parameter-editor>
        </Card>
        <Card class="m-b-50">
            <div slot="title">输出参数</div>
            <parameter-editor :root="root"></parameter-editor>
        </Card>
        <Card class="m-b-50">
            <div slot="title">异常参数</div>
            <parameter-editor :root="root"></parameter-editor>
        </Card>
    </div>
</template>
<script>
import { mapGetters } from 'vuex'
import ParameterEditor from '../../components/editor/parameter/ParameterEditor'
export default {
    components:{
        ParameterEditor
    },
    data(){
        return {
            root:{
                name:'root',
                type: 5,
                parent:null,
                children:[]
            }
        }
    },
    computed:{
        ...mapGetters('parameter',['parameterList'])
    }
}
</script>