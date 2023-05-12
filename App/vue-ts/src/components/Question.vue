<script setup lang="ts">
 import {ref} from "vue";

 const props = defineProps(['value'])
 const answer = ref(null as string)
</script>

<template>
  <el-card style="width: 100%; margin-top: 5px;" :class="answer!=null?'answered':''">
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
          >
              <el-row justify="start" v-for="variant in props.value?.variants">
                  <el-radio style="width: 100%" :label="variant" size="large">{{ variant }}</el-radio>
              </el-row>
          </el-radio-group>
      </div>
  </el-card>
</template>

<style scoped>
.answered{
    background-color: #b1b1f8;
}
</style>