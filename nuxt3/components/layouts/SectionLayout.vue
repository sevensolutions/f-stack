<template>
  <div :style="`flex-grow: ${props.width}`">
    <slot></slot>
  </div>
</template>

<script setup lang="ts">
  const props = withDefaults(defineProps<{
    width: number;
  }>(), {
    width: 1
  });
</script>
