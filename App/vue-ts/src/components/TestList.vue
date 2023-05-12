<script setup lang="ts">

import Test from "./Test.vue";
import {ref, watch} from "vue";
import {useState} from "../../stores/state.ts";
const state = useState();
watch(() => state.selectedTestId, (newValue, oldValue) => {
 state.isShowTestWindow = state.selectedTestId != null;
})
</script>

<template>
 <el-card style="display: flex">
  <div style="font-size: 1rem">
   <span>Список тестов</span>
  </div>
  <div style="display: flex; flex-direction: column;">
   <span class="item" @click="state.selectedTestId = 1">1.Test 1</span>
   <span class="item" @click="state.selectedTestId = 2">2.Test 2</span>
   <span class="item" @click="state.selectedTestId = 3">3.Test 3</span>
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