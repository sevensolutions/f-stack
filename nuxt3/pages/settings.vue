<template>
  <div class="mx-auto max-w-7xl lg:flex lg:gap-x-16 lg:px-8">
  <aside class="flex overflow-x-auto border-b border-gray-900/5 py-4 lg:block lg:w-64 lg:flex-none lg:border-0 lg:py-20">
    <nav class="flex-none px-4 sm:px-6 lg:px-0">
      <ul role="list" class="flex gap-x-3 gap-y-1 whitespace-nowrap lg:flex-col">
        <li v-for="item in secondaryNavigation" :key="item.name">
          <router-link :to="item.url" :class="[route.path === item.url ? 'bg-gray-50 text-primary-600' : 'text-gray-700 hover:text-primary-600 hover:bg-gray-50', 'group flex gap-x-3 rounded-md py-2 pl-2 pr-3 text-sm leading-6 font-semibold']">
            <component :is="item.icon" :class="[route.path === item.url ? 'text-primary-600' : 'text-gray-400 group-hover:text-primary-600', 'h-6 w-6 shrink-0']" aria-hidden="true" />
            {{ item.name }}
          </router-link>
        </li>
      </ul>
    </nav>
  </aside>

  <main class="px-4 py-16 sm:px-6 lg:flex-auto lg:px-0 lg:py-20">
    <NuxtPage></NuxtPage>
  </main>
</div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import {
BellIcon,
CreditCardIcon,
CubeIcon,
FingerPrintIcon,
UserCircleIcon,
UsersIcon,
XMarkIcon,
} from '@heroicons/vue/24/outline'

const route = useRoute();

const secondaryNavigation = [


{ name: 'Profile', url: '/settings', icon: UserCircleIcon },
{ name: 'Security', url: '/settings/security', icon: FingerPrintIcon },
{ name: 'Notifications', url: '/settings/notifications', icon: BellIcon },
{ name: 'Plan', url: '/settings/plan', icon: CubeIcon },
{ name: 'Billing', url: '/settings/billing', icon: CreditCardIcon },
{ name: 'Users', url: '/settings/users', icon: UsersIcon },
]

</script>
