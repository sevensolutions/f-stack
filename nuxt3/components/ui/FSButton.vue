<template>
  <component
    is="button"
    :disabled="disabled"
    class="inline-flex items-center gap-x-1.5 relative font-semibold shadow-sm focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-600"
    :class="[{
      'cursor-not-allowed opacity-50': props.disabled
    }, variantClasses, sizeClasses, hoverClasses]"
    @click="ev => emit('click', ev)"
  >
    <font-awesome-icon v-if="props.icon"
      class="h-4 w-4" :class="{ 'opacity-0': props.loading }"
      aria-hidden="true"
      :icon="`fa-light ${props.icon}`" />

    <div :class="{ 'opacity-0': props.loading }">
      <slot></slot>
    </div>

    <div v-if="props.loading" class="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2">
      <FSSpinner color="white"></FSSpinner>
    </div>
  </component>
</template>

<script setup lang="ts">
  import type { PropType } from 'vue';
  import type { FSButtonVariant, FSButtonSize } from '~/types/ui';
  import FSSpinner from './FSSpinner.vue';

  interface Props {
    variant?: FSButtonVariant;
    size?: FSButtonSize;
    disabled?: boolean;
    icon?: string;
    loading?: boolean;
  }

  const props = withDefaults(defineProps<Props>(), {
    variant: 'primary',
    size: 'md',
    disabled: false,
    loading: false
  });

  const emit = defineEmits(["click"]);

  const sizeClasses = computed(() => {
    switch (props.size) {
      case 'xs': return "rounded px-2 py-1 text-xs";
      case 'sm': return "rounded px-2 py-1 text-sm";
      case 'md': return "rounded-md px-3 py-2 text-sm";
      case 'lg': return "rounded-md px-3 py-2 text-sm";
      case 'xl': return "rounded-md px-3.5 py-2.5 text-sm";
      default: return "";
    }
  });

  const variantClasses = computed(() => {
    switch(props.variant) {
      case 'primary': return "bg-primary-600 text-white";
      case 'secondary': return "bg-white text-gray-900 ring-1 ring-inset ring-gray-300";
      default: return "";
    }
  });

  const hoverClasses = computed(() => {
    if (props.disabled)
      return "";

    switch(props.variant) {
      case 'primary': return "hover:bg-primary-500";
      case 'secondary': return "hover:bg-gray-50";
      default: return "";
    }
  });
</script>
