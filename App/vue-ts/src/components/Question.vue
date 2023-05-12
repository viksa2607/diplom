<script setup lang="ts">
 import {ref} from "vue";

 const answer = ref("")
</script>

<template>
  <el-card style="width: 80vw; display: flex; margin-top: 5px">
      <template #header>
          <div style="font-size: 1rem">
              <span>Текст вопроса</span>
          </div>
          <div>
          <el-radio-group
                  v-model="answer"
                  style="display: flex; flex-direction: column; justify-content: flex-start"
                  type="vertical"
          >
              <el-row>
                  <el-radio label="1" size="large">Ответ 1</el-radio>
              </el-row>
              <el-row>
                  <el-radio label="2" size="large">Ответ 2</el-radio>
              </el-row>
          </el-radio-group>
          </div>
      </template>
  </el-card>
</template>

<style scoped>

</style>