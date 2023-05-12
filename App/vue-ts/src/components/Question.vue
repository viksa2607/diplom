<script setup lang="ts">
 import {ref} from "vue";

 const props = defineProps(['value'])
 const answer = ref(null as string)
</script>

<template>
  <el-card style="width: 100%; display: flex; margin-top: 5px">
      <template #header>
          <div style="font-size: 1rem">
              <span>{{props.value?.question}}</span>
          </div>
          <div>
          <el-radio-group
                  v-model="answer"
                  style="display: flex; flex-direction: column; justify-content: flex-start"
                  type="vertical"
          >
              <el-row v-for="variant in props.value?.variants">
                  <el-radio :label="variant" size="large">{{ variant }}</el-radio>
              </el-row>
          </el-radio-group>
          </div>
      </template>
  </el-card>
</template>

<style scoped>

</style>