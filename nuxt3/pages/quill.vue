<template>
  <div class="px-8 py-4 flex flex-col">
    <div class="flex items-center justify-between mb-4">
      <span class="text-xl">Document Title</span>
      <button type="button" @click="saveDocument" class="rounded-md bg-primary-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-primary-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary-600">Save</button>
    </div>

    <QuillEditor class="flex-1" v-model:content="textContent" theme="snow" toolbar="full" :modules="modules" placeholder="Compose some text..." />
  </div>
</template>

<script setup lang="ts">
  import hljs from 'highlight.js/lib/core';
  import javascript from 'highlight.js/lib/languages/javascript';
  import { QuillEditor } from '@vueup/vue-quill'
  import '@vueup/vue-quill/dist/vue-quill.snow.css';
  import Delta from 'quill-delta';
  import QuillMention from "quill-mention";
  import ImageUploader from "quill-image-uploader";
  import 'quill-image-uploader/dist/quill.imageUploader.min.css';
  import { ImageDrop } from 'quill-image-drop-module';
  import SyntaxModule from 'quill/modules/syntax';

  // Then register the languages you need
  hljs.registerLanguage('javascript', javascript);

  import { useApiClient } from '~/composables/useApiClient';
  import { useNotifications } from '~/composables/useNotifications';

  const apiClient = useApiClient();
  const notifications = useNotifications();

  const textContent = ref<Delta>();

  onMounted(async () => {
    try {
      const content = await apiClient.get("quill");
      if (content) {
        textContent.value = new Delta(content);
      }
    }
    catch(ex: any) {
      notifications.showError(ex);
    }
  });

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
    // Doesn't work yet
    // {
    //   name: 'syntax',
    //   module: SyntaxModule,
    //   options: {
    //     //hljs: hljs,
    //     highlight: (text: string) => hljs.highlightAuto(text).value
    //   }
    // },
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

  async function saveDocument() {
    try {
      var json = JSON.stringify(textContent.value);
      console.log(json);

      await apiClient.post("quill", textContent.value);

      notifications.showInfo("Saved", "The document has been saved successfully.", 2000);
    }
    catch(ex: any) {
      notifications.showError(ex);
    }
  }
</script>

<style>
/* .mention {
  background-color: aqua;
} */

.ql-editor{
  min-height:500px;
}

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
