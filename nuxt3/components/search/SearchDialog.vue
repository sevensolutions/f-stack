<template>
    <TransitionRoot :show="props.modelValue" as="template" @after-leave="query = ''" appear>
      <Dialog as="div" class="relative z-10" @close="props.modelValue = false">
        <TransitionChild as="template" enter="ease-out duration-300" enter-from="opacity-0" enter-to="opacity-100" leave="ease-in duration-200" leave-from="opacity-100" leave-to="opacity-0">
          <div class="fixed inset-0 bg-gray-500 bg-opacity-25 transition-opacity" />
        </TransitionChild>
  
        <div class="fixed inset-0 z-10 overflow-y-auto p-4 sm:p-6 md:p-20">
          <TransitionChild as="template" enter="ease-out duration-300" enter-from="opacity-0 scale-95" enter-to="opacity-100 scale-100" leave="ease-in duration-200" leave-from="opacity-100 scale-100" leave-to="opacity-0 scale-95">
            <DialogPanel class="mx-auto max-w-2xl transform divide-y divide-gray-100 overflow-hidden rounded-xl bg-white shadow-2xl ring-1 ring-black ring-opacity-5 transition-all">
              <search-control @selected="onItemSelected"></search-control>
            </DialogPanel>
          </TransitionChild>
        </div>
      </Dialog>
    </TransitionRoot>
  </template>
  
  <script setup lang="ts">
    import {
      Dialog,
      DialogPanel,
      TransitionChild,
      TransitionRoot,
    } from '@headlessui/vue'
    import SearchControl from "./SearchControl.vue"
  
    const props = defineProps<{
      modelValue: boolean
    }>();
  
    const emit = defineEmits(['selected', 'update:modelValue']);
  
    function onItemSelected(item: any) {
      emit("update:modelValue", false);
      emit("selected", item);
    }
  </script>
  