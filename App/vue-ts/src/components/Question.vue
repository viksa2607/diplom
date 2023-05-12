<script setup lang="ts">
import {onMounted, onUpdated, ref} from "vue";
 import {useState} from "../../stores/state.ts";

 const props = defineProps(['value'])
 const answer = ref(null as string)
 const state = useState()
 
 function onAnswer(id) {
     if(state.testState.answers.some(i => i.id == id)){
         let item = state.testState.answers.filter(i => i.id == id)[0]
         item.answer = answer.value
     }else{
         state.testState.answers.push({id: id, answer: answer.value})
     }
 }
</script>

<template>
  <el-card style="width: 100%; margin-top: 5px;" 
           :class="state.testState.answers.some(i => i.id == props.value?.id)?'answered':''">
      <template #header>
          <div style="font-size: 1rem">
              <span>{{props.value?.question}}</span>
          </div>
      </template>
      <div style="display: flex">
          <el-radio-group
              v-model="answer"
              style="display: flex; flex-direction: column; justify-content: flex-start"
              type="vertical"
              @change="onAnswer(props.value?.id)"
          >
              <el-row justify="start" v-for="variant in props.value?.variants">
                  <el-radio style="width: 100%" :label="variant" size="large">{{ variant }}</el-radio></el-row>
          </el-radio-group>
      </div>
  </el-card>
</template>

<style scoped>
.answered{
    background-color: #b1b1f8;
}
</style>