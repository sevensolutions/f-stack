<template>
  <div :id="data.id" :gs-id="data.id" :gs-x="data.grid.x" :gs-y="data.grid.y" :gs-w="data.grid.w" :gs-h="data.grid.h">
    <div class="grid-stack-item-content group relative p-2 bg-white highlight-white/5 rounded-md shadow-md flex flex-col" :class="{ 'cursor-move': isEditing }">

      <div>
        <span class="text-gray-900">{{ data.title }}</span>
        <DeleteButton v-if="isEditing" class="hidden group-hover:block absolute top-2 right-2" @click="deleteWidget" />
      </div>

      <div class="flex-1 overflow-auto">
        <component :is="data.widget || DefaultWidget"></component>
      </div>
    </div>
  </div>
</template>

<script setup>
  import DeleteButton from "~/components/dashboard/DeleteButton.vue";
  import DefaultWidget from "~/components/dashboard/DefaultWidget.vue";

  const props = defineProps({
    data: {
      type: Object,
      default: () => ({}),
    },
    isEditing: Boolean,
  });
  
  const emit = defineEmits(["delete"]);
  
  function deleteWidget() {
    emit("delete", props.data);
  }
</script>
  