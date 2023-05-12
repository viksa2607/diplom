<script setup lang="ts">
import {onMounted, onUpdated, ref, watch} from "vue";
import Question from "./Question.vue";
import {useState} from "../../stores/state.ts";
import {ElMessage, ElMessageBox} from "element-plus";
import {useBackend} from "../../stores/backend.ts";

const state = useState()

const headerContent = ref(null);
const userName = ref(null as string);
const backend = useBackend();


onMounted(() => {
    (headerContent.value as any).parentNode.style.marginBottom = '5px' //изменение marginBottom DrawerHeader
})

async function sendTestResult() {
    if(state.testState.userName == null){
        ElMessage.error('Укажите имя пользователя')
        return;
    }
    await backend.validateTest(state.testState)
    state.selectedTestId = null as number;
    ElMessage.success('Результат отправлен')
    state.testState = {
        answers: [],
        testId: state.selectedTestId,
        userName: null as string
    }
}
function handleClose() {
    ElMessageBox.confirm(`Вы действительно хотите закрыть тест, несохраненнные данные будут утеряны!`)
        .then(() => {
            state.selectedTestId = null as number
        })
        .catch(() => {
            // catch error
        })
}

</script>

<template>
    <el-drawer size="60%" 
               style="background-color: #747bff" 
               v-model="state.isShowTestWindow"
               :title="state.selectedTestId as string"
               :before-close="handleClose"
    >
        <template #header="{ close, titleId, titleClass }">
            <div ref="headerContent" style="display: flex; justify-content: space-between">
                <h4 :id="titleId" class="titleClass">{{backend.currentTest?.name}}</h4>
            </div>
            <div>
                <el-input v-model="state.testState.userName" placeholder="Имя пользователя"></el-input>
            </div>
        </template>
        <div class="content">
            <Question :value="question" v-for="question in backend.currentTest?.questions"></Question>
        </div>
        <div class="footer">
            <el-button @click="sendTestResult" size="large">Отправить результат</el-button>
        </div>
        
    </el-drawer>
</template>

<style scoped>
.footer{
    margin-top: 10px;
    display: flex;
    justify-content: center;
}
.titleClass{
    color: #ffffff;
}
</style>