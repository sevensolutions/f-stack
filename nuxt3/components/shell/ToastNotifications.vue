<template>
  <div aria-live="assertive" class="pointer-events-none fixed inset-0 top-16 flex items-end px-4 py-6 sm:items-start sm:p-6 z-50">
    <div class="flex w-full flex-col items-center space-y-4 sm:items-end">
      <!-- Notification panel, dynamically insert this into the live region when it needs to be displayed -->

      <transition-group enter-active-class="transform ease-out duration-300 transition" enter-from-class="translate-y-2 opacity-0 sm:translate-y-0 sm:translate-x-2" enter-to-class="translate-y-0 opacity-100 sm:translate-x-0" leave-active-class="transition ease-in duration-100" leave-from-class="opacity-100" leave-to-class="opacity-0">
        <div v-for="item in notifications.notifications" :key="item.id" class="pointer-events-auto w-full max-w-sm overflow-hidden rounded-lg bg-white shadow-lg ring-1 ring-black ring-opacity-5">
          <div class="p-4">
            <div class="flex items-start">
              <div class="flex-shrink-0">
                <font-awesome-icon :icon="`fa-solid ${item.icon}`" :class="`h-6 w-6 ${item.iconColor}`" aria-hidden="true"></font-awesome-icon>
              </div>
              <div class="ml-3 w-0 flex-1 pt-0.5">
                <p class="text-sm font-medium text-gray-900">{{ item.title }}</p>
                <p class="mt-1 text-sm text-gray-500">{{ item.message }}</p>
                <div v-if="item.buttons" class="mt-3 flex space-x-7">
                  <button v-for="(button, index) in item.buttons" :key="index" type="button" @click="button.action()"
                    class="rounded-md bg-white text-sm font-medium text-primary-600 hover:text-primary-500 focus:outline-none focus:ring-2 focus:ring-primary-500 focus:ring-offset-2">
                    {{ button.title }}
                  </button>
                </div>
              </div>
              <div class="ml-4 flex flex-shrink-0">
                <button type="button" @click="item.close()" class="inline-flex rounded-md bg-white text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-primary-500 focus:ring-offset-2">
                  <span class="sr-only">Close</span>
                  <font-awesome-icon icon="fa-solid fa-close" class="h-5 w-5" aria-hidden="true"></font-awesome-icon>
                </button>
              </div>
            </div>
          </div>
        </div>
      </transition-group>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { useNotifications } from "~/composables/useNotifications";

  const notifications = useNotifications();
</script>
