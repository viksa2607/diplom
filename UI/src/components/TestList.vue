<script setup lang="ts">

import {ref, watch} from "vue";
import {useState} from "../../stores/state.ts";
import {useBackend} from "../../stores/backend.ts";
const state = useState();
watch(() => state.selectedTestId, async (newValue, oldValue) => {
 state.isShowTestWindow = state.selectedTestId != null;
 if (state.selectedTestId != null) {
  await backend.getTest(state.selectedTestId);
  state.testState = {
   answers: [],
   testId: state.selectedTestId,
   userName: null as string
  }
 }
})
const backend = useBackend()
backend.updateTestList()
</script>

<template>
 <el-card style="display: flex">
  <div style="font-size: 1rem">
   <span>Список тестов</span>
  </div>
  <div style="display: flex; flex-direction: column;">
   <span class="item" 
         @click="state.selectedTestId = testItem.Id" 
         v-for="testItem in backend.testList">{{testItem.Name}}</span>
  </div>
 </el-card>
 
</template>

<style scoped>
.item{
 cursor: pointer;
 border: #213547 solid 2px;
 margin-top: 2px;
 border-radius: 5px;
 user-select: none;
}
</style>