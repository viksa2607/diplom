<script setup lang="ts">
import {onMounted, ref, watch} from "vue";
import Question from "./Question.vue";
import {useState} from "../../stores/state.ts";
import {ElMessage, ElMessageBox} from "element-plus";

const state = useState()

const headerContent = ref(null);
const userName = ref(null as string);
onMounted(() => {
    (headerContent.value as any).parentNode.style.marginBottom = '5px' //изменение marginBottom DrawerHeader
})

function sendTestResult() {
    if(userName.value == null){
        ElMessage.error('Укажите имя пользователя')
        return;
    }

    ElMessage.success('Результат отправлен')
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
    <el-drawer size="100%" 
               style="background-color: #747bff" 
               v-model="state.isShowTestWindow"
               :title="state.selectedTestId as string"
               :before-close="handleClose"
    >
        <template #header="{ close, titleId, titleClass }">
            <div ref="headerContent" style="display: flex; justify-content: space-between">
                <h4 :id="titleId" class="titleClass">TestId: {{state.selectedTestId}}</h4>
            </div>
            <div>
                <el-input v-model="userName" placeholder="Имя пользователя"></el-input>
            </div>
        </template>
        <div class="content">
            <Question></Question>
            <Question></Question>
            <Question></Question>
            <Question></Question>
            <Question></Question>
            <Question></Question>
            <Question></Question>
            <Question></Question>
        </div>
        <div class="footer">
            <el-button @click="sendTestResult">Отправить результат</el-button>
        </div>
        
    </el-drawer>
</template>

<style scoped>
.footer{
    margin-top: 10px;
}
.titleClass{
    color: #ffffff;
}
</style>