<template>
    <div class="parameter-editor-item">
        <div class="parameter-editor-item-header">
            <div class="expander">
                <Icon size="20" v-if="hasChidlren(parameter)" type="md-arrow-dropright" :class="{'down':showChildren}" @click.stop="showChildren=!showChildren" />
            </div>
            <div class="name">
                <Input v-model="parameter.name"></Input>
            </div>
            <div class="type">
                <Select v-model="parameter.type">
                    <Option v-for="(v,i) in types" :key="i" :value="v">{{i}}</Option>
                </Select>
            </div>
            <div class="comment">
                <Input v-model="parameter.comment"></Input>
            </div>
            <div class="action">

            </div>
        </div>
        <div class="parameter-editor-item-children" v-if="hasChidlren(parameter) && showChildren">
            <parameter-editor-item v-for="(vc,i) in parameter.children" :key="i" :parameter="vc" />
        </div>
    </div>
</template>
<script>
import ParameterType from '../core/enums/parameterType'
export default {
    name:'ParameterEditorItem',
    props:{
        parameter:{
            type:Object,
            default: ()=>null
        }
    },
    data(){
        return {
            showChildren:false
        }
    },
    computed:{
        types(){
            return ParameterType
        },
    },
    methods:{
        hasChidlren(p){
            return p.children && p.children.length > 0 
        }
    }
}
</script>
<style lang="less" scoped>
.parameter-editor-item{
    width: 100%;

    margin-bottom: 10px;

    .parameter-editor-item-header{
        width: 100%;
        display: flex;
        flex-direction: row;
        align-items: center;
        margin-bottom: 10px;

        &>div{
            padding-right: 10px;
        }

        .expander{
            width: 20px;

            .down{
                transform: rotateZ(90deg);
            }
        }

        .name{
            flex:1;
        }

        .type{
            width: 200px;
        }

        .comment{
            width: 200px;
        }

        .action{
            width: 150px;
        }
    }

    .parameter-editor-item-children{
        padding-left: 10px;
    }
}
</style>