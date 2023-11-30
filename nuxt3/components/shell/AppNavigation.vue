<template>
  <aside id="drawer-navigation" class="fixed top-0 left-0 z-40 w-64 pt-16 transition-transform -translate-x-full md:translate-x-0 border-r border-gray-200 dark:border-gray-700" style="height: 100dvh;" aria-label="Sidebar">
    <div class="overflow-y-auto py-4 px-3 h-full bg-white dark:bg-gray-800">
      <ul class="pt-5 space-y-2 dark:border-gray-700">
          <app-navigation-button icon="fa-light fa-gauge" title="Overview" path="/"></app-navigation-button>
          <app-navigation-button icon="fa-light fa-folder-open" title="Code Mirror" path="/code-mirror"></app-navigation-button>
          <app-navigation-button icon="fa-light fa-folder-open" title="Quill Editor" path="/quill"></app-navigation-button>
          <app-navigation-button icon="fa-light fa-folder-open" title="Chat" path="/chat"></app-navigation-button>
          <app-navigation-button icon="fa-light fa-folder-open" title="Form" path="/form"></app-navigation-button>
          <app-navigation-button icon="fa-light fa-folder-open" title="Vue-Flow" path="/flow"></app-navigation-button>
          <app-navigation-button icon="fa-light fa-folder-open" title="AGGrid" path="/ag-grid"></app-navigation-button>
      </ul>
    </div>
    <div class="absolute bottom-0 left-0 justify-center p-4 w-full bg-white dark:bg-gray-800 z-20">
        <p class="text-sm text-gray-500 dark:text-gray-400">Space left</p>
        <div class="font-medium text-gray-900 dark:text-white">70 of 150 GB</div>
        <div class="w-full bg-gray-200 rounded-full h-2.5 mt-2 mb-4 dark:bg-gray-700">
            <div class="bg-green-500 h-2.5 rounded-full" style="width: 50%"></div>
        </div>
        <a href="#" class="inline-flex items-center justify-center w-full py-2.5 px-5 text-sm font-medium text-gray-900 focus:outline-none bg-white rounded-lg border border-gray-200 hover:bg-gray-100 hover:text-blue-700 focus:z-10 focus:ring-4 focus:ring-gray-200 dark:focus:ring-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:border-gray-600 dark:hover:text-white dark:hover:bg-gray-700">
            <svg aria-hidden="true" class="mr-1 w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"></path></svg>
            Upgrade to Pro
        </a>
    </div>
  </aside>
  </template>

  <script setup lang="ts">
    import AppNavigationButton from "./AppNavigationButton.vue";
  </script>
