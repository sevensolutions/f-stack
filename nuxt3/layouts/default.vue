<template>
    <app-shell>
      <slot></slot>
    </app-shell>
  </template>

  <script setup lang="ts">
    import { onMounted } from 'vue'
    import { initFlowbite } from 'flowbite'
    import AppShell from '~/components/shell/AppShell.vue'

    // Initialize components based on data attribute selectors
    onMounted(() => {
      initFlowbite();
    });
  </script>
