<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>

    <div v-for="(v,i) in projects" :key="i">{{v.name}}</div>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

import http from '@/http/index.js'

export default {
  name: 'Home',
  components: {
    HelloWorld
  },
  data(){
    return {
      projects:[]
    }
  },
  async created(){
    this.projects = await http.get("project");
    console.log(this.projects);
  }
}
</script>
