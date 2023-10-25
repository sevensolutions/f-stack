<template>
  <!-- Bell Button -->
  <button type="button" data-dropdown-toggle="notification-dropdown"
    class="p-2 mr-1 text-gray-500 rounded-lg hover:text-gray-900 hover:bg-gray-100 dark:text-white dark:hover:text-white dark:hover:bg-gray-700 focus:ring-4 focus:ring-gray-300 dark:focus:ring-gray-600">
    <span class="sr-only">View Notifications</span>
    <span class="relative inline-block">
      <font-awesome-icon icon="fa-solid fa-bell" class="w-6 h-6"></font-awesome-icon>
      <span v-if="newNotifications" class="absolute right-0 top-0 block h-2 w-2 rounded-full bg-red-400 ring-2 ring-white" />
    </span>

  </button>

  <!-- Dropdown menu -->
  <div id="notification-dropdown" class="hidden overflow-hidden z-50 my-4 max-w-sm text-base list-none bg-white rounded divide-y divide-gray-100 shadow-lg dark:divide-gray-600 dark:bg-gray-700 rounded-xl">
    <div class="block py-2 px-4 text-base font-medium text-center text-gray-700 bg-gray-50 dark:bg-gray-600 dark:text-gray-300">
      Notifications
    </div>
    <div v-if="notifications.length > 0">
      <NotificationPreview v-for="notification in notifications" :key="notification.id" :notification="notification" />
    </div>
    <div v-else class="px-32 py-6">
      <span>No Notifications</span>
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
  import NotificationPreview from "./NotificationPreview.vue";

  const apiClient = useApiClient();
  const signalR = useSignalR("notifications");

  const notifications = ref<IUserNotificationPreview[]>([]);
  const newNotifications = ref(false);

  onMounted(async () => {
    try {
      const n = await apiClient.get("account/notifications");
      notifications.value = n;
    }
    catch(ex: any) {
      console.log("Error:", ex);
    }
  });

  signalR.onMessage("NewNotification", (notification: IUserNotificationPreview) => {
    notifications.value
      .splice(0, 0, notification);

    // Limit to 4 items
    if (notifications.value.length > 4)
      notifications.value.splice(notifications.value.length - 1, 1);

    newNotifications.value = true;
  });
</script>
