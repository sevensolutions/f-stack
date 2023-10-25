<template>
  <a href="#" class="flex py-3 px-4 border-b hover:bg-gray-100 dark:hover:bg-gray-600 dark:border-gray-600">
    <div class="flex-shrink-0">
      <img class="w-11 h-11 rounded-full" src="https://flowbite.s3.amazonaws.com/blocks/marketing-ui/avatars/bonnie-green.png" alt="Bonnie Green avatar" />
    </div>
    <div class="pl-3 w-full">
      <div class="text-gray-500 font-normal text-sm mb-1.5 dark:text-gray-400">
        <span class="font-semibold text-gray-900 dark:text-white">{{ props.notification.title }}</span>
        <p>{{ props.notification.subject }}</p>
      </div>
      <div class="text-xs font-medium text-primary-600 dark:text-primary-500">
        {{ relativeTime }}
      </div>
    </div>
  </a>
</template>

<script setup lang="ts">
  import type { IUserNotificationPreview } from "~/types/api";
  import { DateTime } from "luxon";
  import { useInterval } from '~/composables/useInterval';

  const now = ref<DateTime>(DateTime.utc());

  useInterval(() => {
    now.value = DateTime.utc();
  }, 10000);

  const props = defineProps<{
    notification: IUserNotificationPreview;
  }>();

  const relativeTime = computed(() => {
    const lxDate = DateTime.fromISO(props.notification.createDate);
    return lxDate.toRelative({ base: now.value });
  });
</script>
