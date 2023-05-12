<script setup lang="ts">

import TestList from "./components/TestList.vue";
import Test from "./components/Test.vue";
import TestResult from "./components/TestResult.vue";
import TestResults from "./components/TestResults.vue";
</script>

<template>
    <div class="app">
        <TestList style="display: flex; flex: 1 0 auto"/>
        <TestResults style="display: flex; flex: 1 2 auto"/>
    </div>
    <Test/>
    <TestResult/>
</template>

<style scoped>
.app{
    width: 95vw;
    margin: 10px;
    display: flex;
    gap: 10px;
}
</style>
