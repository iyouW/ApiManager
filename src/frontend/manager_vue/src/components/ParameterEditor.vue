
<template>
    <div class="parameter-editor">
        <div class="parameter-editor-header">
            <div class="expander">
                <Icon size="20" v-if="hasChidlren(parameter)" type="md-arrow-dropright" class="c-p" :class="{'down':showChildren}" @click.stop="showChildren=!showChildren" />
            </div>
            <div class="name">
                <Input v-model="parameter.name" :disabled="isDisabled(parameter)"></Input>
            </div>
            <div class="type">
                <Select v-model="parameter.type" :disabled="isRoot(parameter)" @on-change="onTypeChanged">
                    <Option v-for="(v,i) in types" :key="i" :value="v">{{i}}</Option>
                </Select>
            </div>
            <div class="comment">
                <Input v-model="parameter.comment"></Input>
            </div>
            <div class="action">
                <Icon v-show="!isRoot(parameter)" type="md-add-circle" size="20" class="m-r-5 c-p" @click.stop="()=>addSibling(parameter)" />
                <Icon v-show="isObjectType(parameter)" type="md-add" size="20" class="m-r-5 c-p" @click.stop="()=>addChild(parameter)"  />
                <Icon v-show="!isDisabled(parameter)" type="md-trash" class="c-p" @click.stop="()=>remove(parameter)"/>   
            </div>
        </div>
        <div class="parameter-editor-children" v-if="hasChidlren(parameter) && showChildren">
            <parameter-editor v-for="(vc,i) in parameter.children" :key="i" :parameter="vc" />
        </div>
    </div>
</template>
<script>
import ParameterType from '../core/enums/parameterType'
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
        },
        isDisabled(p){
            return this.isRoot(p) || this.isArrayItem(p)
        },
        isRoot(p){
            return p.name === 'root'
        },
        isArrayItem(p){
            return p.name === 'items'
        },
        isObjectType(p){
            return p.type === ParameterType.Object
        },
        addSibling(p){
            const sibling = {
                name:'',
                type:ParameterType.String,
                parent:p.parent,
                children:[]
            }
            p.parent.children.push(sibling)
        },
        addChild(p){
            const child = {
                name:'',
                type:ParameterType.String,
                parent:p,
                children:[]
            }
            if(p.children){
                p.children.push(child)
            }else{
                p.children = [child]
            }
            if(!this.showChildren){
                this.showChildren = true
            }
        },
        remove(p){
            const arr = p.parent.children
            arr.splice(arr.findIndex(x=>x === p),1)
        },
        onTypeChanged(e){
            if(ParameterType.Array === e){
                const item = {
                    name:'items',
                    type: ParameterType.String,
                    parent: this.parameter,
                    children:[]
                }
                this.parameter.children = [item]
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