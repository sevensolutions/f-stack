<template>
    <li>
      <router-link :to="props.path" class="flex items-center p-2 text-base font-normal text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700 group">
  
        <font-awesome-icon :icon="props.icon" class="w-6 h-6 text-gray-400 transition duration-75 dark:text-gray-400 group-hover:text-gray-900 dark:group-hover:text-white"></font-awesome-icon>
  
        <span class="ml-3">{{ props.title }}</span>
      </router-link>
    </li>
  </template>
  
  <script setup lang="ts">
    import { RouterLink } from 'vue-router';
  
    const props = defineProps<{
      icon: string;
      title?: string;
      path: string;
    }>();
  </script>
  