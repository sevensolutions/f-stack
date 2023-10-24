<template>
  <div class="p-8 flex flex-col items-center">
    <div class="w-6/12">

        <ul role="list" class="space-y-6">
          <li v-for="(activityItem, activityItemIdx) in activity" :key="activityItem.id" class="relative flex gap-x-4">
            <div :class="[activityItemIdx === activity.length - 1 ? 'h-6' : '-bottom-6', 'absolute left-0 top-0 flex w-6 justify-center']">
              <div class="w-px bg-gray-200" />
            </div>
            <template v-if="activityItem.type === 'commented'">
              <img :src="activityItem.person.imageUrl" alt="" class="relative mt-3 h-6 w-6 flex-none rounded-full bg-gray-50" />
              <div class="flex-auto rounded-md p-3 ring-1 ring-inset ring-gray-200">
                <div class="flex justify-between gap-x-4">
                  <div class="py-0.5 text-xs leading-5 text-gray-500">
                    <span class="font-medium text-gray-900">{{ activityItem.person.name }}</span> commented
                  </div>
                  <time :datetime="activityItem.dateTime" class="flex-none py-0.5 text-xs leading-5 text-gray-500">{{ activityItem.date }}</time>
                </div>
                <p class="text-sm leading-6 text-gray-500">{{ activityItem.comment }}</p>
              </div>
            </template>
            <template v-else>
              <div class="relative flex h-6 w-6 flex-none items-center justify-center bg-white">
                <font-awesome-icon v-if="activityItem.type === 'paid'" icon="fa-solid fa-circle-check" class="h-6 w-6 text-indigo-600" aria-hidden="true" />
                <div v-else class="h-1.5 w-1.5 rounded-full bg-gray-100 ring-1 ring-gray-300" />
              </div>
              <p class="flex-auto py-0.5 text-xs leading-5 text-gray-500">
                <span class="font-medium text-gray-900">{{ activityItem.person.name }}</span> {{ activityItem.type }} the invoice.
              </p>
              <time :datetime="activityItem.dateTime" class="flex-none py-0.5 text-xs leading-5 text-gray-500">{{ activityItem.date }}</time>
            </template>
          </li>
        </ul>



      <form action="#" class="relative mt-5">
        <div class="overflow-hidden rounded-lg border border-gray-300 shadow-sm focus-within:border-indigo-500 focus-within:ring-1 focus-within:ring-indigo-500">
          <!--<textarea rows="2" name="description" id="description" class="block w-full resize-none border-0 py-0 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6" placeholder="Write a description..." />-->

          <QuillTextBox placeholder="Write a comment..."></QuillTextBox>

          <!-- Spacer element to match the height of the toolbar -->
          <div aria-hidden="true">
            <div class="py-2">
              <div class="h-9" />
            </div>
            <div class="h-px" />
            <div class="py-2">
              <div class="py-px">
                <div class="h-9" />
              </div>
            </div>
          </div>
        </div>

        <div class="absolute inset-x-px bottom-0">
          <!-- Actions: These are just examples to demonstrate the concept, replace/wire these up however makes sense for your project. -->
          <div class="flex flex-nowrap justify-end space-x-2 px-2 py-2 sm:px-3">
            <Listbox as="div" v-model="assigned" class="flex-shrink-0">
              <ListboxLabel class="sr-only">Assign</ListboxLabel>
              <div class="relative">
                <ListboxButton class="relative inline-flex items-center whitespace-nowrap rounded-full bg-gray-50 px-2 py-2 text-sm font-medium text-gray-500 hover:bg-gray-100 sm:px-3">
                  <font-awesome-icon v-if="assigned.value === null" icon="fa-solid fa-circle-user" class="h-5 w-5 flex-shrink-0 text-gray-300 sm:-ml-1" aria-hidden="true" />

                  <img v-else :src="assigned.avatar" alt="" class="h-5 w-5 flex-shrink-0 rounded-full" />

                  <span :class="[assigned.value === null ? '' : 'text-gray-900', 'hidden truncate sm:ml-2 sm:block']">{{ assigned.value === null ? 'Assign' : assigned.name }}</span>
                </ListboxButton>

                <transition leave-active-class="transition ease-in duration-100" leave-from-class="opacity-100" leave-to-class="opacity-0">
                  <ListboxOptions class="absolute right-0 z-10 mt-1 max-h-56 w-52 overflow-auto rounded-lg bg-white py-3 text-base shadow ring-1 ring-black ring-opacity-5 focus:outline-none sm:text-sm">
                    <ListboxOption as="template" v-for="assignee in assignees" :key="assignee.value" :value="assignee" v-slot="{ active }">
                      <li :class="[active ? 'bg-gray-100' : 'bg-white', 'relative cursor-default select-none px-3 py-2']">
                        <div class="flex items-center">
                          <img v-if="assignee.avatar" :src="assignee.avatar" alt="" class="h-5 w-5 flex-shrink-0 rounded-full" />
                          <font-awesome-icon v-else icon="fa-solid fa-circle-user" class="h-5 w-5 flex-shrink-0 text-gray-400" aria-hidden="true" />
                          <span class="ml-3 block truncate font-medium">{{ assignee.name }}</span>
                        </div>
                      </li>
                    </ListboxOption>
                  </ListboxOptions>
                </transition>
              </div>
            </Listbox>

            <Listbox as="div" v-model="labelled" class="flex-shrink-0">
              <ListboxLabel class="sr-only">Add a label</ListboxLabel>
              <div class="relative">
                <ListboxButton class="relative inline-flex items-center whitespace-nowrap rounded-full bg-gray-50 px-2 py-2 text-sm font-medium text-gray-500 hover:bg-gray-100 sm:px-3">
                  <font-awesome-icon icon="fa-solid fa-tag" :class="[labelled.value === null ? 'text-gray-300' : 'text-gray-500', 'h-5 w-5 flex-shrink-0 sm:-ml-1']" aria-hidden="true" />
                  <span :class="[labelled.value === null ? '' : 'text-gray-900', 'hidden truncate sm:ml-2 sm:block']">{{ labelled.value === null ? 'Label' : labelled.name }}</span>
                </ListboxButton>

                <transition leave-active-class="transition ease-in duration-100" leave-from-class="opacity-100" leave-to-class="opacity-0">
                  <ListboxOptions class="absolute right-0 z-10 mt-1 max-h-56 w-52 overflow-auto rounded-lg bg-white py-3 text-base shadow ring-1 ring-black ring-opacity-5 focus:outline-none sm:text-sm">
                    <ListboxOption as="template" v-for="label in labels" :key="label.value" :value="label" v-slot="{ active }">
                      <li :class="[active ? 'bg-gray-100' : 'bg-white', 'relative cursor-default select-none px-3 py-2']">
                        <div class="flex items-center">
                          <span class="block truncate font-medium">{{ label.name }}</span>
                        </div>
                      </li>
                    </ListboxOption>
                  </ListboxOptions>
                </transition>
              </div>
            </Listbox>

            <Listbox as="div" v-model="dated" class="flex-shrink-0">
              <ListboxLabel class="sr-only">Add a due date</ListboxLabel>
              <div class="relative">
                <ListboxButton class="relative inline-flex items-center whitespace-nowrap rounded-full bg-gray-50 px-2 py-2 text-sm font-medium text-gray-500 hover:bg-gray-100 sm:px-3">
                  <font-awesome-icon icon="fa-solid fa-calendar" :class="[dated.value === null ? 'text-gray-300' : 'text-gray-500', 'h-5 w-5 flex-shrink-0 sm:-ml-1']" aria-hidden="true" />
                  <span :class="[dated.value === null ? '' : 'text-gray-900', 'hidden truncate sm:ml-2 sm:block']">{{ dated.value === null ? 'Due date' : dated.name }}</span>
                </ListboxButton>

                <transition leave-active-class="transition ease-in duration-100" leave-from-class="opacity-100" leave-to-class="opacity-0">
                  <ListboxOptions class="absolute right-0 z-10 mt-1 max-h-56 w-52 overflow-auto rounded-lg bg-white py-3 text-base shadow ring-1 ring-black ring-opacity-5 focus:outline-none sm:text-sm">
                    <ListboxOption as="template" v-for="dueDate in dueDates" :key="dueDate.value" :value="dueDate" v-slot="{ active }">
                      <li :class="[active ? 'bg-gray-100' : 'bg-white', 'relative cursor-default select-none px-3 py-2']">
                        <div class="flex items-center">
                          <span class="block truncate font-medium">{{ dueDate.name }}</span>
                        </div>
                      </li>
                    </ListboxOption>
                  </ListboxOptions>
                </transition>
              </div>
            </Listbox>
          </div>

          <div class="flex items-center justify-between space-x-3 border-t border-gray-200 px-2 py-2 sm:px-3">
            <div class="flex">
              <button type="button" class="group -my-2 -ml-2 inline-flex items-center rounded-full px-3 py-2 text-left text-gray-400">
                <font-awesome-icon icon="fa-solid fa-paperclip" class="-ml-1 mr-2 h-5 w-5 group-hover:text-gray-500" aria-hidden="true" />
                <span class="text-sm italic text-gray-500 group-hover:text-gray-600">Attach a file</span>
              </button>
            </div>
            <div class="flex-shrink-0">
              <button type="submit" class="inline-flex items-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Send</button>
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { Listbox, ListboxButton, ListboxLabel, ListboxOption, ListboxOptions } from '@headlessui/vue'
import QuillTextBox from '~/components/quill/QuillTextBox.vue';

const assignees = [
  { name: 'Unassigned', value: null },
  {
    name: 'Wade Cooper',
    value: 'wade-cooper',
    avatar:
      'https://images.unsplash.com/photo-1491528323818-fdd1faba62cc?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
  },
  // More items...
]
const labels = [
  { name: 'Unlabelled', value: null },
  { name: 'Engineering', value: 'engineering' },
  // More items...
]
const dueDates = [
  { name: 'No due date', value: null },
  { name: 'Today', value: 'today' },
  // More items...
]

const assigned = ref(assignees[0])
const labelled = ref(labels[0])
const dated = ref(dueDates[0])

const activity = [
  { id: 1, type: 'created', person: { name: 'Chelsea Hagon' }, date: '7d ago', dateTime: '2023-01-23T10:32' },
  { id: 2, type: 'edited', person: { name: 'Chelsea Hagon' }, date: '6d ago', dateTime: '2023-01-23T11:03' },
  { id: 3, type: 'sent', person: { name: 'Chelsea Hagon' }, date: '6d ago', dateTime: '2023-01-23T11:24' },
  {
    id: 4,
    type: 'commented',
    person: {
      name: 'Chelsea Hagon',
      imageUrl:
        'https://images.unsplash.com/photo-1550525811-e5869dd03032?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    },
    comment: 'Called client, they reassured me the invoice would be paid by the 25th.',
    date: '3d ago',
    dateTime: '2023-01-23T15:56',
  },
  { id: 5, type: 'viewed', person: { name: 'Alex Curren' }, date: '2d ago', dateTime: '2023-01-24T09:12' },
  { id: 6, type: 'paid', person: { name: 'Alex Curren' }, date: '1d ago', dateTime: '2023-01-24T09:20' },
]

</script>

<style>
  .ql-toolbar.ql-snow {
    border: none;
    border-bottom: 1px solid #d1d5db;
  }
  .ql-container.ql-snow {
    border: none;
  }
</style>
