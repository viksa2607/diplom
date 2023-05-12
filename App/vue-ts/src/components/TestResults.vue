<script setup lang="ts">
import {useBackend} from "../../stores/backend.ts";

const backend = useBackend()
backend.testResultsUpdate()
</script>

<template>
  <el-card style="width: 100%" >
      <div style="font-size: 1rem">
          <span>Последние результаты</span>
      </div>
      <el-table :data="backend.testResults" style="width: 100%" border>
          <el-table-column prop="userName" label="Имя" width="auto"/>
          <el-table-column prop="testName" label="Тест" width="auto"/>
          <el-table-column prop="succeed" label="Пройден" width="auto">
              <template #default="scope">
                  <div style="display: flex; justify-content: center">
                      <el-tag
                              :type="scope.row?.succeed? 'success' : 'error'"
                              disable-transitions
                      >{{ scope.row?.succeed? 'Да' : 'Нет'}}</el-tag>
                  </div>
              </template>
          </el-table-column>
          <el-table-column prop="succeed" label="Процент правильных ответов" width="auto">
              <template #default="scope">
                  <div style="display: flex; justify-content: center">
                      <el-tag
                              :type="scope.row?.succeed? 'success' : 'error'"
                              disable-transitions
                      >{{ scope.row?.percent*100}}%</el-tag>
                  </div>
              </template>
          </el-table-column>
          <el-table-column prop="created" label="Дата выполнения" width="180">
              <template #default="scope">
                  <div style="display: flex; justify-content: center">
                      <el-date-picker :model-value="scope.row.created" type="datetime"
                      disabled>
                      </el-date-picker>
                  </div>
              </template>
          </el-table-column>
      </el-table>
  </el-card>
</template>

<style scoped>
.content{
    
}
</style>