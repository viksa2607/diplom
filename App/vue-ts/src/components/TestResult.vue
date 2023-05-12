<script setup lang="ts">
import {useBackend} from "../../stores/backend.ts";
import {useState} from "../../stores/state.ts";

const backend = useBackend()
const state = useState()
</script>

<template>
<el-dialog :model-value="backend.lastValidateResult" 
           v-if="backend.lastValidateResult"
           :title="'Тест '+backend.currentTest.name + (backend.lastValidateResult?.succeed==true?' пройден':' не пройден')"
>
    <div class="content">
        <div>Имя пользователя: {{state.testState?.userName}}</div>
        <div>Всего вопросов: {{backend.lastValidateResult?.totalQuestions}}</div>
        <div>Правильно отвечено: {{backend.lastValidateResult?.correctAnswerCount}}</div>
        <div>Тест пройден на {{backend.lastValidateResult?.percent * 100}}%</div>
    </div>
</el-dialog>
</template>

<style scoped>
.content{
    display: flex;
    flex-direction: column;
    gap: 10px;
}
</style>