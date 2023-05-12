import {defineStore} from "pinia";
import {ref} from "vue";

export const useBackend = defineStore('backend', () => {
    const testList = ref([])
    async function updateTestList() {
        let result = await fetch('/Test/GetTestList')
        testList.value = await result.json()
    }

    const currentTest = ref(null as any)
    async function getTest(id: number) {
        let result = await fetch('/Test/GetTest?testId='+id)
        currentTest.value = await result.json()
    }
    return { updateTestList, testList, getTest, currentTest }
})