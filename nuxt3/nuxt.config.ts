// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  ssr: false,
  devtools: { enabled: true },
  modules: [
    '@nuxtjs/tailwindcss',
    '@pinia/nuxt'
  ],
  css: [
    '~/assets/scss/main.scss'
  ],
  vite: {
    build: {
      rollupOptions: {
        output: {
          manualChunks: {
            // ...
            codemirror: [
              // Split CodeMirror code.
              'vue-codemirror6',
              'codemirror',
              '@codemirror/autocomplete',
              '@codemirror/commands',
              '@codemirror/language',
              '@codemirror/lint',
              '@codemirror/search',
              '@codemirror/state',
              '@codemirror/view',
              '@codemirror/theme-one-dark'
            ],
            'codemirror-lang': [
              // Add the following as needed.
              '@codemirror/lang-html',
              '@codemirror/lang-javascript',
              '@codemirror/lang-markdown',
            ],
            // ...
          },
        },
      },
    },
  }
})
