
<template>
    <div class="parameter-editor">
        <div class="parameter-editor-header">
            <div class="expander">
                <Icon size="20" v-if="hasChidlren" type="md-arrow-dropright" class="c-p" :class="{'down':showChildren}" @click.stop="showChildren=!showChildren" />
            </div>
            <div class="name">
                <Input v-model="parameter.name" :disabled="isDisabled" placeholder="请输入参数名称"></Input>
            </div>
            <div class="type">
                <Select v-model="parameter.type" :disabled="isRoot" @on-change="onTypeChanged">
                    <Option v-for="(v,i) in types" :key="i" :value="v">{{i}}</Option>
                </Select>
            </div>
            <div class="comment">
                <Input v-model="parameter.comment" placeholder="请输入参数注释"></Input>
            </div>
            <div class="action">
                <Icon v-show="!isDisabled" type="md-add-circle" size="20" class="m-r-5 c-p" @click.stop="addSibling" />
                <Icon v-show="isObjectType" type="md-add" size="20" class="m-r-5 c-p" @click.stop="addChild"  />
                <Icon v-show="!isDisabled" type="md-trash" class="c-p" @click.stop="remove"/>   
            </div>
        </div>
        <div class="parameter-editor-children" v-if="hasChidlren && showChildren">
            <parameter-editor v-for="(vc,i) in parameter.children" :key="i" :parameter="vc" />
        </div>
    </div>
</template>
<script>
import { ParameterNode } from '../core/parameter/parameterNode'

export default {
    name:'ParameterEditor',
    props:{
        parameter:{
            type:Object,
            default: ()=>null
        }
    },
    data(){
        return {
            showChildren:true
        }
    },
    computed:{
        types(){
            return ParameterNode.Type
        },
        hasChidlren(){
            return this.parameter.children && this.parameter.children.length > 0 
        },
        isDisabled(){
            return this.isRoot || this.isArrayItem
        },
        isRoot(){
            return ParameterNode.IsRoot(this.parameter)
        },
        isArrayItem(){
            return ParameterNode.IsArrayItems(this.parameter)
        },
        isObjectType(){
            return ParameterNode.IsObject(this.parameter)
        }
    },
    methods:{
        addSibling(){
            const p = this.parameter
            const sibling = ParameterNode.CreateEmptyNode(p.parent, p.category, p.apiId)
            p.parent.children.push(sibling)
        },
        addChild(){
            const p = this.parameter
            const child = ParameterNode.CreateEmptyNode(p, p.category, p.apiId)
            p.children.push(child)
            if(!this.showChildren){
                this.showChildren = true
            }
        },
        remove(){
            this.parameter.remove()
        },
        onTypeChanged(parameterType){
            const p = this.parameter
            if(ParameterNode.Type.Array === parameterType){
                const item = ParameterNode.CreateArrayItem(p, p.category, p.apiId)
                p.children.push(item)
                if(!this.showChildren){
                    this.showChildren = true
                }
            }else{
                this.parameter.children = []
            }
        }
    }
}
</script>
<style lang="less" scoped>
.parameter-editor{
    width: 100%;

    margin-bottom: 10px;

    .parameter-editor-header{
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

    .parameter-editor-children{
        padding-left: 10px;
    }
}
</style>