<template>
    <nav class="bg-white border-b border-gray-200 px-4 py-2.5 dark:bg-gray-800 dark:border-gray-700 fixed left-0 right-0 top-0 h-16 z-50 flex items-center">
      <div class="flex-auto flex flex-wrap justify-between items-center">
        <div class="flex justify-start items-center">
          <!-- Sidebar Button on Mobile -->
          <button data-drawer-target="drawer-navigation" data-drawer-toggle="drawer-navigation" aria-controls="drawer-navigation" class="p-2 mr-2 text-gray-600 rounded-lg cursor-pointer md:hidden hover:text-gray-900 hover:bg-gray-100 focus:bg-gray-100 dark:focus:bg-gray-700 focus:ring-2 focus:ring-gray-100 dark:focus:ring-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">
            <svg aria-hidden="true" class="w-6 h-6" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
              <path fill-rule="evenodd" d="M3 5a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 10a1 1 0 011-1h6a1 1 0 110 2H4a1 1 0 01-1-1zM3 15a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1z" clip-rule="evenodd"></path>
            </svg>
            <svg aria-hidden="true" class="hidden w-6 h-6" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
              <path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path>
            </svg>
            <span class="sr-only">Toggle sidebar</span>
          </button>

          <!-- Icon/Logo-->
          <a href="/" class="flex items-center justify-between mr-4 dark:text-white">
            <svg xmlns="http://www.w3.org/2000/svg" class="w-8 h-8" fill="currentColor" viewBox="0 0 512 512">
              <path d="M188.9 372l-50.4-50.4c18.6-42.6 61.7-137.7 95.1-187C304.6 30.1 409 24.6 475.7 36.3c11.7 66.7 6.2 171.1-98.4 242c-49.4 33.5-145.5 75.6-188.4 93.7zm-79.9-62.8c-5.2 11.9-2.5 25.7 6.7 34.9l50.7 50.7c9.1 9.1 22.7 11.9 34.5 6.9c6.5-2.7 14.3-6 23-9.8L224 496c0 5.5 2.9 10.7 7.6 13.6s10.6 3.2 15.6 .7l101.5-50.7c21.7-10.8 35.4-33 35.4-57.2V312.1c4-2.5 7.7-4.9 11.3-7.3C516.1 222.9 520.1 100.9 506.7 28.1c-2.1-11.6-11.2-20.6-22.8-22.8C411.1-8.1 289.1-4.1 207.2 116.7c-2.4 3.6-4.9 7.3-7.3 11.3l-90.2 0c-24.2 0-46.4 13.7-57.2 35.4L1.7 264.8c-2.5 5-2.2 10.8 .7 15.6s8.1 7.6 13.6 7.6H118.5c-3.6 8-6.8 15.2-9.4 21.2zM256 470.1l0-92.5c30.3-13.7 65.4-30.3 96-47v71.7c0 12.1-6.8 23.2-17.7 28.6L256 470.1zM109.7 160h71.5c-16.9 30.7-34 65.8-48.1 96H41.9L81 177.7c5.4-10.8 16.5-17.7 28.6-17.7zM392 144a24 24 0 1 1 -48 0 24 24 0 1 1 48 0zM368 88a56 56 0 1 0 0 112 56 56 0 1 0 0-112z"/>
            </svg>
            <span class="ml-2 self-center text-2xl whitespace-nowrap dark:text-white">FStack</span>
          </a>

          <!-- Search Box -->
          <div v-if="systemStore.clientConfig?.typesense?.isEnabled" class="hidden md:block md:pl-2 cursor-pointer" @click="openSearch">
            <label for="topbar-search" class="sr-only">Search</label>
            <div class="relative md:w-64 md:w-96">
              <div class="flex absolute inset-y-0 left-0 items-center pl-3 pointer-events-none">
                <svg class="w-5 h-5 text-gray-500 dark:text-gray-400" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                  <path fill-rule="evenodd" clip-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z"></path>
                </svg>
              </div>
              <span class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500">Search</span>
            </div>
          </div>
        </div>

        <!-- Right Button -->
        <div class="flex items-center">
          <notifications-button></notifications-button>
          <apps-menu-button></apps-menu-button>
          <profile-menu-button></profile-menu-button>
        </div>
      </div>
    </nav>

    <search-dialog v-if="systemStore.clientConfig?.typesense?.isEnabled" v-model="isSearchOpen" @selected="onSearchSelected"></search-dialog>
  </template>

  <script setup lang="ts">
  import SearchDialog from "~/components/search/SearchDialog.vue";
  import NotificationsButton from "~/components/shell/NotificationsButton.vue";
  import AppsMenuButton from "./AppsMenuButton.vue";
  import ProfileMenuButton from "./ProfileMenuButton.vue";
  import { useSystemStore } from "~/stores/system";

  const router = useRouter();
  const systemStore = useSystemStore();

  const isSearchOpen = ref(false);

  function openSearch() {
    isSearchOpen.value = true;
  }
  function onSearchSelected(item: any) {
    router.push({ path: `/resources/${item.objectID}` });
  }
  </script>
