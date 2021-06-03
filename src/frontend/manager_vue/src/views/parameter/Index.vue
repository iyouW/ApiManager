<template>
    <div>
        <Card class="m-b-50">
            <div slot="title">输入参数</div>
            <parameter-editor :parameter="data"></parameter-editor>
        </Card>
        <Card class="m-b-50">
            <div slot="title">输出参数</div>
            <parameter-editor :parameter="data"></parameter-editor>
        </Card>
        <Card class="m-b-50">
            <div slot="title">异常参数</div>
            <parameter-editor :parameter="data"></parameter-editor>
        </Card>
    </div>
</template>
<script>
import { mapGetters } from 'vuex'
import ParameterEditor from '../../components/ParameterEditor.vue'
export default {
    components:{
        ParameterEditor
    },
    data(){
        return {
            data:{
                name:'root',
                type:3,
                comment:'root_c',
                children:[
                    {
                        name:'t_1',
                        type:2,
                        comment:'t_1_c',
                    },
                    {
                        name:'t_2',
                        type:2,
                        comment:'t_2_c',
                        children:[
                            {
                                name:'t_2_1',
                                type:5,
                                comment:'t_2_1_c'
                            },
                            {
                                name:'t_2_2',
                                type:4,
                                comment:'t_2_2_c'
                            },
                            {
                                name:'t_2_3',
                                type:2,
                                comment:'t_2_3_c'
                            }
                        ]
                    }
                ]
            }
        }
    },
    computed:{
        ...mapGetters('parameter',['parameterList'])
    }
}
</script>