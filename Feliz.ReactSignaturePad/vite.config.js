import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  root: "./src",
  build: {
    outDir: "../dist",
    commonjsOptions: {
      include: /node_modules/
    }
  },
  server: {
    port : 8080
  }
})
