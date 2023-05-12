<script setup lang="ts">
import {ref} from "vue";
import Question from "./Question.vue";
import {useState} from "../../stores/state.ts";

const state = useState()
</script>

<template>
    <el-drawer size="100%" style="background-color: #747bff" v-model="state.isShowTestWindow"
    :title="state.selectedTestId as string"
    >
        <Question></Question>
        <Question></Question>
        <Question></Question>
        <Question></Question>
    </el-drawer>
</template>

<style scoped>

</style>