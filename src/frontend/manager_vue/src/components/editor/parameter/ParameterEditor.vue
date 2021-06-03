<template>
    <div class="parameter-editor">
        <parameter-editor-item :parameter="root" />
    </div>
</template>
<script>
import ParameterEditorItem from './ParameterEditorItem.vue'

export default {
    components:{
        ParameterEditorItem
    },
    props:{
        root:{
            type:Object,
            default:()=>null
        }
    }
}
</script>