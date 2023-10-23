<template>
  <!-- Bell Button -->
  <button type="button" data-dropdown-toggle="notification-dropdown"
    class="p-2 mr-1 text-gray-500 rounded-lg hover:text-gray-900 hover:bg-gray-100 dark:text-gray-400 dark:hover:text-white dark:hover:bg-gray-700 focus:ring-4 focus:ring-gray-300 dark:focus:ring-gray-600">
    <span class="sr-only">View notifications</span>
    <font-awesome-icon icon="fa-solid fa-bell" class="w-6 h-6"></font-awesome-icon>
  </button>

  <!-- Dropdown menu -->
  <div id="notification-dropdown" class="hidden overflow-hidden z-50 my-4 max-w-sm text-base list-none bg-white rounded divide-y divide-gray-100 shadow-lg dark:divide-gray-600 dark:bg-gray-700 rounded-xl">
    <div class="block py-2 px-4 text-base font-medium text-center text-gray-700 bg-gray-50 dark:bg-gray-600 dark:text-gray-300">
      Notifications
    </div>
    <div>
      <a href="#" v-for="notification in notifications" :key="notification.id" class="flex py-3 px-4 border-b hover:bg-gray-100 dark:hover:bg-gray-600 dark:border-gray-600">
        <div class="flex-shrink-0">
          <img class="w-11 h-11 rounded-full" src="https://flowbite.s3.amazonaws.com/blocks/marketing-ui/avatars/bonnie-green.png" alt="Bonnie Green avatar" />
        </div>
        <div class="pl-3 w-full">
          <div class="text-gray-500 font-normal text-sm mb-1.5 dark:text-gray-400">
            <span class="font-semibold text-gray-900 dark:text-white">{{ notification.title }}</span>
            <p>{{ notification.subject }}</p>
          </div>
          <div class="text-xs font-medium text-primary-600 dark:text-primary-500">
            {{ getRelativeTime(notification) }}
          </div>
        </div>
      </a>
    </div>

    <router-link to="/notifications" class="block py-2 text-md font-medium text-center text-gray-900 bg-gray-50 hover:bg-gray-100 dark:bg-gray-600 dark:text-white dark:hover:underline">
      <div class="inline-flex items-center">
        <font-awesome-icon icon="fa-solid fa-eye" class="mr-2 w-4 h-4 text-gray-500 dark:text-gray-400"></font-awesome-icon>
        View all
      </div>
    </router-link>
  </div>
</template>

<script setup lang="ts">
  import { RouterLink } from "vue-router";
  import type { IUserNotificationPreview } from "~/types/api";
  import { useApiClient } from "~/composables/useApiClient";
  import { DateTime } from "luxon";

  const apiClient = useApiClient();

  const notifications = ref<IUserNotificationPreview[]>([]);

  onMounted(async () => {
    try {
      const n = await apiClient.get("account/notifications");
      notifications.value = n;
    }
    catch(ex: any) {
      console.log("Error:", ex);
    }
  });

  function getRelativeTime(notification: IUserNotificationPreview): string {
    const lxDate = DateTime.fromISO(notification.createDate);
    return lxDate.toRelative();
  }
</script>
