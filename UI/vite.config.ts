import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import proxy from 'vite-plugin-proxy'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    proxy:{
      '/Test': {
        target: "https://localhost:7210",
        changeOrigin: true,
        secure: false,
      }
    }
  }
})
