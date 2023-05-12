import {defineStore} from "pinia";
import {ref} from "vue";

export const useState = defineStore('state', () => {
    const isShowTestWindow = ref(false)
    const selectedTestId = ref(null as number)
    return { isShowTestWindow, selectedTestId }
})