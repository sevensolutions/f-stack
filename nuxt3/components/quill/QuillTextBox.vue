<template>
  <QuillEditor class="flex-1"
    v-model:content="props.modelValue"
    theme="snow"
    :toolbar="props.toolbar"
    :modules="modules"
    :placeholder="props.placeholder"
    @textChange="onTextChanged"
  />
</template>

<script setup lang="ts">
  import { QuillEditor } from '@vueup/vue-quill'
  import '@vueup/vue-quill/dist/vue-quill.snow.css';
  import Delta from 'quill-delta';
  import QuillMention from "quill-mention";
  import ImageUploader from "quill-image-uploader";
  import 'quill-image-uploader/dist/quill.imageUploader.min.css';
  import { useApiClient } from '~/composables/useApiClient';

  const apiClient = useApiClient();

  const props = withDefaults(defineProps<{
    modelValue: Delta;
    placeholder?: string;
    toolbar: string;
  }>(), {
    toolbar: "slim"
  });

  const emit = defineEmits(["update:modelValue"]);

  function onTextChanged(ev: { delta: Delta, oldContents: Delta, source: Sources }) {
    emit("update:modelValue", ev.delta);
  }

  async function suggestPeople(searchTerm: string) {
    const allPeople = [
      {
        id: 1,
        value: "Fredrik Sundqvist"
      },
      {
        id: 2,
        value: "Patrik Sjölin"
      }
    ];

    return new Promise(resolve => {
      setTimeout(() => {
        const result = allPeople.filter(person => person.value.includes(searchTerm));
        resolve(result);
      }, 1000);
    });
  }

  async function suggestTickets(searchTerm: string) {
    const allTickets = [
      {
        id: 1,
        value: "Ticket 1"
      },
      {
        id: 2,
        value: "Ticket 2"
      }
    ];

    return allTickets.filter(ticket => ticket.value.includes(searchTerm));
  }

  const modules = [
    {
      name: 'mention',
      module: QuillMention,
      options: {
        allowedChars: /^[A-Za-z\sÅÄÖÜåäöü]*$/,
        mentionDenotationChars: ["@", "#"],
        source: async function(searchTerm: string, renderList: any, mentionChar: string) {
          if (mentionChar === "@") {
            const matchedPeople = await suggestPeople(searchTerm);
            renderList(matchedPeople);
          }
          else if (mentionChar === "#") {
            const matchedTickets = await suggestTickets(searchTerm);
            renderList(matchedTickets);
          }
        },
        renderItem: function(item: any, searchTerm: string) {
          const domRootNode = document.createElement("div");
          domRootNode.setAttribute("style", "display: flex; align-items: center;");

          const domImage = document.createElement("img");
          domImage.src = `https://randomuser.me/api/portraits/men/${item.id}.jpg`;
          domImage.setAttribute("style", "width: 2em; height: 2em; border-radius: 50%; margin-right: 0.5em;");
          domRootNode.appendChild(domImage);

          const domSpan = document.createElement("span");
          domSpan.innerText = item.value;
          domRootNode.appendChild(domSpan);
          return domRootNode;
        },
        renderLoading: function() {
          return "Loading...";
        }
      }
    },
    // Not needed, when using ImageUploader
    // {
    //   name: 'imageDrop',
    //   module: ImageDrop
    // },
    {
      name: 'imageUpload',
      module: ImageUploader,
      options: {
        upload: async (file: File) => {
          const data = new FormData();
          data.append('file', file);

          const response = await apiClient.postFormData("quill/upload-image", data);
          return response.url;
        }
      }
    }
  ];
</script>

<style>
/* .mention {
  background-color: aqua;
} */

.ql-mention-loading {
  @apply p-4 rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none;
}

.ql-mention-list-container {
  @apply divide-y divide-gray-100 rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none;
}

.ql-mention-list-item {
  @apply text-gray-700 flex items-center px-4 py-2 text-sm;

  &.selected {
    @apply bg-gray-100 text-gray-900;
  }
}

</style>
