import {defineStore} from "pinia";
import {reactive, ref} from "vue";

export const useState = defineStore('state', () => {
    const isShowTestWindow = ref(false)
    const selectedTestId = ref(null as number)
    
    
    const testState = reactive({
        answers: [],
        testId: null as number,
        userName: null as string
    })
    return { isShowTestWindow, selectedTestId, testState }
})