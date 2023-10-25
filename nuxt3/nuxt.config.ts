const colors = require('tailwindcss/colors');

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
    server: {
      proxy: {
        "/api": {
          target: "http://localhost:5137"
        },
        "/signalr": {
          target: "http://localhost:5137",
          ws: true,
          secure: false
        }
      }
    },
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
  },

  tailwindcss: {
    config: {
      plugins: [
        require('@tailwindcss/forms'),
      ],
      darkMode: 'class',
      theme: {
        extend: {
          colors: {
            'primary': colors.sky
          }
        }
      }
    }
  }
})
