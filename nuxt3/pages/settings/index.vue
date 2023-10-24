<template>
    <div class="mx-auto max-w-2xl space-y-16 sm:space-y-20 lg:mx-0 lg:max-w-none">
      <div>
        <h2 class="text-base font-semibold leading-7 text-gray-900">Profile</h2>
        <p class="mt-1 text-sm leading-6 text-gray-500">This information will be displayed publicly so be careful what you share.</p>

        <dl class="mt-6 space-y-6 divide-y divide-gray-100 border-t border-gray-200 text-sm leading-6">
          <div class="pt-6 sm:flex">
            <dt class="font-medium text-gray-900 sm:w-64 sm:flex-none sm:pr-6">Full Name</dt>
            <dd class="mt-1 flex justify-between gap-x-6 sm:mt-0 sm:flex-auto">
              <div class="text-gray-900">Tom Cook</div>
              <button type="button" class="font-semibold text-indigo-600 hover:text-indigo-500">Update</button>
            </dd>
          </div>
          <div class="pt-6 sm:flex">
            <dt class="font-medium text-gray-900 sm:w-64 sm:flex-none sm:pr-6">Email Address</dt>
            <dd class="mt-1 flex justify-between gap-x-6 sm:mt-0 sm:flex-auto">
              <div class="text-gray-900">tom.cook@example.com</div>
              <button type="button" class="font-semibold text-indigo-600 hover:text-indigo-500">Update</button>
            </dd>
          </div>
        </dl>
      </div>

      <div>
        <h2 class="text-base font-semibold leading-7 text-gray-900">Language and Dates</h2>
        <p class="mt-1 text-sm leading-6 text-gray-500">Choose what language and date format to use throughout your account.</p>

        <dl class="mt-6 space-y-6 divide-y divide-gray-100 border-t border-gray-200 text-sm leading-6">
          <div class="pt-6 sm:flex">
            <dt class="font-medium text-gray-900 sm:w-64 sm:flex-none sm:pr-6">Language</dt>
            <dd class="mt-1 flex justify-between gap-x-6 sm:mt-0 sm:flex-auto">
              <div class="text-gray-900">English</div>
              <button type="button" class="font-semibold text-indigo-600 hover:text-indigo-500">Update</button>
            </dd>
          </div>
          <div class="pt-6 sm:flex">
            <dt class="font-medium text-gray-900 sm:w-64 sm:flex-none sm:pr-6">Date Format</dt>
            <dd class="mt-1 flex justify-between gap-x-6 sm:mt-0 sm:flex-auto">
              <div class="text-gray-900">DD-MM-YYYY</div>
              <button type="button" class="font-semibold text-indigo-600 hover:text-indigo-500">Update</button>
            </dd>
          </div>
          <SwitchGroup as="div" class="flex pt-6">
            <SwitchLabel as="dt" class="flex-none pr-6 font-medium text-gray-900 sm:w-64" passive>Automatic Timezone</SwitchLabel>
            <dd class="flex flex-auto items-center justify-end">
              <Switch v-model="automaticTimezoneEnabled" :class="[automaticTimezoneEnabled ? 'bg-indigo-600' : 'bg-gray-200', 'flex w-8 cursor-pointer rounded-full p-px ring-1 ring-inset ring-gray-900/5 transition-colors duration-200 ease-in-out focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600']">
                <span aria-hidden="true" :class="[automaticTimezoneEnabled ? 'translate-x-3.5' : 'translate-x-0', 'h-4 w-4 transform rounded-full bg-white shadow-sm ring-1 ring-gray-900/5 transition duration-200 ease-in-out']" />
              </Switch>
            </dd>
          </SwitchGroup>
        </dl>
      </div>

      <div>
        <h2 class="text-base font-semibold leading-7 text-gray-900">Danger Zone</h2>
        <p class="mt-1 text-sm leading-6 text-gray-500">No longer want to use our service? You can delete your account here. This action is not reversible. All information related to this account will be deleted permanently.</p>

        <dl class="mt-6 space-y-6 text-sm leading-6">
          <button type="submit" class="rounded-md bg-red-500 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-400">Yes, delete my account</button>
        </dl>
      </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { Dialog, DialogPanel, Switch, SwitchGroup, SwitchLabel } from '@headlessui/vue'
import { Bars3Icon } from '@heroicons/vue/20/solid'
import {
BellIcon,
CreditCardIcon,
CubeIcon,
FingerPrintIcon,
UserCircleIcon,
UsersIcon,
XMarkIcon,
} from '@heroicons/vue/24/outline'

const navigation = [


{ name: 'Home', href: '#' },
{ name: 'Invoices', href: '#' },
{ name: 'Clients', href: '#' },
{ name: 'Expenses', href: '#' },
]
const secondaryNavigation = [


{ name: 'General', href: '#', icon: UserCircleIcon, current: true },
{ name: 'Security', href: '#', icon: FingerPrintIcon, current: false },
{ name: 'Notifications', href: '#', icon: BellIcon, current: false },
{ name: 'Plan', href: '#', icon: CubeIcon, current: false },
{ name: 'Billing', href: '#', icon: CreditCardIcon, current: false },
{ name: 'Team members', href: '#', icon: UsersIcon, current: false },
]

const mobileMenuOpen = ref(false)
const automaticTimezoneEnabled = ref(true)
</script>
