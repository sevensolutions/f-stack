<template>
    <!-- https://www.algolia.com/doc/api-reference/widgets/search-box/vue/ -->

      <ais-instant-search index-name="books" v-bind:search-client="searchClient">
        <Combobox @update:modelValue="onSelect">
          <div class="relative">
            <MagnifyingGlassIcon class="pointer-events-none absolute left-4 top-3.5 h-5 w-5 text-gray-400" aria-hidden="true" />

            <ais-search-box>
              <template v-slot="{ currentRefinement, isSearchStalled, refine }">
                <ComboboxInput class="h-12 w-full border-0 bg-transparent pl-11 pr-4 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm"
                  placeholder="Search..." @change="refine($event.currentTarget.value)">{{ currentRefinement }}</ComboboxInput>
              </template>
            </ais-search-box>
          </div>

          <ComboboxOptions static class="max-h-80 scroll-py-2 divide-y divide-gray-100 overflow-y-auto">
            <li class="p-2">
              <h2 class="mb-2 mt-4 px-3 text-xs font-semibold text-gray-500">Search Results</h2>
              <ul class="text-sm text-gray-700">
                <ais-hits>
                  <template v-slot="{ items, sendEvent }">
                    <ComboboxOption v-for="item in items" :key="item.objectID" :value="item" as="template" v-slot="{ active }">
                      <li :class="['flex cursor-default select-none items-center rounded-md px-3 py-2', active && 'bg-primary-600 text-white']" @click="sendEvent('click', item, 'Select')">
                        <FolderIcon :class="['h-6 w-6 flex-none', active ? 'text-white' : 'text-gray-400']" aria-hidden="true" />
                        <span class="ml-3 flex-auto truncate">{{ item.title }}</span>
                        <span v-if="active" class="ml-3 flex-none text-primary-100">Jump to...</span>
                      </li>
                    </ComboboxOption>
                  </template>
                </ais-hits>
              </ul>
            </li>
          </ComboboxOptions>
        </Combobox>
      </ais-instant-search>
    </template>

  <script setup lang="ts">
    import {
      Combobox,
      ComboboxInput,
      ComboboxOptions,
      ComboboxOption,
      Dialog,
      DialogPanel,
      TransitionChild,
      TransitionRoot,
    } from '@headlessui/vue'

    const emit = defineEmits(['selected']);

    const typesense = useTypesense();
    const searchClient = typesense?.searchClient;

    function onSelect(item: any) {
      emit("selected", item);
    }

  </script>
