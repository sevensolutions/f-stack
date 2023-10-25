<template>
  <FormLayout>
    <TileLayout>
      <SectionLayout :width="2">XX</SectionLayout>
      <SectionLayout>
        XX
      </SectionLayout>
    </TileLayout>
    <TileLayout>
      <SectionLayout>XX</SectionLayout>
      <SectionLayout>
        <FSSpinner></FSSpinner>
      </SectionLayout>
    </TileLayout>
    <SectionLayout>
      <FSButton>Primary Button</FSButton>
      <FSButton variant="secondary">Secondary Button</FSButton>
      <FSButton disabled>Disabled Button</FSButton>
      <FSButton icon="fa-calendar">Button with icon</FSButton>
      <FSButton :loading="isLoading" @click="isLoading = !isLoading">Loading Button</FSButton>
    </SectionLayout>
  </FormLayout>
</template>

<script setup lang="ts">
  import FormLayout from '~/components/layouts/FormLayout.vue';
  import TileLayout from '~/components/layouts/TileLayout.vue';
  import SectionLayout from '~/components/layouts/SectionLayout.vue';
  import FSButton from '~/components/ui/FSButton.vue';
  import FSSpinner from '~/components/ui/FSSpinner.vue';

  const isLoading = ref(false);


</script>
