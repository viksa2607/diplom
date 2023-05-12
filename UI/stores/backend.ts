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
    
    const lastValidateResult = ref(null as any)
    async function validateTest(testCompleted: any){
        const resp = await fetch('/Test/Validate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(testCompleted)
        })
        lastValidateResult.value = await resp.json()
        await testResultsUpdate()
    }

    const testResults = ref([] as any[])
    async function testResultsUpdate(){
        const resp = await fetch('/Test/GetLastResults')
        testResults.value = await resp.json()
    }
    return {
        updateTestList, testList,
        getTest, currentTest,
        validateTest, lastValidateResult,
        testResultsUpdate, testResults
    }
})